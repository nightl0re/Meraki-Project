using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class BookingForm : Form
    {
        private const double ServiceFee = 2.50;
        private static readonly string[] TimeSlots =
        {
            "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "2:00 PM", "3:00 PM",
            "4:00 PM", "5:00 PM", "6:00 PM", "7:00 PM", "8:00 PM",
        };
        private static readonly string[] Durations = { "2 hours", "3 hours", "4 hours", "5 hours", "6+ hours" };

        private readonly int? _preselectedBabysitterId;

        private int _step;
        private DateTime _displayedMonth;
        private int? _selectedDay;
        private string? _selectedTime;
        private string? _selectedDuration;
        private int? _selectedBabysitterId;
        private int _childCount = 1;

        public BookingForm() : this(null) { }

        public BookingForm(int? preselectedBabysitterId)
        {
            InitializeComponent();
            _preselectedBabysitterId = preselectedBabysitterId;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            _displayedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            if (_preselectedBabysitterId.HasValue)
                _selectedBabysitterId = _preselectedBabysitterId;

            RenderCalendar();
            GoToStep(0);
        }

        // ----- Calendar (step 0) -----

        private void btnCalPrev_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(-1);
            ResetDateTimeSelection();
            RenderCalendar();
        }

        private void btnCalNext_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(1);
            ResetDateTimeSelection();
            RenderCalendar();
        }

        private void ResetDateTimeSelection()
        {
            _selectedDay = null;
            _selectedTime = null;
            _selectedDuration = null;
            pnlTimeSlotsCard.Visible = false;
            pnlDurationCard.Visible = false;
            UpdateContinueEnabled();
        }

        private void RenderCalendar()
        {
            for (int i = tlpBookingCalendar.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = tlpBookingCalendar.Controls[i];
                if (tlpBookingCalendar.GetRow(ctrl) > 0)
                {
                    tlpBookingCalendar.Controls.Remove(ctrl);
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
                    tlpBookingCalendar.Controls.Add(BuildDayButton(day), col, row);
                    day++;
                }
            }
        }

        private Control BuildDayButton(int day)
        {
            var date = new DateTime(_displayedMonth.Year, _displayedMonth.Month, day);
            bool isPast = date.Date < DateTime.Today;
            bool isSelected = _selectedDay == day;

            var btn = new Guna2Button
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(2),
                Text = day.ToString(),
                BorderRadius = 8,
                Font = new Font("Segoe UI", 8.5F, isSelected ? FontStyle.Bold : FontStyle.Regular),
                Enabled = !isPast,
                BackColor = Color.White,
            };

            if (isSelected)
            {
                btn.FillColor = Color.FromArgb(232, 113, 74);
                btn.ForeColor = Color.White;
            }
            else if (isPast)
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.FromArgb(200, 200, 200);
            }
            else
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.FromArgb(60, 50, 45);
                btn.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            }

            btn.Click += (s, e) =>
            {
                _selectedDay = day;
                RenderCalendar();
                RenderTimeSlots();
                UpdateContinueEnabled();
            };
            return btn;
        }

        private void RenderTimeSlots()
        {
            pnlTimeSlotsCard.Visible = _selectedDay.HasValue;
            if (!_selectedDay.HasValue) return;

            flpTimeSlots.SuspendLayout();
            flpTimeSlots.Controls.Clear();
            foreach (var slot in TimeSlots)
            {
                bool selected = _selectedTime == slot;
                var btn = new Guna2Button
                {
                    Text = slot,
                    Size = new Size(96, 34),
                    Margin = new Padding(4),
                    BorderRadius = 8,
                    FillColor = selected ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242),
                    ForeColor = selected ? Color.White : Color.FromArgb(60, 50, 45),
                    Font = new Font("Segoe UI", 8F, selected ? FontStyle.Bold : FontStyle.Regular),
                    BackColor = Color.White,
                };
                btn.Click += (s, e) =>
                {
                    _selectedTime = slot;
                    RenderTimeSlots();
                    RenderDurations();
                    UpdateContinueEnabled();
                };
                flpTimeSlots.Controls.Add(btn);
            }
            flpTimeSlots.ResumeLayout();
        }

        private void RenderDurations()
        {
            pnlDurationCard.Visible = _selectedTime != null;
            if (_selectedTime == null) return;

            flpDurations.SuspendLayout();
            flpDurations.Controls.Clear();
            foreach (var d in Durations)
            {
                bool selected = _selectedDuration == d;
                var btn = new Guna2Button
                {
                    Text = d,
                    Size = new Size(110, 34),
                    Margin = new Padding(4),
                    BorderRadius = 8,
                    FillColor = selected ? Color.FromArgb(94, 200, 196) : Color.FromArgb(247, 245, 242),
                    ForeColor = selected ? Color.White : Color.FromArgb(60, 50, 45),
                    Font = new Font("Segoe UI", 8F, selected ? FontStyle.Bold : FontStyle.Regular),
                    BackColor = Color.White,
                };
                btn.Click += (s, e) =>
                {
                    _selectedDuration = d;
                    RenderDurations();
                    UpdateContinueEnabled();
                };
                flpDurations.Controls.Add(btn);
            }
            flpDurations.ResumeLayout();
        }

        // ----- Babysitter choice (step 1) -----

        private void RenderBabysitterChoices()
        {
            flpBabysitterSelect.SuspendLayout();
            flpBabysitterSelect.Controls.Clear();
            foreach (var b in MockData.Babysitters)
                flpBabysitterSelect.Controls.Add(BuildBabysitterChoiceRow(b));
            flpBabysitterSelect.ResumeLayout();
        }

        private Control BuildBabysitterChoiceRow(Babysitter b)
        {
            bool selected = _selectedBabysitterId == b.Id;

            var card = new Guna2Panel
            {
                Width = 860,
                Height = 90,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 14,
                // Tint the whole card when selected - uses only the FillColor/BackColor
                // properties proven everywhere else in the project.
                FillColor = selected ? Color.FromArgb(253, 238, 232) : Color.White,
                BackColor = Color.Transparent,
                Cursor = b.Available ? Cursors.Hand : Cursors.No,
            };

            var avatar = new Guna2Panel
            {
                BorderRadius = 16,
                FillColor = LightenColor(b.Color, 0.8),
                BackColor = Color.Transparent,
                Location = new Point(14, 17),
                Size = new Size(56, 56),
            };
            avatar.Controls.Add(new Label
            {
                Text = b.Avatar,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = b.Color,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.Name + (b.Available ? "" : "  (Unavailable)"),
                Location = new Point(84, 20),
                Size = new Size(400, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = b.Available ? Color.FromArgb(60, 50, 45) : Color.FromArgb(153, 153, 153),
                BackColor = Color.Transparent,
            };
            var detailLabel = new Label
            {
                Text = $"★ {b.Rating:0.0}    ${b.HourlyRate:0}/hr",
                Location = new Point(84, 46),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };

            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailLabel);

            if (selected)
            {
                card.Controls.Add(new Label
                {
                    Text = "✓",
                    Location = new Point(800, 30),
                    Size = new Size(30, 30),
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(232, 113, 74),
                    BackColor = Color.Transparent,
                });
            }

            if (b.Available)
            {
                EventHandler selectHandler = (s, e) =>
                {
                    _selectedBabysitterId = b.Id;
                    RenderBabysitterChoices();
                    UpdateContinueEnabled();
                };
                card.Click += selectHandler;
                nameLabel.Click += selectHandler;
                detailLabel.Click += selectHandler;
                avatar.Click += selectHandler;
            }

            return card;
        }

        private static Color LightenColor(Color c, double amount)
        {
            int r = (int)(c.R + (255 - c.R) * amount);
            int g = (int)(c.G + (255 - c.G) * amount);
            int b = (int)(c.B + (255 - c.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        // ----- Details (step 2) -----

        private void btnDecChildren_Click(object sender, EventArgs e)
        {
            if (_childCount > 1)
            {
                _childCount--;
                lblChildCount.Text = _childCount.ToString();
            }
        }

        private void btnIncChildren_Click(object sender, EventArgs e)
        {
            if (_childCount < 6)
            {
                _childCount++;
                lblChildCount.Text = _childCount.ToString();
            }
        }

        // ----- Confirm (step 3) -----

        private void RenderConfirmSummary()
        {
            var sitter = MockData.Babysitters.FirstOrDefault(b => b.Id == _selectedBabysitterId);
            DateTime date = new(_displayedMonth.Year, _displayedMonth.Month, _selectedDay ?? 1);
            int hours = ParseDurationHours(_selectedDuration);
            double rate = sitter?.HourlyRate ?? 0;
            double sitterTotal = rate * hours;
            double total = sitterTotal + ServiceFee;

            lblSumDate.Text = $"Date:  {date:MMMM d, yyyy}";
            lblSumTime.Text = $"Time:  {_selectedTime} · {_selectedDuration}";
            lblSumBabysitter.Text = $"Babysitter:  {sitter?.Name}";
            lblSumChildren.Text = $"Children:  {_childCount} {(_childCount == 1 ? "child" : "children")}";
            lblSumAddress.Text = $"Address:  {(string.IsNullOrWhiteSpace(tbAddress.Text) ? "Not provided" : tbAddress.Text)}";

            lblCostSitterLine.Text = $"{sitter?.Name} · ${rate:0}/hr × {hours}hr:  ${sitterTotal:0.00}";
            lblCostServiceFee.Text = $"Service fee:  ${ServiceFee:0.00}";
            lblCostTotal.Text = $"Total:  ${total:0.00}";
        }

        private static int ParseDurationHours(string? duration)
        {
            if (string.IsNullOrEmpty(duration)) return 0;
            string digits = new(duration.TakeWhile(char.IsDigit).ToArray());
            return int.TryParse(digits, out int h) ? h : 6;
        }

        private void ConfirmBooking()
        {
            // TODO (Phase 2): INSERT INTO bookings (parent_user_id, babysitter_user_id,
            // booking_date, start_time, duration_hours, address, notes, status, ...)
            // instead of just switching to the static confirmation screen below.
            var sitter = MockData.Babysitters.FirstOrDefault(b => b.Id == _selectedBabysitterId);
            DateTime date = new(_displayedMonth.Year, _displayedMonth.Month, _selectedDay ?? 1);
            int hours = ParseDurationHours(_selectedDuration);
            double total = (sitter?.HourlyRate ?? 0) * hours + ServiceFee;

            lblConfirmedMessage.Text =
                $"Your booking with {sitter?.Name} has been sent successfully. You'll receive a confirmation shortly.";
            lblConfirmedDate.Text = $"Date:  {date:MMMM d, yyyy}";
            lblConfirmedTime.Text = $"Time:  {_selectedTime} · {_selectedDuration}";
            lblConfirmedBabysitter.Text = $"Babysitter:  {sitter?.Name}";
            lblConfirmedTotal.Text = $"Total:  ${total:0.00}";

            pnlStepDateTime.Visible = false;
            pnlStepBabysitter.Visible = false;
            pnlStepDetails.Visible = false;
            pnlStepConfirm.Visible = false;
            pnlBottomBar.Visible = false;
            lblPageTitle.Visible = false;
            lblPageSubtitle.Visible = false;
            SetWizardChromeVisible(false);

            pnlConfirmationScreen.Visible = true;
            pnlConfirmationScreen.BringToFront();
        }

        private void SetWizardChromeVisible(bool visible)
        {
            pnlStepCircle1.Visible = visible;
            pnlStepCircle2.Visible = visible;
            pnlStepCircle3.Visible = visible;
            pnlStepCircle4.Visible = visible;
            lblStepCaption1.Visible = visible;
            lblStepCaption2.Visible = visible;
            lblStepCaption3.Visible = visible;
            lblStepCaption4.Visible = visible;
            pnlStepLine1.Visible = visible;
            pnlStepLine2.Visible = visible;
            pnlStepLine3.Visible = visible;
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ParentDashboardForm());

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            _selectedDay = null;
            _selectedTime = null;
            _selectedDuration = null;
            _selectedBabysitterId = null;
            _childCount = 1;
            tbAddress.Text = "";
            tbNotes.Text = "";
            lblChildCount.Text = "1";

            pnlConfirmationScreen.Visible = false;
            lblPageTitle.Visible = true;
            lblPageSubtitle.Visible = true;
            pnlBottomBar.Visible = true;
            SetWizardChromeVisible(true);

            _displayedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            RenderCalendar();
            GoToStep(0);
        }

        // ----- Wizard step machine -----

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_step == 0)
            {
                if (!_selectedDay.HasValue || _selectedTime == null || _selectedDuration == null)
                {
                    MessageBox.Show("Please select a date, time, and duration.", "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GoToStep(1);
            }
            else if (_step == 1)
            {
                if (!_selectedBabysitterId.HasValue)
                {
                    MessageBox.Show("Please choose a babysitter.", "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GoToStep(2);
            }
            else if (_step == 2)
            {
                if (string.IsNullOrWhiteSpace(tbAddress.Text))
                {
                    MessageBox.Show("Please enter an address.", "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GoToStep(3);
            }
            else
            {
                ConfirmBooking();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_step > 0)
                GoToStep(_step - 1);
        }

        private void GoToStep(int step)
        {
            _step = step;

            pnlStepDateTime.Visible = step == 0;
            pnlStepBabysitter.Visible = step == 1;
            pnlStepDetails.Visible = step == 2;
            pnlStepConfirm.Visible = step == 3;

            btnBack.Visible = step > 0;
            btnContinue.Location = new Point(step > 0 ? 190 : 30, 11);
            btnContinue.Width = step > 0 ? 1280 : 1440;
            btnContinue.Text = step == 3 ? "Confirm Booking" : "Continue >";

            StyleStepCircle(pnlStepCircle1, lblStepNum1, lblStepCaption1, step >= 0, step == 0);
            StyleStepCircle(pnlStepCircle2, lblStepNum2, lblStepCaption2, step >= 1, step == 1);
            StyleStepCircle(pnlStepCircle3, lblStepNum3, lblStepCaption3, step >= 2, step == 2);
            StyleStepCircle(pnlStepCircle4, lblStepNum4, lblStepCaption4, step >= 3, step == 3);
            pnlStepLine1.FillColor = step >= 1 ? Color.FromArgb(232, 113, 74) : Color.FromArgb(230, 224, 218);
            pnlStepLine2.FillColor = step >= 2 ? Color.FromArgb(232, 113, 74) : Color.FromArgb(230, 224, 218);
            pnlStepLine3.FillColor = step >= 3 ? Color.FromArgb(232, 113, 74) : Color.FromArgb(230, 224, 218);

            if (step == 0) RenderTimeSlots();
            if (step == 1) RenderBabysitterChoices();
            if (step == 3) RenderConfirmSummary();

            UpdateContinueEnabled();
        }

        private static void StyleStepCircle(Guna2Panel circle, Label num, Label caption, bool reachedOrCurrent, bool current)
        {
            circle.FillColor = reachedOrCurrent ? Color.FromArgb(232, 113, 74) : Color.FromArgb(247, 245, 242);
            num.ForeColor = reachedOrCurrent ? Color.White : Color.FromArgb(154, 136, 128);
            caption.ForeColor = current ? Color.FromArgb(232, 113, 74) : Color.FromArgb(154, 136, 128);
            caption.Font = new Font("Segoe UI", 8F, current ? FontStyle.Bold : FontStyle.Regular);
        }

        private void UpdateContinueEnabled()
        {
            bool enabled = _step switch
            {
                0 => _selectedDay.HasValue && _selectedTime != null && _selectedDuration != null,
                1 => _selectedBabysitterId.HasValue,
                _ => true,
            };
            btnContinue.Enabled = enabled;
            btnContinue.FillColor = enabled ? Color.FromArgb(232, 113, 74) : Color.FromArgb(229, 231, 235);
            btnContinue.ForeColor = enabled ? Color.White : Color.FromArgb(170, 170, 170);
        }

        // ----- Navigation -----

        private void btnNavParentHome_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ParentDashboardForm());

        private void btnNavFindBabysitter_Click(object sender, EventArgs e) => Navigation.GoTo(this, new SearchBabysitterForm());

        private void btnNavBookNow_Click(object sender, EventArgs e)
        {
            // Already here - no-op.
        }

        private void btnNavMyProfile_Click(object sender, EventArgs e) => Navigation.GoTo(this, new ProfileForm());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
