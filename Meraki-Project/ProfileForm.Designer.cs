namespace Meraki_Project
{
    partial class ProfileForm
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

            // Navbar - every possible link is created here, but only the ones that
            // match the signed-in role get added to pnlNavbar.Controls at runtime
            // (see SetupNavbarForRole in ProfileForm.cs).
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnNavParentHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavBabysitterHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavFindBabysitter = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavBookNow = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();

            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();

            // Header card
            this.pnlProfileHeaderCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBanner = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlAvatarCircle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAvatarInitial = new System.Windows.Forms.Label();
            this.picAvatarPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnChangePhoto = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditProfile = new Guna.UI2.WinForms.Guna2Button();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblRoleBadge = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRatingLocation = new System.Windows.Forms.Label();
            this.pnlStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatBookingsValue = new System.Windows.Forms.Label();
            this.lblStatBookingsLabel = new System.Windows.Forms.Label();
            this.pnlStatExperience = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatExperienceValue = new System.Windows.Forms.Label();
            this.lblStatExperienceLabel = new System.Windows.Forms.Label();
            this.pnlStatRate = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatRateValue = new System.Windows.Forms.Label();
            this.lblStatRateLabel = new System.Windows.Forms.Label();

            // Tabs
            this.pnlTabsBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabReviews = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabSettings = new Guna.UI2.WinForms.Guna2Button();

            // Profile tab
            this.pnlTabProfile = new System.Windows.Forms.Panel();
            this.pnlPersonalInfoCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPersonalInfoTitle = new System.Windows.Forms.Label();
            this.lblFirstNameCaption = new System.Windows.Forms.Label();
            this.tbFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLastNameCaption = new System.Windows.Forms.Label();
            this.tbLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmailCaption = new System.Windows.Forms.Label();
            this.tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhoneCaption = new System.Windows.Forms.Label();
            this.tbPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLocationCaption = new System.Windows.Forms.Label();
            this.tbLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBioCaption = new System.Windows.Forms.Label();
            this.tbBio = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlSkillsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSkillsTitle = new System.Windows.Forms.Label();
            this.flpSkills = new System.Windows.Forms.FlowLayoutPanel();

            // Reviews tab
            this.pnlTabReviews = new System.Windows.Forms.Panel();
            this.flpReviews = new System.Windows.Forms.FlowLayoutPanel();

            // Settings tab
            this.pnlTabSettings = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatarPhoto)).BeginInit();
            this.pnlPageBackground.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlProfileHeaderCard.SuspendLayout();
            this.pnlAvatarCircle.SuspendLayout();
            this.pnlStatBookings.SuspendLayout();
            this.pnlStatExperience.SuspendLayout();
            this.pnlStatRate.SuspendLayout();
            this.pnlTabsBar.SuspendLayout();
            this.pnlTabProfile.SuspendLayout();
            this.pnlPersonalInfoCard.SuspendLayout();
            this.pnlSkillsCard.SuspendLayout();
            this.pnlTabReviews.SuspendLayout();
            this.pnlTabSettings.SuspendLayout();
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
            // pnlNavbar (buttons styled here, added to Controls at runtime per role)
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

            SetupNavButton(this.btnNavParentHome, "Parent Home", false);
            this.btnNavParentHome.Click += new System.EventHandler(this.btnNavParentHome_Click);
            SetupNavButton(this.btnNavBabysitterHome, "Babysitter Home", false);
            this.btnNavBabysitterHome.Click += new System.EventHandler(this.btnNavBabysitterHome_Click);
            SetupNavButton(this.btnNavFindBabysitter, "Find a Babysitter", false);
            this.btnNavFindBabysitter.Click += new System.EventHandler(this.btnNavFindBabysitter_Click);
            SetupNavButton(this.btnNavBookNow, "Book Now", false);
            this.btnNavBookNow.Click += new System.EventHandler(this.btnNavBookNow_Click);
            SetupNavButton(this.btnNavMyProfile, "My Profile", true);
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
            // Role-relevant nav buttons + btnLogout are added in ProfileForm.cs (SetupNavbarForRole).

            //
            // pnlContent
            //
            this.pnlContent.AutoScroll = true;
            this.pnlContent.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlContent.FillColor2 = System.Drawing.Color.FromArgb(225, 240, 239);
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1500, 820);

            //
            // pnlProfileHeaderCard
            //
            this.pnlProfileHeaderCard.BorderRadius = 16;
            this.pnlProfileHeaderCard.FillColor = System.Drawing.Color.White;
            this.pnlProfileHeaderCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlProfileHeaderCard.Location = new System.Drawing.Point(30, 30);
            this.pnlProfileHeaderCard.Name = "pnlProfileHeaderCard";
            this.pnlProfileHeaderCard.Size = new System.Drawing.Size(900, 280);

            this.pnlBanner.BorderRadius = 16;
            this.pnlBanner.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.pnlBanner.FillColor2 = System.Drawing.Color.FromArgb(232, 113, 74);
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Size = new System.Drawing.Size(900, 90);

            this.pnlAvatarCircle.BorderRadius = 45;
            this.pnlAvatarCircle.FillColor = System.Drawing.Color.FromArgb(222, 245, 244);
            this.pnlAvatarCircle.Location = new System.Drawing.Point(24, 60);
            this.pnlAvatarCircle.Size = new System.Drawing.Size(90, 90);

            this.lblAvatarInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatarInitial.Text = "E";
            this.lblAvatarInitial.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.lblAvatarInitial.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAvatarInitial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvatarInitial.BackColor = System.Drawing.Color.Transparent;
            this.pnlAvatarCircle.Controls.Add(this.lblAvatarInitial);

            this.picAvatarPhoto.BorderRadius = 45;
            this.picAvatarPhoto.Location = new System.Drawing.Point(24, 60);
            this.picAvatarPhoto.Size = new System.Drawing.Size(90, 90);
            this.picAvatarPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatarPhoto.Visible = false;

            this.btnChangePhoto.BorderRadius = 15;
            this.btnChangePhoto.BorderThickness = 0;
            this.btnChangePhoto.ShadowDecoration.Enabled = false;
            this.btnChangePhoto.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnChangePhoto.ForeColor = System.Drawing.Color.White;
            this.btnChangePhoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangePhoto.Location = new System.Drawing.Point(90, 128);
            this.btnChangePhoto.Size = new System.Drawing.Size(30, 30);
            this.btnChangePhoto.Text = "\U0001F4F7";
            this.btnChangePhoto.Click += new System.EventHandler(this.btnChangePhoto_Click);

            this.btnEditProfile.BorderRadius = 10;
            this.btnEditProfile.BorderThickness = 0;
            this.btnEditProfile.ShadowDecoration.Enabled = false;
            this.btnEditProfile.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnEditProfile.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditProfile.Location = new System.Drawing.Point(760, 100);
            this.btnEditProfile.Size = new System.Drawing.Size(120, 36);
            this.btnEditProfile.Text = "Edit Profile";
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);

            this.lblProfileName.Location = new System.Drawing.Point(126, 100);
            this.lblProfileName.Size = new System.Drawing.Size(300, 28);
            this.lblProfileName.Text = "Emma Thompson";
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.BackColor = System.Drawing.Color.Transparent;

            this.lblRoleBadge.Location = new System.Drawing.Point(430, 104);
            this.lblRoleBadge.Size = new System.Drawing.Size(100, 24);
            this.lblRoleBadge.Text = "<div style=\"background:#DEF5F4;color:#3CA09C;border-radius:10px;padding:2px 10px;font-weight:bold;\">Babysitter</div>";

            this.lblRatingLocation.Location = new System.Drawing.Point(126, 132);
            this.lblRatingLocation.Size = new System.Drawing.Size(400, 22);
            this.lblRatingLocation.Text = "★ 4.9 (47 reviews)    \U0001F4CD Downtown, New York";
            this.lblRatingLocation.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRatingLocation.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRatingLocation.BackColor = System.Drawing.Color.Transparent;

            SetupHeaderStatCard(this.pnlStatBookings, this.lblStatBookingsValue, this.lblStatBookingsLabel, 126, "47", "Bookings");
            SetupHeaderStatCard(this.pnlStatExperience, this.lblStatExperienceValue, this.lblStatExperienceLabel, 356, "3yr", "Experience");
            SetupHeaderStatCard(this.pnlStatRate, this.lblStatRateValue, this.lblStatRateLabel, 586, "$18/hr", "Rate");

            this.pnlProfileHeaderCard.Controls.Add(this.pnlBanner);
            this.pnlProfileHeaderCard.Controls.Add(this.pnlAvatarCircle);
            this.pnlProfileHeaderCard.Controls.Add(this.picAvatarPhoto);
            this.pnlProfileHeaderCard.Controls.Add(this.btnChangePhoto);
            this.pnlProfileHeaderCard.Controls.Add(this.btnEditProfile);
            this.pnlProfileHeaderCard.Controls.Add(this.lblProfileName);
            this.pnlProfileHeaderCard.Controls.Add(this.lblRoleBadge);
            this.pnlProfileHeaderCard.Controls.Add(this.lblRatingLocation);
            this.pnlProfileHeaderCard.Controls.Add(this.pnlStatBookings);
            this.pnlProfileHeaderCard.Controls.Add(this.pnlStatExperience);
            this.pnlProfileHeaderCard.Controls.Add(this.pnlStatRate);

            //
            // pnlTabsBar
            //
            this.pnlTabsBar.BorderRadius = 16;
            this.pnlTabsBar.FillColor = System.Drawing.Color.White;
            this.pnlTabsBar.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlTabsBar.Location = new System.Drawing.Point(30, 320);
            this.pnlTabsBar.Name = "pnlTabsBar";
            this.pnlTabsBar.Size = new System.Drawing.Size(900, 52);

            SetupTabButton(this.btnTabProfile, "Profile", 4, true);
            this.btnTabProfile.Click += new System.EventHandler(this.btnTabProfile_Click);
            SetupTabButton(this.btnTabReviews, "Reviews", 304, false);
            this.btnTabReviews.Click += new System.EventHandler(this.btnTabReviews_Click);
            SetupTabButton(this.btnTabSettings, "Settings", 604, false);
            this.btnTabSettings.Click += new System.EventHandler(this.btnTabSettings_Click);

            this.pnlTabsBar.Controls.Add(this.btnTabProfile);
            this.pnlTabsBar.Controls.Add(this.btnTabReviews);
            this.pnlTabsBar.Controls.Add(this.btnTabSettings);

            //
            // pnlTabProfile
            //
            this.pnlTabProfile.Location = new System.Drawing.Point(30, 384);
            this.pnlTabProfile.Size = new System.Drawing.Size(900, 600);
            this.pnlTabProfile.BackColor = System.Drawing.Color.Transparent;

            this.pnlPersonalInfoCard.BorderRadius = 16;
            this.pnlPersonalInfoCard.FillColor = System.Drawing.Color.White;
            this.pnlPersonalInfoCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlPersonalInfoCard.Location = new System.Drawing.Point(0, 0);
            this.pnlPersonalInfoCard.Size = new System.Drawing.Size(900, 400);

            this.lblPersonalInfoTitle.Location = new System.Drawing.Point(16, 14);
            this.lblPersonalInfoTitle.Size = new System.Drawing.Size(300, 24);
            this.lblPersonalInfoTitle.Text = "Personal Information";
            this.lblPersonalInfoTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPersonalInfoTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfoTitle.BackColor = System.Drawing.Color.Transparent;

            SetupFieldLabel(this.lblFirstNameCaption, "First Name", 16, 52);
            SetupFieldBox(this.tbFirstName, 16, 74, 410);
            SetupFieldLabel(this.lblLastNameCaption, "Last Name", 436, 52);
            SetupFieldBox(this.tbLastName, 436, 74, 448);
            SetupFieldLabel(this.lblEmailCaption, "Email", 16, 130);
            SetupFieldBox(this.tbEmail, 16, 152, 868);
            SetupFieldLabel(this.lblPhoneCaption, "Phone", 16, 208);
            SetupFieldBox(this.tbPhone, 16, 230, 868);
            SetupFieldLabel(this.lblLocationCaption, "Location", 16, 286);
            SetupFieldBox(this.tbLocation, 16, 308, 868);
            SetupFieldLabel(this.lblBioCaption, "Bio", 16, 364);
            this.tbBio.Multiline = true;
            SetupFieldBox(this.tbBio, 16, 386, 868, 60);

            this.pnlPersonalInfoCard.Controls.Add(this.lblPersonalInfoTitle);
            this.pnlPersonalInfoCard.Controls.Add(this.lblFirstNameCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbFirstName);
            this.pnlPersonalInfoCard.Controls.Add(this.lblLastNameCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbLastName);
            this.pnlPersonalInfoCard.Controls.Add(this.lblEmailCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbEmail);
            this.pnlPersonalInfoCard.Controls.Add(this.lblPhoneCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbPhone);
            this.pnlPersonalInfoCard.Controls.Add(this.lblLocationCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbLocation);
            this.pnlPersonalInfoCard.Controls.Add(this.lblBioCaption);
            this.pnlPersonalInfoCard.Controls.Add(this.tbBio);

            this.pnlSkillsCard.BorderRadius = 16;
            this.pnlSkillsCard.FillColor = System.Drawing.Color.White;
            this.pnlSkillsCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlSkillsCard.Location = new System.Drawing.Point(0, 416);
            this.pnlSkillsCard.Size = new System.Drawing.Size(900, 150);

            this.lblSkillsTitle.Location = new System.Drawing.Point(16, 14);
            this.lblSkillsTitle.Size = new System.Drawing.Size(300, 22);
            this.lblSkillsTitle.Text = "Skills & Specializations";
            this.lblSkillsTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblSkillsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSkillsTitle.BackColor = System.Drawing.Color.Transparent;

            this.flpSkills.Location = new System.Drawing.Point(12, 46);
            this.flpSkills.Size = new System.Drawing.Size(876, 96);
            this.flpSkills.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpSkills.WrapContents = true;
            this.flpSkills.BackColor = System.Drawing.Color.Transparent;

            this.pnlSkillsCard.Controls.Add(this.lblSkillsTitle);
            this.pnlSkillsCard.Controls.Add(this.flpSkills);

            this.pnlTabProfile.Controls.Add(this.pnlPersonalInfoCard);
            this.pnlTabProfile.Controls.Add(this.pnlSkillsCard);

            //
            // pnlTabReviews
            //
            this.pnlTabReviews.Location = new System.Drawing.Point(30, 384);
            this.pnlTabReviews.Size = new System.Drawing.Size(900, 600);
            this.pnlTabReviews.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabReviews.Visible = false;

            this.flpReviews.Location = new System.Drawing.Point(0, 0);
            this.flpReviews.Size = new System.Drawing.Size(900, 600);
            this.flpReviews.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpReviews.WrapContents = false;
            this.flpReviews.AutoScroll = true;
            this.flpReviews.BackColor = System.Drawing.Color.Transparent;

            this.pnlTabReviews.Controls.Add(this.flpReviews);

            //
            // pnlTabSettings - built entirely in ProfileForm.cs (BuildSettingsRow)
            //
            this.pnlTabSettings.Location = new System.Drawing.Point(30, 384);
            this.pnlTabSettings.Size = new System.Drawing.Size(900, 600);
            this.pnlTabSettings.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabSettings.Visible = false;

            this.pnlContent.Controls.Add(this.pnlProfileHeaderCard);
            this.pnlContent.Controls.Add(this.pnlTabsBar);
            this.pnlContent.Controls.Add(this.pnlTabProfile);
            this.pnlContent.Controls.Add(this.pnlTabReviews);
            this.pnlContent.Controls.Add(this.pnlTabSettings);

            //
            // ProfileForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.pnlPageBackground);
            this.MinimumSize = new System.Drawing.Size(1246, 738);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meraki - My Profile";
            this.Load += new System.EventHandler(this.ProfileForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatarPhoto)).EndInit();
            this.pnlTabSettings.ResumeLayout(false);
            this.pnlTabReviews.ResumeLayout(false);
            this.pnlSkillsCard.ResumeLayout(false);
            this.pnlPersonalInfoCard.ResumeLayout(false);
            this.pnlPersonalInfoCard.PerformLayout();
            this.pnlTabProfile.ResumeLayout(false);
            this.pnlTabsBar.ResumeLayout(false);
            this.pnlStatRate.ResumeLayout(false);
            this.pnlStatExperience.ResumeLayout(false);
            this.pnlStatBookings.ResumeLayout(false);
            this.pnlAvatarCircle.ResumeLayout(false);
            this.pnlProfileHeaderCard.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlPageBackground.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, bool active)
        {
            btn.BorderRadius = 8;
            btn.BorderThickness = 0;
            btn.ShadowDecoration.Enabled = false;
            btn.FillColor = active ? System.Drawing.Color.FromArgb(253, 238, 232) : System.Drawing.Color.Transparent;
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = active ? System.Drawing.Color.FromArgb(232, 113, 74) : System.Drawing.Color.FromArgb(154, 136, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 8.5F, active ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            btn.Height = 45;
            btn.Text = text;
        }

        private static void SetupHeaderStatCard(Guna.UI2.WinForms.Guna2Panel card, System.Windows.Forms.Label value,
            System.Windows.Forms.Label caption, int x, string valueText, string captionText)
        {
            card.BorderRadius = 12;
            card.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            card.Location = new System.Drawing.Point(x, 175);
            card.Size = new System.Drawing.Size(220, 70);

            value.Location = new System.Drawing.Point(10, 10);
            value.Size = new System.Drawing.Size(200, 26);
            value.Text = valueText;
            value.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            value.BackColor = System.Drawing.Color.Transparent;

            caption.Location = new System.Drawing.Point(10, 38);
            caption.Size = new System.Drawing.Size(200, 20);
            caption.Text = captionText;
            caption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            caption.Font = new System.Drawing.Font("Segoe UI", 8F);
            caption.BackColor = System.Drawing.Color.Transparent;

            card.Controls.Add(value);
            card.Controls.Add(caption);
        }

        private static void SetupTabButton(Guna.UI2.WinForms.Guna2Button btn, string text, int x, bool active)
        {
            btn.BorderRadius = 12;
            btn.BorderThickness = 0;
            btn.ShadowDecoration.Enabled = false;
            btn.FillColor = active ? System.Drawing.Color.FromArgb(232, 113, 74) : System.Drawing.Color.Transparent;
            btn.ForeColor = active ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(154, 136, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, active ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            btn.Location = new System.Drawing.Point(x, 4);
            btn.Size = new System.Drawing.Size(292, 44);
            btn.Text = text;
        }

        private static void SetupFieldLabel(System.Windows.Forms.Label label, string text, int x, int y)
        {
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(300, 18);
            label.Text = text;
            label.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            label.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            label.BackColor = System.Drawing.Color.Transparent;
        }

        private static void SetupFieldBox(Guna.UI2.WinForms.Guna2TextBox box, int x, int y, int width, int height = 40)
        {
            box.BorderRadius = 10;
            box.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            box.Location = new System.Drawing.Point(x, y);
            box.Size = new System.Drawing.Size(width, height);
            box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 113, 74);
            box.ReadOnly = true;
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlPageBackground;
        private Guna.UI2.WinForms.Guna2Panel pnlNavbar;
        private Guna.UI2.WinForms.Guna2PictureBox picNavLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNavBrand;
        private Guna.UI2.WinForms.Guna2Button btnNavParentHome;
        private Guna.UI2.WinForms.Guna2Button btnNavBabysitterHome;
        private Guna.UI2.WinForms.Guna2Button btnNavFindBabysitter;
        private Guna.UI2.WinForms.Guna2Button btnNavBookNow;
        private Guna.UI2.WinForms.Guna2Button btnNavMyProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;

        private Guna.UI2.WinForms.Guna2Panel pnlProfileHeaderCard;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlBanner;
        private Guna.UI2.WinForms.Guna2Panel pnlAvatarCircle;
        private System.Windows.Forms.Label lblAvatarInitial;
        private Guna.UI2.WinForms.Guna2PictureBox picAvatarPhoto;
        private Guna.UI2.WinForms.Guna2Button btnChangePhoto;
        private Guna.UI2.WinForms.Guna2Button btnEditProfile;
        private System.Windows.Forms.Label lblProfileName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRoleBadge;
        private System.Windows.Forms.Label lblRatingLocation;
        private Guna.UI2.WinForms.Guna2Panel pnlStatBookings;
        private System.Windows.Forms.Label lblStatBookingsValue;
        private System.Windows.Forms.Label lblStatBookingsLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlStatExperience;
        private System.Windows.Forms.Label lblStatExperienceValue;
        private System.Windows.Forms.Label lblStatExperienceLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlStatRate;
        private System.Windows.Forms.Label lblStatRateValue;
        private System.Windows.Forms.Label lblStatRateLabel;

        private Guna.UI2.WinForms.Guna2Panel pnlTabsBar;
        private Guna.UI2.WinForms.Guna2Button btnTabProfile;
        private Guna.UI2.WinForms.Guna2Button btnTabReviews;
        private Guna.UI2.WinForms.Guna2Button btnTabSettings;

        private System.Windows.Forms.Panel pnlTabProfile;
        private Guna.UI2.WinForms.Guna2Panel pnlPersonalInfoCard;
        private System.Windows.Forms.Label lblPersonalInfoTitle;
        private System.Windows.Forms.Label lblFirstNameCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbFirstName;
        private System.Windows.Forms.Label lblLastNameCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbLastName;
        private System.Windows.Forms.Label lblEmailCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbEmail;
        private System.Windows.Forms.Label lblPhoneCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbPhone;
        private System.Windows.Forms.Label lblLocationCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbLocation;
        private System.Windows.Forms.Label lblBioCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbBio;
        private Guna.UI2.WinForms.Guna2Panel pnlSkillsCard;
        private System.Windows.Forms.Label lblSkillsTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSkills;

        private System.Windows.Forms.Panel pnlTabReviews;
        private System.Windows.Forms.FlowLayoutPanel flpReviews;

        private System.Windows.Forms.Panel pnlTabSettings;
    }
}
