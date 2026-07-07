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
        private static readonly Color[] CalendarPalette =
        {
            Color.FromArgb(232, 113, 74),
            Color.FromArgb(94, 200, 196),
            Color.FromArgb(255, 209, 102),
            Color.FromArgb(224, 90, 90),
            Color.FromArgb(244, 168, 124),
        };

        private DateTime _displayedMonth;
        private Dictionary<int, BookingInfo> _calendarBookings = new();
        private List<NotificationInfo> _notifications = new();
        private List<BookingInfo> _pendingRequests = new();

        private readonly ToolTip _calendarToolTip = new();

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

            _displayedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            try
            {
                LoadStats();
                RenderCalendar();
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

        // ----- Calendar (real bookings of the shown month) -----

        private void btnCalPrev_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(-1);
            try { RenderCalendar(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCalNext_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(1);
            try { RenderCalendar(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RenderCalendar()
        {
            _calendarBookings = BookingRepository.GetMonthCalendar(
                Session.CurrentUserId, _displayedMonth.Year, _displayedMonth.Month);

            tlpCalendar.SuspendLayout();
            for (int i = tlpCalendar.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = tlpCalendar.Controls[i];
                if (tlpCalendar.GetRow(ctrl) > 0)
                {
                    tlpCalendar.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            lblCalMonthYear.Text = _displayedMonth.ToString("MMMM yyyy");

            int daysInMonth = DateTime.DaysInMonth(_displayedMonth.Year, _displayedMonth.Month);
            int firstDayOfWeek = (int)new DateTime(_displayedMonth.Year, _displayedMonth.Month, 1).DayOfWeek;

            int day = 1;
            for (int row = 1; row <= 6 && day <= daysInMonth; row++)
            {
                int startCol = row == 1 ? firstDayOfWeek : 0;
                for (int col = startCol; col < 7 && day <= daysInMonth; col++)
                {
                    tlpCalendar.Controls.Add(BuildCalendarDayCell(day), col, row);
                    day++;
                }
            }
            tlpCalendar.ResumeLayout();
        }

        private Control BuildCalendarDayCell(int day)
        {
            var cell = new Panel { Dock = DockStyle.Fill, Margin = new Padding(2) };
            bool hasBooking = _calendarBookings.TryGetValue(day, out var booking);
            Color accent = CalendarPalette[day % CalendarPalette.Length];
            cell.BackColor = hasBooking ? LightenColor(accent, 0.85) : Color.Transparent;

            var dayLabel = new Label
            {
                Text = day.ToString(),
                Dock = DockStyle.Top,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F, hasBooking ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = hasBooking ? accent : Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            cell.Controls.Add(dayLabel);

            if (hasBooking)
            {
                var timeLabel = new Label
                {
                    Text = booking!.TimeRangeShort,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Segoe UI", 6.5F),
                    ForeColor = accent,
                    BackColor = Color.Transparent,
                };
                cell.Controls.Add(timeLabel);
                timeLabel.BringToFront();
                string tip = $"{booking.ParentName} - {booking.TimeRangeText}";
                _calendarToolTip.SetToolTip(cell, tip);
                _calendarToolTip.SetToolTip(timeLabel, tip);
            }

            return cell;
        }

        private static Color LightenColor(Color c, double amount)
        {
            int r = (int)(c.R + (255 - c.R) * amount);
            int g = (int)(c.G + (255 - c.G) * amount);
            int b = (int)(c.B + (255 - c.B) * amount);
            return Color.FromArgb(r, g, b);
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

            card.Controls.Add(acceptBtn);
            card.Controls.Add(declineBtn);
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
                    RenderCalendar();
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
                RenderCalendar();
                LoadPendingRequests();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

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
