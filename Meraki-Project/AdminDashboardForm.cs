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

        // name, role, email, status, joined - same shape as the grid columns.
        // TODO (Phase 2): replace with `SELECT ... FROM users` instead of a fixed list.
        private readonly List<string[]> _allUsers = new();

        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            ApplyDesignPolish();
            LoadSampleUsers();

            // Example only - replace these arrays with real values from your database.
            // Using the same method for both charts guarantees their baselines match exactly,
            // since both are computed the same way instead of being independently hand-tuned.

            UpdateBarChart(
                new[] { barJan, barFeb, barMar, barApr, barMay, barJun },
                new[] { lblBarJan, lblBarFeb, lblBarMar, lblBarApr, lblBarMay, lblBarJun },
                new[] { 65, 78, 90, 110, 125, 145 }); // e.g. monthly booking counts

            UpdateBarChart(
                new[] { revJan, revFeb, revMar, revApr, revMay, revJun },
                new[] { lblRevJan, lblRevFeb, lblRevMar, lblRevApr, lblRevMay, lblRevJun },
                new[] { 3200, 4100, 3800, 5200, 4900, 6100 }); // e.g. monthly revenue totals

            SetActiveSidebarButton(btnSidebarOverview);
        }

        /// <summary>
        /// Small readability improvements applied at runtime so the existing
        /// Designer file doesn't need to be regenerated: section headings get the
        /// dark warm-brown used across the newer pages instead of the pale gray.
        /// </summary>
        private void ApplyDesignPolish()
        {
            lblPageTitle.ForeColor = ColorHeading;
            lblBookingsChartTitle.ForeColor = ColorHeading;
            lblRevenueChartTitle.ForeColor = ColorHeading;
            lblUserTableTitle.ForeColor = ColorHeading;
        }

        /// <summary>
        /// Loads sample/fake rows into the user management grid for design preview.
        /// Replace this with a real database query when you wire up data access.
        /// </summary>
        private void LoadSampleUsers()
        {
            _allUsers.Clear();
            _allUsers.Add(new[] { "Sarah Mitchell", "Parent", "sarah@email.com", "active", "May 12, 2024" });
            _allUsers.Add(new[] { "Emma Thompson", "Babysitter", "emma@email.com", "active", "Apr 3, 2024" });
            _allUsers.Add(new[] { "Jake Reynolds", "Parent", "jake@email.com", "pending", "Jun 1, 2024" });
            _allUsers.Add(new[] { "Lily Chen", "Babysitter", "lily@email.com", "suspended", "Mar 20, 2024" });
            _allUsers.Add(new[] { "Tom Wallace", "Parent", "tom@email.com", "active", "Jun 8, 2024" });

            ApplyUserFilter(string.Empty);
        }

        private void ApplyUserFilter(string search)
        {
            dgvUsers.Rows.Clear();
            search = (search ?? string.Empty).Trim();

            IEnumerable<string[]> rows = _allUsers;
            if (search.Length > 0)
            {
                rows = _allUsers.Where(u =>
                    u[0].Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    u[2].Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var u in rows)
                dgvUsers.Rows.Add(u[0], u[1], u[2], u[3], u[4], "...");
        }

        private void tbSearchUsers_TextChanged(object sender, EventArgs e)
        {
            ApplyUserFilter(tbSearchUsers.Text);
        }

        /// <summary>
        /// Recalculates bar heights/positions inside a chart panel based on real values.
        /// Call this after fetching data from the database instead of relying on the
        /// static design-time bar sizes. Bars and labels must be passed left-to-right.
        /// </summary>
        private void UpdateBarChart(Guna.UI2.WinForms.Guna2Panel[] bars, Label[] labels, int[] values,
            int chartAreaTop = 38, int chartAreaHeight = 141)
        {
            if (bars.Length != values.Length || labels.Length != values.Length)
                throw new ArgumentException("bars, labels, and values must be the same length.");

            int max = values.Length > 0 ? Math.Max(1, GetMax(values)) : 1;

            for (int i = 0; i < bars.Length; i++)
            {
                int barHeight = (int)((double)values[i] / max * chartAreaHeight);
                if (barHeight < 4) barHeight = 4; // keep a visible sliver even for 0/very small values

                int x = bars[i].Location.X;
                bars[i].Height = barHeight;
                bars[i].Location = new System.Drawing.Point(x, chartAreaTop + (chartAreaHeight - barHeight));
            }
        }

        private static int GetMax(int[] values)
        {
            int max = int.MinValue;
            foreach (var v in values)
                if (v > max) max = v;
            return max;
        }

        // ----- Sidebar navigation -----
        // Only "Overview" has real content right now. The other sections are
        // placeholders until their own views get built.

        private void btnSidebarOverview_Click(object sender, EventArgs e) => SetActiveSidebarButton(btnSidebarOverview);

        private void btnSidebarUsers_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarUsers);
            tbSearchUsers.Focus();
        }

        private void btnSidebarBookings_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarBookings);
            MessageBox.Show("A dedicated Bookings view isn't built yet - booking data will show up here once the database is wired up.",
                "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSidebarReports_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarReports);
            MessageBox.Show("Reports view isn't built yet.", "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSidebarSettings_Click(object sender, EventArgs e)
        {
            SetActiveSidebarButton(btnSidebarSettings);
            MessageBox.Show("Admin settings aren't built yet.", "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
