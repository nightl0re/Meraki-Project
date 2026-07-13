using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Login page. Checks the e-mail/password against the users table, blocks
    // accounts that are not yet approved, and sends each person to the dashboard
    // that matches their role (parent, babysitter or admin).
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

            // Fail early with a clear message if MySQL isn't reachable, instead of
            // a confusing crash on the first click.
            try
            {
                Db.TestConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to the MySQL database.\n\n" +
                    "1. Is MySQL running?\n" +
                    "2. Did you run meraki_database.sql?\n" +
                    "3. Is the password in Db.cs correct?\n\n" +
                    "Details: " + ex.Message,
                    "Database connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Role tabs (visual pre-selection only; the account's real role
        //       in the database decides which dashboard opens) -----

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

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User? user;
            UserRepository.LoginResult result;
            try
            {
                result = UserRepository.Authenticate(email, password, out user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while signing in:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result == UserRepository.LoginResult.NoSuchEmail)
            {
                MessageBox.Show("No account found with this email address.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (result == UserRepository.LoginResult.WrongPassword)
            {
                MessageBox.Show("Incorrect password. Please try again.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The selected role tab must match the account's real role - a
            // babysitter can't sign in through the Parent tab and vice versa.
            string requiredRole = _selectedRole switch
            {
                UserRole.Admin => "admin",
                UserRole.Babysitter => "babysitter",
                _ => "parent",
            };
            if (user!.Role != requiredRole)
            {
                MessageBox.Show(
                    $"No {requiredRole} account was found with these details.\n" +
                    "Please check the role tab you selected.",
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Admin approval gate: pending/suspended accounts can't get in.
            if (user!.Status == "pending")
            {
                MessageBox.Show(
                    "Your account is still awaiting admin approval.\nPlease try again later.",
                    "Account pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (user.Status == "suspended")
            {
                MessageBox.Show(
                    "This account has been suspended. Please contact the administrator.",
                    "Account suspended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (user.Status == "declined")
            {
                MessageBox.Show(
                    "Your account was declined by the administrator.\n" +
                    "Please register again with your details.",
                    "Account declined", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Session.CurrentUserId = user.UserId;
            Session.CurrentUserEmail = user.Email;
            Session.CurrentUserName = user.FullName;
            Session.CurrentRole = user.Role switch
            {
                "admin" => UserRole.Admin,
                "babysitter" => UserRole.Babysitter,
                _ => UserRole.Parent,
            };

            Form next = Session.CurrentRole switch
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
                "Please contact the administrator to reset your password.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkCreateAccount_Click(object sender, EventArgs e)
        {
            Navigation.GoTo(this, new RegisterForm());
        }
    }
}
