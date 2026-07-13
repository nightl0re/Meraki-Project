using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Meraki_Project
{
    // A tidy "booking receipt" popup shown when a booking card is clicked.
    // Built entirely in code - no Designer file needed.
    public class ReceiptDialog : Form
    {
        private static readonly Color Coral = Color.FromArgb(232, 113, 74);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);

        // showParentSide = true  -> "Babysitter: ..." (parent is reading it)
        // showParentSide = false -> "Parent: ..."     (babysitter is reading it)
        public ReceiptDialog(BookingInfo b, bool showParentSide)
        {
            Text = "Booking Receipt";
            ClientSize = new Size(440, 520);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(253, 244, 239);

            Guna2Panel header = new Guna2Panel
            {
                Location = new Point(0, 0),
                Size = new Size(440, 96),
                FillColor = Coral,
                BorderRadius = 0,
            };
            header.Controls.Add(new Label
            {
                Text = "Meraki",
                Location = new Point(24, 18),
                Size = new Size(392, 26),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
            });
            header.Controls.Add(new Label
            {
                Text = $"Booking #{b.BookingId}  ·  {StatusText(b.Status)}",
                Location = new Point(24, 50),
                Size = new Size(392, 22),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
            });
            Controls.Add(header);

            int y = 120;
            AddRow("Date", $"{b.Date:dddd, MMMM d, yyyy}", ref y);
            AddRow("Time", b.TimeRangeText, ref y);
            AddRow(showParentSide ? "Babysitter" : "Parent",
                   showParentSide ? b.SitterName : b.ParentName, ref y);
            AddRow("Children", $"{b.ChildrenCount} {(b.ChildrenCount == 1 ? "child" : "children")}", ref y);
            AddRow("Address", string.IsNullOrWhiteSpace(b.Address) ? "Not provided" : b.Address, ref y);
            if (!string.IsNullOrWhiteSpace(b.Notes))
                AddRow("Notes", b.Notes, ref y);

            y += 8;
            Panel divider = new Panel { Location = new Point(24, y), Size = new Size(392, 1), BackColor = Color.FromArgb(230, 224, 218) };
            Controls.Add(divider);
            y += 14;

            AddRow("Rate", $"${b.HourlyRate:0.00}/hr × {b.DurationHours}h", ref y);
            AddRow("Service fee", $"${b.ServiceFee:0.00}", ref y);

            Label totalLabel = new Label
            {
                Text = "Total",
                Location = new Point(24, y),
                Size = new Size(150, 26),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            };
            Label totalValue = new Label
            {
                Text = $"${b.Total:0.00}",
                Location = new Point(180, y),
                Size = new Size(236, 26),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Coral,
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent,
            };
            Controls.Add(totalLabel);
            Controls.Add(totalValue);
            y += 34;

            // Payment line describing where this booking is in the pay-after-completion
            // flow. Older bookings from before the payment feature simply have none.
            try
            {
                (string Status, string Brand, string Last4)? payment =
                    PaymentRepository.GetForBooking(b.BookingId);
                if (payment != null)
                {
                    (string payStatus, string brand, string last4) = payment.Value;
                    string payText = payStatus switch
                    {
                        "authorized" => $"{brand} •••• {last4} on file - billed after the job is completed",
                        "awaiting_confirm" => "Job marked done - waiting for the parent to confirm",
                        "approved" => "Approved by the parent - awaiting admin payout",
                        "paid" => $"Paid with {brand} •••• {last4}",
                        "discarded" => "No charge was made",
                        _ => "",
                    };
                    Controls.Add(new Label
                    {
                        Text = payText,
                        Location = new Point(24, y),
                        Size = new Size(392, 22),
                        Font = new Font("Segoe UI", 8.5F),
                        ForeColor = payStatus == "paid" ? Color.FromArgb(34, 120, 80) : TextMuted,
                        BackColor = Color.Transparent,
                    });
                }
            }
            catch { /* the receipt still works without the payment line */ }

            Guna2Button close = new Guna2Button
            {
                Text = "Close",
                Location = new Point(24, 456),
                Size = new Size(392, 46),
                BorderRadius = 10,
                FillColor = Coral,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            close.Click += (s, e) => DialogResult = DialogResult.OK;
            Controls.Add(close);
        }

        private void AddRow(string label, string value, ref int y)
        {
            Controls.Add(new Label
            {
                Text = label,
                Location = new Point(24, y),
                Size = new Size(130, 22),
                Font = new Font("Segoe UI", 9F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            });
            Controls.Add(new Label
            {
                Text = value,
                Location = new Point(160, y),
                Size = new Size(256, 22),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = TextDark,
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent,
            });
            y += 30;
        }

        private static string StatusText(string status) => status switch
        {
            "pending" => "Pending confirmation",
            "confirmed" => "Confirmed",
            "completed" => "Completed",
            "declined" => "Declined",
            "cancelled" => "Cancelled",
            _ => status,
        };
    }
}
