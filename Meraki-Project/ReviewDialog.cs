using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Small popup a parent uses to rate a completed booking (1-5 stars + comment).
    // Built entirely in code - no Designer file needed for a dialog this small.
    public class ReviewDialog : Form
    {
        public int Rating { get; private set; }
        public string Comment => _tbComment.Text.Trim();

        private readonly Guna2Button[] _stars = new Guna2Button[5];
        private readonly Guna2TextBox _tbComment;

        public ReviewDialog(string babysitterName)
        {
            Text = "Leave a Review";
            ClientSize = new Size(460, 330);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(253, 244, 239);

            var title = new Label
            {
                Text = $"How was {babysitterName}?",
                Location = new Point(24, 20),
                Size = new Size(412, 28),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 50, 45),
                BackColor = Color.Transparent,
            };
            Controls.Add(title);

            for (int i = 0; i < 5; i++)
            {
                int starValue = i + 1;
                var star = new Guna2Button
                {
                    Text = "☆",
                    Location = new Point(24 + i * 64, 60),
                    Size = new Size(56, 56),
                    BorderRadius = 10,
                    FillColor = Color.White,
                    ForeColor = Color.FromArgb(200, 190, 185),
                    Font = new Font("Segoe UI", 20F),
                    BackColor = Color.Transparent,
                };
                star.Click += (s, e) => SetRating(starValue);
                _stars[i] = star;
                Controls.Add(star);
            }

            var commentCaption = new Label
            {
                Text = "Your comment (optional)",
                Location = new Point(24, 132),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(154, 136, 128),
                BackColor = Color.Transparent,
            };
            Controls.Add(commentCaption);

            _tbComment = new Guna2TextBox
            {
                Location = new Point(24, 156),
                Size = new Size(412, 90),
                Multiline = true,
                BorderRadius = 10,
                FillColor = Color.White,
                PlaceholderText = "Tell other parents about your experience...",
                Font = new Font("Segoe UI", 9F),
            };
            _tbComment.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            Controls.Add(_tbComment);

            var submit = new Guna2Button
            {
                Text = "Submit Review",
                Location = new Point(24, 262),
                Size = new Size(240, 46),
                BorderRadius = 10,
                FillColor = Color.FromArgb(232, 113, 74),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            submit.Click += (s, e) =>
            {
                if (Rating == 0)
                {
                    MessageBox.Show("Please pick a star rating first.", "Meraki",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = DialogResult.OK;
            };
            Controls.Add(submit);

            var cancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(276, 262),
                Size = new Size(160, 46),
                BorderRadius = 10,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(154, 136, 128),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.Transparent,
            };
            cancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
            Controls.Add(cancel);
        }

        private void SetRating(int rating)
        {
            Rating = rating;
            for (int i = 0; i < 5; i++)
            {
                bool filled = i < rating;
                _stars[i].Text = filled ? "★" : "☆";
                _stars[i].ForeColor = filled ? Color.FromArgb(255, 209, 102) : Color.FromArgb(200, 190, 185);
            }
        }
    }
}
