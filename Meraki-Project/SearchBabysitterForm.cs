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

        // ----- Search bar -----

        private void tbSearch_TextChanged(object sender, EventArgs e) => RenderResults();

        private void btnToggleFilters_Click(object sender, EventArgs e)
        {
            pnlFiltersPanel.Visible = !pnlFiltersPanel.Visible;
            btnToggleFilters.FillColor = pnlFiltersPanel.Visible
                ? Color.FromArgb(232, 113, 74)
                : Color.FromArgb(247, 245, 242);
            btnToggleFilters.ForeColor = pnlFiltersPanel.Visible ? Color.White : Color.FromArgb(154, 136, 128);

            int top = pnlFiltersPanel.Visible ? 310 : 166;
            flpResults.SetBounds(30, top, 1420, 806 - top);
            lblNoResults.Top = top + 90;

            // Keep the filter panel above the results list so it never renders behind
            // the cards when it expands.
            if (pnlFiltersPanel.Visible) pnlFiltersPanel.BringToFront();
        }

        // ----- Filters -----

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

        private Control BuildBabysitterCard(BabysitterInfo b)
        {
            Color accent = AvatarPalette[b.UserId % AvatarPalette.Length];

            var card = new Guna2Panel
            {
                Size = new Size(450, 310),
                Margin = new Padding(0, 0, 20, 20),
                BorderRadius = 16,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                BackColor = Color.Transparent,
            };

            var avatar = new Guna2Panel
            {
                BorderRadius = 18,
                FillColor = LightenColor(accent, 0.8),
                BackColor = Color.White,
                Location = new Point(16, 16),
                Size = new Size(56, 56),
            };
            avatar.Controls.Add(new Label
            {
                Text = b.Name.Length > 0 ? b.Name.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = accent,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.Name + (b.Verified ? "  ✓" : ""),
                Location = new Point(82, 18),
                Size = new Size(300, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            var locationLabel = new Label
            {
                Text = "📍 " + (b.Location.Length > 0 ? b.Location : "No location set"),
                Location = new Point(82, 42),
                Size = new Size(300, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };

            var favoriteBtn = new Guna2Button
            {
                Text = _favorites.Contains(b.UserId) ? "♥" : "♡",
                Location = new Point(400, 14),
                Size = new Size(34, 30),
                BorderRadius = 6,
                FillColor = Color.Transparent,
                ForeColor = Color.FromArgb(224, 90, 90),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.White,
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

            var bioLabel = new Label
            {
                Text = b.Bio.Length > 0 ? b.Bio : "This babysitter hasn't written a bio yet.",
                Location = new Point(16, 82),
                Size = new Size(418, 38),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };

            var tagsFlow = new FlowLayoutPanel
            {
                Location = new Point(16, 124),
                Size = new Size(418, 50),
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
                    Padding = new Padding(8, 3, 8, 3),
                    Margin = new Padding(0, 0, 6, 6),
                    BackColor = Color.FromArgb(253, 238, 232),
                    ForeColor = Color.FromArgb(232, 113, 74),
                    Font = new Font("Segoe UI", 7.5F),
                });
            }

            var ratingLabel = new Label
            {
                Text = b.ReviewCount > 0
                    ? $"★ {b.AvgRating:0.0} ({b.ReviewCount})    {b.ExperienceYears}yr exp"
                    : $"★ New    {b.ExperienceYears}yr exp",
                Location = new Point(16, 182),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };

            var rateLabel = new Label
            {
                Text = $"${b.HourlyRate:0}/hr",
                Location = new Point(16, 208),
                Size = new Size(120, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(232, 113, 74),
                BackColor = Color.Transparent,
            };
            var availabilityLabel = new Label
            {
                Text = b.Available ? "Available" : "Booked",
                Location = new Point(334, 208),
                Size = new Size(100, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7.5F),
                BackColor = b.Available ? Color.FromArgb(232, 247, 247) : Color.FromArgb(240, 240, 240),
                ForeColor = b.Available ? Color.FromArgb(42, 112, 112) : Color.FromArgb(153, 153, 153),
            };

            var profileBtn = new Guna2Button
            {
                Text = "View Profile",
                Location = new Point(16, 244),
                Size = new Size(198, 44),
                BorderRadius = 10,
                FillColor = Color.FromArgb(247, 245, 242),
                ForeColor = Color.FromArgb(232, 113, 74),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.White,
            };
            profileBtn.Click += (s, e) => OpenProfile(b.UserId);

            var bookBtn = new Guna2Button
            {
                Text = b.Available ? "Book Now" : "Unavailable",
                Location = new Point(222, 244),
                Size = new Size(212, 44),
                BorderRadius = 10,
                FillColor = b.Available ? Color.FromArgb(232, 113, 74) : Color.FromArgb(229, 231, 235),
                ForeColor = b.Available ? Color.White : Color.FromArgb(170, 170, 170),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Enabled = b.Available,
                BackColor = Color.White,
            };
            bookBtn.Click += (s, e) => Navigation.GoTo(this, new BookingForm(b.UserId));

            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(locationLabel);
            card.Controls.Add(favoriteBtn);
            card.Controls.Add(bioLabel);
            card.Controls.Add(tagsFlow);
            card.Controls.Add(ratingLabel);
            card.Controls.Add(rateLabel);
            card.Controls.Add(availabilityLabel);
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

        private void OpenProfile(int babysitterId)
        {
            using var dlg = new BabysitterProfileDialog(babysitterId);
            dlg.ShowDialog(this);
            if (dlg.BookRequested)
            {
                Navigation.GoTo(this, new BookingForm(babysitterId));
                return;
            }
            // A review may have been added - refresh ratings.
            SearchBabysitterForm_Load(this, EventArgs.Empty);
        }

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
