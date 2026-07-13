using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Babysitter-side directory of families: search parents by name and open
    // their profile (reviews from other babysitters, write one yourself).
    public partial class FindParentsForm : Form
    {
        private static readonly Color Teal = Color.FromArgb(94, 200, 196);
        private static readonly Color TealDark = Color.FromArgb(42, 112, 112);
        private static readonly Color TextDark = Color.FromArgb(60, 50, 45);
        private static readonly Color TextMuted = Color.FromArgb(154, 136, 128);

        private List<ParentInfo> _all = new();

        private readonly System.Windows.Forms.Timer _searchDebounce = new() { Interval = 220 };

        public FindParentsForm()
        {
            InitializeComponent();
            _searchDebounce.Tick += (s, e) => { _searchDebounce.Stop(); RenderResults(); };
        }

        private void FindParentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                _all = ParentRepository.GetAllParents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while loading parents:\n" + ex.Message,
                    "Meraki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _all = new List<ParentInfo>();
            }
            Ui.HideScrollbars(flpResults);
            RenderResults();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _searchDebounce.Stop();
            _searchDebounce.Start();
        }

        private void RenderResults()
        {
            string search = tbSearch.Text.Trim();
            List<ParentInfo> filtered = _all.Where(p =>
                search.Length == 0 || p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            lblPageSubtitle.Text = $"{filtered.Count} famil{(filtered.Count == 1 ? "y" : "ies")} on Meraki";

            flpResults.SuspendLayout();
            flpResults.Controls.Clear();
            foreach (ParentInfo p in filtered)
                flpResults.Controls.Add(BuildParentCard(p));
            flpResults.ResumeLayout();

            lblNoResults.Visible = filtered.Count == 0;
        }

        private Control BuildParentCard(ParentInfo p)
        {
            Guna2Panel card = new Guna2Panel
            {
                Size = new Size(1440, 110),
                Margin = new Padding(0, 0, 0, 14),
                BorderRadius = 16,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
            };

            Guna2Panel accentBar = new Guna2Panel
            {
                Location = new Point(12, 18),
                Size = new Size(5, 74),
                BorderRadius = 3,
                FillColor = Teal,
                BackColor = Color.Transparent,
            };
            Guna2Panel avatar = new Guna2Panel
            {
                Location = new Point(30, 22),
                Size = new Size(64, 64),
                BorderRadius = 18,
                FillColor = Ui.Lighten(Teal, 0.78),
                BackColor = Color.Transparent,
            };
            avatar.Controls.Add(new Label
            {
                Text = p.Name.Length > 0 ? p.Name.Substring(0, 1).ToUpper() : "?",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = TealDark,
                BackColor = Color.Transparent,
            });

            Label nameLabel = new Label
            {
                Text = p.Name,
                Location = new Point(112, 22),
                Size = new Size(500, 24),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = TextDark,
                BackColor = Color.Transparent,
            };
            Label metaLabel = new Label
            {
                Text = $"Member since {p.MemberSince:MMM yyyy}   ·   " +
                       $"{p.CompletedBookingCount} completed booking{(p.CompletedBookingCount == 1 ? "" : "s")}   ·   " +
                       (p.ReviewCount > 0 ? $"★ {p.AvgRating:0.0} ({p.ReviewCount})" : "★ No reviews yet"),
                Location = new Point(112, 52),
                Size = new Size(800, 22),
                Font = new Font("Segoe UI", 9F),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
            };

            Guna2Button profileBtn = new Guna2Button
            {
                Text = "View Profile",
                Location = new Point(1250, 32),
                Size = new Size(160, 44),
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 230, 224),
                FillColor = Color.White,
                ForeColor = Color.FromArgb(232, 113, 74),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            profileBtn.Click += (s, e) => OpenProfile(p.UserId);

            EventHandler open = (s, e) => OpenProfile(p.UserId);
            card.Click += open;
            nameLabel.Click += open;
            metaLabel.Click += open;

            card.Controls.Add(accentBar);
            card.Controls.Add(avatar);
            card.Controls.Add(nameLabel);
            card.Controls.Add(metaLabel);
            card.Controls.Add(profileBtn);
            return card;
        }

        private void OpenProfile(int parentId) =>
            Navigation.GoTo(this, new ParentProfileForm(parentId, backToSearch: true));

        // ----- Navigation -----

        private void btnNavBabysitterHome_Click(object sender, EventArgs e) =>
            Navigation.GoTo(this, new BabysitterDashboardForm());

        private void btnNavMyProfile_Click(object sender, EventArgs e) =>
            Navigation.GoTo(this, new ProfileForm());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Navigation.GoTo(this, new LoginForm());
        }
    }
}
