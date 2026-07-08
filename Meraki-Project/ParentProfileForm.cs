using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Parent profile page a BABYSITTER sees: who the family is, the reviews
    // other babysitters left about them, and a Write Review tab.
    // Reached from the Find Parents page and from the babysitter's bookings.
    public partial class ParentProfileForm : Form
    {
        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);
        private static readonly Color StarGold = Color.FromArgb(255, 179, 71);
        private static readonly Color StarGrey = Color.FromArgb(200, 190, 185);

        private readonly int _parentId;
        private readonly bool _backToSearch;

        private ParentInfo? _info;
        private int? _reviewableBookingId;
        private int _rating;

        // backToSearch: true when opened from Find Parents, false when opened
        // from the babysitter dashboard (Back returns to where the user came from).
        public ParentProfileForm(int parentId, bool backToSearch = false)
        {
            InitializeComponent();
            _parentId = parentId;
            _backToSearch = backToSearch;
        }

        private void ParentProfileForm_Load(object sender, EventArgs e)
        {
            List<ReviewInfo> reviews = new();
            try
            {
                _info = ParentRepository.GetParentInfo(_parentId);
                reviews = ReviewRepository.GetForParent(_parentId);
                _reviewableBookingId = BookingRepository.FindReviewableBooking(
                    _parentId, Session.CurrentUserId, "babysitter");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading the profile:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_info == null)
            {
                lblName.Text = "Profile unavailable";
                btnTabWrite.Enabled = false;
                return;
            }

            // Header card
            lblAvatarInitial.Text = _info.Name.Length > 0 ? _info.Name.Substring(0, 1).ToUpper() : "?";
            lblName.Text = _info.Name;
            lblMeta.Text = $"Member since {_info.MemberSince:MMMM yyyy}   ·   " +
                           $"{_info.CompletedBookingCount} completed booking{(_info.CompletedBookingCount == 1 ? "" : "s")}";
            lblRatingSummary.Text = _info.ReviewCount > 0
                ? $"★ {_info.AvgRating:0.0}  ({_info.ReviewCount} review{(_info.ReviewCount == 1 ? "" : "s")} from babysitters)"
                : "★ No reviews from babysitters yet";
            btnTabReviews.Text = $"Reviews ({_info.ReviewCount})";
            lblWriteTitle.Text = $"Review {_info.Name}";

            // Reviews tab
            flpReviews.Controls.Clear();
            if (reviews.Count == 0)
            {
                flpReviews.Controls.Add(new Label
                {
                    Text = "No reviews yet - be the first!",
                    Width = 1360,
                    Height = 32,
                    ForeColor = TextMuted,
                    Font = new Font("Segoe UI", 9.5F),
                    BackColor = Color.Transparent,
                });
            }
            else
            {
                foreach (var rv in reviews)
                    flpReviews.Controls.Add(BuildReviewCard(rv));
            }

            Ui.HideScrollbars(flpReviews);
        }

        private Control BuildReviewCard(ReviewInfo rv)
        {
            var card = new Guna2Panel
            {
                Width = 1360,
                Height = 90,
                Margin = new Padding(0, 0, 0, 10),
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.FromArgb(252, 250, 248),
                BackColor = Color.Transparent,
            };
            card.Controls.Add(new Label
            {
                Text = rv.Author,
                Location = new Point(16, 12),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = new string('★', Math.Clamp(rv.Rating, 0, 5)) + new string('☆', 5 - Math.Clamp(rv.Rating, 0, 5))
                     + $"    {rv.CreatedAt:MMM d, yyyy}",
                Location = new Point(1000, 12),
                Size = new Size(344, 20),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9F),
                ForeColor = StarGold,
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = rv.Comment.Length > 0 ? rv.Comment : "(no comment)",
                Location = new Point(16, 38),
                Size = new Size(1328, 44),
                Font = new Font("Segoe UI", 9F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            });
            return card;
        }

        // ----- Tabs -----

        private void btnTabReviews_Click(object sender, EventArgs e) => ShowTab(0);
        private void btnTabWrite_Click(object sender, EventArgs e) => ShowTab(1);

        private void ShowTab(int index)
        {
            pnlTabReviews.Visible = index == 0;
            pnlTabWrite.Visible = index == 1;
            StyleTab(btnTabReviews, index == 0);
            StyleTab(btnTabWrite, index == 1);
        }

        private static void StyleTab(Guna2Button tab, bool active)
        {
            tab.FillColor = active ? Coral : Color.White;
            tab.ForeColor = active ? Color.White : TextMuted;
            tab.Font = new Font("Segoe UI", 9.5F, active ? FontStyle.Bold : FontStyle.Regular);
        }

        // ----- Write Review -----

        private void btnStar_Click(object sender, EventArgs e)
        {
            _rating = int.Parse((string)((Guna2Button)sender!).Tag!);
            var stars = new[] { btnStar1, btnStar2, btnStar3, btnStar4, btnStar5 };
            for (int i = 0; i < 5; i++)
            {
                bool filled = i < _rating;
                stars[i].Text = filled ? "★" : "☆";
                stars[i].ForeColor = filled ? StarGold : StarGrey;
            }
        }

        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            if (_info == null) return;
            if (_rating == 0)
            {
                MessageBox.Show("Please pick a star rating first.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Linked to the finished booking when there is one; allowed either way.
                ReviewRepository.Add(_reviewableBookingId, _parentId,
                                     Session.CurrentUserId, "babysitter", _rating, tbComment.Text.Trim());
                ExtrasRepository.AddNotification(_parentId,
                    $"{Session.CurrentUserName} left you a {_rating}-star review!");
                MessageBox.Show("Thank you! Your review was saved.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload: the header rating and Reviews tab update immediately.
                _rating = 0;
                tbComment.Text = "";
                foreach (var star in new[] { btnStar1, btnStar2, btnStar3, btnStar4, btnStar5 })
                {
                    star.Text = "☆";
                    star.ForeColor = StarGrey;
                }
                ParentProfileForm_Load(this, EventArgs.Empty);
                ShowTab(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while saving the review:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_backToSearch)
                Navigation.GoTo(this, new FindParentsForm());
            else
                Navigation.GoTo(this, new BabysitterDashboardForm());
        }
    }
}
