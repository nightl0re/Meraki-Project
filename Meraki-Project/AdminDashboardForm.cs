using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Admin control panel. Shows KPI cards and monthly charts, and switches one
    // grid between Users, Bookings, Pending Approvals and Payouts. From here the
    // admin approves/declines accounts, accepts/declines/deletes bookings,
    // deletes users, and settles or discards payments.
    public partial class AdminDashboardForm : Form
    {
        private static readonly Color ColorCoral = Color.FromArgb(232, 113, 74);
        private static readonly Color ColorWarmBrown = Color.FromArgb(154, 136, 128);
        private static readonly Color ColorHeading = Color.FromArgb(60, 50, 45);
        private static readonly Color ColorActiveTabFill = Color.FromArgb(253, 238, 232);

        private enum GridMode { Users, Bookings, PendingApprovals, Payouts }
        private GridMode _mode = GridMode.Users;

        private List<User> _users = new();
        private List<BookingInfo> _bookings = new();

        public AdminDashboardForm()
        {
            InitializeComponent();
            dgvUsers.CellClick += dgvUsers_CellContentClick;
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            ApplyDesignPolish();
            try
            {
                LoadKpisAndCharts();
                ShowUsersGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading the dashboard:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetActiveSidebarButton(btnSidebarOverview);
        }

        private void ApplyDesignPolish()
        {
            lblPageTitle.ForeColor = ColorHeading;
            lblBookingsChartTitle.ForeColor = ColorHeading;
            lblRevenueChartTitle.ForeColor = ColorHeading;
            lblUserTableTitle.ForeColor = ColorHeading;

            // Repurpose the two spare sidebar buttons: Reports -> Pending Approvals
            // (new registrations) and Settings -> Payouts (money ready to release).
            btnSidebarReports.Text = "Pending Approvals";
            btnSidebarSettings.Text = "Payouts";
            btnSidebarSettings.Visible = true;
        }

        // ----- Pending Approvals: new accounts waiting for an admin decision -----

        private void ShowPendingApprovalsGrid()
        {
            _mode = GridMode.PendingApprovals;
            lblUserTableTitle.Text = "Pending Approvals";
            tbSearchUsers.PlaceholderText = "Search pending users...";

            dgvUsers.Columns.Clear();
            AddCol("Name", 190);
            AddCol("Role", 110);
            AddCol("Email", 240);
            AddCol("Requested", 120);
            AddCol("Approve", 95);
            AddCol("Decline", 95);

            ReloadPendingApprovals();
        }

        private void ReloadPendingApprovals()
        {
            _users = UserRepository.GetUsers(tbSearchUsers.Text.Trim())
                .Where(u => u.Status == "pending").ToList();
            dgvUsers.Rows.Clear();
            foreach (User u in _users)
            {
                int idx = dgvUsers.Rows.Add(u.FullName, Capitalize(u.Role), u.Email,
                                            u.CreatedAt.ToString("MMM d, yyyy"), "Approve", "Decline");
                dgvUsers.Rows[idx].Tag = u;
                StyleActionCell(dgvUsers.Rows[idx].Cells[4], ActionStyle.Green);
                StyleActionCell(dgvUsers.Rows[idx].Cells[5], ActionStyle.Red);
            }
            if (_users.Count == 0)
                lblUserTableTitle.Text = "Pending Approvals  ·  all caught up!";
        }

        // ----- KPI cards + the two monthly charts (real data) -----

        private void LoadKpisAndCharts()
        {
            (int parents, int sitters, int monthBookings, decimal revenue) = BookingRepository.GetAdminKpis();
            lblKpiParentsValue.Text = parents.ToString("N0");
            lblKpiBabysittersValue.Text = sitters.ToString("N0");
            lblKpiBookingsValue.Text = monthBookings.ToString("N0");
            lblKpiRevenueValue.Text = "$" + revenue.ToString("N0");

            // Chart the last 6 months ENDING this month, so the month that actually
            // has activity is always on screen and the bars visibly grow as new
            // bookings come in (a fixed Jan-Jun window was empty and looked static).
            DateTime today = DateTime.Today;
            (int Year, int Month)[] months = new (int Year, int Month)[6];
            for (int i = 0; i < 6; i++)
            {
                DateTime d = today.AddMonths(-5 + i);
                months[i] = (d.Year, d.Month);
            }
            Dictionary<int, (int[] Counts, decimal[] Revenue)> statsByYear = new Dictionary<int, (int[] Counts, decimal[] Revenue)>();
            foreach ((int Year, int Month) m in months)
                if (!statsByYear.ContainsKey(m.Year))
                    statsByYear[m.Year] = BookingRepository.GetMonthlyStats(m.Year);

            int[] counts = months.Select(m => statsByYear[m.Year].Counts[m.Month - 1]).ToArray();
            int[] revenueByMonth = months.Select(m => (int)statsByYear[m.Year].Revenue[m.Month - 1]).ToArray();
            string[] captions = months.Select(m => new DateTime(m.Year, m.Month, 1).ToString("MMM")).ToArray();

            UpdateBarChart(
                new[] { barJan, barFeb, barMar, barApr, barMay, barJun },
                new[] { lblBarJan, lblBarFeb, lblBarMar, lblBarApr, lblBarMay, lblBarJun },
                counts, captions);

            UpdateBarChart(
                new[] { revJan, revFeb, revMar, revApr, revMay, revJun },
                new[] { lblRevJan, lblRevFeb, lblRevMar, lblRevApr, lblRevMay, lblRevJun },
                revenueByMonth, captions);
        }

        // ----- Users grid (with Approve / Suspend / Activate actions) -----

        private void ShowUsersGrid()
        {
            _mode = GridMode.Users;
            lblUserTableTitle.Text = "User Management";
            tbSearchUsers.PlaceholderText = "Search users...";

            dgvUsers.Columns.Clear();
            AddCol("Name", 180);
            AddCol("Role", 110);
            AddCol("Email", 220);
            AddCol("Status", 110);
            AddCol("Joined", 110);
            AddCol("Action", 95);
            AddCol("Delete", 80);

            ReloadUsers();
        }

        private void ReloadUsers()
        {
            _users = UserRepository.GetUsers(tbSearchUsers.Text.Trim());
            dgvUsers.Rows.Clear();
            foreach (User u in _users)
            {
                string action = u.Role == "admin" ? "" :
                    u.Status switch
                    {
                        "pending" => "Approve",
                        "suspended" => "Activate",
                        _ => "Suspend",
                    };
                // Admins can't be deleted or status-changed from here (you can't
                // lock yourself out), so their action/delete cells stay blank.
                string deleteText = u.Role == "admin" ? "" : "Delete";
                int idx = dgvUsers.Rows.Add(u.FullName, Capitalize(u.Role), u.Email, u.Status,
                                            u.CreatedAt.ToString("MMM d, yyyy"), action, deleteText);
                dgvUsers.Rows[idx].Tag = u;
                StyleStatusCell(dgvUsers.Rows[idx].Cells[3], u.Status);
                if (u.Role != "admin")
                {
                    StyleActionCell(dgvUsers.Rows[idx].Cells[5],
                        u.Status == "active" ? ActionStyle.Neutral : ActionStyle.Green);
                    StyleActionCell(dgvUsers.Rows[idx].Cells[6], ActionStyle.Red);
                }
            }
        }

        // Coloured "pill" text for status cells, like the design.
        private static void StyleStatusCell(DataGridViewCell cell, string status)
        {
            (Color back, Color fore) = status switch
            {
                "confirmed" => (Color.FromArgb(232, 247, 247), Color.FromArgb(42, 112, 112)),
                "active" => (Color.FromArgb(232, 247, 240), Color.FromArgb(34, 120, 80)),
                "pending" => (Color.FromArgb(255, 248, 224), Color.FromArgb(160, 112, 0)),
                "completed" => (Color.FromArgb(236, 245, 236), Color.FromArgb(70, 120, 70)),
                "declined" => (Color.FromArgb(253, 235, 235), Color.FromArgb(180, 70, 70)),
                "cancelled" => (Color.FromArgb(253, 235, 235), Color.FromArgb(180, 70, 70)),
                "suspended" => (Color.FromArgb(245, 240, 238), Color.FromArgb(140, 130, 124)),
                _ => (Color.White, Color.FromArgb(80, 70, 65)),
            };
            cell.Style.BackColor = back;
            cell.Style.ForeColor = fore;
            cell.Style.SelectionBackColor = back;
            cell.Style.SelectionForeColor = fore;
            cell.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        }

        private enum ActionStyle { Green, Red, Neutral }

        // Action cells look like small buttons so they're obviously clickable.
        private static void StyleActionCell(DataGridViewCell cell, ActionStyle kind)
        {
            (Color back, Color fore) = kind switch
            {
                ActionStyle.Green => (Color.FromArgb(46, 125, 50), Color.White),
                ActionStyle.Red => (Color.FromArgb(198, 63, 63), Color.White),
                _ => (Color.FromArgb(253, 238, 232), ColorCoral),
            };
            cell.Style.BackColor = back;
            cell.Style.ForeColor = fore;
            cell.Style.SelectionBackColor = back;
            cell.Style.SelectionForeColor = fore;
            cell.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ----- Bookings grid (view every booking in the system) -----

        private void ShowBookingsGrid()
        {
            _mode = GridMode.Bookings;
            lblUserTableTitle.Text = "All Bookings";
            tbSearchUsers.PlaceholderText = "Search by parent or babysitter...";

            dgvUsers.Columns.Clear();
            AddCol("Date", 100);
            AddCol("Time", 135);
            AddCol("Parent", 145);
            AddCol("Babysitter", 145);
            AddCol("Children", 70);
            AddCol("Total", 80);
            AddCol("Status", 95);
            AddCol("View", 65);
            AddCol("Accept", 75);
            AddCol("Decline", 75);
            AddCol("Delete", 70);

            try { _bookings = BookingRepository.GetAll(); }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading bookings:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _bookings = new List<BookingInfo>();
            }
            ReloadBookings();
        }

        private void ReloadBookings()
        {
            string search = tbSearchUsers.Text.Trim();
            dgvUsers.Rows.Clear();
            foreach (BookingInfo b in _bookings.Where(b =>
                         search.Length == 0
                         || b.ParentName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || b.SitterName.Contains(search, StringComparison.OrdinalIgnoreCase)))
            {
                bool pending = b.Status == "pending";
                int idx = dgvUsers.Rows.Add(b.Date.ToString("MMM d, yyyy"), b.TimeRangeText,
                                            b.ParentName, b.SitterName, b.ChildrenCount,
                                            "$" + b.Total.ToString("0.00"), b.Status, "View",
                                            pending ? "Accept" : "", pending ? "Decline" : "", "Delete");
                dgvUsers.Rows[idx].Tag = b;
                StyleStatusCell(dgvUsers.Rows[idx].Cells[6], b.Status);
                StyleActionCell(dgvUsers.Rows[idx].Cells[7], ActionStyle.Neutral);
                if (pending)
                {
                    StyleActionCell(dgvUsers.Rows[idx].Cells[8], ActionStyle.Green);
                    StyleActionCell(dgvUsers.Rows[idx].Cells[9], ActionStyle.Red);
                }
                StyleActionCell(dgvUsers.Rows[idx].Cells[10], ActionStyle.Red);
            }
        }

        private void tbSearchUsers_TextChanged(object sender, EventArgs e)
        {
            if (_mode == GridMode.Users) ReloadUsers();
            else if (_mode == GridMode.PendingApprovals) ReloadPendingApprovals();
            else if (_mode == GridMode.Payouts) ReloadPayouts();
            else ReloadBookings();
        }

        // Row actions: approve/decline/suspend users, view/accept/decline bookings.
        private void dgvUsers_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_mode == GridMode.Bookings)
            {
                if (dgvUsers.Rows[e.RowIndex].Tag is not BookingInfo booking) return;
                if (e.ColumnIndex == 7)
                {
                    using ReceiptDialog dlg = new ReceiptDialog(booking, showParentSide: true);
                    dlg.ShowDialog(this);
                }
                else if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && booking.Status == "pending")
                {
                    DecideBooking(booking, accept: e.ColumnIndex == 8);
                }
                else if (e.ColumnIndex == 10)
                {
                    DeleteBooking(booking);
                }
                return;
            }

            if (_mode == GridMode.Payouts)
            {
                if (dgvUsers.Rows[e.RowIndex].Tag is not BookingInfo payout) return;
                if (e.ColumnIndex == 4) SettlePayout(payout, pay: true);   // Pay Babysitter
                else if (e.ColumnIndex == 5) SettlePayout(payout, pay: false); // Discard
                return;
            }

            if (dgvUsers.Rows[e.RowIndex].Tag is not User u || u.Role == "admin") return;

            // Delete column is the last one in both the Users and Pending grids.
            if ((_mode == GridMode.Users && e.ColumnIndex == 6))
            {
                DeleteUser(u);
                return;
            }

            string? newStatus = null;
            if (_mode == GridMode.PendingApprovals)
            {
                if (e.ColumnIndex == 4) newStatus = "active";
                else if (e.ColumnIndex == 5) newStatus = "declined";
            }
            else if (_mode == GridMode.Users && e.ColumnIndex == 5)
            {
                newStatus = u.Status == "active" ? "suspended" : "active";
            }
            if (newStatus == null) return;

            string verb = newStatus switch
            {
                "declined" => "decline",
                "suspended" => "suspend",
                _ => u.Status == "pending" ? "approve" : "re-activate",
            };
            if (MessageBox.Show($"Do you want to {verb} {u.FullName}?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                UserRepository.SetStatus(u.UserId, newStatus);
                if (newStatus == "active")
                    ExtrasRepository.AddNotification(u.UserId,
                        "Your Meraki account has been approved. Welcome!");
                if (_mode == GridMode.PendingApprovals) ShowPendingApprovalsGrid();
                else ReloadUsers();
                LoadKpisAndCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Admin can settle a pending booking directly (both sides get notified).
        private void DecideBooking(BookingInfo booking, bool accept)
        {
            string verb = accept ? "accept" : "decline";
            if (MessageBox.Show(
                    $"Do you want to {verb} the booking between {booking.ParentName} and {booking.SitterName} on {booking.Date:MMM d}?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                BookingRepository.SetStatus(booking.BookingId, accept ? "confirmed" : "declined");
                // Accepting only confirms the booking - no charge yet. Declining
                // drops the payment (nothing was ever charged).
                if (!accept) PaymentRepository.Discard(booking.BookingId);
                ExtrasRepository.AddNotification(booking.ParentId, accept
                    ? $"Your booking for {booking.Date:MMM d} was confirmed by the administrator."
                    : $"Your booking for {booking.Date:MMM d} was declined by the administrator.");
                ExtrasRepository.AddNotification(booking.BabysitterId, accept
                    ? $"Your booking with {booking.ParentName} on {booking.Date:MMM d} was confirmed by the administrator."
                    : $"Your booking with {booking.ParentName} on {booking.Date:MMM d} was declined by the administrator.");
                ShowBookingsGrid();
                LoadKpisAndCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Payouts: money parents have approved, waiting for the admin -----

        private void ShowPayoutsGrid()
        {
            _mode = GridMode.Payouts;
            lblUserTableTitle.Text = "Payouts";
            tbSearchUsers.PlaceholderText = "Search by parent or babysitter...";

            dgvUsers.Columns.Clear();
            AddCol("Date", 130);
            AddCol("Parent", 200);
            AddCol("Babysitter", 200);
            AddCol("Amount", 110);
            AddCol("Pay Babysitter", 150);
            AddCol("Discard", 110);

            try { _bookings = PaymentRepository.GetApprovedPayouts(); }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading payouts:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _bookings = new List<BookingInfo>();
            }
            ReloadPayouts();
        }

        private void ReloadPayouts()
        {
            string search = tbSearchUsers.Text.Trim();
            dgvUsers.Rows.Clear();
            foreach (BookingInfo b in _bookings.Where(b =>
                         search.Length == 0
                         || b.ParentName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || b.SitterName.Contains(search, StringComparison.OrdinalIgnoreCase)))
            {
                int idx = dgvUsers.Rows.Add(b.Date.ToString("MMM d, yyyy"), b.ParentName,
                                            b.SitterName, "$" + b.Total.ToString("0.00"),
                                            "Pay Babysitter", "Discard");
                dgvUsers.Rows[idx].Tag = b;
                StyleActionCell(dgvUsers.Rows[idx].Cells[4], ActionStyle.Green);
                StyleActionCell(dgvUsers.Rows[idx].Cells[5], ActionStyle.Red);
            }
            if (_bookings.Count == 0)
                lblUserTableTitle.Text = "Payouts  ·  nothing to release";
        }

        // pay == true  -> admin charges the parent and pays the babysitter ('paid').
        // pay == false -> admin discards the payment (e.g. a dispute); no money moves.
        private void SettlePayout(BookingInfo b, bool pay)
        {
            string verb = pay ? "charge the parent and pay the babysitter" : "discard the payment";
            if (MessageBox.Show(
                    $"Do you want to {verb} for the {b.Date:MMM d} booking ({b.ParentName} → {b.SitterName}, ${b.Total:0.00})?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (pay)
                {
                    PaymentRepository.MarkPaid(b.BookingId);
                    ExtrasRepository.AddNotification(b.BabysitterId,
                        $"You've been paid ${b.Total:0.00} for the {b.Date:MMM d} booking. Your receipt is ready.");
                    ExtrasRepository.AddNotification(b.ParentId,
                        $"Your card was charged ${b.Total:0.00} for the {b.Date:MMM d} booking. Thank you!");
                }
                else
                {
                    PaymentRepository.Discard(b.BookingId);
                    ExtrasRepository.AddNotification(b.BabysitterId,
                        $"Payment for the {b.Date:MMM d} booking was discarded by the administrator.");
                }
                ShowPayoutsGrid();
                LoadKpisAndCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Delete (admin can remove any user or booking, even confirmed ones) -----

        private void DeleteUser(User u)
        {
            if (MessageBox.Show(
                    $"Permanently delete {u.FullName} and ALL of their bookings, payments and reviews?\nThis cannot be undone.",
                    "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                UserRepository.Delete(u.UserId);
                if (_mode == GridMode.PendingApprovals) ShowPendingApprovalsGrid();
                else ShowUsersGrid();
                LoadKpisAndCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBooking(BookingInfo b)
        {
            if (MessageBox.Show(
                    $"Permanently delete the {b.Date:MMM d} booking between {b.ParentName} and {b.SitterName}?\nThis cannot be undone.",
                    "Delete booking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                BookingRepository.Delete(b.BookingId);
                ShowBookingsGrid();
                LoadKpisAndCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- helpers -----

        private void AddCol(string header, int width)
        {
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = header, Width = width });
        }

        private static string Capitalize(string s) =>
            s.Length == 0 ? s : char.ToUpper(s[0]) + s.Substring(1);

        private void UpdateBarChart(Guna2Panel[] bars, Label[] labels, int[] values,
            string[]? captions = null, int chartAreaTop = 38, int chartAreaHeight = 141)
        {
            if (bars.Length != values.Length || labels.Length != values.Length)
                throw new ArgumentException("bars, labels, and values must be the same length.");

            int max = values.Length > 0 ? Math.Max(1, values.Max()) : 1;

            for (int i = 0; i < bars.Length; i++)
            {
                int barHeight = (int)((double)values[i] / max * chartAreaHeight);
                if (barHeight < 4) barHeight = 4;

                int x = bars[i].Location.X;
                bars[i].Height = barHeight;
                bars[i].Location = new Point(x, chartAreaTop + (chartAreaHeight - barHeight));

                // Relabel the axis to the real month and show the value on hover, so
                // the chart is clearly live data and not a static picture.
                if (captions != null && i < captions.Length)
                    labels[i].Text = captions[i];
                _chartToolTip.SetToolTip(bars[i], $"{labels[i].Text}: {values[i]}");
            }
        }

        private readonly ToolTip _chartToolTip = new();

        // ----- Sidebar navigation -----

        private void btnSidebarOverview_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarOverview);
            try { LoadKpisAndCharts(); ShowUsersGrid(); }
            catch (Exception ex) { MessageBox.Show("Database error:\n" + ex.Message); }
        }

        private void btnSidebarUsers_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarUsers);
            ShowUsersGrid();
            tbSearchUsers.Focus();
        }

        private void btnSidebarBookings_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarBookings);
            ShowBookingsGrid();
        }

        // "Reports" button is relabelled to "Pending Approvals" at load - it lists
        // new registrations waiting for the admin's decision.
        private void btnSidebarReports_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarReports);
            ShowPendingApprovalsGrid();
        }

        // "Settings" button is relabelled to "Payouts" at load - it lists every
        // parent-approved payment the admin still has to charge & release.
        private void btnSidebarSettings_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarSettings);
            ShowPayoutsGrid();
        }

        private void SetActiveSidebarButton(Guna2Button active)
        {
            foreach (Guna2Button btn in new[] { btnSidebarOverview, btnSidebarUsers, btnSidebarBookings, btnSidebarReports, btnSidebarSettings })
            {
                bool isActive = btn == active;
                btn.FillColor = isActive ? ColorActiveTabFill : Color.Transparent;
                btn.ForeColor = isActive ? ColorCoral : ColorWarmBrown;
                btn.Font = new Font("Segoe UI", 9F, isActive ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
