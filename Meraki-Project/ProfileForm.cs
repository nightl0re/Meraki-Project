using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Meraki_Project
{
    public partial class ProfileForm : Form
    {
        private sealed class ReviewItem
        {
            public string Author = "";
            public int Rating;
            public string Text = "";
            public string Date = "";
        }

        // TODO (Phase 2): `SELECT skill FROM babysitter_skills JOIN skills ...` and
        // `SELECT ... FROM reviews WHERE booking_id IN (SELECT booking_id FROM bookings WHERE babysitter_user_id = ...)`
        private static readonly string[] AllSkills =
        {
            "Infant Care", "Toddler Care", "Homework Help", "CPR Certified", "First Aid",
            "Cooking", "Arts & Crafts", "Music", "Swimming", "Special Needs",
        };

        private readonly System.Collections.Generic.HashSet<string> _selectedSkills = new()
        {
            "Infant Care", "Toddler Care", "Arts & Crafts", "CPR Certified",
        };

        private readonly ReviewItem[] _mockReviews =
        {
            new ReviewItem { Author = "Sarah M.", Rating = 5, Text = "Emma was incredible with our two kids. Highly recommend!", Date = "Jun 1, 2024" },
            new ReviewItem { Author = "Tom W.", Rating = 5, Text = "So patient and creative. The kids adore her!", Date = "May 18, 2024" },
            new ReviewItem { Author = "Claire K.", Rating = 4, Text = "Very professional and punctual. Will book again.", Date = "Apr 29, 2024" },
        };

        private bool _editing;

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            SetupNavbarForRole();

            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "User" : Session.CurrentUserName;
            string[] parts = name.Split(' ', 2);

            tbFirstName.Text = parts[0];
            tbLastName.Text = parts.Length > 1 ? parts[1] : "";
            tbEmail.Text = Session.CurrentUserEmail;
            tbPhone.Text = "+1 (555) 234-5678";
            tbLocation.Text = "Downtown, New York";

            lblProfileName.Text = name;
            lblAvatarInitial.Text = name.Length > 0 ? name.Substring(0, 1).ToUpper() : "U";

            bool isBabysitter = Session.CurrentRole == UserRole.Babysitter;
            lblRoleBadge.Text = isBabysitter
                ? "<div style=\"background:#DEF5F4;color:#3CA09C;border-radius:10px;padding:2px 10px;font-weight:bold;\">Babysitter</div>"
                : "<div style=\"background:#FDEEE8;color:#E8714A;border-radius:10px;padding:2px 10px;font-weight:bold;\">Parent</div>";

            if (isBabysitter)
            {
                tbBio.Text = "Hi! I'm a certified babysitter with 3 years of experience. I love working with " +
                              "children of all ages and creating fun, educational activities.";
                lblRatingLocation.Text = "★ 4.9 (47 reviews)    \U0001F4CD Downtown, New York";
                lblStatBookingsValue.Text = "47";
                lblStatExperienceValue.Text = "3yr";
                lblStatExperienceLabel.Text = "Experience";
                lblStatRateValue.Text = "$18/hr";
                lblStatRateLabel.Text = "Rate";
                pnlSkillsCard.Visible = true;
                RenderSkills();
            }
            else
            {
                tbBio.Text = "Parent of two looking for reliable, caring babysitters for date nights and after-school care.";
                lblRatingLocation.Text = "\U0001F4CD Downtown, New York";
                lblStatBookingsValue.Text = "12";
                lblStatExperienceValue.Text = "2";
                lblStatExperienceLabel.Text = "Children";
                lblStatRateValue.Text = "2024";
                lblStatRateLabel.Text = "Member Since";
                pnlSkillsCard.Visible = false;
                pnlPersonalInfoCard.Size = new Size(pnlPersonalInfoCard.Width, pnlPersonalInfoCard.Height + 166);
            }

            ApplyEditingStyle(false);
            RenderReviews();
            RenderSettingsTab();
        }

        // ----- Navbar built per-role -----

        private void SetupNavbarForRole()
        {
            int x = 275;

            if (Session.CurrentRole == UserRole.Babysitter)
            {
                btnNavBabysitterHome.Location = new Point(x, 18);
                btnNavBabysitterHome.Width = 160;
                pnlNavbar.Controls.Add(btnNavBabysitterHome);
                x += 160 + 8;
            }
            else
            {
                btnNavParentHome.Location = new Point(x, 18);
                btnNavParentHome.Width = 138;
                pnlNavbar.Controls.Add(btnNavParentHome);
                x += 138 + 8;

                btnNavFindBabysitter.Location = new Point(x, 18);
                btnNavFindBabysitter.Width = 162;
                pnlNavbar.Controls.Add(btnNavFindBabysitter);
                x += 162 + 8;

                btnNavBookNow.Location = new Point(x, 18);
                btnNavBookNow.Width = 125;
                pnlNavbar.Controls.Add(btnNavBookNow);
                x += 125 + 8;
            }

            btnNavMyProfile.Location = new Point(x, 18);
            btnNavMyProfile.Width = 125;
            pnlNavbar.Controls.Add(btnNavMyProfile);

            pnlNavbar.Controls.Add(btnLogout);
        }

        // ----- Edit toggle -----

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            _editing = !_editing;
            ApplyEditingStyle(_editing);
        }

        private void ApplyEditingStyle(bool editing)
        {
            btnEditProfile.Text = editing ? "Save" : "Edit Profile";
            btnEditProfile.FillColor = editing ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242);
            btnEditProfile.ForeColor = editing ? Color.White : Color.FromArgb(60, 50, 45);

            foreach (var box in new[] { tbFirstName, tbLastName, tbEmail, tbPhone, tbLocation, tbBio })
            {
                box.ReadOnly = !editing;
                box.FillColor = editing ? Color.FromArgb(247, 245, 242) : Color.White;
            }

            if (!editing)
            {
                lblProfileName.Text = $"{tbFirstName.Text} {tbLastName.Text}".Trim();
                // TODO (Phase 2): UPDATE users SET first_name = ..., last_name = ..., phone = ...,
                // and UPDATE babysitter_profiles SET bio = ..., location = ... WHERE user_id = ...
                // instead of just leaving the new values sitting in the textboxes.
            }
        }

        // ----- Photo upload -----

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "Choose a profile photo",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picAvatarPhoto.Image = Image.FromFile(dialog.FileName);
                picAvatarPhoto.Visible = true;
                // TODO (Phase 2): upload dialog.FileName somewhere durable and save its
                // path/URL to `babysitter_profiles.photo_path` (or a `users` photo column).
            }
        }

        // ----- Skills -----

        private void RenderSkills()
        {
            flpSkills.Controls.Clear();
            foreach (var skill in AllSkills)
                flpSkills.Controls.Add(BuildSkillChip(skill));
        }

        private Control BuildSkillChip(string skill)
        {
            bool active = _selectedSkills.Contains(skill);
            var chip = new Guna2Button
            {
                Text = skill,
                AutoSize = true,
                Padding = new Padding(12, 6, 12, 6),
                Margin = new Padding(0, 0, 8, 8),
                BorderRadius = 14,
                BorderThickness = 0,
                FillColor = active ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242),
                ForeColor = active ? Color.White : Color.FromArgb(154, 136, 128),
                Font = new Font("Segoe UI", 8.5F),
            };
            chip.ShadowDecoration.Enabled = false;
            chip.Click += (s, e) =>
            {
                if (!_editing) return;
                if (!_selectedSkills.Remove(skill)) _selectedSkills.Add(skill);
                RenderSkills();
            };
            return chip;
        }

        // ----- Reviews tab -----

        private void RenderReviews()
        {
            flpReviews.Controls.Clear();

            if (Session.CurrentRole != UserRole.Babysitter)
            {
                flpReviews.Controls.Add(new Label
                {
                    Text = "Reviews you leave for babysitters will show up here.",
                    Width = 860,
                    Height = 30,
                    ForeColor = Color.FromArgb(154, 136, 128),
                    Font = new Font("Segoe UI", 9F),
                });
                return;
            }

            foreach (var r in _mockReviews)
                flpReviews.Controls.Add(BuildReviewCard(r));
        }

        private Control BuildReviewCard(ReviewItem r)
        {
            var card = new Guna2Panel
            {
                Width = 860,
                Height = 100,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 16,
                FillColor = Color.White,
                BackColor = Color.FromArgb(253, 238, 232),
            };
            card.Controls.Add(new Label
            {
                Text = r.Author,
                Location = new Point(16, 12),
                Size = new Size(300, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
            });
            card.Controls.Add(new Label
            {
                Text = new string('★', r.Rating) + new string('☆', 5 - r.Rating),
                Location = new Point(700, 12),
                Size = new Size(140, 22),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(255, 209, 102),
                TextAlign = ContentAlignment.MiddleRight,
            });
            card.Controls.Add(new Label
            {
                Text = $"“{r.Text}”",
                Location = new Point(16, 38),
                Size = new Size(820, 36),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
            });
            card.Controls.Add(new Label
            {
                Text = r.Date,
                Location = new Point(16, 74),
                Size = new Size(200, 18),
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
            });
            return card;
        }

        // ----- Settings tab -----

        private void RenderSettingsTab()
        {
            pnlTabSettings.Controls.Clear();

            var items = new (string Title, string Description)[]
            {
                ("Notifications", "Manage your notification preferences"),
                ("Privacy & Security", "Update password and 2FA"),
                ("Verification", "Background check and ID verification"),
                ("Availability", "Set your available hours"),
            };

            int y = 0;
            foreach (var item in items)
            {
                pnlTabSettings.Controls.Add(BuildSettingsRow(item.Title, item.Description, y));
                y += 76;
            }
        }

        private Control BuildSettingsRow(string title, string description, int y)
        {
            var card = new Guna2Panel
            {
                Location = new Point(0, y),
                Size = new Size(900, 66),
                BorderRadius = 14,
                FillColor = Color.White,
                BackColor = Color.FromArgb(253, 238, 232),
                Cursor = Cursors.Hand,
            };
            var titleLabel = new Label
            {
                Text = title,
                Location = new Point(16, 12),
                Size = new Size(400, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
            };
            var descLabel = new Label
            {
                Text = description,
                Location = new Point(16, 36),
                Size = new Size(600, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
            };

            EventHandler openPlaceholder = (s, e) => MessageBox.Show(
                $"{title} isn't wired up yet - this will let you manage it once the database is in place.",
                title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            card.Click += openPlaceholder;
            titleLabel.Click += openPlaceholder;
            descLabel.Click += openPlaceholder;

            card.Controls.Add(titleLabel);
            card.Controls.Add(descLabel);
            return card;
        }

        // ----- Tabs -----

        private void btnTabProfile_Click(object sender, EventArgs e) => SwitchTab(0);
        private void btnTabReviews_Click(object sender, EventArgs e) => SwitchTab(1);
        private void btnTabSettings_Click(object sender, EventArgs e) => SwitchTab(2);

        private void SwitchTab(int index)
        {
            pnlTabProfile.Visible = index == 0;
            pnlTabReviews.Visible = index == 1;
            pnlTabSettings.Visible = index == 2;

            StyleTab(btnTabProfile, index == 0);
            StyleTab(btnTabReviews, index == 1);
            StyleTab(btnTabSettings, index == 2);
        }

        private static void StyleTab(Guna2Button btn, bool active)
        {
            btn.FillColor = active ? Color.FromArgb(232, 113, 74) : Color.Transparent;
            btn.ForeColor = active ? Color.White : Color.FromArgb(154, 136, 128);
            btn.Font = new Font("Segoe UI", 9.5F, active ? FontStyle.Bold : FontStyle.Regular);
        }

        // ----- Navigation -----

        private void btnNavParentHome_Click(object sender, EventArgs e) => GoTo(new ParentDashboardForm());

        private void btnNavBabysitterHome_Click(object sender, EventArgs e) => GoTo(new BabysitterDashboardForm());

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => GoTo(new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e) => GoTo(new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => ProfileForm_Load(sender, e);

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
