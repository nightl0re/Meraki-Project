using System;
using System.Text;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class ParentDashboardForm : Form
    {
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
            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "Parent" : Session.CurrentUserName;

            lblGreeting.Text = TimeOfDayGreeting();
            lblUserName.Text = $"<div style=\"color:white;font-weight:bold;font-size:14pt;\">{name} \U0001F44B</div>";
            lblUserAvatarInitial.Text = name.Length > 0 ? name.Substring(0, 1).ToUpper() : "P";

            // The booking cards on this form are still the fixed design-preview
            // sample data (pnlBookingCard1/2) - TODO (Phase 2): populate them from
            // `SELECT ... FROM bookings WHERE parent_user_id = ... AND status IN (...)`.
        }

        private static string TimeOfDayGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning,";
            if (hour < 18) return "Good afternoon,";
            return "Good evening,";
        }

        // ----- Quick actions -----

        private void btnBookBabysitter_Click(object sender, EventArgs e) => GoTo(new BookingForm());

        private void btnFindBabysitters_Click(object sender, EventArgs e) => GoTo(new SearchBabysitterForm());

        private void btnMyCalendar_Click(object sender, EventArgs e) => GoTo(new BookingForm());

        private void btnFavorites_Click(object sender, EventArgs e) => GoTo(new SearchBabysitterForm());

        private void btnViewAllBookings_Click(object sender, EventArgs e) => GoTo(new BookingForm());

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
            // Already home - just refresh the data on this same form.
            ParentDashboardForm_Load(sender, e);
        }

        private void btnNavBabysitterHome_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar - kept only because the control exists
            // in the Designer; no-op.
        }

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => GoTo(new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e) => GoTo(new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => GoTo(new ProfileForm());

        private void btnNavAdmin_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar - kept only because the control exists
            // in the Designer; no-op.
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void GoTo(Form next)
        {
            next.Show();
            this.Close();
        }
    }
}
