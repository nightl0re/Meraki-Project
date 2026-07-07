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

        private void tbPassword_TextChanged(object sender, EventArgs e) => UpdatePasswordStrength();

        private void UpdatePasswordStrength()
        {
            int strength = ComputePasswordStrength(tbPassword.Text);

            if (strength == 0)
            {
                pnlStrengthBar.Visible = false;
                lblStrengthLabel.Text = "";
                return;
            }

            pnlStrengthBar.Visible = true;
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

            if (firstName.Length < 2 || lastName.Length < 2)
            {
                MessageBox.Show("Please enter your real first and last name (at least 2 letters each).",
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address (e.g. name@example.com).",
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phone.Length < 7)
            {
                MessageBox.Show("Please enter a valid phone number.", "Meraki",
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

            try
            {
                if (UserRepository.EmailExists(email))
                {
                    MessageBox.Show("An account with this email already exists. Try signing in instead.",
                        "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UserRepository.Register(firstName, lastName, email, phone, password, _selectedRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while creating the account:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // New accounts are 'pending' - the admin must approve before first sign-in.
            MessageBox.Show(
                "Your account was created!\n\nAn administrator needs to approve it before " +
                "you can sign in. Please check back soon.",
                "Account created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Navigation.GoTo(this, new LoginForm());
        }

        private void lnkSignIn_Click(object sender, EventArgs e)
        {
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
