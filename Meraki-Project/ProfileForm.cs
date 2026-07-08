using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class ProfileForm : Form
    {
        private List<string> _allSkills = new();
        private readonly HashSet<string> _selectedSkills = new();

        private bool _editing;
        private bool _loaded;

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            Ui.HideScrollbars(pnlContent);
            if (_loaded) return;
            _loaded = true;

            SetupNavbarForRole();

            try
            {
                LoadProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading the profile:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyEditingStyle(false);
            RenderSettingsTab();
        }

        private void LoadProfile()
        {
            var user = UserRepository.GetById(Session.CurrentUserId);
            if (user == null) return;

            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            tbEmail.Text = user.Email;
            tbPhone.Text = user.Phone;

            lblProfileName.Text = user.FullName;
            lblAvatarInitial.Text = user.FirstName.Length > 0 ? user.FirstName.Substring(0, 1).ToUpper() : "U";

            if (user.Photo != null)
            {
                picAvatarPhoto.Image = Image.FromStream(new MemoryStream(user.Photo));
                picAvatarPhoto.Visible = true;
                picAvatarPhoto.BringToFront();
            }

            bool isBabysitter = Session.CurrentRole == UserRole.Babysitter;
            lblRoleBadge.Text = isBabysitter
                ? "<div style=\"background:#DEF5F4;color:#3CA09C;border-radius:10px;padding:2px 10px;font-weight:bold;\">Babysitter</div>"
                : "<div style=\"background:#FDEEE8;color:#E8714A;border-radius:10px;padding:2px 10px;font-weight:bold;\">Parent</div>";

            if (isBabysitter)
            {
                var profile = BabysitterRepository.GetProfile(Session.CurrentUserId);
                var (_, bookings, _, avg, count) = BabysitterRepository.GetDashboardStats(Session.CurrentUserId);

                tbBio.Text = profile.Bio;
                tbLocation.Text = profile.Location;
                lblRatingLocation.Text = count > 0
                    ? $"★ {avg:0.0} ({count} review{(count == 1 ? "" : "s")})    📍 {profile.Location}"
                    : $"No reviews yet    📍 {profile.Location}";

                lblStatBookingsValue.Text = bookings.ToString();
                lblStatExperienceValue.Text = profile.ExperienceYears + "yr";
                lblStatExperienceLabel.Text = "Experience";
                lblStatRateValue.Text = $"${profile.HourlyRate:0}/hr";
                lblStatRateLabel.Text = "Rate";

                pnlSkillsCard.Visible = true;
                _allSkills = BabysitterRepository.GetAllSkills();
                _selectedSkills.Clear();
                foreach (var s in BabysitterRepository.GetSkillsFor(Session.CurrentUserId))
                    _selectedSkills.Add(s);
                RenderSkills();
                RenderReviews(ReviewRepository.GetForBabysitter(Session.CurrentUserId));
            }
            else
            {
                var myBookings = BookingRepository.GetForParent(Session.CurrentUserId);
                tbBio.Text = "Parent looking for reliable, caring babysitters.";
                tbLocation.Text = "";
                lblRatingLocation.Text = $"Member since {user.CreatedAt:MMMM yyyy}";

                lblStatBookingsValue.Text = myBookings.Count.ToString();
                lblStatExperienceValue.Text = myBookings.Count(b => b.Status == "completed").ToString();
                lblStatExperienceLabel.Text = "Completed";
                lblStatRateValue.Text = user.CreatedAt.Year.ToString();
                lblStatRateLabel.Text = "Member Since";

                pnlSkillsCard.Visible = false;
                RenderReviews(new List<ReviewInfo>());
            }
        }

        // ----- Navbar built per-role -----

        private void SetupNavbarForRole()
        {
            int x = 275;

            if (Session.CurrentRole == UserRole.Babysitter)
            {
                btnNavBabysitterHome.Location = new Point(x, 18);
                pnlNavbar.Controls.Add(btnNavBabysitterHome);
                x += btnNavBabysitterHome.Width + 8;
            }
            else
            {
                btnNavParentHome.Location = new Point(x, 18);
                pnlNavbar.Controls.Add(btnNavParentHome);
                x += btnNavParentHome.Width + 8;

                btnNavFindBabysitter.Location = new Point(x, 18);
                pnlNavbar.Controls.Add(btnNavFindBabysitter);
                x += btnNavFindBabysitter.Width + 8;

                btnNavBookNow.Location = new Point(x, 18);
                pnlNavbar.Controls.Add(btnNavBookNow);
                x += btnNavBookNow.Width + 8;
            }

            btnNavMyProfile.Location = new Point(x, 18);
            pnlNavbar.Controls.Add(btnNavMyProfile);

            pnlNavbar.Controls.Add(btnLogout);
        }

        // ----- Edit toggle (Save writes to the database) -----

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (_editing)
            {
                // "Save" pressed - validate and persist.
                string first = tbFirstName.Text.Trim();
                string last = tbLastName.Text.Trim();
                if (first.Length < 2 || last.Length < 2)
                {
                    MessageBox.Show("Please enter your real first and last name.", "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    UserRepository.UpdateContact(Session.CurrentUserId, first, last, tbPhone.Text.Trim());
                    if (Session.CurrentRole == UserRole.Babysitter)
                    {
                        BabysitterRepository.UpdateProfile(Session.CurrentUserId,
                            tbBio.Text.Trim(), tbLocation.Text.Trim());
                        BabysitterRepository.SetSkills(Session.CurrentUserId, _selectedSkills);
                    }
                    Session.CurrentUserName = $"{first} {last}";
                    lblProfileName.Text = Session.CurrentUserName;
                    MessageBox.Show("Profile saved.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error while saving:\n" + ex.Message, "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _editing = !_editing;
            ApplyEditingStyle(_editing);
        }

        private void ApplyEditingStyle(bool editing)
        {
            btnEditProfile.Text = editing ? "Save" : "Edit Profile";
            btnEditProfile.FillColor = editing ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242);
            btnEditProfile.ForeColor = editing ? Color.White : Color.FromArgb(60, 50, 45);

            foreach (var box in new[] { tbFirstName, tbLastName, tbPhone, tbLocation, tbBio })
            {
                box.ReadOnly = !editing;
                box.FillColor = editing ? Color.FromArgb(247, 245, 242) : Color.White;
            }
            // Email is the login key - it stays read-only.
            tbEmail.ReadOnly = true;
            tbEmail.FillColor = Color.White;
        }

        // ----- Photo upload: resized and stored IN the database (no file paths) -----

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "Choose a profile photo",
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var original = Image.FromFile(dialog.FileName);
                using var resized = new Bitmap(original, new Size(200, 200));
                using var ms = new MemoryStream();
                resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.ToArray();

                UserRepository.SetPhoto(Session.CurrentUserId, bytes);

                picAvatarPhoto.Image = Image.FromStream(new MemoryStream(bytes));
                picAvatarPhoto.Visible = true;
                picAvatarPhoto.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the photo:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Skills -----

        private void RenderSkills()
        {
            flpSkills.SuspendLayout();
            flpSkills.Controls.Clear();
            foreach (var skill in _allSkills)
                flpSkills.Controls.Add(BuildSkillChip(skill));
            flpSkills.ResumeLayout();
        }

        private Control BuildSkillChip(string skill)
        {
            bool active = _selectedSkills.Contains(skill);
            int width = TextRenderer.MeasureText(skill, new Font("Segoe UI", 8.5F)).Width + 28;
            var chip = new Guna2Button
            {
                Text = skill,
                Size = new Size(width, 32),
                Margin = new Padding(0, 0, 8, 8),
                BorderRadius = 14,
                FillColor = active ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242),
                ForeColor = active ? Color.White : Color.FromArgb(154, 136, 128),
                Font = new Font("Segoe UI", 8.5F),
                BackColor = Color.White,
            };
            chip.Click += (s, e) =>
            {
                if (!_editing) return;
                bool nowActive = !_selectedSkills.Remove(skill);
                if (nowActive) _selectedSkills.Add(skill);
                chip.FillColor = nowActive ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242);
                chip.ForeColor = nowActive ? Color.White : Color.FromArgb(154, 136, 128);
            };
            return chip;
        }

        // ----- Reviews tab -----

        private void RenderReviews(List<ReviewInfo> reviews)
        {
            flpReviews.SuspendLayout();
            flpReviews.Controls.Clear();

            if (Session.CurrentRole != UserRole.Babysitter)
            {
                flpReviews.Controls.Add(new Label
                {
                    Text = "Reviews you leave after completed bookings appear on each babysitter's profile.",
                    Width = 860,
                    Height = 30,
                    ForeColor = Color.FromArgb(154, 136, 128),
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent,
                });
            }
            else if (reviews.Count == 0)
            {
                flpReviews.Controls.Add(new Label
                {
                    Text = "No reviews yet - they'll appear here after your first completed bookings.",
                    Width = 860,
                    Height = 30,
                    ForeColor = Color.FromArgb(154, 136, 128),
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent,
                });
            }
            else
            {
                foreach (var r in reviews)
                    flpReviews.Controls.Add(BuildReviewCard(r));
            }
            flpReviews.ResumeLayout();
        }

        private Control BuildReviewCard(ReviewInfo r)
        {
            var card = new Guna2Panel
            {
                Width = 860,
                Height = 100,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 16,
                FillColor = Color.White,
                BackColor = Color.Transparent,
            };
            card.Controls.Add(new Label
            {
                Text = r.Author,
                Location = new Point(16, 12),
                Size = new Size(300, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = new string('★', r.Rating) + new string('☆', 5 - r.Rating),
                Location = new Point(700, 12),
                Size = new Size(140, 22),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(255, 209, 102),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = r.Comment.Length > 0 ? $"“{r.Comment}”" : "(no comment)",
                Location = new Point(16, 38),
                Size = new Size(820, 36),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = r.CreatedAt.ToString("MMM d, yyyy"),
                Location = new Point(16, 74),
                Size = new Size(200, 18),
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
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
                ("Privacy & Security", "Update password and account security"),
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
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };
            var titleLabel = new Label
            {
                Text = title,
                Location = new Point(16, 12),
                Size = new Size(400, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            var descLabel = new Label
            {
                Text = description,
                Location = new Point(16, 36),
                Size = new Size(600, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };

            EventHandler openPlaceholder = (s, e) => MessageBox.Show(
                $"{title} isn't wired up yet.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNavParentHome_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ParentDashboardForm());

        private void btnNavBabysitterHome_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BabysitterDashboardForm());

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e)
        {
            // Already on this page - no-op.
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
