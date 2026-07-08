using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class ParentDashboardForm : Form
    {
        private static readonly Color ColorHeading = Color.FromArgb(60, 50, 45);
        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);

        public ParentDashboardForm()
        {
            InitializeComponent();
        }

        private void ParentDashboardForm_Load(object sender, EventArgs e)
        {
            ApplyDesignPolish();
            Ui.HideScrollbars(flpBookings);

            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "Parent" : Session.CurrentUserName;
            lblGreeting.Text = TimeOfDayGreeting();
            lblUserName.Text = $"<div style=\"color:white;font-weight:bold;font-size:14pt;\">{name} \U0001F44B</div>";
            lblUserAvatarInitial.Text = name.Length > 0 ? name.Substring(0, 1).ToUpper() : "P";

            try
            {
                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading your bookings:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookings()
        {
            // Past confirmed bookings are finished - promote them so they count and
            // so a review can be left. Best-effort; never block the dashboard.
            try { BookingRepository.AutoCompletePastBookings(); } catch { }

            var all = BookingRepository.GetForParent(Session.CurrentUserId);
            var upcoming = all
                .Where(b => (b.Status == "pending" || b.Status == "confirmed") && b.Date >= DateTime.Today)
                .OrderBy(b => b.Date).ThenBy(b => b.Start)
                .ToList();
            var reviewable = all
                .Where(b => !b.HasReview && b.Date < DateTime.Today
                            && (b.Status == "confirmed" || b.Status == "completed"))
                .OrderByDescending(b => b.Date).ThenByDescending(b => b.Start)
                .ToList();

            int thisWeek = upcoming.Count(b => b.Date < DateTime.Today.AddDays(7));
            lblBannerSubtext.Text = upcoming.Count == 0
                ? "You have no upcoming bookings - time to book a babysitter!"
                : $"You have {thisWeek} upcoming booking{(thisWeek == 1 ? "" : "s")} this week.";

            flpBookings.SuspendLayout();
            flpBookings.Controls.Clear();

            if (upcoming.Count == 0 && reviewable.Count == 0)
            {
                flpBookings.Controls.Add(EmptyLabel("No bookings yet. Tap \"Book a Babysitter\" to get started."));
            }
            else
            {
                foreach (var b in upcoming)
                    flpBookings.Controls.Add(BuildBookingCard(b, reviewable: false));

                if (reviewable.Count > 0)
                {
                    flpBookings.Controls.Add(SectionLabel("Leave a review"));
                    foreach (var b in reviewable)
                        flpBookings.Controls.Add(BuildBookingCard(b, reviewable: true));
                }
            }
            flpBookings.ResumeLayout();
        }

        private Label EmptyLabel(string text) => new()
        {
            Text = text,
            Width = 1400,
            Height = 40,
            Margin = new Padding(0, 6, 0, 0),
            ForeColor = TextMuted,
            Font = new Font("Segoe UI", 10F),
            BackColor = Color.Transparent,
        };

        private Label SectionLabel(string text) => new()
        {
            Text = text,
            Width = 1400,
            Height = 30,
            Margin = new Padding(0, 12, 0, 2),
            ForeColor = TextMuted,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            BackColor = Color.Transparent,
        };

        private Control BuildBookingCard(BookingInfo b, bool reviewable)
        {
            var card = new Guna2Panel
            {
                Width = 1400,
                Height = 96,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 16,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };

            bool confirmedCard = b.Status == "confirmed";
            Color accent = confirmedCard ? Color.FromArgb(94, 200, 196) : Color.FromArgb(244, 168, 124);

            // Left accent bar (rounded) - the fresh look from the design.
            var accentBar = new Guna2Panel
            {
                Location = new Point(12, 16),
                Size = new Size(5, 64),
                BorderRadius = 3,
                FillColor = accent,
                BackColor = Color.Transparent,
            };
            // Avatar with the sitter's initial.
            var avatar = new Guna2Panel
            {
                Location = new Point(28, 20),
                Size = new Size(56, 56),
                BorderRadius = 16,
                FillColor = Ui.Lighten(accent, 0.78),
                BackColor = Color.Transparent,
            };
            avatar.Controls.Add(new Label
            {
                Text = b.SitterName.Length > 0 ? b.SitterName.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = accent,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.SitterName,
                Location = new Point(100, 16),
                Size = new Size(480, 24),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = ColorHeading,
                BackColor = Color.Transparent,
            };
            var dateLabel = new Label
            {
                Text = $"{b.Date:ddd, MMM d}  ·  {b.TimeRangeText}",
                Location = new Point(100, 44),
                Size = new Size(480, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };
            var detailLabel = new Label
            {
                Text = $"{b.ChildrenCount} {(b.ChildrenCount == 1 ? "child" : "children")}  ·  ${b.Total:0.00}  ·  tap for receipt",
                Location = new Point(100, 66),
                Size = new Size(580, 20),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };

            card.Controls.Add(accentBar);
            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(dateLabel);
            card.Controls.Add(detailLabel);

            EventHandler openReceipt = (s, e) =>
            {
                using var dlg = new ReceiptDialog(b, showParentSide: true);
                dlg.ShowDialog(this);
            };
            card.Click += openReceipt;
            nameLabel.Click += openReceipt;
            dateLabel.Click += openReceipt;
            detailLabel.Click += openReceipt;

            if (reviewable)
            {
                var reviewBtn = new Guna2Button
                {
                    Text = "★  Leave a review",
                    Location = new Point(1180, 28),
                    Size = new Size(190, 40),
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(255, 209, 102),
                    ForeColor = Color.FromArgb(90, 66, 0),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.Transparent,
                };
                reviewBtn.Click += (s, e) => LeaveReview(b);
                card.Controls.Add(reviewBtn);
            }
            else
            {
                bool confirmed = b.Status == "confirmed";
                var badge = new Label
                {
                    Text = confirmed ? "Confirmed" : "Pending",
                    Location = new Point(1230, 34),
                    Size = new Size(140, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = confirmed ? Color.FromArgb(232, 247, 247) : Color.FromArgb(255, 248, 224),
                    ForeColor = confirmed ? Color.FromArgb(42, 112, 112) : Color.FromArgb(160, 112, 0),
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                };
                badge.Click += openReceipt;
                card.Controls.Add(badge);
            }

            // View the babysitter's profile / reviews straight from the booking.
            var profileBtn = new Guna2Button
            {
                Text = "View Profile",
                Location = new Point(1010, 28),
                Size = new Size(150, 40),
                BorderRadius = 10,
                FillColor = Color.FromArgb(247, 245, 242),
                ForeColor = Coral,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            profileBtn.Click += (s, e) => OpenBabysitterProfile(b.BabysitterId);
            card.Controls.Add(profileBtn);

            return card;
        }

        private void OpenBabysitterProfile(int babysitterId) =>
            Navigation.GoTo(this, new BabysitterProfileForm(babysitterId, backToSearch: false));

        private void LeaveReview(BookingInfo booking)
        {
            using var dialog = new ReviewDialog(booking.SitterName);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                ReviewRepository.Add(booking.BookingId, Session.CurrentUserId,
                                     booking.BabysitterId, dialog.Rating, dialog.Comment);
                ExtrasRepository.AddNotification(booking.BabysitterId,
                    $"{Session.CurrentUserName} left you a {dialog.Rating}-star review!");
                MessageBox.Show("Thank you! Your review was saved.", "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while saving the review:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyDesignPolish()
        {
            lblQuickActionsTitle.ForeColor = ColorHeading;
            lblUpcomingTitle.ForeColor = ColorHeading;

            btnNotifications.BackColor = Color.Transparent;
            picUserAvatar.BackColor = Color.Transparent;
        }

        private static string TimeOfDayGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning,";
            if (hour < 18) return "Good afternoon,";
            return "Good evening,";
        }

        // ----- Quick actions -----

        private void btnBookBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnFindBabysitters_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnMyCalendar_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnFavorites_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnViewAllBookings_Click(object sender, EventArgs e)
        {
            try
            {
                var all = BookingRepository.GetForParent(Session.CurrentUserId);
                if (all.Count == 0)
                {
                    MessageBox.Show("You have no bookings yet.", "My Bookings",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var sb = new StringBuilder();
                foreach (var b in all.Take(12))
                    sb.AppendLine($"{b.Date:MMM d, yyyy}  {b.TimeRangeText}  ·  {b.SitterName}  ·  ${b.Total:0.00}  ·  {b.Status}");
                MessageBox.Show(sb.ToString(), "My Bookings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            try
            {
                var notifications = ExtrasRepository.GetNotifications(Session.CurrentUserId);
                if (notifications.Count == 0)
                {
                    MessageBox.Show("No notifications yet.", "Notifications",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var sb = new StringBuilder();
                foreach (var n in notifications)
                    sb.AppendLine($"{(n.Unread ? "●" : "○")}  {n.Message}   ({n.TimeAgoText})");
                MessageBox.Show(sb.ToString(), "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExtrasRepository.MarkAllRead(Session.CurrentUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Navbar -----

        private void btnNavParentHome_Click(object sender, EventArgs e)
        {
            try { LoadBookings(); } catch { /* refresh only */ }
        }

        private void btnNavBabysitterHome_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar; no-op.
        }

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e) => Navigation.GoTo(this, new BookingForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnNavAdmin_Click(object sender, EventArgs e)
        {
            // Not shown on the Parent navbar; no-op.
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
