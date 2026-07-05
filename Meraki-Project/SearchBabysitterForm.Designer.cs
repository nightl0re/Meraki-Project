namespace Meraki_Project
{
    partial class SearchBabysitterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlPageBackground = new Guna.UI2.WinForms.Guna2GradientPanel();

            // Navbar
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnNavParentHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavFindBabysitter = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavBookNow = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();

            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();

            // Search bar
            this.pnlSearchBar = new Guna.UI2.WinForms.Guna2Panel();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnToggleFilters = new Guna.UI2.WinForms.Guna2Button();

            // Filters panel
            this.pnlFiltersPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMaxRateCaption = new System.Windows.Forms.Label();
            this.tbMaxRate = new System.Windows.Forms.TrackBar();
            this.lblMaxRateRange = new System.Windows.Forms.Label();
            this.lblMinRatingCaption = new System.Windows.Forms.Label();
            this.btnRatingAny = new Guna.UI2.WinForms.Guna2Button();
            this.btnRating4 = new Guna.UI2.WinForms.Guna2Button();
            this.btnRating45 = new Guna.UI2.WinForms.Guna2Button();
            this.btnRating48 = new Guna.UI2.WinForms.Guna2Button();
            this.lblAvailabilityCaption = new System.Windows.Forms.Label();
            this.cbAvailableOnly = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.lblAvailableOnly = new System.Windows.Forms.Label();
            this.lblVerificationCaption = new System.Windows.Forms.Label();
            this.cbVerifiedOnly = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.lblVerifiedOnly = new System.Windows.Forms.Label();

            // Results
            this.flpResults = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoResults = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRate)).BeginInit();
            this.pnlPageBackground.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSearchBar.SuspendLayout();
            this.pnlFiltersPanel.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlPageBackground
            //
            this.pnlPageBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageBackground.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlPageBackground.FillColor2 = System.Drawing.Color.FromArgb(225, 240, 239);
            this.pnlPageBackground.Name = "pnlPageBackground";
            this.pnlPageBackground.Size = new System.Drawing.Size(1500, 900);
            this.pnlPageBackground.Controls.Add(this.pnlContent);
            this.pnlPageBackground.Controls.Add(this.pnlNavbar);

            //
            // pnlNavbar
            //
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.FillColor = System.Drawing.Color.White;
            this.pnlNavbar.BackColor = System.Drawing.Color.White;
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1500, 80);

            this.picNavLogo.BorderRadius = 10;
            this.picNavLogo.Image = global::Meraki_Project.Properties.Resources.meraki_logo;
            this.picNavLogo.Location = new System.Drawing.Point(25, 15);
            this.picNavLogo.Name = "picNavLogo";
            this.picNavLogo.Size = new System.Drawing.Size(50, 50);
            this.picNavLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.lblNavBrand.Location = new System.Drawing.Point(85, 25);
            this.lblNavBrand.Name = "lblNavBrand";
            this.lblNavBrand.Size = new System.Drawing.Size(90, 30);
            this.lblNavBrand.Text = "<div style=\"color:#E8714A;font-weight:bold;font-size:12pt;\">Meraki</div>";

            SetupNavButton(this.btnNavParentHome, "Parent Home", 275, 138, false);
            this.btnNavParentHome.Click += new System.EventHandler(this.btnNavParentHome_Click);
            SetupNavButton(this.btnNavFindBabysitter, "Find a Babysitter", 423, 162, true);
            this.btnNavFindBabysitter.Click += new System.EventHandler(this.btnNavFindBabysitter_Click);
            SetupNavButton(this.btnNavBookNow, "Book Now", 595, 125, false);
            this.btnNavBookNow.Click += new System.EventHandler(this.btnNavBookNow_Click);
            SetupNavButton(this.btnNavMyProfile, "My Profile", 730, 125, false);
            this.btnNavMyProfile.Click += new System.EventHandler(this.btnNavMyProfile_Click);

            this.btnLogout.BorderRadius = 8;
            this.btnLogout.BorderThickness = 0;
            this.btnLogout.ShadowDecoration.Enabled = false;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(224, 90, 90);
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 232, 232);
            this.btnLogout.Location = new System.Drawing.Point(1350, 18);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 45);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlNavbar.Controls.Add(this.picNavLogo);
            this.pnlNavbar.Controls.Add(this.lblNavBrand);
            this.pnlNavbar.Controls.Add(this.btnNavParentHome);
            this.pnlNavbar.Controls.Add(this.btnNavFindBabysitter);
            this.pnlNavbar.Controls.Add(this.btnNavBookNow);
            this.pnlNavbar.Controls.Add(this.btnNavMyProfile);
            this.pnlNavbar.Controls.Add(this.btnLogout);

            //
            // pnlContent
            //
            this.pnlContent.AutoScroll = true;
            this.pnlContent.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlContent.FillColor2 = System.Drawing.Color.FromArgb(225, 240, 239);
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1500, 820);

            this.lblPageTitle.Location = new System.Drawing.Point(30, 24);
            this.lblPageTitle.Size = new System.Drawing.Size(400, 30);
            this.lblPageTitle.Text = "Find a Babysitter";
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblPageSubtitle.Location = new System.Drawing.Point(30, 56);
            this.lblPageSubtitle.Size = new System.Drawing.Size(400, 22);
            this.lblPageSubtitle.Text = "6 caregivers available in your area";
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.BackColor = System.Drawing.Color.Transparent;

            //
            // pnlSearchBar
            //
            this.pnlSearchBar.BorderRadius = 16;
            this.pnlSearchBar.FillColor = System.Drawing.Color.White;
            this.pnlSearchBar.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlSearchBar.Location = new System.Drawing.Point(30, 90);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Size = new System.Drawing.Size(1420, 60);

            this.tbSearch.BorderRadius = 10;
            this.tbSearch.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.tbSearch.PlaceholderText = "Search by name, skill, or location...";
            this.tbSearch.Location = new System.Drawing.Point(12, 10);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(1200, 40);
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);

            this.btnToggleFilters.BorderRadius = 10;
            this.btnToggleFilters.BorderThickness = 0;
            this.btnToggleFilters.ShadowDecoration.Enabled = false;
            this.btnToggleFilters.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnToggleFilters.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnToggleFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToggleFilters.Location = new System.Drawing.Point(1224, 10);
            this.btnToggleFilters.Name = "btnToggleFilters";
            this.btnToggleFilters.Size = new System.Drawing.Size(184, 40);
            this.btnToggleFilters.Text = "⚙ Filters";
            this.btnToggleFilters.Click += new System.EventHandler(this.btnToggleFilters_Click);

            this.pnlSearchBar.Controls.Add(this.tbSearch);
            this.pnlSearchBar.Controls.Add(this.btnToggleFilters);

            //
            // pnlFiltersPanel (hidden until "Filters" is clicked)
            //
            this.pnlFiltersPanel.BorderRadius = 16;
            this.pnlFiltersPanel.FillColor = System.Drawing.Color.White;
            this.pnlFiltersPanel.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlFiltersPanel.Location = new System.Drawing.Point(30, 160);
            this.pnlFiltersPanel.Name = "pnlFiltersPanel";
            this.pnlFiltersPanel.Size = new System.Drawing.Size(1420, 140);
            this.pnlFiltersPanel.Visible = false;

            this.lblMaxRateCaption.Location = new System.Drawing.Point(24, 16);
            this.lblMaxRateCaption.Size = new System.Drawing.Size(220, 22);
            this.lblMaxRateCaption.Text = "Max Rate: $25/hr";
            this.lblMaxRateCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblMaxRateCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxRateCaption.BackColor = System.Drawing.Color.Transparent;

            this.tbMaxRate.Location = new System.Drawing.Point(24, 42);
            this.tbMaxRate.Name = "tbMaxRate";
            this.tbMaxRate.Size = new System.Drawing.Size(300, 45);
            this.tbMaxRate.Minimum = 10;
            this.tbMaxRate.Maximum = 30;
            this.tbMaxRate.Value = 25;
            this.tbMaxRate.TickFrequency = 5;
            this.tbMaxRate.Scroll += new System.EventHandler(this.tbMaxRate_Scroll);

            this.lblMaxRateRange.Location = new System.Drawing.Point(24, 90);
            this.lblMaxRateRange.Size = new System.Drawing.Size(300, 18);
            this.lblMaxRateRange.Text = "$10/hr                                   $30/hr";
            this.lblMaxRateRange.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblMaxRateRange.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblMaxRateRange.BackColor = System.Drawing.Color.Transparent;

            this.lblMinRatingCaption.Location = new System.Drawing.Point(360, 16);
            this.lblMinRatingCaption.Size = new System.Drawing.Size(150, 22);
            this.lblMinRatingCaption.Text = "Min Rating";
            this.lblMinRatingCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblMinRatingCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinRatingCaption.BackColor = System.Drawing.Color.Transparent;

            SetupRatingButton(this.btnRatingAny, "Any", 360, 46);
            this.btnRatingAny.Click += new System.EventHandler(this.btnRatingAny_Click);
            SetupRatingButton(this.btnRating4, "4+", 440, 46);
            this.btnRating4.Click += new System.EventHandler(this.btnRating4_Click);
            SetupRatingButton(this.btnRating45, "4.5+", 510, 46);
            this.btnRating45.Click += new System.EventHandler(this.btnRating45_Click);
            SetupRatingButton(this.btnRating48, "4.8+", 590, 46);
            this.btnRating48.Click += new System.EventHandler(this.btnRating48_Click);

            this.lblAvailabilityCaption.Location = new System.Drawing.Point(700, 16);
            this.lblAvailabilityCaption.Size = new System.Drawing.Size(150, 22);
            this.lblAvailabilityCaption.Text = "Availability";
            this.lblAvailabilityCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblAvailabilityCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailabilityCaption.BackColor = System.Drawing.Color.Transparent;

            this.cbAvailableOnly.CheckedState.BorderRadius = 4;
            this.cbAvailableOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.cbAvailableOnly.UncheckedState.BorderRadius = 4;
            this.cbAvailableOnly.Location = new System.Drawing.Point(700, 48);
            this.cbAvailableOnly.Name = "cbAvailableOnly";
            this.cbAvailableOnly.Size = new System.Drawing.Size(22, 22);
            this.cbAvailableOnly.CheckedChanged += new System.EventHandler(this.cbAvailableOnly_CheckedChanged);

            this.lblAvailableOnly.Location = new System.Drawing.Point(730, 50);
            this.lblAvailableOnly.Size = new System.Drawing.Size(150, 20);
            this.lblAvailableOnly.Text = "Available only";
            this.lblAvailableOnly.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblAvailableOnly.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAvailableOnly.BackColor = System.Drawing.Color.Transparent;

            this.lblVerificationCaption.Location = new System.Drawing.Point(920, 16);
            this.lblVerificationCaption.Size = new System.Drawing.Size(150, 22);
            this.lblVerificationCaption.Text = "Verification";
            this.lblVerificationCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblVerificationCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVerificationCaption.BackColor = System.Drawing.Color.Transparent;

            this.cbVerifiedOnly.CheckedState.BorderRadius = 4;
            this.cbVerifiedOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.cbVerifiedOnly.UncheckedState.BorderRadius = 4;
            this.cbVerifiedOnly.Location = new System.Drawing.Point(920, 48);
            this.cbVerifiedOnly.Name = "cbVerifiedOnly";
            this.cbVerifiedOnly.Size = new System.Drawing.Size(22, 22);
            this.cbVerifiedOnly.CheckedChanged += new System.EventHandler(this.cbVerifiedOnly_CheckedChanged);

            this.lblVerifiedOnly.Location = new System.Drawing.Point(950, 50);
            this.lblVerifiedOnly.Size = new System.Drawing.Size(150, 20);
            this.lblVerifiedOnly.Text = "Verified only";
            this.lblVerifiedOnly.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblVerifiedOnly.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVerifiedOnly.BackColor = System.Drawing.Color.Transparent;

            this.pnlFiltersPanel.Controls.Add(this.lblMaxRateCaption);
            this.pnlFiltersPanel.Controls.Add(this.tbMaxRate);
            this.pnlFiltersPanel.Controls.Add(this.lblMaxRateRange);
            this.pnlFiltersPanel.Controls.Add(this.lblMinRatingCaption);
            this.pnlFiltersPanel.Controls.Add(this.btnRatingAny);
            this.pnlFiltersPanel.Controls.Add(this.btnRating4);
            this.pnlFiltersPanel.Controls.Add(this.btnRating45);
            this.pnlFiltersPanel.Controls.Add(this.btnRating48);
            this.pnlFiltersPanel.Controls.Add(this.lblAvailabilityCaption);
            this.pnlFiltersPanel.Controls.Add(this.cbAvailableOnly);
            this.pnlFiltersPanel.Controls.Add(this.lblAvailableOnly);
            this.pnlFiltersPanel.Controls.Add(this.lblVerificationCaption);
            this.pnlFiltersPanel.Controls.Add(this.cbVerifiedOnly);
            this.pnlFiltersPanel.Controls.Add(this.lblVerifiedOnly);

            //
            // flpResults - populated at runtime in SearchBabysitterForm.cs
            //
            this.flpResults.Location = new System.Drawing.Point(30, 160);
            this.flpResults.Name = "flpResults";
            this.flpResults.Size = new System.Drawing.Size(1420, 620);
            this.flpResults.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpResults.WrapContents = true;
            this.flpResults.AutoScroll = true;
            this.flpResults.BackColor = System.Drawing.Color.Transparent;

            this.lblNoResults.Location = new System.Drawing.Point(30, 260);
            this.lblNoResults.Size = new System.Drawing.Size(500, 60);
            this.lblNoResults.Text = "No babysitters match your filters.";
            this.lblNoResults.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblNoResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNoResults.BackColor = System.Drawing.Color.Transparent;
            this.lblNoResults.Visible = false;

            this.pnlContent.Controls.Add(this.lblPageTitle);
            this.pnlContent.Controls.Add(this.lblPageSubtitle);
            this.pnlContent.Controls.Add(this.pnlSearchBar);
            this.pnlContent.Controls.Add(this.pnlFiltersPanel);
            this.pnlContent.Controls.Add(this.flpResults);
            this.pnlContent.Controls.Add(this.lblNoResults);

            //
            // SearchBabysitterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.pnlPageBackground);
            this.MinimumSize = new System.Drawing.Size(1246, 738);
            this.Name = "SearchBabysitterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meraki - Find a Babysitter";
            this.Load += new System.EventHandler(this.SearchBabysitterForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRate)).EndInit();
            this.pnlFiltersPanel.ResumeLayout(false);
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlPageBackground.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, int x, int width, bool active)
        {
            btn.BorderRadius = 8;
            btn.BorderThickness = 0;
            btn.ShadowDecoration.Enabled = false;
            btn.FillColor = active ? System.Drawing.Color.FromArgb(253, 238, 232) : System.Drawing.Color.Transparent;
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = active ? System.Drawing.Color.FromArgb(232, 113, 74) : System.Drawing.Color.FromArgb(154, 136, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 8.5F, active ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            btn.Location = new System.Drawing.Point(x, 18);
            btn.Size = new System.Drawing.Size(width, 45);
            btn.Text = text;
        }

        private static void SetupRatingButton(Guna.UI2.WinForms.Guna2Button btn, string text, int x, int y)
        {
            btn.BorderRadius = 8;
            btn.BorderThickness = 0;
            btn.ShadowDecoration.Enabled = false;
            btn.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            btn.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 8F);
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(64, 34);
            btn.Text = text;
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlPageBackground;
        private Guna.UI2.WinForms.Guna2Panel pnlNavbar;
        private Guna.UI2.WinForms.Guna2PictureBox picNavLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNavBrand;
        private Guna.UI2.WinForms.Guna2Button btnNavParentHome;
        private Guna.UI2.WinForms.Guna2Button btnNavFindBabysitter;
        private Guna.UI2.WinForms.Guna2Button btnNavBookNow;
        private Guna.UI2.WinForms.Guna2Button btnNavMyProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;

        private Guna.UI2.WinForms.Guna2Panel pnlSearchBar;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private Guna.UI2.WinForms.Guna2Button btnToggleFilters;

        private Guna.UI2.WinForms.Guna2Panel pnlFiltersPanel;
        private System.Windows.Forms.Label lblMaxRateCaption;
        private System.Windows.Forms.TrackBar tbMaxRate;
        private System.Windows.Forms.Label lblMaxRateRange;
        private System.Windows.Forms.Label lblMinRatingCaption;
        private Guna.UI2.WinForms.Guna2Button btnRatingAny;
        private Guna.UI2.WinForms.Guna2Button btnRating4;
        private Guna.UI2.WinForms.Guna2Button btnRating45;
        private Guna.UI2.WinForms.Guna2Button btnRating48;
        private System.Windows.Forms.Label lblAvailabilityCaption;
        private Guna.UI2.WinForms.Guna2CustomCheckBox cbAvailableOnly;
        private System.Windows.Forms.Label lblAvailableOnly;
        private System.Windows.Forms.Label lblVerificationCaption;
        private Guna.UI2.WinForms.Guna2CustomCheckBox cbVerifiedOnly;
        private System.Windows.Forms.Label lblVerifiedOnly;

        private System.Windows.Forms.FlowLayoutPanel flpResults;
        private System.Windows.Forms.Label lblNoResults;
    }
}
