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
            pnlPageBackground = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNavParentHome = new Guna.UI2.WinForms.Guna2Button();
            btnNavBabysitterHome = new Guna.UI2.WinForms.Guna2Button();
            btnNavFindBabysitter = new Guna.UI2.WinForms.Guna2Button();
            btnNavBookNow = new Guna.UI2.WinForms.Guna2Button();
            btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlProfileHeaderCard = new Guna.UI2.WinForms.Guna2Panel();
            pnlBanner = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlAvatarCircle = new Guna.UI2.WinForms.Guna2Panel();
            lblAvatarInitial = new Label();
            picAvatarPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            btnChangePhoto = new Guna.UI2.WinForms.Guna2Button();
            btnEditProfile = new Guna.UI2.WinForms.Guna2Button();
            lblProfileName = new Label();
            lblRoleBadge = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblRatingLocation = new Label();
            pnlStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            lblStatBookingsValue = new Label();
            lblStatBookingsLabel = new Label();
            pnlStatExperience = new Guna.UI2.WinForms.Guna2Panel();
            lblStatExperienceValue = new Label();
            lblStatExperienceLabel = new Label();
            pnlStatRate = new Guna.UI2.WinForms.Guna2Panel();
            lblStatRateValue = new Label();
            lblStatRateLabel = new Label();
            pnlTabsBar = new Guna.UI2.WinForms.Guna2Panel();
            btnTabProfile = new Guna.UI2.WinForms.Guna2Button();
            btnTabReviews = new Guna.UI2.WinForms.Guna2Button();
            btnTabSettings = new Guna.UI2.WinForms.Guna2Button();
            pnlTabProfile = new Panel();
            pnlPersonalInfoCard = new Guna.UI2.WinForms.Guna2Panel();
            lblPersonalInfoTitle = new Label();
            lblFirstNameCaption = new Label();
            tbFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            lblLastNameCaption = new Label();
            tbLastName = new Guna.UI2.WinForms.Guna2TextBox();
            lblEmailCaption = new Label();
            tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblPhoneCaption = new Label();
            tbPhone = new Guna.UI2.WinForms.Guna2TextBox();
            lblLocationCaption = new Label();
            tbLocation = new Guna.UI2.WinForms.Guna2TextBox();
            lblBioCaption = new Label();
            tbBio = new Guna.UI2.WinForms.Guna2TextBox();
            pnlSkillsCard = new Guna.UI2.WinForms.Guna2Panel();
            lblSkillsTitle = new Label();
            flpSkills = new FlowLayoutPanel();
            pnlTabReviews = new Panel();
            flpReviews = new FlowLayoutPanel();
            pnlTabSettings = new Panel();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAvatarPhoto).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlProfileHeaderCard.SuspendLayout();
            pnlAvatarCircle.SuspendLayout();
            pnlStatBookings.SuspendLayout();
            pnlStatExperience.SuspendLayout();
            pnlStatRate.SuspendLayout();
            pnlTabsBar.SuspendLayout();
            pnlTabProfile.SuspendLayout();
            pnlPersonalInfoCard.SuspendLayout();
            pnlSkillsCard.SuspendLayout();
            pnlTabReviews.SuspendLayout();
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
            // pnlNavbar (only logo + brand added here; role-specific nav buttons and
            // Logout are positioned and added at runtime by SetupNavbarForRole)
            //
            pnlNavbar.BackColor = Color.Transparent;
            pnlNavbar.Controls.Add(picNavLogo);
            pnlNavbar.Controls.Add(lblNavBrand);
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
            btnNavBabysitterHome.Size = new Size(160, 45);
            btnNavBabysitterHome.TabIndex = 3;
            btnNavBabysitterHome.Text = "Babysitter Home";
            btnNavBabysitterHome.Click += btnNavBabysitterHome_Click;
            //
            // btnNavFindBabysitter
            //
            btnNavFindBabysitter.BackColor = Color.White;
            btnNavFindBabysitter.BorderRadius = 8;
            btnNavFindBabysitter.FillColor = Color.Transparent;
            btnNavFindBabysitter.Font = new Font("Segoe UI", 8.5F);
            btnNavFindBabysitter.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavFindBabysitter.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavFindBabysitter.Location = new Point(421, 18);
            btnNavFindBabysitter.Name = "btnNavFindBabysitter";
            btnNavFindBabysitter.Size = new Size(162, 45);
            btnNavFindBabysitter.TabIndex = 4;
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
            btnNavBookNow.Location = new Point(591, 18);
            btnNavBookNow.Name = "btnNavBookNow";
            btnNavBookNow.Size = new Size(125, 45);
            btnNavBookNow.TabIndex = 5;
            btnNavBookNow.Text = "Book Now";
            btnNavBookNow.Click += btnNavBookNow_Click;
            //
            // btnNavMyProfile (active page)
            //
            btnNavMyProfile.BackColor = Color.White;
            btnNavMyProfile.BorderRadius = 8;
            btnNavMyProfile.FillColor = Color.FromArgb(253, 238, 232);
            btnNavMyProfile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNavMyProfile.ForeColor = Color.FromArgb(232, 113, 74);
            btnNavMyProfile.HoverState.FillColor = Color.FromArgb(250, 226, 216);
            btnNavMyProfile.Location = new Point(724, 18);
            btnNavMyProfile.Name = "btnNavMyProfile";
            btnNavMyProfile.Size = new Size(125, 45);
            btnNavMyProfile.TabIndex = 6;
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
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            //
            // pnlContent
            //
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(pnlProfileHeaderCard);
            pnlContent.Controls.Add(pnlTabsBar);
            pnlContent.Controls.Add(pnlTabProfile);
            pnlContent.Controls.Add(pnlTabReviews);
            pnlContent.Controls.Add(pnlTabSettings);
            pnlContent.FillColor = Color.FromArgb(253, 238, 232);
            pnlContent.FillColor2 = Color.FromArgb(225, 240, 239);
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1500, 820);
            pnlContent.TabIndex = 0;
            //
            // pnlProfileHeaderCard
            //
            pnlProfileHeaderCard.BackColor = Color.Transparent;
            pnlProfileHeaderCard.BorderRadius = 16;
            pnlProfileHeaderCard.Controls.Add(pnlBanner);
            pnlProfileHeaderCard.Controls.Add(pnlAvatarCircle);
            pnlProfileHeaderCard.Controls.Add(picAvatarPhoto);
            pnlProfileHeaderCard.Controls.Add(btnChangePhoto);
            pnlProfileHeaderCard.Controls.Add(btnEditProfile);
            pnlProfileHeaderCard.Controls.Add(lblProfileName);
            pnlProfileHeaderCard.Controls.Add(lblRoleBadge);
            pnlProfileHeaderCard.Controls.Add(lblRatingLocation);
            pnlProfileHeaderCard.Controls.Add(pnlStatBookings);
            pnlProfileHeaderCard.Controls.Add(pnlStatExperience);
            pnlProfileHeaderCard.Controls.Add(pnlStatRate);
            pnlProfileHeaderCard.FillColor = Color.White;
            pnlProfileHeaderCard.Location = new Point(30, 30);
            pnlProfileHeaderCard.Name = "pnlProfileHeaderCard";
            pnlProfileHeaderCard.Size = new Size(900, 270);
            pnlProfileHeaderCard.TabIndex = 0;
            //
            // pnlBanner
            //
            pnlBanner.BackColor = Color.Transparent;
            pnlBanner.BorderRadius = 16;
            pnlBanner.FillColor = Color.FromArgb(94, 200, 196);
            pnlBanner.FillColor2 = Color.FromArgb(232, 113, 74);
            pnlBanner.Location = new Point(0, 0);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(900, 90);
            pnlBanner.TabIndex = 0;
            //
            // pnlAvatarCircle (sits BELOW the banner - overlapping siblings can't be
            // rendered transparently in WinForms, so we avoid the overlap entirely)
            //
            pnlAvatarCircle.BackColor = Color.White;
            pnlAvatarCircle.BorderRadius = 34;
            pnlAvatarCircle.Controls.Add(lblAvatarInitial);
            pnlAvatarCircle.FillColor = Color.FromArgb(222, 245, 244);
            pnlAvatarCircle.Location = new Point(24, 104);
            pnlAvatarCircle.Name = "pnlAvatarCircle";
            pnlAvatarCircle.Size = new Size(70, 70);
            pnlAvatarCircle.TabIndex = 1;
            //
            // lblAvatarInitial
            //
            lblAvatarInitial.BackColor = Color.Transparent;
            lblAvatarInitial.Dock = DockStyle.Fill;
            lblAvatarInitial.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAvatarInitial.ForeColor = Color.FromArgb(94, 200, 196);
            lblAvatarInitial.Location = new Point(0, 0);
            lblAvatarInitial.Name = "lblAvatarInitial";
            lblAvatarInitial.Size = new Size(70, 70);
            lblAvatarInitial.TabIndex = 0;
            lblAvatarInitial.Text = "U";
            lblAvatarInitial.TextAlign = ContentAlignment.MiddleCenter;
            //
            // picAvatarPhoto (shown instead of the initial once a photo is chosen)
            //
            picAvatarPhoto.BackColor = Color.White;
            picAvatarPhoto.BorderRadius = 34;
            picAvatarPhoto.ImageRotate = 0F;
            picAvatarPhoto.Location = new Point(24, 104);
            picAvatarPhoto.Name = "picAvatarPhoto";
            picAvatarPhoto.Size = new Size(70, 70);
            picAvatarPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatarPhoto.TabIndex = 2;
            picAvatarPhoto.TabStop = false;
            picAvatarPhoto.Visible = false;
            //
            // btnChangePhoto
            //
            btnChangePhoto.BackColor = Color.White;
            btnChangePhoto.BorderRadius = 14;
            btnChangePhoto.FillColor = Color.FromArgb(232, 113, 74);
            btnChangePhoto.Font = new Font("Segoe UI", 9F);
            btnChangePhoto.ForeColor = Color.White;
            btnChangePhoto.Location = new Point(24, 182);
            btnChangePhoto.Name = "btnChangePhoto";
            btnChangePhoto.Size = new Size(70, 28);
            btnChangePhoto.TabIndex = 3;
            btnChangePhoto.Text = "📷";
            btnChangePhoto.Click += btnChangePhoto_Click;
            //
            // btnEditProfile
            //
            btnEditProfile.BackColor = Color.White;
            btnEditProfile.BorderRadius = 10;
            btnEditProfile.FillColor = Color.FromArgb(247, 245, 242);
            btnEditProfile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditProfile.ForeColor = Color.FromArgb(60, 50, 45);
            btnEditProfile.Location = new Point(760, 104);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(120, 36);
            btnEditProfile.TabIndex = 4;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.Click += btnEditProfile_Click;
            //
            // lblProfileName
            //
            lblProfileName.BackColor = Color.Transparent;
            lblProfileName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfileName.ForeColor = Color.FromArgb(60, 50, 45);
            lblProfileName.Location = new Point(110, 104);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(320, 26);
            lblProfileName.TabIndex = 5;
            lblProfileName.Text = "Emma Thompson";
            //
            // lblRoleBadge
            //
            lblRoleBadge.BackColor = Color.Transparent;
            lblRoleBadge.Location = new Point(440, 106);
            lblRoleBadge.Name = "lblRoleBadge";
            lblRoleBadge.Size = new Size(110, 24);
            lblRoleBadge.TabIndex = 6;
            lblRoleBadge.Text = "<div style=\"background:#DEF5F4;color:#3CA09C;border-radius:10px;padding:2px 10px;font-weight:bold;\">Babysitter</div>";
            //
            // lblRatingLocation
            //
            lblRatingLocation.BackColor = Color.Transparent;
            lblRatingLocation.Font = new Font("Segoe UI", 8.5F);
            lblRatingLocation.ForeColor = Color.FromArgb(154, 136, 128);
            lblRatingLocation.Location = new Point(110, 134);
            lblRatingLocation.Name = "lblRatingLocation";
            lblRatingLocation.Size = new Size(430, 20);
            lblRatingLocation.TabIndex = 7;
            lblRatingLocation.Text = "★ 4.9 (47 reviews)    📍 Downtown, New York";
            //
            // pnlStatBookings
            //
            pnlStatBookings.BackColor = Color.White;
            pnlStatBookings.BorderRadius = 12;
            pnlStatBookings.Controls.Add(lblStatBookingsValue);
            pnlStatBookings.Controls.Add(lblStatBookingsLabel);
            pnlStatBookings.FillColor = Color.FromArgb(253, 238, 232);
            pnlStatBookings.Location = new Point(110, 178);
            pnlStatBookings.Name = "pnlStatBookings";
            pnlStatBookings.Size = new Size(220, 74);
            pnlStatBookings.TabIndex = 8;
            //
            // lblStatBookingsValue
            //
            lblStatBookingsValue.BackColor = Color.Transparent;
            lblStatBookingsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatBookingsValue.ForeColor = Color.FromArgb(232, 113, 74);
            lblStatBookingsValue.Location = new Point(10, 10);
            lblStatBookingsValue.Name = "lblStatBookingsValue";
            lblStatBookingsValue.Size = new Size(200, 26);
            lblStatBookingsValue.TabIndex = 0;
            lblStatBookingsValue.Text = "47";
            //
            // lblStatBookingsLabel
            //
            lblStatBookingsLabel.BackColor = Color.Transparent;
            lblStatBookingsLabel.Font = new Font("Segoe UI", 8F);
            lblStatBookingsLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatBookingsLabel.Location = new Point(10, 40);
            lblStatBookingsLabel.Name = "lblStatBookingsLabel";
            lblStatBookingsLabel.Size = new Size(200, 20);
            lblStatBookingsLabel.TabIndex = 1;
            lblStatBookingsLabel.Text = "Bookings";
            //
            // pnlStatExperience
            //
            pnlStatExperience.BackColor = Color.White;
            pnlStatExperience.BorderRadius = 12;
            pnlStatExperience.Controls.Add(lblStatExperienceValue);
            pnlStatExperience.Controls.Add(lblStatExperienceLabel);
            pnlStatExperience.FillColor = Color.FromArgb(253, 238, 232);
            pnlStatExperience.Location = new Point(350, 178);
            pnlStatExperience.Name = "pnlStatExperience";
            pnlStatExperience.Size = new Size(220, 74);
            pnlStatExperience.TabIndex = 9;
            //
            // lblStatExperienceValue
            //
            lblStatExperienceValue.BackColor = Color.Transparent;
            lblStatExperienceValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatExperienceValue.ForeColor = Color.FromArgb(232, 113, 74);
            lblStatExperienceValue.Location = new Point(10, 10);
            lblStatExperienceValue.Name = "lblStatExperienceValue";
            lblStatExperienceValue.Size = new Size(200, 26);
            lblStatExperienceValue.TabIndex = 0;
            lblStatExperienceValue.Text = "3yr";
            //
            // lblStatExperienceLabel
            //
            lblStatExperienceLabel.BackColor = Color.Transparent;
            lblStatExperienceLabel.Font = new Font("Segoe UI", 8F);
            lblStatExperienceLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatExperienceLabel.Location = new Point(10, 40);
            lblStatExperienceLabel.Name = "lblStatExperienceLabel";
            lblStatExperienceLabel.Size = new Size(200, 20);
            lblStatExperienceLabel.TabIndex = 1;
            lblStatExperienceLabel.Text = "Experience";
            //
            // pnlStatRate
            //
            pnlStatRate.BackColor = Color.White;
            pnlStatRate.BorderRadius = 12;
            pnlStatRate.Controls.Add(lblStatRateValue);
            pnlStatRate.Controls.Add(lblStatRateLabel);
            pnlStatRate.FillColor = Color.FromArgb(253, 238, 232);
            pnlStatRate.Location = new Point(590, 178);
            pnlStatRate.Name = "pnlStatRate";
            pnlStatRate.Size = new Size(220, 74);
            pnlStatRate.TabIndex = 10;
            //
            // lblStatRateValue
            //
            lblStatRateValue.BackColor = Color.Transparent;
            lblStatRateValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatRateValue.ForeColor = Color.FromArgb(232, 113, 74);
            lblStatRateValue.Location = new Point(10, 10);
            lblStatRateValue.Name = "lblStatRateValue";
            lblStatRateValue.Size = new Size(200, 26);
            lblStatRateValue.TabIndex = 0;
            lblStatRateValue.Text = "$18/hr";
            //
            // lblStatRateLabel
            //
            lblStatRateLabel.BackColor = Color.Transparent;
            lblStatRateLabel.Font = new Font("Segoe UI", 8F);
            lblStatRateLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatRateLabel.Location = new Point(10, 40);
            lblStatRateLabel.Name = "lblStatRateLabel";
            lblStatRateLabel.Size = new Size(200, 20);
            lblStatRateLabel.TabIndex = 1;
            lblStatRateLabel.Text = "Rate";
            //
            // pnlTabsBar
            //
            pnlTabsBar.BackColor = Color.Transparent;
            pnlTabsBar.BorderRadius = 16;
            pnlTabsBar.Controls.Add(btnTabProfile);
            pnlTabsBar.Controls.Add(btnTabReviews);
            pnlTabsBar.Controls.Add(btnTabSettings);
            pnlTabsBar.FillColor = Color.White;
            pnlTabsBar.Location = new Point(30, 316);
            pnlTabsBar.Name = "pnlTabsBar";
            pnlTabsBar.Size = new Size(900, 52);
            pnlTabsBar.TabIndex = 1;
            //
            // btnTabProfile
            //
            btnTabProfile.BackColor = Color.White;
            btnTabProfile.BorderRadius = 12;
            btnTabProfile.FillColor = Color.FromArgb(232, 113, 74);
            btnTabProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabProfile.ForeColor = Color.White;
            btnTabProfile.Location = new Point(4, 4);
            btnTabProfile.Name = "btnTabProfile";
            btnTabProfile.Size = new Size(292, 44);
            btnTabProfile.TabIndex = 0;
            btnTabProfile.Text = "Profile";
            btnTabProfile.Click += btnTabProfile_Click;
            //
            // btnTabReviews
            //
            btnTabReviews.BackColor = Color.White;
            btnTabReviews.BorderRadius = 12;
            btnTabReviews.FillColor = Color.Transparent;
            btnTabReviews.Font = new Font("Segoe UI", 9.5F);
            btnTabReviews.ForeColor = Color.FromArgb(154, 136, 128);
            btnTabReviews.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnTabReviews.Location = new Point(304, 4);
            btnTabReviews.Name = "btnTabReviews";
            btnTabReviews.Size = new Size(292, 44);
            btnTabReviews.TabIndex = 1;
            btnTabReviews.Text = "Reviews";
            btnTabReviews.Click += btnTabReviews_Click;
            //
            // btnTabSettings
            //
            btnTabSettings.BackColor = Color.White;
            btnTabSettings.BorderRadius = 12;
            btnTabSettings.FillColor = Color.Transparent;
            btnTabSettings.Font = new Font("Segoe UI", 9.5F);
            btnTabSettings.ForeColor = Color.FromArgb(154, 136, 128);
            btnTabSettings.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnTabSettings.Location = new Point(604, 4);
            btnTabSettings.Name = "btnTabSettings";
            btnTabSettings.Size = new Size(292, 44);
            btnTabSettings.TabIndex = 2;
            btnTabSettings.Text = "Settings";
            btnTabSettings.Click += btnTabSettings_Click;
            //
            // pnlTabProfile
            //
            pnlTabProfile.BackColor = Color.Transparent;
            pnlTabProfile.Controls.Add(pnlPersonalInfoCard);
            pnlTabProfile.Controls.Add(pnlSkillsCard);
            pnlTabProfile.Location = new Point(30, 384);
            pnlTabProfile.Name = "pnlTabProfile";
            pnlTabProfile.Size = new Size(900, 640);
            pnlTabProfile.TabIndex = 2;
            //
            // pnlPersonalInfoCard
            //
            pnlPersonalInfoCard.BackColor = Color.Transparent;
            pnlPersonalInfoCard.BorderRadius = 16;
            pnlPersonalInfoCard.Controls.Add(lblPersonalInfoTitle);
            pnlPersonalInfoCard.Controls.Add(lblFirstNameCaption);
            pnlPersonalInfoCard.Controls.Add(tbFirstName);
            pnlPersonalInfoCard.Controls.Add(lblLastNameCaption);
            pnlPersonalInfoCard.Controls.Add(tbLastName);
            pnlPersonalInfoCard.Controls.Add(lblEmailCaption);
            pnlPersonalInfoCard.Controls.Add(tbEmail);
            pnlPersonalInfoCard.Controls.Add(lblPhoneCaption);
            pnlPersonalInfoCard.Controls.Add(tbPhone);
            pnlPersonalInfoCard.Controls.Add(lblLocationCaption);
            pnlPersonalInfoCard.Controls.Add(tbLocation);
            pnlPersonalInfoCard.Controls.Add(lblBioCaption);
            pnlPersonalInfoCard.Controls.Add(tbBio);
            pnlPersonalInfoCard.FillColor = Color.White;
            pnlPersonalInfoCard.Location = new Point(0, 0);
            pnlPersonalInfoCard.Name = "pnlPersonalInfoCard";
            pnlPersonalInfoCard.Size = new Size(900, 460);
            pnlPersonalInfoCard.TabIndex = 0;
            //
            // lblPersonalInfoTitle
            //
            lblPersonalInfoTitle.BackColor = Color.Transparent;
            lblPersonalInfoTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPersonalInfoTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPersonalInfoTitle.Location = new Point(16, 14);
            lblPersonalInfoTitle.Name = "lblPersonalInfoTitle";
            lblPersonalInfoTitle.Size = new Size(300, 24);
            lblPersonalInfoTitle.TabIndex = 0;
            lblPersonalInfoTitle.Text = "Personal Information";
            //
            // lblFirstNameCaption
            //
            lblFirstNameCaption.BackColor = Color.Transparent;
            lblFirstNameCaption.Font = new Font("Segoe UI", 7.5F);
            lblFirstNameCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblFirstNameCaption.Location = new Point(16, 50);
            lblFirstNameCaption.Name = "lblFirstNameCaption";
            lblFirstNameCaption.Size = new Size(300, 18);
            lblFirstNameCaption.TabIndex = 1;
            lblFirstNameCaption.Text = "First Name";
            //
            // tbFirstName
            //
            tbFirstName.BorderRadius = 10;
            tbFirstName.DefaultText = "";
            tbFirstName.FillColor = Color.FromArgb(247, 245, 242);
            tbFirstName.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbFirstName.Font = new Font("Segoe UI", 9F);
            tbFirstName.Location = new Point(16, 72);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.ReadOnly = true;
            tbFirstName.SelectedText = "";
            tbFirstName.Size = new Size(410, 44);
            tbFirstName.TabIndex = 2;
            //
            // lblLastNameCaption
            //
            lblLastNameCaption.BackColor = Color.Transparent;
            lblLastNameCaption.Font = new Font("Segoe UI", 7.5F);
            lblLastNameCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblLastNameCaption.Location = new Point(436, 50);
            lblLastNameCaption.Name = "lblLastNameCaption";
            lblLastNameCaption.Size = new Size(300, 18);
            lblLastNameCaption.TabIndex = 3;
            lblLastNameCaption.Text = "Last Name";
            //
            // tbLastName
            //
            tbLastName.BorderRadius = 10;
            tbLastName.DefaultText = "";
            tbLastName.FillColor = Color.FromArgb(247, 245, 242);
            tbLastName.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbLastName.Font = new Font("Segoe UI", 9F);
            tbLastName.Location = new Point(436, 72);
            tbLastName.Name = "tbLastName";
            tbLastName.ReadOnly = true;
            tbLastName.SelectedText = "";
            tbLastName.Size = new Size(448, 44);
            tbLastName.TabIndex = 4;
            //
            // lblEmailCaption
            //
            lblEmailCaption.BackColor = Color.Transparent;
            lblEmailCaption.Font = new Font("Segoe UI", 7.5F);
            lblEmailCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblEmailCaption.Location = new Point(16, 128);
            lblEmailCaption.Name = "lblEmailCaption";
            lblEmailCaption.Size = new Size(300, 18);
            lblEmailCaption.TabIndex = 5;
            lblEmailCaption.Text = "Email";
            //
            // tbEmail
            //
            tbEmail.BorderRadius = 10;
            tbEmail.DefaultText = "";
            tbEmail.FillColor = Color.FromArgb(247, 245, 242);
            tbEmail.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbEmail.Font = new Font("Segoe UI", 9F);
            tbEmail.Location = new Point(16, 150);
            tbEmail.Name = "tbEmail";
            tbEmail.ReadOnly = true;
            tbEmail.SelectedText = "";
            tbEmail.Size = new Size(868, 44);
            tbEmail.TabIndex = 6;
            //
            // lblPhoneCaption
            //
            lblPhoneCaption.BackColor = Color.Transparent;
            lblPhoneCaption.Font = new Font("Segoe UI", 7.5F);
            lblPhoneCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblPhoneCaption.Location = new Point(16, 206);
            lblPhoneCaption.Name = "lblPhoneCaption";
            lblPhoneCaption.Size = new Size(300, 18);
            lblPhoneCaption.TabIndex = 7;
            lblPhoneCaption.Text = "Phone";
            //
            // tbPhone
            //
            tbPhone.BorderRadius = 10;
            tbPhone.DefaultText = "";
            tbPhone.FillColor = Color.FromArgb(247, 245, 242);
            tbPhone.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbPhone.Font = new Font("Segoe UI", 9F);
            tbPhone.Location = new Point(16, 228);
            tbPhone.Name = "tbPhone";
            tbPhone.ReadOnly = true;
            tbPhone.SelectedText = "";
            tbPhone.Size = new Size(868, 44);
            tbPhone.TabIndex = 8;
            //
            // lblLocationCaption
            //
            lblLocationCaption.BackColor = Color.Transparent;
            lblLocationCaption.Font = new Font("Segoe UI", 7.5F);
            lblLocationCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblLocationCaption.Location = new Point(16, 284);
            lblLocationCaption.Name = "lblLocationCaption";
            lblLocationCaption.Size = new Size(300, 18);
            lblLocationCaption.TabIndex = 9;
            lblLocationCaption.Text = "Location";
            //
            // tbLocation
            //
            tbLocation.BorderRadius = 10;
            tbLocation.DefaultText = "";
            tbLocation.FillColor = Color.FromArgb(247, 245, 242);
            tbLocation.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbLocation.Font = new Font("Segoe UI", 9F);
            tbLocation.Location = new Point(16, 306);
            tbLocation.Name = "tbLocation";
            tbLocation.ReadOnly = true;
            tbLocation.SelectedText = "";
            tbLocation.Size = new Size(868, 44);
            tbLocation.TabIndex = 10;
            //
            // lblBioCaption
            //
            lblBioCaption.BackColor = Color.Transparent;
            lblBioCaption.Font = new Font("Segoe UI", 7.5F);
            lblBioCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblBioCaption.Location = new Point(16, 362);
            lblBioCaption.Name = "lblBioCaption";
            lblBioCaption.Size = new Size(300, 18);
            lblBioCaption.TabIndex = 11;
            lblBioCaption.Text = "Bio";
            //
            // tbBio
            //
            tbBio.BorderRadius = 10;
            tbBio.DefaultText = "";
            tbBio.FillColor = Color.FromArgb(247, 245, 242);
            tbBio.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbBio.Font = new Font("Segoe UI", 9F);
            tbBio.Location = new Point(16, 384);
            tbBio.Multiline = true;
            tbBio.Name = "tbBio";
            tbBio.ReadOnly = true;
            tbBio.SelectedText = "";
            tbBio.Size = new Size(868, 60);
            tbBio.TabIndex = 12;
            //
            // pnlSkillsCard
            //
            pnlSkillsCard.BackColor = Color.Transparent;
            pnlSkillsCard.BorderRadius = 16;
            pnlSkillsCard.Controls.Add(lblSkillsTitle);
            pnlSkillsCard.Controls.Add(flpSkills);
            pnlSkillsCard.FillColor = Color.White;
            pnlSkillsCard.Location = new Point(0, 476);
            pnlSkillsCard.Name = "pnlSkillsCard";
            pnlSkillsCard.Size = new Size(900, 150);
            pnlSkillsCard.TabIndex = 1;
            //
            // lblSkillsTitle
            //
            lblSkillsTitle.BackColor = Color.Transparent;
            lblSkillsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSkillsTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblSkillsTitle.Location = new Point(16, 14);
            lblSkillsTitle.Name = "lblSkillsTitle";
            lblSkillsTitle.Size = new Size(300, 22);
            lblSkillsTitle.TabIndex = 0;
            lblSkillsTitle.Text = "Skills & Specializations";
            //
            // flpSkills
            //
            flpSkills.BackColor = Color.Transparent;
            flpSkills.Location = new Point(12, 46);
            flpSkills.Name = "flpSkills";
            flpSkills.Size = new Size(876, 96);
            flpSkills.TabIndex = 1;
            //
            // pnlTabReviews
            //
            pnlTabReviews.BackColor = Color.Transparent;
            pnlTabReviews.Controls.Add(flpReviews);
            pnlTabReviews.Location = new Point(30, 384);
            pnlTabReviews.Name = "pnlTabReviews";
            pnlTabReviews.Size = new Size(900, 560);
            pnlTabReviews.TabIndex = 3;
            pnlTabReviews.Visible = false;
            //
            // flpReviews
            //
            flpReviews.AutoScroll = true;
            flpReviews.BackColor = Color.Transparent;
            flpReviews.FlowDirection = FlowDirection.TopDown;
            flpReviews.Location = new Point(0, 0);
            flpReviews.Name = "flpReviews";
            flpReviews.Size = new Size(900, 560);
            flpReviews.TabIndex = 0;
            flpReviews.WrapContents = false;
            //
            // pnlTabSettings (rows are generated at runtime in ProfileForm.cs)
            //
            pnlTabSettings.BackColor = Color.Transparent;
            pnlTabSettings.Location = new Point(30, 384);
            pnlTabSettings.Name = "pnlTabSettings";
            pnlTabSettings.Size = new Size(900, 560);
            pnlTabSettings.TabIndex = 4;
            pnlTabSettings.Visible = false;
            //
            // ProfileForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - My Profile";
            Load += ProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAvatarPhoto).EndInit();
            pnlTabReviews.ResumeLayout(false);
            pnlSkillsCard.ResumeLayout(false);
            pnlPersonalInfoCard.ResumeLayout(false);
            pnlTabProfile.ResumeLayout(false);
            pnlTabsBar.ResumeLayout(false);
            pnlStatRate.ResumeLayout(false);
            pnlStatExperience.ResumeLayout(false);
            pnlStatBookings.ResumeLayout(false);
            pnlAvatarCircle.ResumeLayout(false);
            pnlProfileHeaderCard.ResumeLayout(false);
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
