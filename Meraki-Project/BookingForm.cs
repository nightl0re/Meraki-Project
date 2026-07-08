using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class BookingForm : Form
    {
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
        private static readonly Color[] AvatarPalette =
        {
            Color.FromArgb(94, 200, 196),
            Color.FromArgb(244, 168, 124),
            Color.FromArgb(232, 113, 74),
            Color.FromArgb(224, 90, 90),
            Color.FromArgb(255, 209, 102),
        };

        private readonly int? _preselectedBabysitterId;

        private decimal _serviceFee = 2.50m;
        private List<BabysitterInfo> _sitters = new();

        private int _step;
        private DateTime? _selectedDate;
        private string? _selectedTime;
        private string? _selectedDuration;
        private int? _selectedBabysitterId;
        private int _childCount = 1;

        // Guard so we don't react to SelectedIndexChanged while (re)filling combos.
        private bool _fillingDateCombos;

        // Controls are built ONCE and only restyled on selection - rebuilding
        // heavy Guna2 controls inside their own click handlers froze the form.
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
            if (_preselectedBabysitterId.HasValue)
                _selectedBabysitterId = _preselectedBabysitterId;

            try
            {
                _serviceFee = ExtrasRepository.GetServiceFee();
                _sitters = BabysitterRepository.GetActiveBabysitters()
                    .Where(b => b.Available).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading babysitters:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _sitters = new List<BabysitterInfo>();
            }

            FillDateAndTimeCombos();
            BuildDurationButtons();
            GoToStep(0);
        }

        private BabysitterInfo? SelectedSitter =>
            _sitters.FirstOrDefault(b => b.UserId == _selectedBabysitterId);

        // ----- Step 0: date & time (Month / Day / Year + Start Time dropdowns) -----

        private void FillDateAndTimeCombos()
        {
            _fillingDateCombos = true;

            cbMonth.Items.Clear();
            for (int m = 1; m <= 12; m++)
                cbMonth.Items.Add(new DateTime(2000, m, 1).ToString("MMMM"));

            cbYear.Items.Clear();
            cbYear.Items.Add(DateTime.Today.Year.ToString());
            cbYear.Items.Add((DateTime.Today.Year + 1).ToString());

            cbStartTime.Items.Clear();
            foreach (var slot in TimeSlots)
                cbStartTime.Items.Add(slot);

            // Default to today so the parent only has to pick time + duration.
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
            cbYear.SelectedIndex = 0;
            _fillingDateCombos = false;

            FillDayCombo();                       // also sets _selectedDate
            cbDay.SelectedIndex = DateTime.Today.Day - 1;
        }

        // Day list depends on the chosen month/year (28-31 entries).
        private void FillDayCombo()
        {
            _fillingDateCombos = true;
            int month = cbMonth.SelectedIndex + 1;
            int year = int.Parse(cbYear.SelectedItem?.ToString() ?? DateTime.Today.Year.ToString());
            int days = DateTime.DaysInMonth(year, month);

            int previousDay = cbDay.SelectedIndex + 1;
            cbDay.Items.Clear();
            for (int d = 1; d <= days; d++)
                cbDay.Items.Add(d.ToString());
            if (previousDay >= 1)
                cbDay.SelectedIndex = Math.Min(previousDay, days) - 1;
            _fillingDateCombos = false;

            UpdateSelectedDate();
        }

        private void cbDate_Changed(object sender, EventArgs e)
        {
            if (_fillingDateCombos) return;
            if (sender == cbMonth || sender == cbYear)
                FillDayCombo();   // re-fills days, then updates the date
            else
                UpdateSelectedDate();
        }

        private void UpdateSelectedDate()
        {
            if (cbMonth.SelectedIndex < 0 || cbDay.SelectedIndex < 0 || cbYear.SelectedIndex < 0)
            {
                _selectedDate = null;
            }
            else
            {
                var date = new DateTime(
                    int.Parse(cbYear.SelectedItem!.ToString()!),
                    cbMonth.SelectedIndex + 1,
                    cbDay.SelectedIndex + 1);
                _selectedDate = date;
            }
            UpdateContinueAppearance();
        }

        private void cbStartTime_Changed(object sender, EventArgs e)
        {
            _selectedTime = cbStartTime.SelectedIndex >= 0
                ? cbStartTime.SelectedItem!.ToString()
                : null;
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

        // ----- Step 1: babysitter -----

        private void EnsureBabysitterRows()
        {
            if (_sitterRowsBuilt) return;
            _sitterRowsBuilt = true;

            flpBabysitterSelect.SuspendLayout();
            if (_sitters.Count == 0)
            {
                flpBabysitterSelect.Controls.Add(new Label
                {
                    Text = "No available babysitters right now. Please check back later.",
                    Width = 700,
                    Height = 30,
                    ForeColor = TextMuted,
                    Font = new Font("Segoe UI", 9.5F),
                    BackColor = Color.Transparent,
                });
            }
            foreach (var b in _sitters)
                flpBabysitterSelect.Controls.Add(BuildBabysitterChoiceRow(b));
            flpBabysitterSelect.ResumeLayout();
        }

        private Control BuildBabysitterChoiceRow(BabysitterInfo b)
        {
            bool selected = _selectedBabysitterId == b.UserId;
            Color accent = AvatarPalette[b.UserId % AvatarPalette.Length];

            var card = new Guna2Panel
            {
                Width = 860,
                Height = 90,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 14,
                FillColor = selected ? Color.FromArgb(253, 238, 232) : Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };

            var avatar = new Guna2Panel
            {
                BorderRadius = 16,
                FillColor = LightenColor(accent, 0.8),
                BackColor = Color.Transparent,
                Location = new Point(14, 17),
                Size = new Size(56, 56),
            };
            avatar.Controls.Add(new Label
            {
                Text = b.Name.Length > 0 ? b.Name.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accent,
                BackColor = Color.Transparent,
            });

            var nameLabel = new Label
            {
                Text = b.Name,
                Location = new Point(84, 20),
                Size = new Size(400, 22),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            };
            var detailLabel = new Label
            {
                Text = (b.ReviewCount > 0 ? $"★ {b.AvgRating:0.0}" : "★ New") + $"    ${b.HourlyRate:0}/hr",
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
                Visible = selected,
            };

            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailLabel);
            card.Controls.Add(checkLabel);

            _sitterRows[b.UserId] = card;
            _sitterChecks[b.UserId] = checkLabel;

            EventHandler selectHandler = (s, e) => SelectBabysitter(b.UserId);
            card.Click += selectHandler;
            nameLabel.Click += selectHandler;
            detailLabel.Click += selectHandler;
            avatar.Click += selectHandler;

            return card;
        }

        private void SelectBabysitter(int id)
        {
            _selectedBabysitterId = id;
            foreach (var sitterId in _sitterRows.Keys)
            {
                bool sel = sitterId == id;
                _sitterRows[sitterId].FillColor = sel ? Color.FromArgb(253, 238, 232) : Color.White;
                _sitterChecks[sitterId].Visible = sel;
            }
            UpdateContinueAppearance();
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
            var sitter = SelectedSitter;
            DateTime date = _selectedDate ?? DateTime.Today;
            int hours = ParseDurationHours(_selectedDuration);
            decimal rate = sitter?.HourlyRate ?? 0;
            decimal sitterTotal = rate * hours;
            decimal total = sitterTotal + _serviceFee;

            lblSumDate.Text = $"Date:  {date:MMMM d, yyyy}";
            lblSumTime.Text = $"Time:  {_selectedTime} · {_selectedDuration}";
            lblSumBabysitter.Text = $"Babysitter:  {sitter?.Name}";
            lblSumChildren.Text = $"Children:  {_childCount} {(_childCount == 1 ? "child" : "children")}";
            lblSumAddress.Text = $"Address:  {(string.IsNullOrWhiteSpace(tbAddress.Text) ? "Not provided" : tbAddress.Text)}";

            lblCostSitterLine.Text = $"{sitter?.Name} · ${rate:0}/hr × {hours}hr:  ${sitterTotal:0.00}";
            lblCostServiceFee.Text = $"Service fee:  ${_serviceFee:0.00}";
            lblCostTotal.Text = $"Total:  ${total:0.00}";
        }

        private static int ParseDurationHours(string? duration)
        {
            if (string.IsNullOrEmpty(duration)) return 0;
            string digits = new(duration.TakeWhile(char.IsDigit).ToArray());
            return int.TryParse(digits, out int h) ? h : 6;
        }

        private static TimeSpan ParseStartTime(string slot) =>
            DateTime.ParseExact(slot, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

        private void ConfirmBooking()
        {
            var sitter = SelectedSitter;
            if (sitter == null) return;

            DateTime date = _selectedDate ?? DateTime.Today;
            int hours = ParseDurationHours(_selectedDuration);
            decimal total = sitter.HourlyRate * hours + _serviceFee;

            try
            {
                BookingRepository.Create(
                    Session.CurrentUserId, sitter.UserId, date, ParseStartTime(_selectedTime!),
                    hours, _childCount, tbAddress.Text.Trim(), tbNotes.Text.Trim(),
                    sitter.HourlyRate, _serviceFee, total);

                ExtrasRepository.AddNotification(sitter.UserId,
                    $"New booking request from {Session.CurrentUserName} for {date:MMM d}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while saving the booking:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblConfirmedMessage.Text =
                $"Your booking request was sent to {sitter.Name}. You'll see it as confirmed " +
                "once they accept.";
            lblConfirmedDate.Text = $"Date:  {date:MMMM d, yyyy}";
            lblConfirmedTime.Text = $"Time:  {_selectedTime} · {_selectedDuration}";
            lblConfirmedBabysitter.Text = $"Babysitter:  {sitter.Name}";
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
            _selectedDate = DateTime.Today;
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

            FillDateAndTimeCombos();
            cbStartTime.SelectedIndex = -1;
            foreach (var pair in _durationButtons) StyleChoiceButton(pair.Value, false, Teal);
            foreach (var sitterId in _sitterRows.Keys)
            {
                _sitterRows[sitterId].FillColor = Color.White;
                _sitterChecks[sitterId].Visible = false;
            }
            GoToStep(0);
        }

        // ----- Wizard step machine -----

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_step == 0)
            {
                if (!_selectedDate.HasValue)
                {
                    MessageBox.Show("Please pick a date.", "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_selectedDate.Value < DateTime.Today)
                {
                    MessageBox.Show("That date has already passed - please pick today or a future date.",
                        "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void UpdateContinueAppearance()
        {
            bool ready = _step switch
            {
                0 => _selectedDate.HasValue && _selectedTime != null && _selectedDuration != null,
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
