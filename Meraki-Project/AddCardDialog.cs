using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Popup where a parent adds a debit/credit card. The full number and CVV
    // are validated here and immediately discarded - only the last 4 digits,
    // brand, holder name, and expiry are saved (see PaymentRepository.AddCard).
    public class AddCardDialog : Form
    {
        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);

        public string Holder { get; private set; } = "";
        public string Last4 { get; private set; } = "";
        public string Brand { get; private set; } = "";
        public int ExpMonth { get; private set; }
        public int ExpYear { get; private set; }

        private readonly Guna2TextBox _tbHolder;
        private readonly Guna2TextBox _tbNumber;
        private readonly Guna2ComboBox _cbMonth;
        private readonly Guna2ComboBox _cbYear;
        private readonly Guna2TextBox _tbCvv;

        public AddCardDialog()
        {
            Text = "Add a Card";
            ClientSize = new Size(460, 420);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(253, 244, 239);

            Controls.Add(MakeCaption("Cardholder Name *", 20));
            _tbHolder = MakeTextBox(44, "Name exactly as printed on the card");
            Controls.Add(_tbHolder);

            Controls.Add(MakeCaption("Card Number *", 100));
            _tbNumber = MakeTextBox(124, "1234 5678 9012 3456");
            _tbNumber.MaxLength = 23;
            Controls.Add(_tbNumber);

            Controls.Add(MakeCaption("Expiry *", 180));
            _cbMonth = MakeCombo(new Point(24, 204), 120);
            for (int m = 1; m <= 12; m++) _cbMonth.Items.Add(m.ToString("00"));
            Controls.Add(_cbMonth);
            _cbYear = MakeCombo(new Point(152, 204), 120);
            for (int y = DateTime.Today.Year; y <= DateTime.Today.Year + 10; y++)
                _cbYear.Items.Add(y.ToString());
            Controls.Add(_cbYear);

            Controls.Add(MakeCaption("CVV *", 260));
            _tbCvv = MakeTextBox(284, "3 or 4 digits");
            _tbCvv.Size = new Size(120, 40);
            _tbCvv.MaxLength = 4;
            _tbCvv.PasswordChar = '●';
            Controls.Add(_tbCvv);

            var note = new Label
            {
                Text = "Only the last 4 digits are stored. Your CVV is never saved.",
                Location = new Point(160, 294),
                Size = new Size(280, 30),
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };
            Controls.Add(note);

            var save = new Guna2Button
            {
                Text = "Save Card",
                Location = new Point(24, 350),
                Size = new Size(240, 46),
                BorderRadius = 10,
                FillColor = Coral,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            save.Click += (s, e) => TrySave();
            Controls.Add(save);

            var cancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(276, 350),
                Size = new Size(160, 46),
                BorderRadius = 10,
                FillColor = Color.White,
                ForeColor = TextMuted,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.Transparent,
            };
            cancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
            Controls.Add(cancel);
        }

        private void TrySave()
        {
            string holder = _tbHolder.Text.Trim();
            string digits = new(_tbNumber.Text.Where(char.IsDigit).ToArray());
            string cvv = _tbCvv.Text.Trim();

            if (holder.Length < 3)
            {
                Warn("Please enter the cardholder's name."); return;
            }
            if (digits.Length < 13 || digits.Length > 19 || !PassesLuhn(digits))
            {
                Warn("That card number doesn't look valid. Please check it."); return;
            }
            if (_cbMonth.SelectedIndex < 0 || _cbYear.SelectedIndex < 0)
            {
                Warn("Please pick the card's expiry month and year."); return;
            }
            int month = _cbMonth.SelectedIndex + 1;
            int year = int.Parse(_cbYear.SelectedItem!.ToString()!);
            if (new DateTime(year, month, 1).AddMonths(1) <= DateTime.Today)
            {
                Warn("This card has already expired."); return;
            }
            if (cvv.Length < 3 || !cvv.All(char.IsDigit))
            {
                Warn("Please enter the 3 or 4 digit CVV."); return;
            }

            Holder = holder;
            Last4 = digits[^4..];
            Brand = DetectBrand(digits);
            ExpMonth = month;
            ExpYear = year;
            DialogResult = DialogResult.OK;
        }

        // Standard Luhn checksum - catches typos in the card number.
        private static bool PassesLuhn(string digits)
        {
            int sum = 0;
            bool doubleIt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int d = digits[i] - '0';
                if (doubleIt) { d *= 2; if (d > 9) d -= 9; }
                sum += d;
                doubleIt = !doubleIt;
            }
            return sum % 10 == 0;
        }

        private static string DetectBrand(string digits) => digits[0] switch
        {
            '4' => "Visa",
            '5' => "Mastercard",
            '3' => "Amex",
            '6' => "Discover",
            _ => "Card",
        };

        private static void Warn(string message) =>
            MessageBox.Show(message, "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static Label MakeCaption(string text, int y) => new()
        {
            Text = text,
            Location = new Point(24, y),
            Size = new Size(300, 20),
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ForeColor = TextDark,
            BackColor = Color.Transparent,
        };

        private static Guna2TextBox MakeTextBox(int y, string placeholder)
        {
            var tb = new Guna2TextBox
            {
                Location = new Point(24, y),
                Size = new Size(412, 40),
                BorderRadius = 10,
                FillColor = Color.White,
                PlaceholderText = placeholder,
                Font = new Font("Segoe UI", 9.5F),
            };
            tb.FocusedState.BorderColor = Coral;
            return tb;
        }

        private static Guna2ComboBox MakeCombo(Point location, int width)
        {
            return new Guna2ComboBox
            {
                Location = location,
                Size = new Size(width, 40),
                BorderRadius = 8,
                FillColor = Color.White,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = TextDark,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList,
                ItemHeight = 30,
                BackColor = Color.Transparent,
            };
        }
    }
}
