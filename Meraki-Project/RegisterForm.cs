using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class RegisterForm : Form
    {
        private static readonly Color ColorCoral = Color.FromArgb(232, 113, 74);
        private static readonly Color ColorWarmBrown = Color.FromArgb(154, 136, 128);

        private static readonly Color[] StrengthColors =
        {
            Color.FromArgb(224, 90, 90),   // Weak
            Color.FromArgb(244, 168, 124), // Fair
            Color.FromArgb(255, 209, 102), // Good
            Color.FromArgb(94, 200, 196),  // Strong
        };
        private static readonly string[] StrengthLabels = { "Weak", "Fair", "Good", "Strong" };
        private const int StrengthBarFullWidth = 325;

        private UserRole _selectedRole = UserRole.Parent;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            SetActiveRole(UserRole.Parent);
            UpdatePasswordStrength();
        }

        // ----- Role tabs -----

        private void rbParent_Click(object sender, EventArgs e) => SetActiveRole(UserRole.Parent);

        private void rbBabysitter_Click(object sender, EventArgs e) => SetActiveRole(UserRole.Babysitter);

        private void SetActiveRole(UserRole role)
        {
            _selectedRole = role;
            StyleRoleTab(rbParent, role == UserRole.Parent);
            StyleRoleTab(rbBabysitter, role == UserRole.Babysitter);
        }

        private static void StyleRoleTab(Guna2Button tab, bool active)
        {
            tab.FillColor = active ? Color.White : Color.Transparent;
            tab.ForeColor = active ? ColorCoral : ColorWarmBrown;
            tab.Font = new Font("Segoe UI", 9F, active ? FontStyle.Bold : FontStyle.Regular);
        }

        // ----- Password strength meter -----
        // Requires wiring tbPassword.TextChanged += tbPassword_TextChanged in the Designer
        // (see notes) so the bar/label update as the user types.

        private void tbPassword_TextChanged(object sender, EventArgs e) => UpdatePasswordStrength();

        private void UpdatePasswordStrength()
        {
            int strength = ComputePasswordStrength(tbPassword.Text);

            if (strength == 0)
            {
                pnlStrengthBar.Width = 0;
                lblStrengthLabel.Text = "";
                return;
            }

            pnlStrengthBar.FillColor = StrengthColors[strength - 1];
            pnlStrengthBar.Width = StrengthBarFullWidth * strength / 4;
            lblStrengthLabel.Text = StrengthLabels[strength - 1];
            lblStrengthLabel.ForeColor = StrengthColors[strength - 1];
        }

        private static int ComputePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password)) return 0;
            int score = 0;
            if (password.Length >= 8) score++;
            if (Regex.IsMatch(password, "[A-Z]")) score++;
            if (Regex.IsMatch(password, "[0-9]")) score++;
            if (Regex.IsMatch(password, @"[^A-Za-z0-9]")) score++;
            return score;
        }

        // ----- Submit -----

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text.Trim();
            string lastName = tbLastName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter your first and last name.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter a phone number.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!cbAgreeTerms.Checked)
            {
                MessageBox.Show("Please agree to the Terms of Service and Privacy Policy.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO (Phase 2): INSERT a new row into `users` (and `babysitter_profiles`
            // when role == Babysitter) with a PBKDF2 hash of `password` instead of
            // just holding these values in memory for the session.
            Session.CurrentUserEmail = email;
            Session.CurrentUserName = $"{firstName} {lastName}";
            Session.CurrentRole = _selectedRole;

            Form next = _selectedRole == UserRole.Babysitter
                ? new BabysitterDashboardForm()
                : new ParentDashboardForm();

            next.Show();
            this.Close();
        }

        private void lnkSignIn_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
