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
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at, password
                  FROM users WHERE email = @e", conn);
            cmd.Parameters.AddWithValue("@e", email);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return LoginResult.NoSuchEmail;

            string stored = r.GetString("password");
            if (!string.Equals(stored, password, StringComparison.Ordinal))
                return LoginResult.WrongPassword;

            user = ReadUser(r);
            return LoginResult.Ok;
        }

        public static bool EmailExists(string email)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE email = @e", conn);
            cmd.Parameters.AddWithValue("@e", email);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Inserts the new account with status 'pending' - an admin must approve
        // it before the person can sign in.
        public static int Register(string firstName, string lastName, string email,
                                   string phone, string password, UserRole role)
        {
            using var conn = Db.Open();
            using var tx = conn.BeginTransaction();

            using var cmd = new MySqlCommand(
                @"INSERT INTO users (role, first_name, last_name, email, phone, password, status)
                  VALUES (@role, @fn, @ln, @e, @ph, @pw, 'pending')", conn, tx);
            cmd.Parameters.AddWithValue("@role", role == UserRole.Babysitter ? "babysitter" : "parent");
            cmd.Parameters.AddWithValue("@fn", firstName);
            cmd.Parameters.AddWithValue("@ln", lastName);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.Parameters.AddWithValue("@pw", password);
            cmd.ExecuteNonQuery();
            int userId = (int)cmd.LastInsertedId;

            if (role == UserRole.Babysitter)
            {
                using var profileCmd = new MySqlCommand(
                    @"INSERT INTO babysitter_profiles (user_id, bio, location) VALUES (@id, '', '')", conn, tx);
                profileCmd.Parameters.AddWithValue("@id", userId);
                profileCmd.ExecuteNonQuery();
            }

            tx.Commit();
            return userId;
        }

        public static User? GetById(int userId)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at, photo
                  FROM users WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            var u = ReadUser(r);
            u.Photo = r.IsDBNull(r.GetOrdinal("photo")) ? null : (byte[])r["photo"];
            return u;
        }

        // Admin grid. Search matches name or email.
        public static List<User> GetUsers(string search)
        {
            var list = new List<User>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT user_id, role, first_name, last_name, email, phone, status, created_at
                  FROM users
                  WHERE (@s = '' OR CONCAT(first_name,' ',last_name) LIKE @like OR email LIKE @like)
                  ORDER BY (status = 'pending') DESC, created_at DESC", conn);
            cmd.Parameters.AddWithValue("@s", search);
            cmd.Parameters.AddWithValue("@like", "%" + search + "%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(ReadUser(r));
            return list;
        }

        public static void SetStatus(int userId, string status)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand("UPDATE users SET status = @s WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateContact(int userId, string firstName, string lastName, string phone)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "UPDATE users SET first_name = @fn, last_name = @ln, phone = @ph WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@fn", firstName);
            cmd.Parameters.AddWithValue("@ln", lastName);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void SetPhoto(int userId, byte[] imageBytes)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand("UPDATE users SET photo = @p WHERE user_id = @id", conn);
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
            var list = new List<BabysitterInfo>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT u.user_id, CONCAT(u.first_name,' ',u.last_name) AS name,
                         COALESCE(p.bio,'') AS bio, p.hourly_rate, p.experience_years,
                         p.location, p.verified, p.available,
                         COALESCE((SELECT AVG(r.rating) FROM reviews r
                                   JOIN bookings b ON b.booking_id = r.booking_id
                                   WHERE b.babysitter_id = u.user_id), 0) AS avg_rating,
                         (SELECT COUNT(*) FROM reviews r
                          JOIN bookings b ON b.booking_id = r.booking_id
                          WHERE b.babysitter_id = u.user_id) AS review_count,
                         COALESCE((SELECT GROUP_CONCAT(s.name ORDER BY s.skill_id SEPARATOR '|')
                                   FROM babysitter_skills bs
                                   JOIN skills s ON s.skill_id = bs.skill_id
                                   WHERE bs.babysitter_id = u.user_id), '') AS skills
                  FROM users u
                  JOIN babysitter_profiles p ON p.user_id = u.user_id
                  WHERE u.status = 'active'
                  ORDER BY avg_rating DESC, name", conn);
            using var r = cmd.ExecuteReader();
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

        public static (string Bio, string Location, decimal HourlyRate, int ExperienceYears, bool Verified)
            GetProfile(int userId)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT COALESCE(bio,'') bio, location, hourly_rate, experience_years, verified
                  FROM babysitter_profiles WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return ("", "", 15m, 0, false);
            return (r.GetString("bio"), r.GetString("location"),
                    r.GetDecimal("hourly_rate"), r.GetInt32("experience_years"), r.GetBoolean("verified"));
        }

        public static void UpdateProfile(int userId, string bio, string location)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "UPDATE babysitter_profiles SET bio = @b, location = @l WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@b", bio);
            cmd.Parameters.AddWithValue("@l", location);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static List<string> GetAllSkills()
        {
            var list = new List<string>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand("SELECT name FROM skills ORDER BY skill_id", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        public static List<string> GetSkillsFor(int userId)
        {
            var list = new List<string>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT s.name FROM babysitter_skills bs
                  JOIN skills s ON s.skill_id = bs.skill_id
                  WHERE bs.babysitter_id = @id ORDER BY s.skill_id", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        public static void SetSkills(int userId, IEnumerable<string> skillNames)
        {
            using var conn = Db.Open();
            using var tx = conn.BeginTransaction();
            using (var del = new MySqlCommand("DELETE FROM babysitter_skills WHERE babysitter_id = @id", conn, tx))
            {
                del.Parameters.AddWithValue("@id", userId);
                del.ExecuteNonQuery();
            }
            foreach (var name in skillNames)
            {
                using var ins = new MySqlCommand(
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
            using var conn = Db.Open();
            decimal earnings = 0; int bookings = 0, hours = 0;
            using (var cmd = new MySqlCommand(
                @"SELECT COALESCE(SUM(CASE WHEN status = 'completed'
                                            AND YEAR(booking_date) = YEAR(CURDATE())
                                            AND MONTH(booking_date) = MONTH(CURDATE())
                                           THEN total END), 0) AS month_earnings,
                         SUM(CASE WHEN status IN ('confirmed','completed') THEN 1 ELSE 0 END) AS total_bookings,
                         COALESCE(SUM(CASE WHEN status = 'completed' THEN duration_hours END), 0) AS hours_worked
                  FROM bookings WHERE babysitter_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    earnings = r.GetDecimal("month_earnings");
                    bookings = r.IsDBNull(r.GetOrdinal("total_bookings")) ? 0 : Convert.ToInt32(r["total_bookings"]);
                    hours = Convert.ToInt32(r["hours_worked"]);
                }
            }

            double avg = 0; int count = 0;
            using (var cmd = new MySqlCommand(
                @"SELECT COALESCE(AVG(r.rating),0) a, COUNT(r.review_id) c
                  FROM reviews r JOIN bookings b ON b.booking_id = r.booking_id
                  WHERE b.babysitter_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using var r = cmd.ExecuteReader();
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
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
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

        // All of a parent's bookings, newest first, with a "was it reviewed" flag.
        public static List<BookingInfo> GetForParent(int parentId)
        {
            const string sql =
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS sitter_name,
                         (r.review_id IS NOT NULL) AS has_review
                  FROM bookings b
                  JOIN users u ON u.user_id = b.babysitter_id
                  LEFT JOIN reviews r ON r.booking_id = b.booking_id
                  WHERE b.parent_id = @id
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

        // Confirmed/completed bookings of one month, for the dashboard calendar.
        public static Dictionary<int, BookingInfo> GetMonthCalendar(int babysitterId, int year, int month)
        {
            var dict = new Dictionary<int, BookingInfo>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT b.*, CONCAT(u.first_name,' ',u.last_name) AS parent_name
                  FROM bookings b
                  JOIN users u ON u.user_id = b.parent_id
                  WHERE b.babysitter_id = @id AND b.status IN ('confirmed','completed')
                    AND YEAR(b.booking_date) = @y AND MONTH(b.booking_date) = @m", conn);
            cmd.Parameters.AddWithValue("@id", babysitterId);
            cmd.Parameters.AddWithValue("@y", year);
            cmd.Parameters.AddWithValue("@m", month);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                var b = ReadBooking(r);
                dict[b.Date.Day] = b;   // one entry per day is enough for the cell
            }
            return dict;
        }

        public static void SetStatus(int bookingId, string status)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand("UPDATE bookings SET status = @s WHERE booking_id = @id", conn);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", bookingId);
            cmd.ExecuteNonQuery();
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
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT (SELECT COUNT(*) FROM users WHERE role = 'parent') AS parents,
                         (SELECT COUNT(*) FROM users WHERE role = 'babysitter') AS sitters,
                         (SELECT COUNT(*) FROM bookings
                          WHERE YEAR(booking_date) = YEAR(CURDATE())
                            AND MONTH(booking_date) = MONTH(CURDATE())) AS month_bookings,
                         (SELECT COALESCE(SUM(total),0) FROM bookings WHERE status = 'completed') AS revenue", conn);
            using var r = cmd.ExecuteReader();
            r.Read();
            return (r.GetInt32("parents"), r.GetInt32("sitters"),
                    r.GetInt32("month_bookings"), r.GetDecimal("revenue"));
        }

        // counts[0] = January ... counts[11] = December, for the given year.
        public static (int[] Counts, decimal[] Revenue) GetMonthlyStats(int year)
        {
            var counts = new int[12];
            var revenue = new decimal[12];
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT MONTH(booking_date) AS m, COUNT(*) AS c,
                         COALESCE(SUM(CASE WHEN status = 'completed' THEN total END), 0) AS rev
                  FROM bookings WHERE YEAR(booking_date) = @y
                  GROUP BY MONTH(booking_date)", conn);
            cmd.Parameters.AddWithValue("@y", year);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                int m = r.GetInt32("m") - 1;
                counts[m] = r.GetInt32("c");
                revenue[m] = r.GetDecimal("rev");
            }
            return (counts, revenue);
        }

        // ----- shared row mapping -----

        private static List<BookingInfo> Query(string sql, string? paramName, int paramValue)
        {
            var list = new List<BookingInfo>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(sql, conn);
            if (paramName != null)
                cmd.Parameters.AddWithValue(paramName, paramValue);
            using var r = cmd.ExecuteReader();
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

    // ----- Reviews -----
    internal static class ReviewRepository
    {
        public static List<ReviewInfo> GetForBabysitter(int babysitterId)
        {
            var list = new List<ReviewInfo>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT CONCAT(u.first_name, ' ', LEFT(u.last_name, 1), '.') AS author,
                         r.rating, COALESCE(r.comment,'') AS comment, r.created_at
                  FROM reviews r
                  JOIN bookings b ON b.booking_id = r.booking_id
                  JOIN users u ON u.user_id = b.parent_id
                  WHERE b.babysitter_id = @id
                  ORDER BY r.created_at DESC", conn);
            cmd.Parameters.AddWithValue("@id", babysitterId);
            using var r = cmd.ExecuteReader();
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

        public static void Add(int bookingId, int rating, string comment)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "INSERT INTO reviews (booking_id, rating, comment) VALUES (@b, @r, @c)", conn);
            cmd.Parameters.AddWithValue("@b", bookingId);
            cmd.Parameters.AddWithValue("@r", rating);
            cmd.Parameters.AddWithValue("@c", comment);
            cmd.ExecuteNonQuery();
        }
    }

    // ----- Favorites, notifications, settings -----
    internal static class ExtrasRepository
    {
        public static HashSet<int> GetFavoriteIds(int parentId)
        {
            var set = new HashSet<int>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "SELECT babysitter_id FROM favorites WHERE parent_id = @p", conn);
            cmd.Parameters.AddWithValue("@p", parentId);
            using var r = cmd.ExecuteReader();
            while (r.Read()) set.Add(r.GetInt32(0));
            return set;
        }

        // Returns true when the babysitter is now a favorite.
        public static bool ToggleFavorite(int parentId, int babysitterId)
        {
            using var conn = Db.Open();
            using var del = new MySqlCommand(
                "DELETE FROM favorites WHERE parent_id = @p AND babysitter_id = @b", conn);
            del.Parameters.AddWithValue("@p", parentId);
            del.Parameters.AddWithValue("@b", babysitterId);
            if (del.ExecuteNonQuery() > 0)
                return false;   // it existed and was removed

            using var ins = new MySqlCommand(
                "INSERT INTO favorites (parent_id, babysitter_id) VALUES (@p, @b)", conn);
            ins.Parameters.AddWithValue("@p", parentId);
            ins.Parameters.AddWithValue("@b", babysitterId);
            ins.ExecuteNonQuery();
            return true;
        }

        public static List<NotificationInfo> GetNotifications(int userId, int limit = 12)
        {
            var list = new List<NotificationInfo>();
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                @"SELECT notification_id, message, is_read, created_at
                  FROM notifications WHERE user_id = @u
                  ORDER BY created_at DESC LIMIT " + limit, conn);
            cmd.Parameters.AddWithValue("@u", userId);
            using var r = cmd.ExecuteReader();
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
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "UPDATE notifications SET is_read = TRUE WHERE user_id = @u", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.ExecuteNonQuery();
        }

        public static void AddNotification(int userId, string message)
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "INSERT INTO notifications (user_id, message) VALUES (@u, @m)", conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.Parameters.AddWithValue("@m", message);
            cmd.ExecuteNonQuery();
        }

        public static decimal GetServiceFee()
        {
            using var conn = Db.Open();
            using var cmd = new MySqlCommand(
                "SELECT setting_value FROM settings WHERE setting_key = 'service_fee'", conn);
            object? v = cmd.ExecuteScalar();
            return v != null && decimal.TryParse(v.ToString(), out var fee) ? fee : 2.50m;
        }
    }
}
