using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class SearchBabysitterForm : Form
    {
        private static readonly Color[] AvatarPalette =
        {
            Color.FromArgb(94, 200, 196),
            Color.FromArgb(244, 168, 124),
            Color.FromArgb(232, 113, 74),
            Color.FromArgb(224, 90, 90),
            Color.FromArgb(255, 209, 102),
        };

        private List<BabysitterInfo> _all = new();
        private HashSet<int> _favorites = new();

        private int _maxRate = 25;
        private double _minRating = 0;
        private bool _availableOnly;
        private bool _verifiedOnly;

        public SearchBabysitterForm()
        {
            InitializeComponent();
        }

        private void SearchBabysitterForm_Load(object sender, EventArgs e)
        {
            tbSearch.PlaceholderText = "Search by name...";
            try
            {
                _all = BabysitterRepository.GetActiveBabysitters();
                _favorites = ExtrasRepository.GetFavoriteIds(Session.CurrentUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading babysitters:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _all = new List<BabysitterInfo>();
            }
            RenderResults();
        }

        // ----- Filters (fixed left sidebar - the layout never moves) -----

        private void tbSearch_TextChanged(object sender, EventArgs e) => RenderResults();

        private void tbMaxRate_Scroll(object sender, EventArgs e)
        {
            _maxRate = tbMaxRate.Value;
            lblMaxRateCaption.Text = $"Max Rate: ${_maxRate}/hr";
            RenderResults();
        }

        private void btnRatingAny_Click(object sender, EventArgs e) => SetMinRating(0, btnRatingAny);
        private void btnRating4_Click(object sender, EventArgs e) => SetMinRating(4, btnRating4);
        private void btnRating45_Click(object sender, EventArgs e) => SetMinRating(4.5, btnRating45);
        private void btnRating48_Click(object sender, EventArgs e) => SetMinRating(4.8, btnRating48);

        private void SetMinRating(double rating, Guna2Button activeButton)
        {
            _minRating = rating;
            foreach (var btn in new[] { btnRatingAny, btnRating4, btnRating45, btnRating48 })
            {
                bool active = btn == activeButton;
                btn.FillColor = active ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242);
                btn.ForeColor = active ? Color.White : Color.FromArgb(154, 136, 128);
            }
            RenderResults();
        }

        private void cbAvailableOnly_CheckedChanged(object sender, EventArgs e)
        {
            _availableOnly = cbAvailableOnly.Checked;
            RenderResults();
        }

        private void cbVerifiedOnly_CheckedChanged(object sender, EventArgs e)
        {
            _verifiedOnly = cbVerifiedOnly.Checked;
            RenderResults();
        }

        // ----- Results -----

        private void RenderResults()
        {
            string search = tbSearch.Text.Trim();

            // Search by name only for now (location/skill search comes later).
            var filtered = _all.Where(b =>
                (search.Length == 0
                    || b.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                && b.HourlyRate <= _maxRate
                && (_minRating == 0 || b.AvgRating >= _minRating)
                && (!_availableOnly || b.Available)
                && (!_verifiedOnly || b.Verified))
                .ToList();

            lblPageSubtitle.Text = $"{filtered.Count} caregiver{(filtered.Count == 1 ? "" : "s")} available in your area";

            flpResults.SuspendLayout();
            flpResults.Controls.Clear();
            foreach (var b in filtered)
                flpResults.Controls.Add(BuildBabysitterCard(b));
            flpResults.ResumeLayout();

            lblNoResults.Visible = filtered.Count == 0;
        }

        // One horizontal row per babysitter, like the design: accent stripe, avatar,
        // name + location/exp/rating, bio, tags on the left; price and actions right.
        private Control BuildBabysitterCard(BabysitterInfo b)
        {
            Color accent = AvatarPalette[b.UserId % AvatarPalette.Length];

            var card = new Guna2Panel
            {
                Size = new Size(1100, 170),
                Margin = new Padding(0, 0, 0, 16),
                BorderRadius = 16,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                BackColor = Color.Transparent,
            };

            var accentBar = new Guna2Panel
            {
                Location = new Point(10, 16),
                Size = new Size(5, 138),
                BorderRadius = 3,
                FillColor = accent,
                BackColor = Color.Transparent,
            };

            var avatar = new Guna2Panel
            {
                BorderRadius = 18,
                FillColor = LightenColor(accent, 0.8),
                BackColor = Color.Transparent,
                Location = new Point(28, 24),
                Size = new Size(70, 70),
            };
            avatar.Controls.Add(new Label
            {
                Text = b.Name.Length > 0 ? b.Name.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = accent,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.Name + (b.Verified ? "  ✓" : ""),
                Location = new Point(114, 22),
                Size = new Size(420, 24),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            var metaLabel = new Label
            {
                Text = $"📍 {(b.Location.Length > 0 ? b.Location : "No location")}   ·   {b.ExperienceYears}yr exp   ·   "
                     + (b.ReviewCount > 0 ? $"★ {b.AvgRating:0.0} ({b.ReviewCount})" : "★ New"),
                Location = new Point(114, 50),
                Size = new Size(560, 20),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };
            var bioLabel = new Label
            {
                Text = b.Bio.Length > 0 ? b.Bio : "This babysitter hasn't written a bio yet.",
                Location = new Point(114, 76),
                Size = new Size(640, 20),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(120, 108, 100),
                BackColor = Color.Transparent,
            };

            var tagsFlow = new FlowLayoutPanel
            {
                Location = new Point(112, 104),
                Size = new Size(640, 54),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.Transparent,
            };
            foreach (var tag in b.Skills.Take(4))
            {
                tagsFlow.Controls.Add(new Label
                {
                    Text = tag,
                    AutoSize = true,
                    Padding = new Padding(9, 4, 9, 4),
                    Margin = new Padding(0, 0, 8, 6),
                    BackColor = Color.FromArgb(253, 238, 232),
                    ForeColor = Color.FromArgb(232, 113, 74),
                    Font = new Font("Segoe UI", 8F),
                });
            }

            var favoriteBtn = new Guna2Button
            {
                Text = _favorites.Contains(b.UserId) ? "♥" : "♡",
                Location = new Point(1046, 14),
                Size = new Size(38, 32),
                BorderRadius = 6,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(224, 90, 90),
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.Transparent,
            };
            favoriteBtn.Click += (s, e) =>
            {
                try
                {
                    bool nowFavorite = ExtrasRepository.ToggleFavorite(Session.CurrentUserId, b.UserId);
                    if (nowFavorite) _favorites.Add(b.UserId); else _favorites.Remove(b.UserId);
                    ((Guna2Button)s!).Text = nowFavorite ? "♥" : "♡";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error:\n" + ex.Message);
                }
            };

            var rateLabel = new Label
            {
                Text = $"${b.HourlyRate:0}/hr",
                Location = new Point(880, 44),
                Size = new Size(150, 28),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(232, 113, 74),
                BackColor = Color.Transparent,
            };

            var profileBtn = new Guna2Button
            {
                Text = "View Profile",
                Location = new Point(870, 78),
                Size = new Size(160, 38),
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                ForeColor = Color.FromArgb(232, 113, 74),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            profileBtn.Click += (s, e) => OpenProfile(b.UserId);

            var bookBtn = new Guna2Button
            {
                Text = b.Available ? "Book Now" : "Unavailable",
                Location = new Point(870, 122),
                Size = new Size(160, 38),
                BorderRadius = 10,
                FillColor = b.Available ? Color.FromArgb(232, 113, 74) : Color.FromArgb(229, 231, 235),
                ForeColor = b.Available ? Color.White : Color.FromArgb(170, 170, 170),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Enabled = b.Available,
                BackColor = Color.Transparent,
            };
            bookBtn.Click += (s, e) => Navigation.GoTo(this, new BookingForm(b.UserId));

            card.Controls.Add(accentBar);
            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(metaLabel);
            card.Controls.Add(bioLabel);
            card.Controls.Add(tagsFlow);
            card.Controls.Add(favoriteBtn);
            card.Controls.Add(rateLabel);
            card.Controls.Add(profileBtn);
            card.Controls.Add(bookBtn);
            return card;
        }

        private static Color LightenColor(Color c, double amount)
        {
            int r = (int)(c.R + (255 - c.R) * amount);
            int g = (int)(c.G + (255 - c.G) * amount);
            int b = (int)(c.B + (255 - c.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        private void OpenProfile(int babysitterId) =>
            Navigation.GoTo(this, new BabysitterProfileForm(babysitterId, backToSearch: true));

        // ----- Navigation -----

        private void btnNavParentHome_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ParentDashboardForm());

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => SearchBabysitterForm_Load(sender, e);

        private void btnNavBookNow_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
