using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class BabysitterDashboardForm : Form
    {
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);

        private List<NotificationInfo> _notifications = new();
        private List<BookingInfo> _pendingRequests = new();

        public BabysitterDashboardForm()
        {
            InitializeComponent();
        }

        private void BabysitterDashboardForm_Load(object sender, EventArgs e)
        {
            string name = string.IsNullOrWhiteSpace(Session.CurrentUserName) ? "Babysitter" : Session.CurrentUserName;
            lblUserName.Text = $"<div style=\"color:white;font-weight:bold;font-size:14pt;\">{name}</div>";
            lblQuickName.Text = name;
            lblQuickAvatarInitial.Text = name.Length > 0 ? name.Substring(0, 1).ToUpper() : "B";

            // Past confirmed bookings are finished - promote them so earnings/hours
            // are accurate. Best-effort; never block the dashboard.
            try { BookingRepository.AutoCompletePastBookings(); } catch { }

            Ui.HideScrollbars(flpSchedule);
            Ui.HideScrollbars(flpPendingRequests);
            Ui.HideScrollbars(flpNotificationsList);

            try
            {
                LoadStats();
                RenderSchedule();
                LoadPendingRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading the dashboard:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStats()
        {
            var (earnings, bookings, hours, avg, count) =
                BabysitterRepository.GetDashboardStats(Session.CurrentUserId);
            var profile = BabysitterRepository.GetProfile(Session.CurrentUserId);

            lblStatMonthValue.Text = "$" + earnings.ToString("0");
            lblStatBookingsValue.Text = bookings.ToString();
            lblStatRatingValue.Text = count > 0 ? avg.ToString("0.0") : "—";
            lblStatHoursValue.Text = hours + "h";

            lblRatingSummary.Text = count > 0
                ? $"★ {avg:0.0}  ·  {count} review{(count == 1 ? "" : "s")}"
                : "No reviews yet";

            lblQuickBookingsValue.Text = bookings.ToString();
            lblQuickRatingValue.Text = count > 0 ? avg.ToString("0.0") : "—";
            lblQuickSubtitle.Text = $"Babysitter · {profile.ExperienceYears} yrs experience";
        }

        // ----- Schedule list (real confirmed / completed bookings) -----
        //
        // A confirmed booking appears here as a coloured card; when it is done it
        // turns grey ("Completed") - simple, readable schedule instead of a calendar.

        private void RenderSchedule()
        {
            var bookings = BookingRepository.GetScheduleForBabysitter(Session.CurrentUserId);
            var today = DateTime.Today;
            var upcoming = bookings.Where(b => b.Date >= today)
                                   .OrderBy(b => b.Date).ThenBy(b => b.Start).ToList();
            var past = bookings.Where(b => b.Date < today)
                               .OrderByDescending(b => b.Date).ThenByDescending(b => b.Start).ToList();

            flpSchedule.SuspendLayout();
            flpSchedule.Controls.Clear();

            if (upcoming.Count == 0 && past.Count == 0)
            {
                flpSchedule.Controls.Add(EmptyLabel("No confirmed bookings yet. Accept a request and it will show up here."));
            }
            else
            {
                if (upcoming.Count > 0)
                {
                    flpSchedule.Controls.Add(SectionLabel("Upcoming"));
                    foreach (var b in upcoming) flpSchedule.Controls.Add(BuildScheduleCard(b));
                }
                if (past.Count > 0)
                {
                    flpSchedule.Controls.Add(SectionLabel("Past"));
                    foreach (var b in past.Take(10)) flpSchedule.Controls.Add(BuildScheduleCard(b));
                }
            }
            flpSchedule.ResumeLayout();
        }

        private Label EmptyLabel(string text) => new()
        {
            Text = text,
            Width = 820,
            Height = 44,
            Margin = new Padding(0, 6, 0, 0),
            ForeColor = TextMuted,
            Font = new Font("Segoe UI", 9.5F),
            BackColor = Color.Transparent,
        };

        private Label SectionLabel(string text) => new()
        {
            Text = text,
            Width = 820,
            Height = 26,
            Margin = new Padding(0, 8, 0, 2),
            ForeColor = TextMuted,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            BackColor = Color.Transparent,
        };

        private Control BuildScheduleCard(BookingInfo b)
        {
            bool completed = b.Status == "completed";
            Color stripe = completed ? Color.FromArgb(210, 205, 200) : Color.FromArgb(94, 200, 196);

            var card = new Guna2Panel
            {
                Width = 820,
                Height = 78,
                Margin = new Padding(0, 0, 0, 10),
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = completed ? Color.FromArgb(230, 226, 221) : Color.FromArgb(200, 232, 230),
                FillColor = completed ? Color.FromArgb(247, 245, 242) : Color.FromArgb(232, 247, 247),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };

            var accentBar = new Guna2Panel
            {
                Location = new Point(10, 14),
                Size = new Size(4, 50),
                BorderRadius = 2,
                FillColor = stripe,
                BackColor = Color.Transparent,
            };
            var avatar = new Guna2Panel
            {
                Location = new Point(22, 15),
                Size = new Size(48, 48),
                BorderRadius = 14,
                FillColor = completed ? Color.FromArgb(238, 235, 231) : Color.FromArgb(214, 240, 238),
                BackColor = Color.Transparent,
            };
            avatar.Controls.Add(new Label
            {
                Text = b.ParentName.Length > 0 ? b.ParentName.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = completed ? TextMuted : Color.FromArgb(42, 112, 112),
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.ParentName,
                Location = new Point(84, 10),
                Size = new Size(400, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            };
            var whenLabel = new Label
            {
                Text = $"{b.Date:ddd, MMM d}  ·  {b.TimeRangeText}",
                Location = new Point(84, 34),
                Size = new Size(500, 18),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };
            var payLabel = new Label
            {
                Text = $"{b.ChildrenCount} {(b.ChildrenCount == 1 ? "child" : "children")}  ·  ${b.Total:0.00}",
                Location = new Point(84, 52),
                Size = new Size(500, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };
            var statusLabel = new Label
            {
                Text = completed ? "Completed" : "Confirmed",
                Location = new Point(680, 26),
                Size = new Size(120, 26),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = completed ? Color.FromArgb(235, 232, 228) : Color.FromArgb(210, 240, 238),
                ForeColor = completed ? TextMuted : Color.FromArgb(42, 112, 112),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            };

            // A small explicit receipt link; clicking anywhere else on the card
            // opens the parent's profile (reviews + write one).
            var receiptLink = new Label
            {
                Text = "Receipt",
                Location = new Point(680, 52),
                Size = new Size(120, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F, FontStyle.Underline),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };
            receiptLink.Click += (s, e) =>
            {
                using var dlg = new ReceiptDialog(b, showParentSide: false);
                dlg.ShowDialog(this);
            };

            card.Controls.Add(accentBar);
            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(whenLabel);
            card.Controls.Add(payLabel);
            card.Controls.Add(statusLabel);
            card.Controls.Add(receiptLink);

            EventHandler openParent = (s, e) =>
                Navigation.GoTo(this, new ParentProfileForm(b.ParentId));
            card.Click += openParent;
            nameLabel.Click += openParent;
            whenLabel.Click += openParent;
            payLabel.Click += openParent;
            statusLabel.Click += openParent;

            return card;
        }

        // ----- Notifications dropdown -----

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            pnlNotificationsDropdown.Visible = !pnlNotificationsDropdown.Visible;
            if (pnlNotificationsDropdown.Visible)
            {
                pnlNotificationsDropdown.BringToFront();
                try
                {
                    _notifications = ExtrasRepository.GetNotifications(Session.CurrentUserId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error:\n" + ex.Message);
                    _notifications = new List<NotificationInfo>();
                }
                RenderNotifications();
            }
        }

        private void RenderNotifications()
        {
            flpNotificationsList.SuspendLayout();
            flpNotificationsList.Controls.Clear();

            if (_notifications.Count == 0)
            {
                flpNotificationsList.Controls.Add(new Label
                {
                    Text = "No notifications yet.",
                    Width = flpNotificationsList.ClientSize.Width - 8,
                    Height = 30,
                    ForeColor = Color.FromArgb(154, 136, 128),
                    Font = new Font("Segoe UI", 8.5F),
                    BackColor = Color.Transparent,
                });
            }
            else
            {
                foreach (var n in _notifications)
                    flpNotificationsList.Controls.Add(BuildNotificationRow(n));
            }
            flpNotificationsList.ResumeLayout();
        }

        private Control BuildNotificationRow(NotificationInfo n)
        {
            var panel = new Panel
            {
                Width = flpNotificationsList.ClientSize.Width - 8,
                Height = 46,
                Margin = new Padding(0, 0, 0, 4),
                BackColor = n.Unread ? Color.FromArgb(253, 238, 232) : Color.Transparent,
            };
            panel.Controls.Add(new Label
            {
                Text = n.Message,
                Location = new Point(8, 4),
                Size = new Size(panel.Width - 16, 26),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            });
            panel.Controls.Add(new Label
            {
                Text = n.TimeAgoText,
                Location = new Point(8, 29),
                Size = new Size(panel.Width - 16, 14),
                Font = new Font("Segoe UI", 7F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            });
            return panel;
        }

        private void btnMarkAllRead_Click(object sender, EventArgs e)
        {
            try
            {
                ExtrasRepository.MarkAllRead(Session.CurrentUserId);
                foreach (var n in _notifications) n.Unread = false;
                RenderNotifications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }
        }

        // ----- Pending requests (Accept / Decline update the database) -----

        private void LoadPendingRequests()
        {
            _pendingRequests = BookingRepository.GetPendingForBabysitter(Session.CurrentUserId);
            RenderPendingRequests();
        }

        private void RenderPendingRequests()
        {
            flpPendingRequests.SuspendLayout();
            flpPendingRequests.Controls.Clear();

            if (_pendingRequests.Count == 0)
            {
                flpPendingRequests.Controls.Add(new Label
                {
                    Text = "No pending requests right now.",
                    Width = flpPendingRequests.ClientSize.Width - 8,
                    Height = 30,
                    ForeColor = Color.FromArgb(154, 136, 128),
                    Font = new Font("Segoe UI", 8.5F),
                    BackColor = Color.Transparent,
                });
            }
            else
            {
                foreach (var r in _pendingRequests)
                    flpPendingRequests.Controls.Add(BuildPendingRequestCard(r));
            }
            flpPendingRequests.ResumeLayout();
        }

        private Control BuildPendingRequestCard(BookingInfo r)
        {
            var card = new Guna2Panel
            {
                Width = flpPendingRequests.ClientSize.Width - 8,
                Height = 100,
                Margin = new Padding(0, 0, 0, 8),
                BorderRadius = 12,
                FillColor = Color.FromArgb(253, 238, 232),
                BackColor = Color.Transparent,
            };

            card.Controls.Add(new Label
            {
                Text = r.ParentName,
                Location = new Point(12, 8),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = $"{r.Date:MMM d}  ·  {r.TimeRangeText}",
                Location = new Point(12, 30),
                Size = new Size(320, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = $"{r.ChildrenCount} {(r.ChildrenCount == 1 ? "child" : "children")}  ·  ${r.HourlyRate:0}/hr  ·  ${r.Total:0.00} total",
                Location = new Point(12, 48),
                Size = new Size(320, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            });

            var acceptBtn = new Guna2Button
            {
                Text = "Accept",
                Location = new Point(12, 68),
                Size = new Size(150, 26),
                BorderRadius = 8,
                FillColor = Color.FromArgb(232, 113, 74),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            acceptBtn.Click += (s, e) => RespondToRequest(r, accepted: true);

            var declineBtn = new Guna2Button
            {
                Text = "Decline",
                Location = new Point(170, 68),
                Size = new Size(150, 26),
                BorderRadius = 8,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(224, 90, 90),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            declineBtn.Click += (s, e) => RespondToRequest(r, accepted: false);

            var viewParentBtn = new Guna2Button
            {
                Text = "View Parent",
                Location = new Point(328, 68),
                Size = new Size(130, 26),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                ForeColor = Color.FromArgb(154, 136, 128),
                Font = new Font("Segoe UI", 8F),
                BackColor = Color.Transparent,
            };
            viewParentBtn.Click += (s, e) =>
                Navigation.GoTo(this, new ParentProfileForm(r.ParentId));

            card.Controls.Add(acceptBtn);
            card.Controls.Add(declineBtn);
            card.Controls.Add(viewParentBtn);
            return card;
        }

        private void RespondToRequest(BookingInfo r, bool accepted)
        {
            try
            {
                BookingRepository.SetStatus(r.BookingId, accepted ? "confirmed" : "declined");
                ExtrasRepository.AddNotification(r.ParentId, accepted
                    ? $"{Session.CurrentUserName} confirmed your booking for {r.Date:MMM d}"
                    : $"{Session.CurrentUserName} declined your booking request for {r.Date:MMM d}");

                // Defer the list rebuild so we never dispose the button that is
                // still running its own click handler.
                BeginInvoke(new Action(() =>
                {
                    LoadPendingRequests();
                    RenderSchedule();
                    LoadStats();
                }));

                MessageBox.Show(
                    accepted ? $"Booking with {r.ParentName} accepted." : $"Booking with {r.ParentName} declined.",
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Meraki",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Navigation -----

        private void btnNavBabysitterHome_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStats();
                RenderSchedule();
                LoadPendingRequests();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnNavFindParents_Click(object sender, EventArgs e) => Navigation.GoTo(this, new FindParentsForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnMyProfileIcon_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void pnlProfileQuickView_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
