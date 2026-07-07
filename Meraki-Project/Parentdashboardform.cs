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

        private Guna2Button? _reviewButton;
        private BookingInfo? _bookingToReview;

        public ParentDashboardForm()
        {
            InitializeComponent();
        }

        private void ParentDashboardForm_Load(object sender, EventArgs e)
        {
            ApplyDesignPolish();

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
            var all = BookingRepository.GetForParent(Session.CurrentUserId);
            var upcoming = all
                .Where(b => (b.Status == "pending" || b.Status == "confirmed") && b.Date >= DateTime.Today)
                .OrderBy(b => b.Date).ThenBy(b => b.Start)
                .ToList();

            int thisWeek = upcoming.Count(b => b.Date < DateTime.Today.AddDays(7));
            lblBannerSubtext.Text = upcoming.Count == 0
                ? "You have no upcoming bookings - time to book a babysitter!"
                : $"You have {thisWeek} upcoming booking{(thisWeek == 1 ? "" : "s")} this week.";

            FillBookingCard(upcoming.ElementAtOrDefault(0), pnlBookingCard1,
                lblBookingSitterName1, lblBookingStatus1, lblBookingDateTime1, lblBookingChildren1, lblAvatarInitial1);
            FillBookingCard(upcoming.ElementAtOrDefault(1), pnlBookingCard2,
                lblBookingSitterName2, lblBookingStatus2, lblBookingDateTime2, lblBookingChildren2, lblAvatarInitial2);

            // Offer a review for the most recent completed booking without one.
            _bookingToReview = all.FirstOrDefault(b => b.Status == "completed" && !b.HasReview);
            ShowOrHideReviewButton();
        }

        private void FillBookingCard(BookingInfo? b, Guna2Panel card, Label nameLabel,
            Guna2HtmlLabel statusLabel, Label dateTimeLabel, Label childrenLabel, Label avatarInitial)
        {
            if (b == null)
            {
                card.Visible = false;
                return;
            }
            card.Visible = true;
            nameLabel.Text = b.SitterName;
            avatarInitial.Text = b.SitterName.Length > 0 ? b.SitterName.Substring(0, 1).ToUpper() : "?";
            dateTimeLabel.Text = $"{b.Date:ddd, MMM d}  ·  {b.TimeRangeText}";
            childrenLabel.Text = $"{b.ChildrenCount} {(b.ChildrenCount == 1 ? "child" : "children")}  ·  ${b.Total:0.00}";
            statusLabel.Text = b.Status == "confirmed"
                ? "<div style=\"background:#E8F7F7;color:#2A7070;border-radius:10px;padding:2px 10px;font-weight:bold;\">Confirmed</div>"
                : "<div style=\"background:#FFF8E0;color:#A07000;border-radius:10px;padding:2px 10px;font-weight:bold;\">Pending</div>";
        }

        private void ShowOrHideReviewButton()
        {
            if (_bookingToReview == null)
            {
                if (_reviewButton != null) _reviewButton.Visible = false;
                return;
            }

            if (_reviewButton == null)
            {
                _reviewButton = new Guna2Button
                {
                    Location = new Point(30, 610),
                    Size = new Size(560, 48),
                    BorderRadius = 12,
                    FillColor = Color.FromArgb(255, 244, 217),
                    ForeColor = Color.FromArgb(160, 112, 0),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    BackColor = Color.Transparent,
                };
                _reviewButton.Click += ReviewButton_Click;
                pnlContent.Controls.Add(_reviewButton);
                _reviewButton.BringToFront();
            }

            _reviewButton.Text = $"★  How was your booking with {_bookingToReview.SitterName}?  Leave a review";
            _reviewButton.Visible = true;
        }

        private void ReviewButton_Click(object? sender, EventArgs e)
        {
            if (_bookingToReview == null) return;

            using var dialog = new ReviewDialog(_bookingToReview.SitterName);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                ReviewRepository.Add(_bookingToReview.BookingId, dialog.Rating, dialog.Comment);
                ExtrasRepository.AddNotification(_bookingToReview.BabysitterId,
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
            lblBookingSitterName1.ForeColor = ColorHeading;
            lblBookingSitterName2.ForeColor = ColorHeading;

            btnNotifications.BackColor = Color.Transparent;
            picUserAvatar.BackColor = Color.Transparent;
            pnlAvatar1.BackColor = Color.Transparent;
            pnlAvatar2.BackColor = Color.Transparent;
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
