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
            pnlPageBackground = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNavParentHome = new Guna.UI2.WinForms.Guna2Button();
            btnNavFindBabysitter = new Guna.UI2.WinForms.Guna2Button();
            btnNavBookNow = new Guna.UI2.WinForms.Guna2Button();
            btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblPageTitle = new Label();
            lblPageSubtitle = new Label();
            pnlFiltersPanel = new Guna.UI2.WinForms.Guna2Panel();
            lblFilterHeader = new Label();
            lblKeywordCaption = new Label();
            tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblMaxRateCaption = new Label();
            tbMaxRate = new TrackBar();
            lblMaxRateRange = new Label();
            lblMinRatingCaption = new Label();
            btnRatingAny = new Guna.UI2.WinForms.Guna2Button();
            btnRating4 = new Guna.UI2.WinForms.Guna2Button();
            btnRating45 = new Guna.UI2.WinForms.Guna2Button();
            btnRating48 = new Guna.UI2.WinForms.Guna2Button();
            lblAvailabilityCaption = new Label();
            cbAvailableOnly = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            lblAvailableOnly = new Label();
            cbVerifiedOnly = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            lblVerifiedOnly = new Label();
            flpResults = new FlowLayoutPanel();
            lblNoResults = new Label();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbMaxRate).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFiltersPanel.SuspendLayout();
            SuspendLayout();
            //
            // pnlPageBackground
            //
            pnlPageBackground.Controls.Add(pnlContent);
            pnlPageBackground.Controls.Add(pnlNavbar);
            pnlPageBackground.BackColor = Color.FromArgb(253, 238, 232);
            pnlPageBackground.Dock = DockStyle.Fill;
            pnlPageBackground.FillColor = Color.FromArgb(253, 238, 232);
            pnlPageBackground.FillColor2 = Color.FromArgb(225, 240, 239);
            pnlPageBackground.Location = new Point(0, 0);
            pnlPageBackground.Name = "pnlPageBackground";
            pnlPageBackground.Size = new Size(1500, 900);
            pnlPageBackground.TabIndex = 0;
            //
            // pnlNavbar
            //
            pnlNavbar.BackColor = Color.Transparent;
            pnlNavbar.Controls.Add(picNavLogo);
            pnlNavbar.Controls.Add(lblNavBrand);
            pnlNavbar.Controls.Add(btnNavParentHome);
            pnlNavbar.Controls.Add(btnNavFindBabysitter);
            pnlNavbar.Controls.Add(btnNavBookNow);
            pnlNavbar.Controls.Add(btnNavMyProfile);
            pnlNavbar.Controls.Add(btnLogout);
            pnlNavbar.Dock = DockStyle.Top;
            pnlNavbar.FillColor = Color.White;
            pnlNavbar.Location = new Point(0, 0);
            pnlNavbar.Name = "pnlNavbar";
            pnlNavbar.Size = new Size(1500, 80);
            pnlNavbar.TabIndex = 1;
            //
            // picNavLogo
            //
            picNavLogo.BorderRadius = 10;
            picNavLogo.Image = Properties.Resources.meraki_logo;
            picNavLogo.ImageRotate = 0F;
            picNavLogo.Location = new Point(25, 15);
            picNavLogo.Name = "picNavLogo";
            picNavLogo.Size = new Size(50, 50);
            picNavLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picNavLogo.TabIndex = 0;
            picNavLogo.TabStop = false;
            //
            // lblNavBrand
            //
            lblNavBrand.BackColor = Color.Transparent;
            lblNavBrand.Location = new Point(85, 25);
            lblNavBrand.Name = "lblNavBrand";
            lblNavBrand.Size = new Size(90, 30);
            lblNavBrand.TabIndex = 1;
            lblNavBrand.Text = "<div style=\"color:#E8714A;font-weight:bold;font-size:12pt;\">Meraki</div>";
            //
            // btnNavParentHome
            //
            btnNavParentHome.BackColor = Color.White;
            btnNavParentHome.BorderRadius = 8;
            btnNavParentHome.FillColor = Color.Transparent;
            btnNavParentHome.Font = new Font("Segoe UI", 8.5F);
            btnNavParentHome.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavParentHome.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavParentHome.Location = new Point(275, 18);
            btnNavParentHome.Name = "btnNavParentHome";
            btnNavParentHome.Size = new Size(138, 45);
            btnNavParentHome.TabIndex = 2;
            btnNavParentHome.Text = "Parent Home";
            btnNavParentHome.Click += btnNavParentHome_Click;
            //
            // btnNavFindBabysitter
            //
            btnNavFindBabysitter.BackColor = Color.White;
            btnNavFindBabysitter.BorderRadius = 8;
            btnNavFindBabysitter.FillColor = Color.FromArgb(253, 238, 232);
            btnNavFindBabysitter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNavFindBabysitter.ForeColor = Color.FromArgb(232, 113, 74);
            btnNavFindBabysitter.HoverState.FillColor = Color.FromArgb(250, 226, 216);
            btnNavFindBabysitter.Location = new Point(423, 18);
            btnNavFindBabysitter.Name = "btnNavFindBabysitter";
            btnNavFindBabysitter.Size = new Size(162, 45);
            btnNavFindBabysitter.TabIndex = 3;
            btnNavFindBabysitter.Text = "Find a Babysitter";
            btnNavFindBabysitter.Click += btnNavFindBabysitter_Click;
            //
            // btnNavBookNow
            //
            btnNavBookNow.BackColor = Color.White;
            btnNavBookNow.BorderRadius = 8;
            btnNavBookNow.FillColor = Color.Transparent;
            btnNavBookNow.Font = new Font("Segoe UI", 8.5F);
            btnNavBookNow.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavBookNow.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavBookNow.Location = new Point(595, 18);
            btnNavBookNow.Name = "btnNavBookNow";
            btnNavBookNow.Size = new Size(125, 45);
            btnNavBookNow.TabIndex = 4;
            btnNavBookNow.Text = "Book Now";
            btnNavBookNow.Click += btnNavBookNow_Click;
            //
            // btnNavMyProfile
            //
            btnNavMyProfile.BackColor = Color.White;
            btnNavMyProfile.BorderRadius = 8;
            btnNavMyProfile.FillColor = Color.Transparent;
            btnNavMyProfile.Font = new Font("Segoe UI", 8.5F);
            btnNavMyProfile.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavMyProfile.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavMyProfile.Location = new Point(730, 18);
            btnNavMyProfile.Name = "btnNavMyProfile";
            btnNavMyProfile.Size = new Size(125, 45);
            btnNavMyProfile.TabIndex = 5;
            btnNavMyProfile.Text = "My Profile";
            btnNavMyProfile.Click += btnNavMyProfile_Click;
            //
            // btnLogout
            //
            btnLogout.BackColor = Color.White;
            btnLogout.BorderRadius = 8;
            btnLogout.FillColor = Color.Transparent;
            btnLogout.Font = new Font("Segoe UI", 8.5F);
            btnLogout.ForeColor = Color.FromArgb(224, 90, 90);
            btnLogout.HoverState.FillColor = Color.FromArgb(253, 232, 232);
            btnLogout.Location = new Point(1350, 18);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 45);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            //
            // pnlContent
            //
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(lblPageTitle);
            pnlContent.Controls.Add(lblPageSubtitle);
            pnlContent.Controls.Add(pnlFiltersPanel);
            pnlContent.Controls.Add(flpResults);
            pnlContent.Controls.Add(lblNoResults);
            pnlContent.FillColor = Color.FromArgb(253, 238, 232);
            pnlContent.FillColor2 = Color.FromArgb(225, 240, 239);
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1500, 820);
            pnlContent.TabIndex = 0;
            //
            // lblPageTitle
            //
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPageTitle.Location = new Point(30, 20);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(400, 30);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Find a Babysitter";
            //
            // lblPageSubtitle
            //
            lblPageSubtitle.BackColor = Color.Transparent;
            lblPageSubtitle.Font = new Font("Segoe UI", 9F);
            lblPageSubtitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPageSubtitle.Location = new Point(30, 52);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(400, 22);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "6 caregivers available in your area";
            //
            // pnlFiltersPanel  (fixed left sidebar, always visible - like the design)
            //
            pnlFiltersPanel.BackColor = Color.Transparent;
            pnlFiltersPanel.BorderRadius = 16;
            pnlFiltersPanel.BorderThickness = 1;
            pnlFiltersPanel.BorderColor = Color.FromArgb(238, 230, 224);
            pnlFiltersPanel.Controls.Add(lblFilterHeader);
            pnlFiltersPanel.Controls.Add(lblKeywordCaption);
            pnlFiltersPanel.Controls.Add(tbSearch);
            pnlFiltersPanel.Controls.Add(lblMaxRateCaption);
            pnlFiltersPanel.Controls.Add(tbMaxRate);
            pnlFiltersPanel.Controls.Add(lblMaxRateRange);
            pnlFiltersPanel.Controls.Add(lblMinRatingCaption);
            pnlFiltersPanel.Controls.Add(btnRatingAny);
            pnlFiltersPanel.Controls.Add(btnRating4);
            pnlFiltersPanel.Controls.Add(btnRating45);
            pnlFiltersPanel.Controls.Add(btnRating48);
            pnlFiltersPanel.Controls.Add(lblAvailabilityCaption);
            pnlFiltersPanel.Controls.Add(cbAvailableOnly);
            pnlFiltersPanel.Controls.Add(lblAvailableOnly);
            pnlFiltersPanel.Controls.Add(cbVerifiedOnly);
            pnlFiltersPanel.Controls.Add(lblVerifiedOnly);
            pnlFiltersPanel.FillColor = Color.White;
            pnlFiltersPanel.Location = new Point(30, 96);
            pnlFiltersPanel.Name = "pnlFiltersPanel";
            pnlFiltersPanel.Size = new Size(280, 620);
            pnlFiltersPanel.TabIndex = 3;
            //
            // lblFilterHeader
            //
            lblFilterHeader.BackColor = Color.FromArgb(232, 113, 74);
            lblFilterHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblFilterHeader.ForeColor = Color.White;
            lblFilterHeader.Location = new Point(1, 1);
            lblFilterHeader.Name = "lblFilterHeader";
            lblFilterHeader.Padding = new Padding(20, 0, 0, 0);
            lblFilterHeader.Size = new Size(278, 48);
            lblFilterHeader.TabIndex = 0;
            lblFilterHeader.Text = "Filter Results";
            lblFilterHeader.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblKeywordCaption
            //
            lblKeywordCaption.BackColor = Color.Transparent;
            lblKeywordCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKeywordCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblKeywordCaption.Location = new Point(20, 64);
            lblKeywordCaption.Name = "lblKeywordCaption";
            lblKeywordCaption.Size = new Size(240, 22);
            lblKeywordCaption.TabIndex = 1;
            lblKeywordCaption.Text = "Keyword Search";
            //
            // tbSearch
            //
            tbSearch.BorderRadius = 10;
            tbSearch.DefaultText = "";
            tbSearch.FillColor = Color.FromArgb(247, 245, 242);
            tbSearch.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbSearch.Font = new Font("Segoe UI", 9F);
            tbSearch.Location = new Point(20, 90);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search by name...";
            tbSearch.SelectedText = "";
            tbSearch.Size = new Size(240, 40);
            tbSearch.TabIndex = 2;
            tbSearch.TextChanged += tbSearch_TextChanged;
            //
            // lblMaxRateCaption
            //
            lblMaxRateCaption.BackColor = Color.Transparent;
            lblMaxRateCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaxRateCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblMaxRateCaption.Location = new Point(20, 150);
            lblMaxRateCaption.Name = "lblMaxRateCaption";
            lblMaxRateCaption.Size = new Size(240, 22);
            lblMaxRateCaption.TabIndex = 3;
            lblMaxRateCaption.Text = "Max Rate: $25/hr";
            //
            // tbMaxRate
            //
            tbMaxRate.BackColor = Color.White;
            tbMaxRate.Location = new Point(20, 176);
            tbMaxRate.Maximum = 30;
            tbMaxRate.Minimum = 10;
            tbMaxRate.Name = "tbMaxRate";
            tbMaxRate.Size = new Size(240, 45);
            tbMaxRate.TabIndex = 4;
            tbMaxRate.TickFrequency = 5;
            tbMaxRate.Value = 25;
            tbMaxRate.Scroll += tbMaxRate_Scroll;
            //
            // lblMaxRateRange
            //
            lblMaxRateRange.BackColor = Color.Transparent;
            lblMaxRateRange.Font = new Font("Segoe UI", 7.5F);
            lblMaxRateRange.ForeColor = Color.FromArgb(154, 136, 128);
            lblMaxRateRange.Location = new Point(20, 222);
            lblMaxRateRange.Name = "lblMaxRateRange";
            lblMaxRateRange.Size = new Size(240, 18);
            lblMaxRateRange.TabIndex = 5;
            lblMaxRateRange.Text = "$10/hr                                  $30/hr";
            //
            // lblMinRatingCaption
            //
            lblMinRatingCaption.BackColor = Color.Transparent;
            lblMinRatingCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMinRatingCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblMinRatingCaption.Location = new Point(20, 262);
            lblMinRatingCaption.Name = "lblMinRatingCaption";
            lblMinRatingCaption.Size = new Size(240, 22);
            lblMinRatingCaption.TabIndex = 6;
            lblMinRatingCaption.Text = "Minimum Rating";
            //
            // btnRatingAny
            //
            btnRatingAny.BackColor = Color.White;
            btnRatingAny.BorderRadius = 8;
            btnRatingAny.FillColor = Color.FromArgb(232, 113, 74);
            btnRatingAny.Font = new Font("Segoe UI", 8F);
            btnRatingAny.ForeColor = Color.White;
            btnRatingAny.Location = new Point(20, 290);
            btnRatingAny.Name = "btnRatingAny";
            btnRatingAny.Size = new Size(116, 34);
            btnRatingAny.TabIndex = 7;
            btnRatingAny.Text = "Any";
            btnRatingAny.Click += btnRatingAny_Click;
            //
            // btnRating4
            //
            btnRating4.BackColor = Color.White;
            btnRating4.BorderRadius = 8;
            btnRating4.FillColor = Color.FromArgb(247, 245, 242);
            btnRating4.Font = new Font("Segoe UI", 8F);
            btnRating4.ForeColor = Color.FromArgb(154, 136, 128);
            btnRating4.Location = new Point(144, 290);
            btnRating4.Name = "btnRating4";
            btnRating4.Size = new Size(116, 34);
            btnRating4.TabIndex = 8;
            btnRating4.Text = "4+";
            btnRating4.Click += btnRating4_Click;
            //
            // btnRating45
            //
            btnRating45.BackColor = Color.White;
            btnRating45.BorderRadius = 8;
            btnRating45.FillColor = Color.FromArgb(247, 245, 242);
            btnRating45.Font = new Font("Segoe UI", 8F);
            btnRating45.ForeColor = Color.FromArgb(154, 136, 128);
            btnRating45.Location = new Point(20, 330);
            btnRating45.Name = "btnRating45";
            btnRating45.Size = new Size(116, 34);
            btnRating45.TabIndex = 9;
            btnRating45.Text = "4.5+";
            btnRating45.Click += btnRating45_Click;
            //
            // btnRating48
            //
            btnRating48.BackColor = Color.White;
            btnRating48.BorderRadius = 8;
            btnRating48.FillColor = Color.FromArgb(247, 245, 242);
            btnRating48.Font = new Font("Segoe UI", 8F);
            btnRating48.ForeColor = Color.FromArgb(154, 136, 128);
            btnRating48.Location = new Point(144, 330);
            btnRating48.Name = "btnRating48";
            btnRating48.Size = new Size(116, 34);
            btnRating48.TabIndex = 10;
            btnRating48.Text = "4.8+";
            btnRating48.Click += btnRating48_Click;
            //
            // lblAvailabilityCaption
            //
            lblAvailabilityCaption.BackColor = Color.Transparent;
            lblAvailabilityCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvailabilityCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblAvailabilityCaption.Location = new Point(20, 388);
            lblAvailabilityCaption.Name = "lblAvailabilityCaption";
            lblAvailabilityCaption.Size = new Size(240, 22);
            lblAvailabilityCaption.TabIndex = 11;
            lblAvailabilityCaption.Text = "Availability";
            //
            // cbAvailableOnly
            //
            cbAvailableOnly.CheckedState.BorderColor = Color.FromArgb(94, 200, 196);
            cbAvailableOnly.CheckedState.BorderRadius = 4;
            cbAvailableOnly.CheckedState.BorderThickness = 0;
            cbAvailableOnly.CheckedState.FillColor = Color.FromArgb(94, 200, 196);
            cbAvailableOnly.Location = new Point(20, 418);
            cbAvailableOnly.Name = "cbAvailableOnly";
            cbAvailableOnly.Size = new Size(22, 22);
            cbAvailableOnly.TabIndex = 12;
            cbAvailableOnly.UncheckedState.BorderColor = Color.FromArgb(200, 190, 185);
            cbAvailableOnly.UncheckedState.BorderRadius = 4;
            cbAvailableOnly.UncheckedState.BorderThickness = 1;
            cbAvailableOnly.UncheckedState.FillColor = Color.FromArgb(247, 245, 242);
            cbAvailableOnly.CheckedChanged += cbAvailableOnly_CheckedChanged;
            //
            // lblAvailableOnly
            //
            lblAvailableOnly.BackColor = Color.Transparent;
            lblAvailableOnly.Font = new Font("Segoe UI", 8.5F);
            lblAvailableOnly.ForeColor = Color.FromArgb(154, 136, 128);
            lblAvailableOnly.Location = new Point(50, 420);
            lblAvailableOnly.Name = "lblAvailableOnly";
            lblAvailableOnly.Size = new Size(200, 20);
            lblAvailableOnly.TabIndex = 13;
            lblAvailableOnly.Text = "Available only";
            //
            // cbVerifiedOnly
            //
            cbVerifiedOnly.CheckedState.BorderColor = Color.FromArgb(94, 200, 196);
            cbVerifiedOnly.CheckedState.BorderRadius = 4;
            cbVerifiedOnly.CheckedState.BorderThickness = 0;
            cbVerifiedOnly.CheckedState.FillColor = Color.FromArgb(94, 200, 196);
            cbVerifiedOnly.Location = new Point(20, 450);
            cbVerifiedOnly.Name = "cbVerifiedOnly";
            cbVerifiedOnly.Size = new Size(22, 22);
            cbVerifiedOnly.TabIndex = 14;
            cbVerifiedOnly.UncheckedState.BorderColor = Color.FromArgb(200, 190, 185);
            cbVerifiedOnly.UncheckedState.BorderRadius = 4;
            cbVerifiedOnly.UncheckedState.BorderThickness = 1;
            cbVerifiedOnly.UncheckedState.FillColor = Color.FromArgb(247, 245, 242);
            cbVerifiedOnly.CheckedChanged += cbVerifiedOnly_CheckedChanged;
            //
            // lblVerifiedOnly
            //
            lblVerifiedOnly.BackColor = Color.Transparent;
            lblVerifiedOnly.Font = new Font("Segoe UI", 8.5F);
            lblVerifiedOnly.ForeColor = Color.FromArgb(154, 136, 128);
            lblVerifiedOnly.Location = new Point(50, 452);
            lblVerifiedOnly.Name = "lblVerifiedOnly";
            lblVerifiedOnly.Size = new Size(200, 20);
            lblVerifiedOnly.TabIndex = 15;
            lblVerifiedOnly.Text = "Verified only";
            //
            // flpResults
            //
            flpResults.AutoScroll = true;
            flpResults.BackColor = Color.Transparent;
            flpResults.FlowDirection = FlowDirection.TopDown;
            flpResults.Location = new Point(330, 96);
            flpResults.Name = "flpResults";
            flpResults.Size = new Size(1140, 700);
            flpResults.TabIndex = 4;
            flpResults.WrapContents = false;
            //
            // lblNoResults
            //
            lblNoResults.BackColor = Color.Transparent;
            lblNoResults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNoResults.ForeColor = Color.FromArgb(154, 136, 128);
            lblNoResults.Location = new Point(360, 200);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(500, 60);
            lblNoResults.TabIndex = 5;
            lblNoResults.Text = "No babysitters match your filters.";
            lblNoResults.Visible = false;
            //
            // SearchBabysitterForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "SearchBabysitterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - Find a Babysitter";
            Load += SearchBabysitterForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbMaxRate).EndInit();
            pnlFiltersPanel.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlNavbar.ResumeLayout(false);
            pnlPageBackground.ResumeLayout(false);
            ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Panel pnlFiltersPanel;
        private System.Windows.Forms.Label lblFilterHeader;
        private System.Windows.Forms.Label lblKeywordCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
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
        private Guna.UI2.WinForms.Guna2CustomCheckBox cbVerifiedOnly;
        private System.Windows.Forms.Label lblVerifiedOnly;
        private System.Windows.Forms.FlowLayoutPanel flpResults;
        private System.Windows.Forms.Label lblNoResults;
    }
}
