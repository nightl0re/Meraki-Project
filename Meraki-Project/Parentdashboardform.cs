using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class ParentDashboardForm : Form
    {
        private static readonly Color ColorHeading = Color.FromArgb(60, 50, 45);

        // Mock notification feed shown by the bell button.
        // TODO (Phase 2): replace with `SELECT ... FROM notifications WHERE user_id = ...`.
        private readonly string[] _mockNotifications =
        {
            "Emma Thompson confirmed your booking for Sat, Jun 15.",
            "Mia Rodriguez sent you a message about Wed's booking.",
            "Reminder: booking with Sarah Park starts in 2 days.",
        };

        public ParentDashboardForm()
        {
            InitializeComponent();
        }

        private void ParentDashboardForm_Load(object sender, EventArgs e)
        {
            ApplyDesignPolish();

            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "Parent" : Session.CurrentUserName;

            lblGreeting.Text = TimeOfDayGreeting();
            lblUserName.Text = $"<div style=\"color:white;font-weight:bold;font-size:14pt;\">{name} \U0001F44B</div>";
            lblUserAvatarInitial.Text = name.Length > 0 ? name.Substring(0, 1).ToUpper() : "P";

            // The booking cards on this form are still the fixed design-preview
            // sample data (pnlBookingCard1/2) - TODO (Phase 2): populate them from
            // `SELECT ... FROM bookings WHERE parent_user_id = ... AND status IN (...)`.
        }

        /// <summary>
        /// Runtime readability polish for the existing designer layout: section
        /// headings and card titles get the darker warm-brown used on newer pages,
        /// and controls sitting on the gradient banner get transparent backs so
        /// their rounded corners don't show square color blocks.
        /// </summary>
        private void ApplyDesignPolish()
        {
            lblQuickActionsTitle.ForeColor = ColorHeading;
            lblUpcomingTitle.ForeColor = ColorHeading;
            lblBookingSitterName1.ForeColor = ColorHeading;
            lblBookingSitterName2.ForeColor = ColorHeading;

            btnNotifications.BackColor = Color.Transparent;
            picUserAvatar.BackColor = Color.Transparent;
            pnlAvatar1.BackColor = Color.Transparent;
            pnlAvatar2.BackColor = Color.Transparent;
        }

        private static string TimeOfDayGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning,";
            if (hour < 18) return "Good afternoon,";
            return "Good evening,";
        }

        // ----- Quick actions -----

        private void btnBookBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnFindBabysitters_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnMyCalendar_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnFavorites_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnViewAllBookings_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var n in _mockNotifications)
                sb.AppendLine("• " + n);

            MessageBox.Show(sb.ToString(), "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ----- Navbar -----

        private void btnNavParentHome_Click(object sender, EventArgs e)
        {
            // Already home - just refresh the greeting/labels on this same form.
            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "Parent" : Session.CurrentUserName;
            lblGreeting.Text = TimeOfDayGreeting();
            lblUserName.Text = $"<div style=\"color:white;font-weight:bold;font-size:14pt;\">{name} \U0001F44B</div>";
        }

        private void btnNavBabysitterHome_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar - kept only because the control exists
            // in the Designer; no-op.
        }

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnNavAdmin_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar - kept only because the control exists
            // in the Designer; no-op.
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
