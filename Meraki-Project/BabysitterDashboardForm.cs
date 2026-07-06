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
        private sealed class NotificationItem
        {
            public string Message = "";
            public string Time = "";
            public bool Unread;
        }

        private sealed class PendingRequest
        {
            public string Family = "";
            public string Date = "";
            public string Time = "";
            public int Children;
            public string Rate = "";
        }

        // ----- Mock data - all of this becomes real queries in Phase 2 -----

        private DateTime _displayedMonth;

        // Keyed by day-of-month; same fixed set of "example bookings" regardless of
        // which month is showing, purely so the calendar isn't empty in the demo.
        // TODO (Phase 2): `SELECT booking_date, ... FROM bookings WHERE babysitter_user_id = ...`
        private readonly Dictionary<int, (string Family, string Time, Color Color)> _mockCalendarBookings = new()
        {
            { 3, ("Mitchell Family", "6-10 PM", Color.FromArgb(232, 113, 74)) },
            { 8, ("Chen Family", "3-7 PM", Color.FromArgb(94, 200, 196)) },
            { 12, ("Reynolds Family", "5-9 PM", Color.FromArgb(255, 209, 102)) },
            { 17, ("Thompson Family", "7-11 PM", Color.FromArgb(224, 90, 90)) },
            { 22, ("Park Family", "2-6 PM", Color.FromArgb(244, 168, 124)) },
            { 28, ("Wallace Family", "6-10 PM", Color.FromArgb(94, 200, 196)) },
        };

        private readonly List<NotificationItem> _notifications = new()
        {
            new NotificationItem { Message = "New booking request from Mitchell Family", Time = "5 min ago", Unread = true },
            new NotificationItem { Message = "Sarah Mitchell left you a 5-star review!", Time = "2 hrs ago", Unread = true },
            new NotificationItem { Message = "Payment of $80 received from Chen Family", Time = "Yesterday", Unread = false },
            new NotificationItem { Message = "Upcoming booking tomorrow at 3:00 PM", Time = "Yesterday", Unread = false },
        };

        private readonly List<PendingRequest> _pendingRequests = new()
        {
            new PendingRequest { Family = "Nelson Family", Date = "Jun 20", Time = "6-10 PM", Children = 2, Rate = "$18/hr" },
            new PendingRequest { Family = "Gomez Family", Date = "Jun 23", Time = "3-8 PM", Children = 1, Rate = "$18/hr" },
        };

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
            RenderCalendar();
            RenderPendingRequests();
        }

        // ----- Calendar -----

        private void btnCalPrev_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(-1);
            RenderCalendar();
        }

        private void btnCalNext_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(1);
            RenderCalendar();
        }

        private void RenderCalendar()
        {
            // Remove every previously-generated day cell (anything below the Sun..Sat
            // header row) before drawing the newly selected month.
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
            int firstDayOfWeek = (int)new DateTime(_displayedMonth.Year, _displayedMonth.Month, 1).DayOfWeek; // 0 = Sunday

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
        }

        private Control BuildCalendarDayCell(int day)
        {
            var cell = new Panel { Dock = DockStyle.Fill, Margin = new Padding(2) };
            bool hasBooking = _mockCalendarBookings.TryGetValue(day, out var booking);
            cell.BackColor = hasBooking ? LightenColor(booking.Color, 0.85) : Color.Transparent;

            var dayLabel = new Label
            {
                Text = day.ToString(),
                Dock = DockStyle.Top,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F, hasBooking ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = hasBooking ? booking.Color : Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            cell.Controls.Add(dayLabel);

            if (hasBooking)
            {
                var timeLabel = new Label
                {
                    Text = booking.Time,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Segoe UI", 6.5F),
                    ForeColor = booking.Color,
                    BackColor = Color.Transparent,
                };
                cell.Controls.Add(timeLabel);
                timeLabel.BringToFront();
                _calendarToolTip.SetToolTip(cell, $"{booking.Family} - {booking.Time}");
                _calendarToolTip.SetToolTip(timeLabel, $"{booking.Family} - {booking.Time}");
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
                RenderNotifications();
            }
        }

        private void RenderNotifications()
        {
            flpNotificationsList.Controls.Clear();
            foreach (var n in _notifications)
                flpNotificationsList.Controls.Add(BuildNotificationRow(n));
        }

        private Control BuildNotificationRow(NotificationItem n)
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
                Text = n.Time,
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
            foreach (var n in _notifications)
                n.Unread = false;
            RenderNotifications();
        }

        // ----- Pending requests -----

        private void RenderPendingRequests()
        {
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
                return;
            }

            foreach (var r in _pendingRequests.ToList())
                flpPendingRequests.Controls.Add(BuildPendingRequestCard(r));
        }

        private Control BuildPendingRequestCard(PendingRequest r)
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
                Text = r.Family,
                Location = new Point(12, 8),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = $"{r.Date}  ·  {r.Time}",
                Location = new Point(12, 30),
                Size = new Size(300, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            });
            card.Controls.Add(new Label
            {
                Text = $"{r.Children} {(r.Children == 1 ? "child" : "children")}  ·  {r.Rate}",
                Location = new Point(12, 48),
                Size = new Size(300, 18),
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

        private void RespondToRequest(PendingRequest r, bool accepted)
        {
            // TODO (Phase 2): UPDATE bookings SET status = 'confirmed'/'declined'
            // WHERE booking_id = ... instead of just removing it from the in-memory list.
            _pendingRequests.Remove(r);
            RenderPendingRequests();
            MessageBox.Show(
                accepted ? $"Booking with {r.Family} accepted." : $"Booking with {r.Family} declined.",
                "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ----- Navigation -----

        private void btnNavBabysitterHome_Click(object sender, EventArgs e)
        {
            // Already home - refresh the data on this same form.
            RenderCalendar();
            RenderPendingRequests();
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
