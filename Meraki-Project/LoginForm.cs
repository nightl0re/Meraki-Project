using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class LoginForm : Form
    {
        // Meraki color palette
        public static readonly Color ColorCoral = Color.FromArgb(232, 113, 74);
        public static readonly Color ColorPeach = Color.FromArgb(253, 238, 232);
        public static readonly Color ColorTeal = Color.FromArgb(94, 200, 196);
        public static readonly Color ColorWarmBrown = Color.FromArgb(154, 136, 128);
        public static readonly Color ColorCream = Color.FromArgb(242, 237, 228);

        private UserRole _selectedRole = UserRole.Parent;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetActiveRole(UserRole.Parent);
        }

        // ----- Role tabs -----

        private void rbParent_Click(object sender, EventArgs e) => SetActiveRole(UserRole.Parent);

        private void rbBabysitter_Click(object sender, EventArgs e) => SetActiveRole(UserRole.Babysitter);

        private void rbAdmin_Click(object sender, EventArgs e) => SetActiveRole(UserRole.Admin);

        private void SetActiveRole(UserRole role)
        {
            _selectedRole = role;
            StyleRoleTab(rbParent, role == UserRole.Parent);
            StyleRoleTab(rbBabysitter, role == UserRole.Babysitter);
            StyleRoleTab(rbAdmin, role == UserRole.Admin);
        }

        private static void StyleRoleTab(Guna2Button tab, bool active)
        {
            tab.FillColor = active ? Color.White : Color.Transparent;
            tab.ForeColor = active ? ColorCoral : ColorWarmBrown;
            tab.Font = new Font("Segoe UI", 9F, active ? FontStyle.Bold : FontStyle.Regular);
        }

        // ----- Sign in -----

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both your email/username and password.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO (Phase 2): replace this with a real lookup + password-hash check
            // against the `users` table instead of accepting any non-empty input.
            Session.CurrentUserEmail = email;
            Session.CurrentUserName = Session.DeriveDisplayName(email);
            Session.CurrentRole = _selectedRole;

            Form next = _selectedRole switch
            {
                UserRole.Admin => new AdminDashboardForm(),
                UserRole.Babysitter => new BabysitterDashboardForm(),
                _ => new ParentDashboardForm(),
            };

            Navigation.GoTo(this, next);
        }

        // ----- Footer links -----

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Password reset isn't wired up yet - this will email a reset link once the database is in place.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkCreateAccount_Click(object sender, EventArgs e)
        {
            Navigation.GoTo(this, new RegisterForm());
        }
    }
}
