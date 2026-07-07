using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class AdminDashboardForm : Form
    {
        private static readonly Color ColorCoral = Color.FromArgb(232, 113, 74);
        private static readonly Color ColorWarmBrown = Color.FromArgb(154, 136, 128);
        private static readonly Color ColorHeading = Color.FromArgb(60, 50, 45);
        private static readonly Color ColorActiveTabFill = Color.FromArgb(253, 238, 232);

        private enum GridMode { Users, Bookings, Requests }
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

            // Repurpose the two unused sidebar buttons: Reports -> Requests
            // (pending bookings needing action), and hide Settings entirely.
            btnSidebarReports.Text = "Requests";
            btnSidebarSettings.Visible = false;
        }

        // ----- Requests grid: every booking still 'pending' a babysitter reply -----

        private void ShowRequestsGrid()
        {
            _mode = GridMode.Requests;
            lblUserTableTitle.Text = "Pending Requests";
            tbSearchUsers.PlaceholderText = "Search by parent or babysitter...";

            dgvUsers.Columns.Clear();
            AddCol("Date", 110);
            AddCol("Time", 150);
            AddCol("Parent", 170);
            AddCol("Babysitter", 170);
            AddCol("Children", 80);
            AddCol("Total", 90);
            AddCol("Status", 110);

            try { _bookings = BookingRepository.GetAll().Where(b => b.Status == "pending").ToList(); }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading requests:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _bookings = new List<BookingInfo>();
            }
            ReloadBookings();
        }

        // ----- KPI cards + the two monthly charts (real data) -----

        private void LoadKpisAndCharts()
        {
            var (parents, sitters, monthBookings, revenue) = BookingRepository.GetAdminKpis();
            lblKpiParentsValue.Text = parents.ToString("N0");
            lblKpiBabysittersValue.Text = sitters.ToString("N0");
            lblKpiBookingsValue.Text = monthBookings.ToString("N0");
            lblKpiRevenueValue.Text = "$" + revenue.ToString("N0");

            // Chart labels are Jan..Jun in the designer, so we chart months 1-6
            // of the current year.
            var (counts, monthlyRevenue) = BookingRepository.GetMonthlyStats(DateTime.Today.Year);

            UpdateBarChart(
                new[] { barJan, barFeb, barMar, barApr, barMay, barJun },
                new[] { lblBarJan, lblBarFeb, lblBarMar, lblBarApr, lblBarMay, lblBarJun },
                counts.Take(6).ToArray());

            UpdateBarChart(
                new[] { revJan, revFeb, revMar, revApr, revMay, revJun },
                new[] { lblRevJan, lblRevFeb, lblRevMar, lblRevApr, lblRevMay, lblRevJun },
                monthlyRevenue.Take(6).Select(x => (int)x).ToArray());
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
            AddCol("Joined", 120);
            AddCol("Action", 100);

            ReloadUsers();
        }

        private void ReloadUsers()
        {
            _users = UserRepository.GetUsers(tbSearchUsers.Text.Trim());
            dgvUsers.Rows.Clear();
            foreach (var u in _users)
            {
                string action = u.Role == "admin" ? "" :
                    u.Status switch
                    {
                        "pending" => "Approve",
                        "suspended" => "Activate",
                        _ => "Suspend",
                    };
                int idx = dgvUsers.Rows.Add(u.FullName, Capitalize(u.Role), u.Email, u.Status,
                                            u.CreatedAt.ToString("MMM d, yyyy"), action);
                dgvUsers.Rows[idx].Tag = u;
            }
        }

        // ----- Bookings grid (view every booking in the system) -----

        private void ShowBookingsGrid()
        {
            _mode = GridMode.Bookings;
            lblUserTableTitle.Text = "All Bookings";
            tbSearchUsers.PlaceholderText = "Search by parent or babysitter...";

            dgvUsers.Columns.Clear();
            AddCol("Date", 110);
            AddCol("Time", 150);
            AddCol("Parent", 170);
            AddCol("Babysitter", 170);
            AddCol("Children", 80);
            AddCol("Total", 90);
            AddCol("Status", 110);

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
            foreach (var b in _bookings.Where(b =>
                         search.Length == 0
                         || b.ParentName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || b.SitterName.Contains(search, StringComparison.OrdinalIgnoreCase)))
            {
                dgvUsers.Rows.Add(b.Date.ToString("MMM d, yyyy"), b.TimeRangeText,
                                  b.ParentName, b.SitterName, b.ChildrenCount,
                                  "$" + b.Total.ToString("0.00"), b.Status);
            }
        }

        private void tbSearchUsers_TextChanged(object sender, EventArgs e)
        {
            if (_mode == GridMode.Users) ReloadUsers();
            else ReloadBookings(); // Bookings and Requests share the same filter
        }

        // Approve / Suspend / Activate when the Action cell is clicked.
        private void dgvUsers_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_mode != GridMode.Users || e.RowIndex < 0 || e.ColumnIndex != 5) return;
            if (dgvUsers.Rows[e.RowIndex].Tag is not User u || u.Role == "admin") return;

            string newStatus = u.Status == "active" ? "suspended" : "active";
            string verb = newStatus == "active"
                ? (u.Status == "pending" ? "approve" : "re-activate")
                : "suspend";

            if (MessageBox.Show($"Do you want to {verb} {u.FullName}?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                UserRepository.SetStatus(u.UserId, newStatus);
                if (newStatus == "active")
                    ExtrasRepository.AddNotification(u.UserId,
                        "Your Meraki account has been approved. Welcome!");
                ReloadUsers();
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
            int chartAreaTop = 38, int chartAreaHeight = 141)
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
            }
        }

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

        // "Reports" button is relabelled to "Requests" at load - it lists every
        // booking still awaiting a babysitter's response, across the whole system.
        private void btnSidebarReports_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarReports);
            ShowRequestsGrid();
        }

        // "Settings" button is hidden at load; this handler is kept only because the
        // designer wires it, and does nothing.
        private void btnSidebarSettings_Click(object sender, EventArgs e)
        {
        }

        private void SetActiveSidebarButton(Guna2Button active)
        {
            foreach (var btn in new[] { btnSidebarOverview, btnSidebarUsers, btnSidebarBookings, btnSidebarReports, btnSidebarSettings })
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
