using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Meraki_Project
{
    public partial class SearchBabysitterForm : Form
    {
        private readonly System.Collections.Generic.HashSet<int> _favorites = new();

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

            // The results grid sits right below the filters panel, so it has to move
            // down/up depending on whether the panel is showing.
            flpResults.Location = new Point(flpResults.Location.X, pnlFiltersPanel.Visible ? 320 : 160);
            lblNoResults.Location = new Point(lblNoResults.Location.X, pnlFiltersPanel.Visible ? 420 : 260);
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

            var filtered = MockData.Babysitters.Where(b =>
                (search.Length == 0
                    || b.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || b.Location.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || b.Tags.Any(t => t.Contains(search, StringComparison.OrdinalIgnoreCase)))
                && b.HourlyRate <= _maxRate
                && b.Rating >= _minRating
                && (!_availableOnly || b.Available)
                && (!_verifiedOnly || b.Verified))
                .ToList();

            lblPageSubtitle.Text = $"{filtered.Count} caregiver{(filtered.Count == 1 ? "" : "s")} available in your area";

            flpResults.Controls.Clear();
            foreach (var b in filtered)
                flpResults.Controls.Add(BuildBabysitterCard(b));

            lblNoResults.Visible = filtered.Count == 0;
        }

        private Control BuildBabysitterCard(Babysitter b)
        {
            var card = new Guna2Panel
            {
                Size = new Size(450, 300),
                Margin = new Padding(0, 0, 20, 20),
                BorderRadius = 16,
                FillColor = Color.White,
                BackColor = Color.FromArgb(253, 238, 232),
            };

            var avatar = new Guna2Panel
            {
                BorderRadius = 18,
                FillColor = LightenColor(b.Color, 0.8),
                Location = new Point(16, 16),
                Size = new Size(56, 56),
            };
            avatar.Controls.Add(new Label
            {
                Text = b.Avatar,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = b.Color,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.Name + (b.Verified ? "  ✓" : ""),
                Location = new Point(82, 18),
                Size = new Size(260, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
            };
            var locationLabel = new Label
            {
                Text = "\U0001F4CD " + b.Location,
                Location = new Point(82, 42),
                Size = new Size(260, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
            };

            var favoriteBtn = new Guna2Button
            {
                Text = _favorites.Contains(b.Id) ? "♥" : "♡",
                Location = new Point(400, 14),
                Size = new Size(34, 30),
                BorderRadius = 6,
                BorderThickness = 0,
                FillColor = Color.Transparent,
                ForeColor = Color.FromArgb(224, 90, 90),
                Font = new Font("Segoe UI", 11F),
            };
            favoriteBtn.ShadowDecoration.Enabled = false;
            favoriteBtn.Click += (s, e) =>
            {
                if (!_favorites.Add(b.Id)) _favorites.Remove(b.Id);
                RenderResults();
            };

            var bioLabel = new Label
            {
                Text = b.Bio,
                Location = new Point(16, 80),
                Size = new Size(418, 40),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
            };

            var tagsFlow = new FlowLayoutPanel
            {
                Location = new Point(16, 124),
                Size = new Size(418, 48),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.Transparent,
            };
            foreach (var tag in b.Tags)
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
                Text = $"★ {b.Rating:0.0} ({b.ReviewCount})   ⏱ {b.ExperienceYears}yr exp",
                Location = new Point(16, 182),
                Size = new Size(418, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
            };

            var rateLabel = new Label
            {
                Text = $"${b.HourlyRate:0}/hr",
                Location = new Point(16, 206),
                Size = new Size(100, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(232, 113, 74),
            };
            var availabilityLabel = new Label
            {
                Text = b.Available ? "Available" : "Booked",
                Location = new Point(330, 208),
                Size = new Size(100, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7.5F),
                BackColor = b.Available ? Color.FromArgb(232, 247, 247) : Color.FromArgb(240, 240, 240),
                ForeColor = b.Available ? Color.FromArgb(42, 112, 112) : Color.FromArgb(153, 153, 153),
            };

            var bookBtn = new Guna2Button
            {
                Text = b.Available ? "Book Now" : "Unavailable",
                Location = new Point(16, 240),
                Size = new Size(418, 42),
                BorderRadius = 10,
                BorderThickness = 0,
                FillColor = b.Available ? Color.FromArgb(232, 113, 74) : Color.FromArgb(229, 231, 235),
                ForeColor = b.Available ? Color.White : Color.FromArgb(170, 170, 170),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Enabled = b.Available,
            };
            bookBtn.ShadowDecoration.Enabled = false;
            bookBtn.Click += (s, e) => GoTo(new BookingForm(b.Id));

            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(locationLabel);
            card.Controls.Add(favoriteBtn);
            card.Controls.Add(bioLabel);
            card.Controls.Add(tagsFlow);
            card.Controls.Add(ratingLabel);
            card.Controls.Add(rateLabel);
            card.Controls.Add(availabilityLabel);
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

        // ----- Navigation -----

        private void btnNavParentHome_Click(object sender, EventArgs e) => GoTo(new ParentDashboardForm());

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => SearchBabysitterForm_Load(sender, e);

        private void btnNavBookNow_Click(object sender, EventArgs e) => GoTo(new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => GoTo(new ProfileForm());

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
