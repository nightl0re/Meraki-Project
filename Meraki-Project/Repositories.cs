using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meraki_Project
{
    // =====================================================================
    //  All database access lives in this file, grouped per area.
    //  Every method opens a short-lived connection, runs its query with
    //  parameters (never string-concatenated SQL), and returns plain models.
    // =====================================================================

    // ----- Users: login, register, admin management, photo -----
    internal static class UserRepository
    {
        public enum LoginResult { Ok, NoSuchEmail, WrongPassword }

        public static LoginResult Authenticate(string email, string password, out User? user)
        {
            user = null;
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at, password
                  FROM users WHERE email = @e", conn);
            cmd.Parameters.AddWithValue("@e", email);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return LoginResult.NoSuchEmail;

            string stored = r.GetString("password");
            if (!string.Equals(stored, password, StringComparison.Ordinal))
                return LoginResult.WrongPassword;

            user = ReadUser(r);
            return LoginResult.Ok;
        }

        // Declined accounts don't block their email - the person is invited to
        // register again, which reuses (resets) the declined row.
        public static bool EmailExists(string email)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM users WHERE email = @e AND status <> 'declined'", conn);
            cmd.Parameters.AddWithValue("@e", email);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Inserts the new account with status 'pending' - an admin must approve
        // it before the person can sign in. If a previously DECLINED account
        // exists with this email, that row is reset and reused instead (the
        // email column is UNIQUE, and a declined person may try again).
        public static int Register(string firstName, string lastName, string email,
                                   string phone, string password, UserRole role)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlTransaction tx = conn.BeginTransaction();

            int userId;
            using (MySqlCommand find = new MySqlCommand(
                "SELECT user_id FROM users WHERE email = @e AND status = 'declined'", conn, tx))
            {
                find.Parameters.AddWithValue("@e", email);
                object? existing = find.ExecuteScalar();
                userId = existing == null || existing is DBNull ? 0 : Convert.ToInt32(existing);
            }

            using MySqlCommand cmd = userId > 0
                ? new MySqlCommand(
                    @"UPDATE users SET role = @role, first_name = @fn, last_name = @ln,
                             phone = @ph, password = @pw, status = 'pending',
                             created_at = CURRENT_TIMESTAMP
                      WHERE user_id = @id", conn, tx)
                : new MySqlCommand(
                    @"INSERT INTO users (role, first_name, last_name, email, phone, password, status)
                      VALUES (@role, @fn, @ln, @e, @ph, @pw, 'pending')", conn, tx);
            cmd.Parameters.AddWithValue("@role", role == UserRole.Babysitter ? "babysitter" : "parent");
            cmd.Parameters.AddWithValue("@fn", firstName);
            cmd.Parameters.AddWithValue("@ln", lastName);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.Parameters.AddWithValue("@pw", password);
            if (userId > 0) cmd.Parameters.AddWithValue("@id", userId);
            else cmd.Parameters.AddWithValue("@e", email);
            cmd.ExecuteNonQuery();
            if (userId == 0) userId = (int)cmd.LastInsertedId;

            if (role == UserRole.Babysitter)
            {
                using MySqlCommand profileCmd = new MySqlCommand(
                    @"INSERT IGNORE INTO babysitter_profiles (user_id, bio, location) VALUES (@id, '', '')", conn, tx);
                profileCmd.Parameters.AddWithValue("@id", userId);
                profileCmd.ExecuteNonQuery();
            }

            tx.Commit();
            return userId;
        }

        public static User? GetById(int userId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at, photo
                  FROM users WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            User u = ReadUser(r);
            u.Photo = r.IsDBNull(r.GetOrdinal("photo")) ? null : (byte[])r["photo"];
            return u;
        }

        // Admin grid. Search matches name or email.
        public static List<User> GetUsers(string search)
        {
            List<User> list = new List<User>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at
                  FROM users
                  WHERE (@s = '' OR CONCAT(first_name,' ',last_name) LIKE @like OR email LIKE @like)
                  ORDER BY (status = 'pending') DESC, created_at DESC", conn);
            cmd.Parameters.AddWithValue("@s", search);
            cmd.Parameters.AddWithValue("@like", "%" + search + "%");
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(ReadUser(r));
            return list;
        }

        public static void SetStatus(int userId, string status)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand("UPDATE users SET status = @s WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        // Admin permanently deletes an account and everything that references it.
        // Foreign keys force a strict delete order (children before parents), so the
        // whole thing runs in one transaction: it all succeeds or nothing changes.
        public static void Delete(int userId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlTransaction tx = conn.BeginTransaction();

            // 1) reviews that mention this user, or that hang off this user's bookings.
            Exec(conn, tx,
                @"DELETE FROM reviews
                  WHERE parent_id = @id OR babysitter_id = @id
                     OR booking_id IN (SELECT booking_id FROM bookings
                                       WHERE parent_id = @id OR babysitter_id = @id)", userId);
            // 2) payments for this user's bookings or made with this user's cards.
            Exec(conn, tx,
                @"DELETE FROM payments
                  WHERE booking_id IN (SELECT booking_id FROM bookings
                                       WHERE parent_id = @id OR babysitter_id = @id)
                     OR card_id IN (SELECT card_id FROM payment_cards WHERE user_id = @id)", userId);
            // 3) now the bookings themselves are free of children.
            Exec(conn, tx, "DELETE FROM bookings WHERE parent_id = @id OR babysitter_id = @id", userId);
            // 4) the remaining rows that point straight at the user.
            Exec(conn, tx, "DELETE FROM payment_cards WHERE user_id = @id", userId);
            Exec(conn, tx, "DELETE FROM favorites WHERE parent_id = @id OR babysitter_id = @id", userId);
            Exec(conn, tx, "DELETE FROM notifications WHERE user_id = @id", userId);
            Exec(conn, tx, "DELETE FROM babysitter_skills WHERE babysitter_id = @id", userId);
            Exec(conn, tx, "DELETE FROM babysitter_profiles WHERE user_id = @id", userId);
            // 5) finally the account row.
            Exec(conn, tx, "DELETE FROM users WHERE user_id = @id", userId);

            tx.Commit();
        }

        // Small helper so the delete cascade above stays readable.
        private static void Exec(MySqlConnection conn, MySqlTransaction tx, string sql, int id)
        {
            using MySqlCommand cmd = new MySqlCommand(sql, conn, tx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateContact(int userId, string firstName, string lastName, string phone)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "UPDATE users SET first_name = @fn, last_name = @ln, phone = @ph WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@fn", firstName);
            cmd.Parameters.AddWithValue("@ln", lastName);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void SetPhoto(int userId, byte[] imageBytes)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand("UPDATE users SET photo = @p WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@p", imageBytes);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        private static User ReadUser(MySqlDataReader r) => new()
        {
            UserId = r.GetInt32("user_id"),
            Role = r.GetString("role"),
            FirstName = r.GetString("first_name"),
            LastName = r.GetString("last_name"),
            Email = r.GetString("email"),
            Phone = r.GetString("phone"),
            Status = r.GetString("status"),
            CreatedAt = r.GetDateTime("created_at"),
        };
    }

    // ----- Babysitters: search page, profile page, dashboard stats -----
    internal static class BabysitterRepository
    {
        // Everything the Search page and Booking page need, one query.
        // Only 'active' (admin-approved) accounts are ever shown to parents.
        public static List<BabysitterInfo> GetActiveBabysitters()
        {
            List<BabysitterInfo> list = new List<BabysitterInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT u.user_id, CONCAT(u.first_name,' ',u.last_name) AS name,
                         COALESCE(p.bio,'') AS bio, p.hourly_rate, p.experience_years,
                         p.location, p.verified, p.available,
                         COALESCE((SELECT AVG(r.rating) FROM reviews r
                                   WHERE r.babysitter_id = u.user_id), 0) AS avg_rating,
                         (SELECT COUNT(*) FROM reviews r
                          WHERE r.babysitter_id = u.user_id) AS review_count,
                         COALESCE((SELECT GROUP_CONCAT(s.name ORDER BY s.skill_id SEPARATOR '|')
                                   FROM babysitter_skills bs
                                   JOIN skills s ON s.skill_id = bs.skill_id
                                   WHERE bs.babysitter_id = u.user_id), '') AS skills
                  FROM users u
                  JOIN babysitter_profiles p ON p.user_id = u.user_id
                  WHERE u.status = 'active'
                  ORDER BY avg_rating DESC, name", conn);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                string skills = r.GetString("skills");
                list.Add(new BabysitterInfo
                {
                    UserId = r.GetInt32("user_id"),
                    Name = r.GetString("name"),
                    Bio = r.GetString("bio"),
                    HourlyRate = r.GetDecimal("hourly_rate"),
                    ExperienceYears = r.GetInt32("experience_years"),
                    Location = r.GetString("location"),
                    Verified = r.GetBoolean("verified"),
                    Available = r.GetBoolean("available"),
                    AvgRating = r.GetDouble("avg_rating"),
                    ReviewCount = r.GetInt32("review_count"),
                    Skills = skills.Length == 0 ? new List<string>() : skills.Split('|').ToList(),
                });
            }
            return list;
        }

        // Full public card for ONE babysitter (for the "View Profile" popup).
        public static BabysitterInfo? GetBabysitterInfo(int userId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT u.user_id, CONCAT(u.first_name,' ',u.last_name) AS name,
                         COALESCE(p.bio,'') AS bio, p.hourly_rate, p.experience_years,
                         p.location, p.verified, p.available,
                         COALESCE((SELECT AVG(r.rating) FROM reviews r
                                   WHERE r.babysitter_id = u.user_id), 0) AS avg_rating,
                         (SELECT COUNT(*) FROM reviews r
                          WHERE r.babysitter_id = u.user_id) AS review_count,
                         COALESCE((SELECT GROUP_CONCAT(s.name ORDER BY s.skill_id SEPARATOR '|')
                                   FROM babysitter_skills bs
                                   JOIN skills s ON s.skill_id = bs.skill_id
                                   WHERE bs.babysitter_id = u.user_id), '') AS skills
                  FROM users u
                  JOIN babysitter_profiles p ON p.user_id = u.user_id
                  WHERE u.user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            string skills = r.GetString("skills");
            return new BabysitterInfo
            {
                UserId = r.GetInt32("user_id"),
                Name = r.GetString("name"),
                Bio = r.GetString("bio"),
                HourlyRate = r.GetDecimal("hourly_rate"),
                ExperienceYears = r.GetInt32("experience_years"),
                Location = r.GetString("location"),
                Verified = r.GetBoolean("verified"),
                Available = r.GetBoolean("available"),
                AvgRating = r.GetDouble("avg_rating"),
                ReviewCount = r.GetInt32("review_count"),
                Skills = skills.Length == 0 ? new List<string>() : skills.Split('|').ToList(),
            };
        }

        public static (string Bio, string Location, decimal HourlyRate, int ExperienceYears, bool Verified)
            GetProfile(int userId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT COALESCE(bio,'') bio, location, hourly_rate, experience_years, verified
                  FROM babysitter_profiles WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return ("", "", 15m, 0, false);
            return (r.GetString("bio"), r.GetString("location"),
                    r.GetDecimal("hourly_rate"), r.GetInt32("experience_years"), r.GetBoolean("verified"));
        }

        // Saves everything a babysitter can edit about their own profile, now
        // including their hourly rate and years of experience.
        public static void UpdateProfile(int userId, string bio, string location,
                                         decimal hourlyRate, int experienceYears)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"UPDATE babysitter_profiles
                  SET bio = @b, location = @l, hourly_rate = @rate, experience_years = @exp
                  WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@b", bio);
            cmd.Parameters.AddWithValue("@l", location);
            cmd.Parameters.AddWithValue("@rate", hourlyRate);
            cmd.Parameters.AddWithValue("@exp", experienceYears);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static List<string> GetAllSkills()
        {
            List<string> list = new List<string>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand("SELECT name FROM skills ORDER BY skill_id", conn);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        public static List<string> GetSkillsFor(int userId)
        {
            List<string> list = new List<string>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT s.name FROM babysitter_skills bs
                  JOIN skills s ON s.skill_id = bs.skill_id
                  WHERE bs.babysitter_id = @id ORDER BY s.skill_id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        public static void SetSkills(int userId, IEnumerable<string> skillNames)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlTransaction tx = conn.BeginTransaction();
            using (MySqlCommand del = new MySqlCommand("DELETE FROM babysitter_skills WHERE babysitter_id = @id", conn, tx))
            {
                del.Parameters.AddWithValue("@id", userId);
                del.ExecuteNonQuery();
            }
            foreach (string name in skillNames)
            {
                using MySqlCommand ins = new MySqlCommand(
                    @"INSERT INTO babysitter_skills (babysitter_id, skill_id)
                      SELECT @id, skill_id FROM skills WHERE name = @n", conn, tx);
                ins.Parameters.AddWithValue("@id", userId);
                ins.Parameters.AddWithValue("@n", name);
                ins.ExecuteNonQuery();
            }
            tx.Commit();
        }

        // Babysitter dashboard tiles: earnings this month, bookings, hours, rating.
        public static (decimal MonthEarnings, int TotalBookings, int HoursWorked, double AvgRating, int ReviewCount)
            GetDashboardStats(int userId)
        {
            using MySqlConnection conn = Db.Open();
            decimal earnings = 0; int bookings = 0, hours = 0;
            // Earnings now come from payments the admin has actually PAID OUT this
            // month - not merely from completed bookings - so the tile reflects real
            // money received. Booking/hours counts still use the bookings table.
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT COALESCE((SELECT SUM(pay.amount) FROM payments pay
                                   JOIN bookings pb ON pb.booking_id = pay.booking_id
                                   WHERE pb.babysitter_id = @id AND pay.status = 'paid'
                                     AND YEAR(pay.paid_at) = YEAR(CURDATE())
                                     AND MONTH(pay.paid_at) = MONTH(CURDATE())), 0) AS month_earnings,
                         SUM(CASE WHEN status IN ('confirmed','completed') THEN 1 ELSE 0 END) AS total_bookings,
                         COALESCE(SUM(CASE WHEN status = 'completed' THEN duration_hours END), 0) AS hours_worked
                  FROM bookings WHERE babysitter_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    earnings = r.GetDecimal("month_earnings");
                    bookings = r.IsDBNull(r.GetOrdinal("total_bookings")) ? 0 : Convert.ToInt32(r["total_bookings"]);
                    hours = Convert.ToInt32(r["hours_worked"]);
                }
            }

            double avg = 0; int count = 0;
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT COALESCE(AVG(rating),0) a, COUNT(review_id) c
                  FROM reviews WHERE babysitter_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read()) { avg = r.GetDouble("a"); count = r.GetInt32("c"); }
            }
            return (earnings, bookings, hours, avg, count);
        }
    }

    // ----- Bookings: the wizard, both dashboards, the admin grid + charts -----
    internal static class BookingRepository
    {
        public static int Create(int parentId, int babysitterId, DateTime date, TimeSpan start,
                                 int hours, int children, string address, string notes,
                                 decimal hourlyRate, decimal serviceFee, decimal total)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO bookings (parent_id, babysitter_id, booking_date, start_time, duration_hours,
                                        children_count, address, notes, status, hourly_rate, service_fee, total)
                  VALUES (@p, @b, @d, @t, @h, @c, @a, @n, 'pending', @rate, @fee, @total)", conn);
            cmd.Parameters.AddWithValue("@p", parentId);
            cmd.Parameters.AddWithValue("@b", babysitterId);
            cmd.Parameters.AddWithValue("@d", date.Date);
            cmd.Parameters.AddWithValue("@t", start);
            cmd.Parameters.AddWithValue("@h", hours);
            cmd.Parameters.AddWithValue("@c", children);
            cmd.Parameters.AddWithValue("@a", address);
            cmd.Parameters.AddWithValue("@n", notes);
            cmd.Parameters.AddWithValue("@rate", hourlyRate);
            cmd.Parameters.AddWithValue("@fee", serviceFee);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }

        // All of a parent's bookings, newest first, with a "did I review it" flag.
        // The join is scoped to author_role='parent': a booking can also carry the
        // babysitter's review of the parent, which must not count here (and would
        // duplicate rows in the join otherwise).
        public static List<BookingInfo> GetForParent(int parentId)
        {
            const string sql =
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS sitter_name,
                         (r.review_id IS NOT NULL) AS has_review
                  FROM bookings b
                  JOIN users u ON u.user_id = b.babysitter_id
                  LEFT JOIN reviews r ON r.booking_id = b.booking_id AND r.author_role = 'parent'
                  WHERE b.parent_id = @id
                  ORDER BY b.booking_date DESC, b.start_time DESC";
            return Query(sql, "@id", parentId);
        }

        // Bookings the babysitter has marked done and that are now waiting for THIS
        // parent to confirm the job was completed properly (payment 'awaiting_confirm').
        public static List<BookingInfo> GetAwaitingParentConfirm(int parentId)
        {
            const string sql =
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS sitter_name
                  FROM bookings b
                  JOIN users u ON u.user_id = b.babysitter_id
                  JOIN payments pay ON pay.booking_id = b.booking_id
                  WHERE b.parent_id = @id AND pay.status = 'awaiting_confirm'
                  ORDER BY b.booking_date DESC, b.start_time DESC";
            return Query(sql, "@id", parentId);
        }

        public static List<BookingInfo> GetPendingForBabysitter(int babysitterId)
        {
            const string sql =
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS parent_name
                  FROM bookings b
                  JOIN users u ON u.user_id = b.parent_id
                  WHERE b.babysitter_id = @id AND b.status = 'pending' AND b.booking_date >= CURDATE()
                  ORDER BY b.booking_date, b.start_time";
            return Query(sql, "@id", babysitterId);
        }

        // A babysitter's confirmed + completed bookings, most recent first, for the
        // dashboard schedule list (replaces the old month-grid calendar).
        public static List<BookingInfo> GetScheduleForBabysitter(int babysitterId)
        {
            const string sql =
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS parent_name
                  FROM bookings b
                  JOIN users u ON u.user_id = b.parent_id
                  WHERE b.babysitter_id = @id AND b.status IN ('confirmed','completed')
                  ORDER BY b.booking_date DESC, b.start_time DESC";
            return Query(sql, "@id", babysitterId);
        }

        // Any 'confirmed' booking whose date has already passed is really finished,
        // so flip it to 'completed'. This makes it count toward the babysitter's
        // earnings/hours and lets the parent leave a review. Safe to call on load.
        public static void AutoCompletePastBookings()
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "UPDATE bookings SET status = 'completed' WHERE status = 'confirmed' AND booking_date < CURDATE()", conn);
            cmd.ExecuteNonQuery();
        }

        // Confirmed/completed bookings of one month, for the dashboard calendar.
        public static Dictionary<int, BookingInfo> GetMonthCalendar(int babysitterId, int year, int month)
        {
            Dictionary<int, BookingInfo> dict = new Dictionary<int, BookingInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS parent_name
                  FROM bookings b
                  JOIN users u ON u.user_id = b.parent_id
                  WHERE b.babysitter_id = @id AND b.status IN ('confirmed','completed')
                    AND YEAR(b.booking_date) = @y AND MONTH(b.booking_date) = @m", conn);
            cmd.Parameters.AddWithValue("@id", babysitterId);
            cmd.Parameters.AddWithValue("@y", year);
            cmd.Parameters.AddWithValue("@m", month);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                BookingInfo b = ReadBooking(r);
                dict[b.Date.Day] = b;   // one entry per day is enough for the cell
            }
            return dict;
        }

        // Newest finished (or past-confirmed) booking between this parent and
        // babysitter that this author role hasn't reviewed yet - the one a new
        // review would attach to. A booking can carry one review per direction
        // (parent-about-sitter and sitter-about-parent are independent), so the
        // "already reviewed" check only looks at reviews from the same author role.
        // Returns null when there's nothing left to review for this pairing.
        public static int? FindReviewableBooking(int parentId, int babysitterId, string authorRole)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT b.booking_id
                  FROM bookings b
                  LEFT JOIN reviews r ON r.booking_id = b.booking_id AND r.author_role = @role
                  WHERE b.parent_id = @p AND b.babysitter_id = @b AND r.review_id IS NULL
                    AND (b.status = 'completed'
                         OR (b.status = 'confirmed' AND b.booking_date < CURDATE()))
                  ORDER BY b.booking_date DESC, b.start_time DESC
                  LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@p", parentId);
            cmd.Parameters.AddWithValue("@b", babysitterId);
            cmd.Parameters.AddWithValue("@role", authorRole);
            object? v = cmd.ExecuteScalar();
            return v == null || v is DBNull ? (int?)null : Convert.ToInt32(v);
        }

        public static void SetStatus(int bookingId, string status)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand("UPDATE bookings SET status = @s WHERE booking_id = @id", conn);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", bookingId);
            cmd.ExecuteNonQuery();
        }

        // Admin deletes a single booking. Its payment and any reviews must go first
        // (they reference the booking), so all three run in one transaction.
        public static void Delete(int bookingId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlTransaction tx = conn.BeginTransaction();
            foreach (string table in new[] { "reviews", "payments" })
            {
                using MySqlCommand child = new MySqlCommand(
                    $"DELETE FROM {table} WHERE booking_id = @id", conn, tx);
                child.Parameters.AddWithValue("@id", bookingId);
                child.ExecuteNonQuery();
            }
            using MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM bookings WHERE booking_id = @id", conn, tx);
            cmd.Parameters.AddWithValue("@id", bookingId);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }

        // ----- Admin -----

        public static List<BookingInfo> GetAll()
        {
            const string sql =
                @"SELECT b.*, CONCAT(p.first_name,' ',p.last_name) AS parent_name,
                         CONCAT(s.first_name,' ',s.last_name) AS sitter_name
                  FROM bookings b
                  JOIN users p ON p.user_id = b.parent_id
                  JOIN users s ON s.user_id = b.babysitter_id
                  ORDER BY b.booking_date DESC, b.start_time DESC";
            return Query(sql, null, 0);
        }

        public static (int Parents, int Babysitters, int BookingsThisMonth, decimal Revenue) GetAdminKpis()
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT (SELECT COUNT(*) FROM users WHERE role = 'parent') AS parents,
                         (SELECT COUNT(*) FROM users WHERE role = 'babysitter') AS sitters,
                         (SELECT COUNT(*) FROM bookings
                          WHERE YEAR(booking_date) = YEAR(CURDATE())
                            AND MONTH(booking_date) = MONTH(CURDATE())) AS month_bookings,
                         (SELECT COALESCE(SUM(amount),0) FROM payments WHERE status = 'paid') AS revenue", conn);
            using MySqlDataReader r = cmd.ExecuteReader();
            r.Read();
            return (r.GetInt32("parents"), r.GetInt32("sitters"),
                    r.GetInt32("month_bookings"), r.GetDecimal("revenue"));
        }

        // counts[0] = January ... counts[11] = December, for the given year.
        public static (int[] Counts, decimal[] Revenue) GetMonthlyStats(int year)
        {
            int[] counts = new int[12];
            decimal[] revenue = new decimal[12];
            using MySqlConnection conn = Db.Open();

            // Bars = number of bookings per month. Grouped on its own so every
            // selected column is either the GROUP BY expression or an aggregate
            // (required by MySQL's only_full_group_by mode).
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT MONTH(booking_date) AS m, COUNT(*) AS c
                  FROM bookings WHERE YEAR(booking_date) = @y
                  GROUP BY MONTH(booking_date)", conn))
            {
                cmd.Parameters.AddWithValue("@y", year);
                using MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                    counts[r.GetInt32("m") - 1] = r.GetInt32("c");
            }

            // Revenue = money actually paid out each month, taken straight from the
            // payments table and grouped by its own paid_at month - a separate query
            // instead of a correlated subquery, so the two charts stay truthful.
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT MONTH(paid_at) AS m, SUM(amount) AS rev
                  FROM payments WHERE status = 'paid' AND YEAR(paid_at) = @y
                  GROUP BY MONTH(paid_at)", conn))
            {
                cmd.Parameters.AddWithValue("@y", year);
                using MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                    revenue[r.GetInt32("m") - 1] = r.GetDecimal("rev");
            }

            return (counts, revenue);
        }

        // ----- shared row mapping -----

        // Lets other repositories (e.g. PaymentRepository) reuse the booking-row
        // mapper for a parameterless query without duplicating ReadBooking.
        public static List<BookingInfo> QueryPublic(string sql) => Query(sql, null, 0);

        private static List<BookingInfo> Query(string sql, string? paramName, int paramValue)
        {
            List<BookingInfo> list = new List<BookingInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (paramName != null)
                cmd.Parameters.AddWithValue(paramName, paramValue);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(ReadBooking(r));
            return list;
        }

        private static BookingInfo ReadBooking(MySqlDataReader r)
        {
            bool Has(string col)
            {
                for (int i = 0; i < r.FieldCount; i++)
                    if (r.GetName(i).Equals(col, StringComparison.OrdinalIgnoreCase)) return true;
                return false;
            }
            return new BookingInfo
            {
                BookingId = r.GetInt32("booking_id"),
                ParentId = r.GetInt32("parent_id"),
                BabysitterId = r.GetInt32("babysitter_id"),
                ParentName = Has("parent_name") ? r.GetString("parent_name") : "",
                SitterName = Has("sitter_name") ? r.GetString("sitter_name") : "",
                Date = r.GetDateTime("booking_date"),
                Start = r.GetTimeSpan("start_time"),
                DurationHours = r.GetInt32("duration_hours"),
                ChildrenCount = r.GetInt32("children_count"),
                Address = r.GetString("address"),
                Notes = r.IsDBNull(r.GetOrdinal("notes")) ? "" : r.GetString("notes"),
                Status = r.GetString("status"),
                HourlyRate = r.GetDecimal("hourly_rate"),
                ServiceFee = r.GetDecimal("service_fee"),
                Total = r.GetDecimal("total"),
                HasReview = Has("has_review") && Convert.ToBoolean(r["has_review"]),
            };
        }
    }

    // ----- Reviews (two-way: parent-about-sitter and sitter-about-parent) -----
    internal static class ReviewRepository
    {
        // Reviews a babysitter received from parents.
        public static List<ReviewInfo> GetForBabysitter(int babysitterId)
        {
            const string sql =
                @"SELECT CONCAT(u.first_name, ' ', LEFT(u.last_name, 1), '.') AS author,
                         r.rating, COALESCE(r.comment,'') AS comment, r.created_at
                  FROM reviews r
                  JOIN users u ON u.user_id = r.parent_id
                  WHERE r.babysitter_id = @id AND r.author_role = 'parent'
                  ORDER BY r.created_at DESC";
            return Query(sql, babysitterId);
        }

        // Reviews a parent received from babysitters.
        public static List<ReviewInfo> GetForParent(int parentId)
        {
            const string sql =
                @"SELECT CONCAT(u.first_name, ' ', LEFT(u.last_name, 1), '.') AS author,
                         r.rating, COALESCE(r.comment,'') AS comment, r.created_at
                  FROM reviews r
                  JOIN users u ON u.user_id = r.babysitter_id
                  WHERE r.parent_id = @id AND r.author_role = 'babysitter'
                  ORDER BY r.created_at DESC";
            return Query(sql, parentId);
        }

        private static List<ReviewInfo> Query(string sql, int id)
        {
            List<ReviewInfo> list = new List<ReviewInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new ReviewInfo
                {
                    Author = r.GetString("author"),
                    Rating = r.GetInt32("rating"),
                    Comment = r.GetString("comment"),
                    CreatedAt = r.GetDateTime("created_at"),
                });
            }
            return list;
        }

        // bookingId is optional: reviews written from a finished booking link to
        // it (and complete it); reviews written straight from a profile don't.
        // authorRole is "parent" when a parent is reviewing the sitter, or
        // "babysitter" when the sitter is reviewing the parent right back.
        public static void Add(int? bookingId, int parentId, int babysitterId,
                               string authorRole, int rating, string comment)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlTransaction tx = conn.BeginTransaction();
            using (MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO reviews (booking_id, parent_id, babysitter_id, author_role, rating, comment)
                  VALUES (@b, @p, @s, @role, @r, @c)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@b", (object?)bookingId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@p", parentId);
                cmd.Parameters.AddWithValue("@s", babysitterId);
                cmd.Parameters.AddWithValue("@role", authorRole);
                cmd.Parameters.AddWithValue("@r", rating);
                cmd.Parameters.AddWithValue("@c", comment);
                cmd.ExecuteNonQuery();
            }
            if (bookingId.HasValue)
            {
                // A reviewed booking is, by definition, finished.
                using MySqlCommand done = new MySqlCommand(
                    "UPDATE bookings SET status = 'completed' WHERE booking_id = @b", conn, tx);
                done.Parameters.AddWithValue("@b", bookingId.Value);
                done.ExecuteNonQuery();
            }
            tx.Commit();
        }
    }

    // ----- Parents: profile page babysitters see, "Find Parents" search -----
    internal static class ParentRepository
    {
        // Every parent with at least one booking, for the babysitter-side search
        // page. (Parents don't set up a public profile the way sitters do, so
        // there's no "active/available" gate here - any parent who has ever
        // booked is discoverable.)
        public static List<ParentInfo> GetAllParents()
        {
            List<ParentInfo> list = new List<ParentInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT u.user_id, CONCAT(u.first_name,' ',u.last_name) AS name, u.created_at,
                         COALESCE((SELECT AVG(r.rating) FROM reviews r
                                   WHERE r.parent_id = u.user_id AND r.author_role = 'babysitter'), 0) AS avg_rating,
                         (SELECT COUNT(*) FROM reviews r
                          WHERE r.parent_id = u.user_id AND r.author_role = 'babysitter') AS review_count,
                         (SELECT COUNT(*) FROM bookings b
                          WHERE b.parent_id = u.user_id AND b.status = 'completed') AS completed_count
                  FROM users u
                  WHERE u.role = 'parent' AND u.status = 'active'
                  ORDER BY name", conn);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new ParentInfo
                {
                    UserId = r.GetInt32("user_id"),
                    Name = r.GetString("name"),
                    MemberSince = r.GetDateTime("created_at"),
                    AvgRating = r.GetDouble("avg_rating"),
                    ReviewCount = r.GetInt32("review_count"),
                    CompletedBookingCount = r.GetInt32("completed_count"),
                });
            }
            return list;
        }

        public static ParentInfo? GetParentInfo(int parentId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT u.user_id, CONCAT(u.first_name,' ',u.last_name) AS name, u.created_at,
                         COALESCE((SELECT AVG(r.rating) FROM reviews r
                                   WHERE r.parent_id = u.user_id AND r.author_role = 'babysitter'), 0) AS avg_rating,
                         (SELECT COUNT(*) FROM reviews r
                          WHERE r.parent_id = u.user_id AND r.author_role = 'babysitter') AS review_count,
                         (SELECT COUNT(*) FROM bookings b
                          WHERE b.parent_id = u.user_id AND b.status = 'completed') AS completed_count
                  FROM users u WHERE u.user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", parentId);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new ParentInfo
            {
                UserId = r.GetInt32("user_id"),
                Name = r.GetString("name"),
                MemberSince = r.GetDateTime("created_at"),
                AvgRating = r.GetDouble("avg_rating"),
                ReviewCount = r.GetInt32("review_count"),
                CompletedBookingCount = r.GetInt32("completed_count"),
            };
        }
    }

    // ----- Payments: saved cards + one simulated payment per booking -----
    internal static class PaymentRepository
    {
        public static List<PaymentCard> GetCards(int userId)
        {
            List<PaymentCard> list = new List<PaymentCard>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT card_id, card_holder, last4, brand, exp_month, exp_year
                  FROM payment_cards WHERE user_id = @u ORDER BY card_id", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new PaymentCard
                {
                    CardId = r.GetInt32("card_id"),
                    Holder = r.GetString("card_holder"),
                    Last4 = r.GetString("last4"),
                    Brand = r.GetString("brand"),
                    ExpMonth = r.GetInt32("exp_month"),
                    ExpYear = r.GetInt32("exp_year"),
                });
            }
            return list;
        }

        // Only the last 4 digits and brand are persisted - the caller validates
        // the full number (Luhn) and the CVV, then throws them away.
        public static int AddCard(int userId, string holder, string last4, string brand,
                                  int expMonth, int expYear)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO payment_cards (user_id, card_holder, last4, brand, exp_month, exp_year)
                  VALUES (@u, @h, @l4, @b, @m, @y)", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.Parameters.AddWithValue("@h", holder);
            cmd.Parameters.AddWithValue("@l4", last4);
            cmd.Parameters.AddWithValue("@b", brand);
            cmd.Parameters.AddWithValue("@m", expMonth);
            cmd.Parameters.AddWithValue("@y", expYear);
            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }

        // Records the chosen card against a new booking WITHOUT charging anything.
        // The parent only pays after the job is finished, so it starts 'authorized'.
        public static void CreateAuthorizedPayment(int bookingId, int cardId, decimal amount)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO payments (booking_id, card_id, amount, status)
                  VALUES (@b, @c, @a, 'authorized')", conn);
            cmd.Parameters.AddWithValue("@b", bookingId);
            cmd.Parameters.AddWithValue("@c", cardId);
            cmd.Parameters.AddWithValue("@a", amount);
            cmd.ExecuteNonQuery();
        }

        // Moves a payment from one status to the next, but only from the exact
        // status we expect - so the same button can't fire the step twice.
        private static void Advance(int bookingId, string fromStatus, string toStatus)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"UPDATE payments SET status = @to
                  WHERE booking_id = @b AND status = @from", conn);
            cmd.Parameters.AddWithValue("@to", toStatus);
            cmd.Parameters.AddWithValue("@from", fromStatus);
            cmd.Parameters.AddWithValue("@b", bookingId);
            cmd.ExecuteNonQuery();
        }

        // Babysitter says the job is done -> now waiting for the parent to confirm.
        public static void MarkAwaitingConfirm(int bookingId) =>
            Advance(bookingId, "authorized", "awaiting_confirm");

        // Parent confirms the job was completed properly -> ready for the admin.
        public static void MarkApprovedByParent(int bookingId) =>
            Advance(bookingId, "awaiting_confirm", "approved");

        // Admin charges the parent and pays the babysitter -> receipt now exists.
        public static void MarkPaid(int bookingId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"UPDATE payments SET status = 'paid', paid_at = NOW()
                  WHERE booking_id = @b AND status = 'approved'", conn);
            cmd.Parameters.AddWithValue("@b", bookingId);
            cmd.ExecuteNonQuery();
        }

        // Admin (or a decline) drops the payment: no money changes hands. Allowed
        // from any not-yet-paid status so a no-show can be discarded at any point.
        public static void Discard(int bookingId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"UPDATE payments SET status = 'discarded'
                  WHERE booking_id = @b AND status <> 'paid'", conn);
            cmd.Parameters.AddWithValue("@b", bookingId);
            cmd.ExecuteNonQuery();
        }

        // For the receipt/status line: current payment state + which card. Null when
        // the booking predates the payment feature.
        public static (string Status, string Brand, string Last4)? GetForBooking(int bookingId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT p.status, c.brand, c.last4
                  FROM payments p JOIN payment_cards c ON c.card_id = p.card_id
                  WHERE p.booking_id = @b", conn);
            cmd.Parameters.AddWithValue("@b", bookingId);
            using MySqlDataReader r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return (r.GetString("status"), r.GetString("brand"), r.GetString("last4"));
        }

        // Admin "Payouts" screen: every payment the parent has approved and that
        // the admin has not settled yet - i.e. money ready to charge & pay out.
        public static List<BookingInfo> GetApprovedPayouts()
        {
            const string sql =
                @"SELECT b.*, CONCAT(p.first_name,' ',p.last_name) AS parent_name,
                         CONCAT(s.first_name,' ',s.last_name) AS sitter_name
                  FROM bookings b
                  JOIN payments pay ON pay.booking_id = b.booking_id
                  JOIN users p ON p.user_id = b.parent_id
                  JOIN users s ON s.user_id = b.babysitter_id
                  WHERE pay.status = 'approved'
                  ORDER BY b.booking_date DESC, b.start_time DESC";
            return BookingRepository.QueryPublic(sql);
        }
    }

    // ----- Favorites, notifications, settings -----
    internal static class ExtrasRepository
    {
        public static HashSet<int> GetFavoriteIds(int parentId)
        {
            HashSet<int> set = new HashSet<int>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "SELECT babysitter_id FROM favorites WHERE parent_id = @p", conn);
            cmd.Parameters.AddWithValue("@p", parentId);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) set.Add(r.GetInt32(0));
            return set;
        }

        // Returns true when the babysitter is now a favorite.
        public static bool ToggleFavorite(int parentId, int babysitterId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand del = new MySqlCommand(
                "DELETE FROM favorites WHERE parent_id = @p AND babysitter_id = @b", conn);
            del.Parameters.AddWithValue("@p", parentId);
            del.Parameters.AddWithValue("@b", babysitterId);
            if (del.ExecuteNonQuery() > 0)
                return false;   // it existed and was removed

            using MySqlCommand ins = new MySqlCommand(
                "INSERT INTO favorites (parent_id, babysitter_id) VALUES (@p, @b)", conn);
            ins.Parameters.AddWithValue("@p", parentId);
            ins.Parameters.AddWithValue("@b", babysitterId);
            ins.ExecuteNonQuery();
            return true;
        }

        public static List<NotificationInfo> GetNotifications(int userId, int limit = 12)
        {
            List<NotificationInfo> list = new List<NotificationInfo>();
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                @"SELECT notification_id, message, is_read, created_at
                  FROM notifications WHERE user_id = @u
                  ORDER BY created_at DESC LIMIT " + limit, conn);
            cmd.Parameters.AddWithValue("@u", userId);
            using MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new NotificationInfo
                {
                    NotificationId = r.GetInt32("notification_id"),
                    Message = r.GetString("message"),
                    Unread = !r.GetBoolean("is_read"),
                    CreatedAt = r.GetDateTime("created_at"),
                });
            }
            return list;
        }

        public static void MarkAllRead(int userId)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "UPDATE notifications SET is_read = TRUE WHERE user_id = @u", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.ExecuteNonQuery();
        }

        public static void AddNotification(int userId, string message)
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO notifications (user_id, message) VALUES (@u, @m)", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.Parameters.AddWithValue("@m", message);
            cmd.ExecuteNonQuery();
        }

        public static decimal GetServiceFee()
        {
            using MySqlConnection conn = Db.Open();
            using MySqlCommand cmd = new MySqlCommand(
                "SELECT setting_value FROM settings WHERE setting_key = 'service_fee'", conn);
            object? v = cmd.ExecuteScalar();
            return v != null && decimal.TryParse(v.ToString(), out decimal fee) ? fee : 2.50m;
        }
    }
}
