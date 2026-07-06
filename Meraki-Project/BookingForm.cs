using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
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

        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color Teal = Color.FromArgb(94, 200, 196);
        private static readonly Color InputGray = Color.FromArgb(247, 245, 242);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);

        private readonly int? _preselectedBabysitterId;

        private int _step;
        private DateTime _displayedMonth;
        private int? _selectedDay;
        private string? _selectedTime;
        private string? _selectedDuration;
        private int? _selectedBabysitterId;
        private int _childCount = 1;

        // Controls are built ONCE and only restyled on selection. Rebuilding
        // (and especially disposing) dozens of Guna2 buttons on every click is
        // what froze the form before - never do that inside a click handler.
        private readonly Dictionary<int, Label> _dayCells = new();
        private readonly Dictionary<string, Guna2Button> _timeButtons = new();
        private readonly Dictionary<string, Guna2Button> _durationButtons = new();
        private readonly Dictionary<int, Guna2Panel> _sitterRows = new();
        private readonly Dictionary<int, Label> _sitterChecks = new();
        private bool _sitterRowsBuilt;

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

            BuildMonthCalendar();
            BuildTimeSlotButtons();
            BuildDurationButtons();
            GoToStep(0);
        }

        // ----- Step 0: calendar (built once per month, cells are cheap Labels) -----

        private void btnCalPrev_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(-1);
            _selectedDay = null;
            BuildMonthCalendar();
            UpdateContinueAppearance();
        }

        private void btnCalNext_Click(object sender, EventArgs e)
        {
            _displayedMonth = _displayedMonth.AddMonths(1);
            _selectedDay = null;
            BuildMonthCalendar();
            UpdateContinueAppearance();
        }

        private void BuildMonthCalendar()
        {
            tlpBookingCalendar.SuspendLayout();

            // Remove previous month's day cells (everything below the Su..Sa header row).
            for (int i = tlpBookingCalendar.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = tlpBookingCalendar.Controls[i];
                if (tlpBookingCalendar.GetRow(ctrl) > 0)
                {
                    tlpBookingCalendar.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
            _dayCells.Clear();

            lblCalMonthYear.Text = _displayedMonth.ToString("MMMM yyyy");

            int daysInMonth = DateTime.DaysInMonth(_displayedMonth.Year, _displayedMonth.Month);
            int firstDayOfWeek = (int)new DateTime(_displayedMonth.Year, _displayedMonth.Month, 1).DayOfWeek;

            int day = 1;
            for (int row = 1; row <= 6 && day <= daysInMonth; row++)
            {
                int startCol = row == 1 ? firstDayOfWeek : 0;
                for (int col = startCol; col < 7 && day <= daysInMonth; col++)
                {
                    var cell = BuildDayCell(day);
                    _dayCells[day] = cell;
                    tlpBookingCalendar.Controls.Add(cell, col, row);
                    day++;
                }
            }

            tlpBookingCalendar.ResumeLayout();
        }

        private Label BuildDayCell(int day)
        {
            var date = new DateTime(_displayedMonth.Year, _displayedMonth.Month, day);
            bool isPast = date.Date < DateTime.Today;

            var cell = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(3),
                Text = day.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F),
                Cursor = isPast ? Cursors.Default : Cursors.Hand,
            };
            StyleDayCell(cell, day, isPast);

            if (!isPast)
            {
                // Selection only RESTYLES the two affected cells - no rebuild, no dispose.
                cell.Click += (s, e) => SelectDay(day);
            }
            return cell;
        }

        private void SelectDay(int day)
        {
            int? previous = _selectedDay;
            _selectedDay = day;

            if (previous.HasValue && _dayCells.TryGetValue(previous.Value, out var prevCell))
                StyleDayCell(prevCell, previous.Value, isPast: false);
            if (_dayCells.TryGetValue(day, out var newCell))
                StyleDayCell(newCell, day, isPast: false);

            UpdateContinueAppearance();
        }

        private void StyleDayCell(Label cell, int day, bool isPast)
        {
            bool selected = _selectedDay == day;
            if (selected)
            {
                cell.BackColor = Coral;
                cell.ForeColor = Color.White;
                cell.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else
            {
                cell.BackColor = isPast ? Color.White : InputGray;
                cell.ForeColor = isPast ? Color.FromArgb(210, 205, 200) : TextDark;
                cell.Font = new Font("Segoe UI", 9F);
            }
        }

        // ----- Step 0: time slots + duration (built once, restyled on click) -----

        private void BuildTimeSlotButtons()
        {
            flpTimeSlots.SuspendLayout();
            flpTimeSlots.Controls.Clear();
            _timeButtons.Clear();

            foreach (var slot in TimeSlots)
            {
                var btn = new Guna2Button
                {
                    Text = slot,
                    Size = new Size(140, 40),
                    Margin = new Padding(4),
                    BorderRadius = 8,
                    Font = new Font("Segoe UI", 8.5F),
                    BackColor = Color.White,
                };
                string captured = slot;
                btn.Click += (s, e) => SelectTime(captured);
                _timeButtons[slot] = btn;
                flpTimeSlots.Controls.Add(btn);
                StyleChoiceButton(btn, selected: false, Coral);
            }
            flpTimeSlots.ResumeLayout();
        }

        private void SelectTime(string slot)
        {
            _selectedTime = slot;
            foreach (var pair in _timeButtons)
                StyleChoiceButton(pair.Value, pair.Key == slot, Coral);
            UpdateContinueAppearance();
        }

        private void BuildDurationButtons()
        {
            flpDurations.SuspendLayout();
            flpDurations.Controls.Clear();
            _durationButtons.Clear();

            foreach (var d in Durations)
            {
                var btn = new Guna2Button
                {
                    Text = d,
                    Size = new Size(120, 40),
                    Margin = new Padding(4),
                    BorderRadius = 8,
                    Font = new Font("Segoe UI", 8.5F),
                    BackColor = Color.White,
                };
                string captured = d;
                btn.Click += (s, e) => SelectDuration(captured);
                _durationButtons[d] = btn;
                flpDurations.Controls.Add(btn);
                StyleChoiceButton(btn, selected: false, Teal);
            }
            flpDurations.ResumeLayout();
        }

        private void SelectDuration(string duration)
        {
            _selectedDuration = duration;
            foreach (var pair in _durationButtons)
                StyleChoiceButton(pair.Value, pair.Key == duration, Teal);
            UpdateContinueAppearance();
        }

        private static void StyleChoiceButton(Guna2Button btn, bool selected, Color accent)
        {
            btn.FillColor = selected ? accent : InputGray;
            btn.ForeColor = selected ? Color.White : TextDark;
            btn.Font = new Font("Segoe UI", 8.5F, selected ? FontStyle.Bold : FontStyle.Regular);
        }

        // ----- Step 1: babysitter (rows built once, restyled on selection) -----

        private void EnsureBabysitterRows()
        {
            if (_sitterRowsBuilt) return;
            _sitterRowsBuilt = true;

            flpBabysitterSelect.SuspendLayout();
            foreach (var b in MockData.Babysitters)
                flpBabysitterSelect.Controls.Add(BuildBabysitterChoiceRow(b));
            flpBabysitterSelect.ResumeLayout();
        }

        private Control BuildBabysitterChoiceRow(Babysitter b)
        {
            var card = new Guna2Panel
            {
                Width = 860,
                Height = 90,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 14,
                FillColor = Color.White,
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
                ForeColor = b.Available ? TextDark : Color.FromArgb(153, 153, 153),
                BackColor = Color.Transparent,
            };
            var detailLabel = new Label
            {
                Text = $"★ {b.Rating:0.0}    ${b.HourlyRate:0}/hr",
                Location = new Point(84, 46),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };
            var checkLabel = new Label
            {
                Text = "✓",
                Location = new Point(800, 30),
                Size = new Size(30, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Coral,
                BackColor = Color.Transparent,
                Visible = false,
            };

            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailLabel);
            card.Controls.Add(checkLabel);

            _sitterRows[b.Id] = card;
            _sitterChecks[b.Id] = checkLabel;

            if (b.Available)
            {
                EventHandler selectHandler = (s, e) => SelectBabysitter(b.Id);
                card.Click += selectHandler;
                nameLabel.Click += selectHandler;
                detailLabel.Click += selectHandler;
                avatar.Click += selectHandler;
            }

            RestyleSitterRow(b.Id);
            return card;
        }

        private void SelectBabysitter(int id)
        {
            _selectedBabysitterId = id;
            foreach (var sitterId in _sitterRows.Keys)
                RestyleSitterRow(sitterId);
            UpdateContinueAppearance();
        }

        private void RestyleSitterRow(int id)
        {
            bool selected = _selectedBabysitterId == id;
            _sitterRows[id].FillColor = selected ? Color.FromArgb(253, 238, 232) : Color.White;
            _sitterChecks[id].Visible = selected;
        }

        private static Color LightenColor(Color c, double amount)
        {
            int r = (int)(c.R + (255 - c.R) * amount);
            int g = (int)(c.G + (255 - c.G) * amount);
            int b = (int)(c.B + (255 - c.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        // ----- Step 2: details -----

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

        // ----- Step 3: confirm -----

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
            // booking_date, start_time, duration_hours, address, notes, status, ...).
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
            BuildMonthCalendar();
            SelectTime(_selectedTime ?? "");   // clears highlight
            _selectedTime = null;
            SelectDuration(_selectedDuration ?? "");
            _selectedDuration = null;
            foreach (var id in _sitterRows.Keys)
                RestyleSitterRow(id);
            GoToStep(0);
        }

        // ----- Wizard step machine -----

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_step == 0)
            {
                if (!_selectedDay.HasValue)
                {
                    MessageBox.Show("Please pick a date on the calendar.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_selectedTime == null)
                {
                    MessageBox.Show("Please pick a start time.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_selectedDuration == null)
                {
                    MessageBox.Show("Please pick a duration.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GoToStep(1);
            }
            else if (_step == 1)
            {
                if (!_selectedBabysitterId.HasValue)
                {
                    MessageBox.Show("Please choose a babysitter.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GoToStep(2);
            }
            else if (_step == 2)
            {
                if (string.IsNullOrWhiteSpace(tbAddress.Text))
                {
                    MessageBox.Show("Please enter an address.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (step == 1) EnsureBabysitterRows();
            if (step == 3) RenderConfirmSummary();

            btnBack.Visible = step > 0;
            btnContinue.Location = new Point(step > 0 ? 190 : 30, 11);
            btnContinue.Width = step > 0 ? 1280 : 1440;
            btnContinue.Text = step == 3 ? "Confirm Booking" : "Continue >";

            StyleStepCircle(pnlStepCircle1, lblStepNum1, lblStepCaption1, step >= 0, step == 0);
            StyleStepCircle(pnlStepCircle2, lblStepNum2, lblStepCaption2, step >= 1, step == 1);
            StyleStepCircle(pnlStepCircle3, lblStepNum3, lblStepCaption3, step >= 2, step == 2);
            StyleStepCircle(pnlStepCircle4, lblStepNum4, lblStepCaption4, step >= 3, step == 3);
            pnlStepLine1.FillColor = step >= 1 ? Coral : Color.FromArgb(230, 224, 218);
            pnlStepLine2.FillColor = step >= 2 ? Coral : Color.FromArgb(230, 224, 218);
            pnlStepLine3.FillColor = step >= 3 ? Coral : Color.FromArgb(230, 224, 218);

            UpdateContinueAppearance();
        }

        private static void StyleStepCircle(Guna2Panel circle, Label num, Label caption, bool reachedOrCurrent, bool current)
        {
            circle.FillColor = reachedOrCurrent ? Coral : InputGray;
            num.ForeColor = reachedOrCurrent ? Color.White : TextMuted;
            caption.ForeColor = current ? Coral : TextMuted;
            caption.Font = new Font("Segoe UI", 8F, current ? FontStyle.Bold : FontStyle.Regular);
        }

        // The button stays ENABLED so a click can always explain what's missing;
        // only its color hints at readiness.
        private void UpdateContinueAppearance()
        {
            bool ready = _step switch
            {
                0 => _selectedDay.HasValue && _selectedTime != null && _selectedDuration != null,
                1 => _selectedBabysitterId.HasValue,
                _ => true,
            };
            btnContinue.FillColor = ready ? Coral : Color.FromArgb(240, 190, 170);
            btnContinue.ForeColor = Color.White;
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
