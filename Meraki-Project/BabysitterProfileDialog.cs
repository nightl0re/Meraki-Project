using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Meraki_Project
{
    // A read-only "babysitter profile" popup: bio, skills, rate, rating, and the
    // reviews other parents left - plus a "Leave a review" button when this parent
    // has a finished booking with them, and a "Book Now" shortcut.
    // Built entirely in code so it needs no Designer file.
    public class BabysitterProfileDialog : Form
    {
        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color Teal = Color.FromArgb(94, 200, 196);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);
        private static readonly Color CardBg = Color.White;

        // Caller reads this after ShowDialog: true => the parent asked to book.
        public bool BookRequested { get; private set; }

        private readonly int _babysitterId;

        public BabysitterProfileDialog(int babysitterId)
        {
            _babysitterId = babysitterId;

            Text = "Babysitter Profile";
            ClientSize = new Size(520, 640);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(253, 244, 239);

            BabysitterInfo? info = null;
            List<ReviewInfo> reviews = new();
            int? reviewableBookingId = null;
            try
            {
                info = BabysitterRepository.GetBabysitterInfo(babysitterId);
                reviews = ReviewRepository.GetForBabysitter(babysitterId);
                reviewableBookingId = BookingRepository.FindReviewableBooking(
                    Session.CurrentUserId, babysitterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load this profile:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (info == null)
            {
                Controls.Add(new Label
                {
                    Text = "This profile is unavailable.",
                    Location = new Point(24, 24),
                    Size = new Size(460, 30),
                    ForeColor = TextMuted,
                    Font = new Font("Segoe UI", 10F),
                });
                AddCloseButton();
                return;
            }

            BuildHeader(info);
            BuildBody(info, reviews, reviewableBookingId);
        }

        private void BuildHeader(BabysitterInfo info)
        {
            var header = new Guna2Panel
            {
                Location = new Point(0, 0),
                Size = new Size(520, 120),
                FillColor = Coral,
                BorderRadius = 0,
            };

            var avatar = new Guna2Panel
            {
                Location = new Point(24, 26),
                Size = new Size(68, 68),
                BorderRadius = 20,
                FillColor = Color.White,
                BackColor = Color.Transparent,
            };
            avatar.Controls.Add(new Label
            {
                Text = info.Name.Length > 0 ? info.Name.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Coral,
                BackColor = Color.Transparent,
            });
            header.Controls.Add(avatar);

            header.Controls.Add(new Label
            {
                Text = info.Name + (info.Verified ? "  ✓" : ""),
                Location = new Point(108, 30),
                Size = new Size(390, 28),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
            });
            header.Controls.Add(new Label
            {
                Text = $"\U0001F4CD {(info.Location.Length > 0 ? info.Location : "No location set")}   ·   {info.ExperienceYears} yr exp",
                Location = new Point(108, 62),
                Size = new Size(390, 22),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
            });
            Controls.Add(header);
        }

        private void BuildBody(BabysitterInfo info, List<ReviewInfo> reviews, int? reviewableBookingId)
        {
            // rate + rating strip
            Controls.Add(new Label
            {
                Text = $"${info.HourlyRate:0}/hr",
                Location = new Point(24, 134),
                Size = new Size(160, 26),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Coral,
                BackColor = Color.Transparent,
            });
            Controls.Add(new Label
            {
                Text = info.ReviewCount > 0
                    ? $"★ {info.AvgRating:0.0}  ({info.ReviewCount} review{(info.ReviewCount == 1 ? "" : "s")})"
                    : "★ No reviews yet",
                Location = new Point(300, 138),
                Size = new Size(196, 22),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            });

            // bio
            Controls.Add(new Label
            {
                Text = info.Bio.Length > 0 ? info.Bio : "This babysitter hasn't written a bio yet.",
                Location = new Point(24, 172),
                Size = new Size(472, 44),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            });

            // skills
            var tags = new FlowLayoutPanel
            {
                Location = new Point(22, 220),
                Size = new Size(476, 40),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.Transparent,
            };
            foreach (var skill in info.Skills)
            {
                tags.Controls.Add(new Label
                {
                    Text = skill,
                    AutoSize = true,
                    Padding = new Padding(10, 4, 10, 4),
                    Margin = new Padding(0, 0, 8, 6),
                    BackColor = Color.FromArgb(253, 238, 232),
                    ForeColor = Coral,
                    Font = new Font("Segoe UI", 8F),
                });
            }
            Controls.Add(tags);

            // reviews header
            Controls.Add(new Label
            {
                Text = "Reviews",
                Location = new Point(24, 272),
                Size = new Size(200, 24),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            });

            var reviewList = new FlowLayoutPanel
            {
                Location = new Point(22, 300),
                Size = new Size(476, 216),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.Transparent,
            };
            if (reviews.Count == 0)
            {
                reviewList.Controls.Add(new Label
                {
                    Text = "No reviews yet - be the first after your booking.",
                    Width = 440,
                    Height = 30,
                    ForeColor = TextMuted,
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent,
                });
            }
            else
            {
                foreach (var rv in reviews)
                    reviewList.Controls.Add(BuildReviewCard(rv));
            }
            Controls.Add(reviewList);

            // action buttons
            var bookBtn = new Guna2Button
            {
                Text = "Book Now",
                Location = new Point(24, 532),
                Size = new Size(232, 46),
                BorderRadius = 12,
                FillColor = Coral,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            bookBtn.Click += (s, e) => { BookRequested = true; DialogResult = DialogResult.OK; };
            Controls.Add(bookBtn);

            var reviewBtn = new Guna2Button
            {
                Text = reviewableBookingId.HasValue ? "★ Leave a review" : "Review after booking",
                Location = new Point(264, 532),
                Size = new Size(232, 46),
                BorderRadius = 12,
                FillColor = reviewableBookingId.HasValue ? Color.FromArgb(255, 209, 102) : Color.FromArgb(235, 232, 228),
                ForeColor = reviewableBookingId.HasValue ? Color.FromArgb(90, 66, 0) : TextMuted,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Enabled = reviewableBookingId.HasValue,
                BackColor = Color.Transparent,
            };
            reviewBtn.Click += (s, e) => LeaveReview(info, reviewableBookingId);
            Controls.Add(reviewBtn);

            var close = new Guna2Button
            {
                Text = "Close",
                Location = new Point(24, 586),
                Size = new Size(472, 40),
                BorderRadius = 12,
                FillColor = Color.White,
                ForeColor = TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                BackColor = Color.Transparent,
            };
            close.Click += (s, e) => DialogResult = DialogResult.Cancel;
            Controls.Add(close);
        }

        private Control BuildReviewCard(ReviewInfo rv)
        {
            var card = new Guna2Panel
            {
                Width = 448,
                Height = 68,
                Margin = new Padding(0, 0, 0, 8),
                BorderRadius = 10,
                FillColor = CardBg,
                BackColor = Color.Transparent,
            };
            card.Controls.Add(new Label
            {
                Text = rv.Author,
                Location = new Point(12, 8),
                Size = new Size(300, 18),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = new string('★', Math.Clamp(rv.Rating, 0, 5)) + new string('☆', 5 - Math.Clamp(rv.Rating, 0, 5)),
                Location = new Point(316, 8),
                Size = new Size(120, 18),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(255, 179, 71),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = rv.Comment.Length > 0 ? rv.Comment : "(no comment)",
                Location = new Point(12, 28),
                Size = new Size(424, 34),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            });
            return card;
        }

        private void LeaveReview(BabysitterInfo info, int? bookingId)
        {
            if (!bookingId.HasValue) return;

            using var dialog = new ReviewDialog(info.Name);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                ReviewRepository.Add(bookingId.Value, dialog.Rating, dialog.Comment);
                ExtrasRepository.AddNotification(info.UserId,
                    $"{Session.CurrentUserName} left you a {dialog.Rating}-star review!");
                MessageBox.Show("Thank you! Your review was saved.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; // close so the refreshed data reloads
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while saving the review:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCloseButton()
        {
            var close = new Guna2Button
            {
                Text = "Close",
                Location = new Point(24, 586),
                Size = new Size(472, 40),
                BorderRadius = 12,
                FillColor = Color.White,
                ForeColor = TextMuted,
                Font = new Font("Segoe UI", 9.5F),
                BackColor = Color.Transparent,
            };
            close.Click += (s, e) => DialogResult = DialogResult.Cancel;
            Controls.Add(close);
        }
    }
}
