using System;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
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
        }

        /// <summary>
        /// Loads sample/fake rows into the user management grid for design preview.
        /// This lives in the code-behind (not the Designer file) on purpose: the VS
        /// Designer regenerates AdminDashboardForm.Designer.cs on every property edit
        /// and would silently delete any hand-typed Rows.Add() calls placed there.
        /// Replace this with a real database query when you wire up data access.
        /// </summary>
        private void LoadSampleUsers()
        {
            dgvUsers.Rows.Clear();
            dgvUsers.Rows.Add("Sarah Mitchell", "Parent", "sarah@email.com", "active", "May 12, 2024", "...");
            dgvUsers.Rows.Add("Emma Thompson", "Babysitter", "emma@email.com", "active", "Apr 3, 2024", "...");
            dgvUsers.Rows.Add("Jake Reynolds", "Parent", "jake@email.com", "pending", "Jun 1, 2024", "...");
            dgvUsers.Rows.Add("Lily Chen", "Babysitter", "lily@email.com", "suspended", "Mar 20, 2024", "...");
            dgvUsers.Rows.Add("Tom Wallace", "Parent", "tom@email.com", "active", "Jun 8, 2024", "...");
        }

        /// <summary>
        /// Recalculates bar heights/positions inside a chart panel based on real values.
        /// Call this after fetching data from the database (e.g. monthly booking counts,
        /// revenue totals) instead of relying on the static design-time bar sizes.
        /// Bars and labels must be passed in left-to-right order; chartAreaHeight is the
        /// usable vertical space in pixels (bottom-aligned at y = chartAreaHeight + topOffset).
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

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnSidebarOverview_Click(object sender, EventArgs e)
        {

        }

        private void btnSidebarUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnSidebarBookings_Click(object sender, EventArgs e)
        {

        }

        private void btnSidebarReports_Click(object sender, EventArgs e)
        {

        }

        private void btnSidebarSettings_Click(object sender, EventArgs e)
        {

        }

        private void tbSearchUsers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}