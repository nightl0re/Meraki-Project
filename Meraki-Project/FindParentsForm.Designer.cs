namespace Meraki_Project
{
    partial class FindParentsForm
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
            btnNavBabysitterHome = new Guna.UI2.WinForms.Guna2Button();
            btnNavFindParents = new Guna.UI2.WinForms.Guna2Button();
            btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblPageTitle = new Label();
            lblPageSubtitle = new Label();
            pnlSearchCard = new Guna.UI2.WinForms.Guna2Panel();
            tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            flpResults = new FlowLayoutPanel();
            lblNoResults = new Label();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSearchCard.SuspendLayout();
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
            pnlNavbar.Controls.Add(btnNavBabysitterHome);
            pnlNavbar.Controls.Add(btnNavFindParents);
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
            // btnNavBabysitterHome
            //
            btnNavBabysitterHome.BackColor = Color.White;
            btnNavBabysitterHome.BorderRadius = 8;
            btnNavBabysitterHome.FillColor = Color.Transparent;
            btnNavBabysitterHome.Font = new Font("Segoe UI", 8.5F);
            btnNavBabysitterHome.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavBabysitterHome.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavBabysitterHome.Location = new Point(275, 18);
            btnNavBabysitterHome.Name = "btnNavBabysitterHome";
            btnNavBabysitterHome.Size = new Size(165, 45);
            btnNavBabysitterHome.TabIndex = 2;
            btnNavBabysitterHome.Text = "Babysitter Home";
            btnNavBabysitterHome.Click += btnNavBabysitterHome_Click;
            //
            // btnNavFindParents
            //
            btnNavFindParents.BackColor = Color.White;
            btnNavFindParents.BorderRadius = 8;
            btnNavFindParents.FillColor = Color.FromArgb(253, 238, 232);
            btnNavFindParents.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNavFindParents.ForeColor = Color.FromArgb(232, 113, 74);
            btnNavFindParents.HoverState.FillColor = Color.FromArgb(250, 226, 216);
            btnNavFindParents.Location = new Point(450, 18);
            btnNavFindParents.Name = "btnNavFindParents";
            btnNavFindParents.Size = new Size(145, 45);
            btnNavFindParents.TabIndex = 3;
            btnNavFindParents.Text = "Find Parents";
            //
            // btnNavMyProfile
            //
            btnNavMyProfile.BackColor = Color.White;
            btnNavMyProfile.BorderRadius = 8;
            btnNavMyProfile.FillColor = Color.Transparent;
            btnNavMyProfile.Font = new Font("Segoe UI", 8.5F);
            btnNavMyProfile.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavMyProfile.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavMyProfile.Location = new Point(605, 18);
            btnNavMyProfile.Name = "btnNavMyProfile";
            btnNavMyProfile.Size = new Size(125, 45);
            btnNavMyProfile.TabIndex = 4;
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
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            //
            // pnlContent
            //
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(lblPageTitle);
            pnlContent.Controls.Add(lblPageSubtitle);
            pnlContent.Controls.Add(pnlSearchCard);
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
            lblPageTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblPageTitle.Location = new Point(30, 20);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(400, 30);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Find Parents";
            //
            // lblPageSubtitle
            //
            lblPageSubtitle.BackColor = Color.Transparent;
            lblPageSubtitle.Font = new Font("Segoe UI", 9F);
            lblPageSubtitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPageSubtitle.Location = new Point(30, 52);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(500, 22);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Families on Meraki";
            //
            // pnlSearchCard
            //
            pnlSearchCard.BackColor = Color.Transparent;
            pnlSearchCard.BorderRadius = 16;
            pnlSearchCard.BorderThickness = 1;
            pnlSearchCard.BorderColor = Color.FromArgb(238, 230, 224);
            pnlSearchCard.Controls.Add(tbSearch);
            pnlSearchCard.FillColor = Color.White;
            pnlSearchCard.Location = new Point(30, 86);
            pnlSearchCard.Name = "pnlSearchCard";
            pnlSearchCard.Size = new Size(1440, 60);
            pnlSearchCard.TabIndex = 2;
            //
            // tbSearch
            //
            tbSearch.BorderRadius = 10;
            tbSearch.DefaultText = "";
            tbSearch.FillColor = Color.FromArgb(247, 245, 242);
            tbSearch.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbSearch.Font = new Font("Segoe UI", 9F);
            tbSearch.Location = new Point(12, 10);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search by name...";
            tbSearch.SelectedText = "";
            tbSearch.Size = new Size(1416, 40);
            tbSearch.TabIndex = 0;
            tbSearch.TextChanged += tbSearch_TextChanged;
            //
            // flpResults
            //
            flpResults.AutoScroll = true;
            flpResults.BackColor = Color.FromArgb(253, 238, 232);
            flpResults.FlowDirection = FlowDirection.TopDown;
            flpResults.Location = new Point(30, 162);
            flpResults.Name = "flpResults";
            flpResults.Size = new Size(1440, 640);
            flpResults.TabIndex = 3;
            flpResults.WrapContents = false;
            //
            // lblNoResults
            //
            lblNoResults.BackColor = Color.Transparent;
            lblNoResults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNoResults.ForeColor = Color.FromArgb(154, 136, 128);
            lblNoResults.Location = new Point(30, 240);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(500, 60);
            lblNoResults.TabIndex = 4;
            lblNoResults.Text = "No parents match your search.";
            lblNoResults.Visible = false;
            //
            // FindParentsForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "FindParentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - Find Parents";
            Load += FindParentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            pnlSearchCard.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnNavBabysitterHome;
        private Guna.UI2.WinForms.Guna2Button btnNavFindParents;
        private Guna.UI2.WinForms.Guna2Button btnNavMyProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchCard;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.FlowLayoutPanel flpResults;
        private System.Windows.Forms.Label lblNoResults;
    }
}
