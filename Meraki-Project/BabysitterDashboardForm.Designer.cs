namespace Meraki_Project
{
    partial class BabysitterDashboardForm
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
            btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlWelcomeBanner = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblGreeting = new Label();
            lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblRatingSummary = new Label();
            btnNotifications = new Guna.UI2.WinForms.Guna2Button();
            btnMyProfileIcon = new Guna.UI2.WinForms.Guna2Button();
            pnlNotificationsDropdown = new Guna.UI2.WinForms.Guna2Panel();
            lblNotificationsTitle = new Label();
            btnMarkAllRead = new Guna.UI2.WinForms.Guna2Button();
            flpNotificationsList = new FlowLayoutPanel();
            pnlStatMonth = new Guna.UI2.WinForms.Guna2Panel();
            pnlStatMonthIcon = new Guna.UI2.WinForms.Guna2Panel();
            lblStatMonthIcon = new Label();
            lblStatMonthValue = new Label();
            lblStatMonthLabel = new Label();
            pnlStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            pnlStatBookingsIcon = new Guna.UI2.WinForms.Guna2Panel();
            lblStatBookingsIcon = new Label();
            lblStatBookingsValue = new Label();
            lblStatBookingsLabel = new Label();
            pnlStatRating = new Guna.UI2.WinForms.Guna2Panel();
            pnlStatRatingIcon = new Guna.UI2.WinForms.Guna2Panel();
            lblStatRatingIcon = new Label();
            lblStatRatingValue = new Label();
            lblStatRatingLabel = new Label();
            pnlStatHours = new Guna.UI2.WinForms.Guna2Panel();
            pnlStatHoursIcon = new Guna.UI2.WinForms.Guna2Panel();
            lblStatHoursIcon = new Label();
            lblStatHoursValue = new Label();
            lblStatHoursLabel = new Label();
            pnlCalendarCard = new Guna.UI2.WinForms.Guna2Panel();
            lblCalendarTitle = new Label();
            pnlPendingRequestsCard = new Guna.UI2.WinForms.Guna2Panel();
            lblPendingTitle = new Label();
            flpPendingRequests = new FlowLayoutPanel();
            flpSchedule = new FlowLayoutPanel();
            pnlProfileQuickView = new Guna.UI2.WinForms.Guna2Panel();
            lblProfileQuickTitle = new Label();
            pnlQuickAvatar = new Guna.UI2.WinForms.Guna2Panel();
            lblQuickAvatarInitial = new Label();
            lblQuickName = new Label();
            lblQuickSubtitle = new Label();
            pnlQuickStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            lblQuickBookingsValue = new Label();
            lblQuickBookingsLabel = new Label();
            pnlQuickStatRating = new Guna.UI2.WinForms.Guna2Panel();
            lblQuickRatingValue = new Label();
            lblQuickRatingLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlWelcomeBanner.SuspendLayout();
            pnlNotificationsDropdown.SuspendLayout();
            pnlStatMonth.SuspendLayout();
            pnlStatMonthIcon.SuspendLayout();
            pnlStatBookings.SuspendLayout();
            pnlStatBookingsIcon.SuspendLayout();
            pnlStatRating.SuspendLayout();
            pnlStatRatingIcon.SuspendLayout();
            pnlStatHours.SuspendLayout();
            pnlStatHoursIcon.SuspendLayout();
            pnlCalendarCard.SuspendLayout();
            pnlPendingRequestsCard.SuspendLayout();
            pnlProfileQuickView.SuspendLayout();
            pnlQuickAvatar.SuspendLayout();
            pnlQuickStatBookings.SuspendLayout();
            pnlQuickStatRating.SuspendLayout();
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
            btnNavBabysitterHome.FillColor = Color.FromArgb(253, 238, 232);
            btnNavBabysitterHome.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNavBabysitterHome.ForeColor = Color.FromArgb(232, 113, 74);
            btnNavBabysitterHome.HoverState.FillColor = Color.FromArgb(250, 226, 216);
            btnNavBabysitterHome.Location = new Point(275, 18);
            btnNavBabysitterHome.Name = "btnNavBabysitterHome";
            btnNavBabysitterHome.Size = new Size(160, 45);
            btnNavBabysitterHome.TabIndex = 2;
            btnNavBabysitterHome.Text = "Babysitter Home";
            btnNavBabysitterHome.Click += btnNavBabysitterHome_Click;
            //
            // btnNavMyProfile
            //
            btnNavMyProfile.BackColor = Color.White;
            btnNavMyProfile.BorderRadius = 8;
            btnNavMyProfile.FillColor = Color.Transparent;
            btnNavMyProfile.Font = new Font("Segoe UI", 8.5F);
            btnNavMyProfile.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavMyProfile.HoverState.FillColor = Color.FromArgb(253, 238, 232);
            btnNavMyProfile.Location = new Point(445, 18);
            btnNavMyProfile.Name = "btnNavMyProfile";
            btnNavMyProfile.Size = new Size(125, 45);
            btnNavMyProfile.TabIndex = 3;
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
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            //
            // pnlContent
            //
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(pnlNotificationsDropdown);
            pnlContent.Controls.Add(pnlWelcomeBanner);
            pnlContent.Controls.Add(pnlStatMonth);
            pnlContent.Controls.Add(pnlStatBookings);
            pnlContent.Controls.Add(pnlStatRating);
            pnlContent.Controls.Add(pnlStatHours);
            pnlContent.Controls.Add(pnlCalendarCard);
            pnlContent.Controls.Add(pnlPendingRequestsCard);
            pnlContent.Controls.Add(pnlProfileQuickView);
            pnlContent.FillColor = Color.FromArgb(253, 238, 232);
            pnlContent.FillColor2 = Color.FromArgb(225, 240, 239);
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1500, 820);
            pnlContent.TabIndex = 0;
            //
            // pnlWelcomeBanner
            //
            pnlWelcomeBanner.BackColor = Color.Transparent;
            pnlWelcomeBanner.BorderRadius = 18;
            pnlWelcomeBanner.Controls.Add(lblGreeting);
            pnlWelcomeBanner.Controls.Add(lblUserName);
            pnlWelcomeBanner.Controls.Add(lblRatingSummary);
            pnlWelcomeBanner.Controls.Add(btnNotifications);
            pnlWelcomeBanner.Controls.Add(btnMyProfileIcon);
            pnlWelcomeBanner.FillColor = Color.FromArgb(94, 200, 196);
            pnlWelcomeBanner.FillColor2 = Color.FromArgb(125, 216, 213);
            pnlWelcomeBanner.Location = new Point(30, 30);
            pnlWelcomeBanner.Name = "pnlWelcomeBanner";
            pnlWelcomeBanner.Size = new Size(1420, 120);
            pnlWelcomeBanner.TabIndex = 0;
            //
            // lblGreeting
            //
            lblGreeting.BackColor = Color.Transparent;
            lblGreeting.ForeColor = Color.White;
            lblGreeting.Location = new Point(35, 20);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(250, 22);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "Welcome back,";
            //
            // lblUserName
            //
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Location = new Point(32, 42);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(300, 33);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "<div style=\"color:white;font-weight:bold;font-size:14pt;\">Emma Thompson</div>";
            //
            // lblRatingSummary
            //
            lblRatingSummary.BackColor = Color.Transparent;
            lblRatingSummary.ForeColor = Color.White;
            lblRatingSummary.Location = new Point(35, 84);
            lblRatingSummary.Name = "lblRatingSummary";
            lblRatingSummary.Size = new Size(250, 22);
            lblRatingSummary.TabIndex = 2;
            lblRatingSummary.Text = "★ 4.9  ·  47 reviews";
            //
            // btnNotifications
            //
            btnNotifications.BackColor = Color.Transparent;
            btnNotifications.BorderRadius = 22;
            btnNotifications.FillColor = Color.White;
            btnNotifications.Font = new Font("Segoe UI", 12F);
            btnNotifications.ForeColor = Color.FromArgb(94, 200, 196);
            btnNotifications.HoverState.FillColor = Color.FromArgb(240, 250, 250);
            btnNotifications.Location = new Point(1250, 33);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(55, 55);
            btnNotifications.TabIndex = 3;
            btnNotifications.Text = "🔔";
            btnNotifications.Click += btnNotifications_Click;
            //
            // btnMyProfileIcon
            //
            btnMyProfileIcon.BackColor = Color.Transparent;
            btnMyProfileIcon.BorderRadius = 22;
            btnMyProfileIcon.FillColor = Color.White;
            btnMyProfileIcon.Font = new Font("Segoe UI", 12F);
            btnMyProfileIcon.ForeColor = Color.FromArgb(94, 200, 196);
            btnMyProfileIcon.HoverState.FillColor = Color.FromArgb(240, 250, 250);
            btnMyProfileIcon.Location = new Point(1325, 33);
            btnMyProfileIcon.Name = "btnMyProfileIcon";
            btnMyProfileIcon.Size = new Size(55, 55);
            btnMyProfileIcon.TabIndex = 4;
            btnMyProfileIcon.Text = "👤";
            btnMyProfileIcon.Click += btnMyProfileIcon_Click;
            //
            // pnlNotificationsDropdown
            //
            pnlNotificationsDropdown.BackColor = Color.Transparent;
            pnlNotificationsDropdown.BorderRadius = 16;
            pnlNotificationsDropdown.Controls.Add(lblNotificationsTitle);
            pnlNotificationsDropdown.Controls.Add(btnMarkAllRead);
            pnlNotificationsDropdown.Controls.Add(flpNotificationsList);
            pnlNotificationsDropdown.FillColor = Color.White;
            pnlNotificationsDropdown.Location = new Point(990, 160);
            pnlNotificationsDropdown.Name = "pnlNotificationsDropdown";
            pnlNotificationsDropdown.Size = new Size(460, 240);
            pnlNotificationsDropdown.TabIndex = 1;
            pnlNotificationsDropdown.Visible = false;
            //
            // lblNotificationsTitle
            //
            lblNotificationsTitle.BackColor = Color.Transparent;
            lblNotificationsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotificationsTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblNotificationsTitle.Location = new Point(16, 14);
            lblNotificationsTitle.Name = "lblNotificationsTitle";
            lblNotificationsTitle.Size = new Size(200, 22);
            lblNotificationsTitle.TabIndex = 0;
            lblNotificationsTitle.Text = "Notifications";
            //
            // btnMarkAllRead
            //
            btnMarkAllRead.BackColor = Color.White;
            btnMarkAllRead.BorderRadius = 6;
            btnMarkAllRead.FillColor = Color.Transparent;
            btnMarkAllRead.Font = new Font("Segoe UI", 8F);
            btnMarkAllRead.ForeColor = Color.FromArgb(94, 200, 196);
            btnMarkAllRead.HoverState.FillColor = Color.FromArgb(232, 247, 247);
            btnMarkAllRead.Location = new Point(320, 12);
            btnMarkAllRead.Name = "btnMarkAllRead";
            btnMarkAllRead.Size = new Size(120, 26);
            btnMarkAllRead.TabIndex = 1;
            btnMarkAllRead.Text = "Mark all read";
            btnMarkAllRead.Click += btnMarkAllRead_Click;
            //
            // flpNotificationsList
            //
            flpNotificationsList.AutoScroll = true;
            flpNotificationsList.BackColor = Color.Transparent;
            flpNotificationsList.FlowDirection = FlowDirection.TopDown;
            flpNotificationsList.Location = new Point(12, 46);
            flpNotificationsList.Name = "flpNotificationsList";
            flpNotificationsList.Size = new Size(436, 184);
            flpNotificationsList.TabIndex = 2;
            flpNotificationsList.WrapContents = false;
            //
            // pnlStatMonth
            //
            pnlStatMonth.BackColor = Color.Transparent;
            pnlStatMonth.BorderRadius = 16;
            pnlStatMonth.Controls.Add(pnlStatMonthIcon);
            pnlStatMonth.Controls.Add(lblStatMonthValue);
            pnlStatMonth.Controls.Add(lblStatMonthLabel);
            pnlStatMonth.FillColor = Color.White;
            pnlStatMonth.Location = new Point(30, 170);
            pnlStatMonth.Name = "pnlStatMonth";
            pnlStatMonth.Size = new Size(340, 110);
            pnlStatMonth.TabIndex = 2;
            //
            // pnlStatMonthIcon
            //
            pnlStatMonthIcon.BackColor = Color.White;
            pnlStatMonthIcon.BorderRadius = 18;
            pnlStatMonthIcon.Controls.Add(lblStatMonthIcon);
            pnlStatMonthIcon.FillColor = Color.FromArgb(253, 226, 220);
            pnlStatMonthIcon.Location = new Point(16, 16);
            pnlStatMonthIcon.Name = "pnlStatMonthIcon";
            pnlStatMonthIcon.Size = new Size(36, 36);
            pnlStatMonthIcon.TabIndex = 0;
            //
            // lblStatMonthIcon
            //
            lblStatMonthIcon.BackColor = Color.Transparent;
            lblStatMonthIcon.Dock = DockStyle.Fill;
            lblStatMonthIcon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatMonthIcon.ForeColor = Color.FromArgb(232, 113, 74);
            lblStatMonthIcon.Location = new Point(0, 0);
            lblStatMonthIcon.Name = "lblStatMonthIcon";
            lblStatMonthIcon.Size = new Size(36, 36);
            lblStatMonthIcon.TabIndex = 0;
            lblStatMonthIcon.Text = "$";
            lblStatMonthIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStatMonthValue
            //
            lblStatMonthValue.BackColor = Color.Transparent;
            lblStatMonthValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblStatMonthValue.ForeColor = Color.FromArgb(60, 50, 45);
            lblStatMonthValue.Location = new Point(16, 58);
            lblStatMonthValue.Name = "lblStatMonthValue";
            lblStatMonthValue.Size = new Size(200, 30);
            lblStatMonthValue.TabIndex = 1;
            lblStatMonthValue.Text = "$480";
            //
            // lblStatMonthLabel
            //
            lblStatMonthLabel.BackColor = Color.Transparent;
            lblStatMonthLabel.Font = new Font("Segoe UI", 8.5F);
            lblStatMonthLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatMonthLabel.Location = new Point(16, 88);
            lblStatMonthLabel.Name = "lblStatMonthLabel";
            lblStatMonthLabel.Size = new Size(220, 20);
            lblStatMonthLabel.TabIndex = 2;
            lblStatMonthLabel.Text = "This Month";
            //
            // pnlStatBookings
            //
            pnlStatBookings.BackColor = Color.Transparent;
            pnlStatBookings.BorderRadius = 16;
            pnlStatBookings.Controls.Add(pnlStatBookingsIcon);
            pnlStatBookings.Controls.Add(lblStatBookingsValue);
            pnlStatBookings.Controls.Add(lblStatBookingsLabel);
            pnlStatBookings.FillColor = Color.White;
            pnlStatBookings.Location = new Point(390, 170);
            pnlStatBookings.Name = "pnlStatBookings";
            pnlStatBookings.Size = new Size(340, 110);
            pnlStatBookings.TabIndex = 3;
            //
            // pnlStatBookingsIcon
            //
            pnlStatBookingsIcon.BackColor = Color.White;
            pnlStatBookingsIcon.BorderRadius = 18;
            pnlStatBookingsIcon.Controls.Add(lblStatBookingsIcon);
            pnlStatBookingsIcon.FillColor = Color.FromArgb(222, 245, 244);
            pnlStatBookingsIcon.Location = new Point(16, 16);
            pnlStatBookingsIcon.Name = "pnlStatBookingsIcon";
            pnlStatBookingsIcon.Size = new Size(36, 36);
            pnlStatBookingsIcon.TabIndex = 0;
            //
            // lblStatBookingsIcon
            //
            lblStatBookingsIcon.BackColor = Color.Transparent;
            lblStatBookingsIcon.Dock = DockStyle.Fill;
            lblStatBookingsIcon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatBookingsIcon.ForeColor = Color.FromArgb(94, 200, 196);
            lblStatBookingsIcon.Location = new Point(0, 0);
            lblStatBookingsIcon.Name = "lblStatBookingsIcon";
            lblStatBookingsIcon.Size = new Size(36, 36);
            lblStatBookingsIcon.TabIndex = 0;
            lblStatBookingsIcon.Text = "C";
            lblStatBookingsIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStatBookingsValue
            //
            lblStatBookingsValue.BackColor = Color.Transparent;
            lblStatBookingsValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblStatBookingsValue.ForeColor = Color.FromArgb(60, 50, 45);
            lblStatBookingsValue.Location = new Point(16, 58);
            lblStatBookingsValue.Name = "lblStatBookingsValue";
            lblStatBookingsValue.Size = new Size(200, 30);
            lblStatBookingsValue.TabIndex = 1;
            lblStatBookingsValue.Text = "47";
            //
            // lblStatBookingsLabel
            //
            lblStatBookingsLabel.BackColor = Color.Transparent;
            lblStatBookingsLabel.Font = new Font("Segoe UI", 8.5F);
            lblStatBookingsLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatBookingsLabel.Location = new Point(16, 88);
            lblStatBookingsLabel.Name = "lblStatBookingsLabel";
            lblStatBookingsLabel.Size = new Size(220, 20);
            lblStatBookingsLabel.TabIndex = 2;
            lblStatBookingsLabel.Text = "Total Bookings";
            //
            // pnlStatRating
            //
            pnlStatRating.BackColor = Color.Transparent;
            pnlStatRating.BorderRadius = 16;
            pnlStatRating.Controls.Add(pnlStatRatingIcon);
            pnlStatRating.Controls.Add(lblStatRatingValue);
            pnlStatRating.Controls.Add(lblStatRatingLabel);
            pnlStatRating.FillColor = Color.White;
            pnlStatRating.Location = new Point(750, 170);
            pnlStatRating.Name = "pnlStatRating";
            pnlStatRating.Size = new Size(340, 110);
            pnlStatRating.TabIndex = 4;
            //
            // pnlStatRatingIcon
            //
            pnlStatRatingIcon.BackColor = Color.White;
            pnlStatRatingIcon.BorderRadius = 18;
            pnlStatRatingIcon.Controls.Add(lblStatRatingIcon);
            pnlStatRatingIcon.FillColor = Color.FromArgb(255, 244, 217);
            pnlStatRatingIcon.Location = new Point(16, 16);
            pnlStatRatingIcon.Name = "pnlStatRatingIcon";
            pnlStatRatingIcon.Size = new Size(36, 36);
            pnlStatRatingIcon.TabIndex = 0;
            //
            // lblStatRatingIcon
            //
            lblStatRatingIcon.BackColor = Color.Transparent;
            lblStatRatingIcon.Dock = DockStyle.Fill;
            lblStatRatingIcon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatRatingIcon.ForeColor = Color.FromArgb(255, 209, 102);
            lblStatRatingIcon.Location = new Point(0, 0);
            lblStatRatingIcon.Name = "lblStatRatingIcon";
            lblStatRatingIcon.Size = new Size(36, 36);
            lblStatRatingIcon.TabIndex = 0;
            lblStatRatingIcon.Text = "★";
            lblStatRatingIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStatRatingValue
            //
            lblStatRatingValue.BackColor = Color.Transparent;
            lblStatRatingValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblStatRatingValue.ForeColor = Color.FromArgb(60, 50, 45);
            lblStatRatingValue.Location = new Point(16, 58);
            lblStatRatingValue.Name = "lblStatRatingValue";
            lblStatRatingValue.Size = new Size(200, 30);
            lblStatRatingValue.TabIndex = 1;
            lblStatRatingValue.Text = "4.9";
            //
            // lblStatRatingLabel
            //
            lblStatRatingLabel.BackColor = Color.Transparent;
            lblStatRatingLabel.Font = new Font("Segoe UI", 8.5F);
            lblStatRatingLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatRatingLabel.Location = new Point(16, 88);
            lblStatRatingLabel.Name = "lblStatRatingLabel";
            lblStatRatingLabel.Size = new Size(220, 20);
            lblStatRatingLabel.TabIndex = 2;
            lblStatRatingLabel.Text = "Avg. Rating";
            //
            // pnlStatHours
            //
            pnlStatHours.BackColor = Color.Transparent;
            pnlStatHours.BorderRadius = 16;
            pnlStatHours.Controls.Add(pnlStatHoursIcon);
            pnlStatHours.Controls.Add(lblStatHoursValue);
            pnlStatHours.Controls.Add(lblStatHoursLabel);
            pnlStatHours.FillColor = Color.White;
            pnlStatHours.Location = new Point(1110, 170);
            pnlStatHours.Name = "pnlStatHours";
            pnlStatHours.Size = new Size(340, 110);
            pnlStatHours.TabIndex = 5;
            //
            // pnlStatHoursIcon
            //
            pnlStatHoursIcon.BackColor = Color.White;
            pnlStatHoursIcon.BorderRadius = 18;
            pnlStatHoursIcon.Controls.Add(lblStatHoursIcon);
            pnlStatHoursIcon.FillColor = Color.FromArgb(253, 225, 225);
            pnlStatHoursIcon.Location = new Point(16, 16);
            pnlStatHoursIcon.Name = "pnlStatHoursIcon";
            pnlStatHoursIcon.Size = new Size(36, 36);
            pnlStatHoursIcon.TabIndex = 0;
            //
            // lblStatHoursIcon
            //
            lblStatHoursIcon.BackColor = Color.Transparent;
            lblStatHoursIcon.Dock = DockStyle.Fill;
            lblStatHoursIcon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatHoursIcon.ForeColor = Color.FromArgb(224, 90, 90);
            lblStatHoursIcon.Location = new Point(0, 0);
            lblStatHoursIcon.Name = "lblStatHoursIcon";
            lblStatHoursIcon.Size = new Size(36, 36);
            lblStatHoursIcon.TabIndex = 0;
            lblStatHoursIcon.Text = "H";
            lblStatHoursIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStatHoursValue
            //
            lblStatHoursValue.BackColor = Color.Transparent;
            lblStatHoursValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblStatHoursValue.ForeColor = Color.FromArgb(60, 50, 45);
            lblStatHoursValue.Location = new Point(16, 58);
            lblStatHoursValue.Name = "lblStatHoursValue";
            lblStatHoursValue.Size = new Size(200, 30);
            lblStatHoursValue.TabIndex = 1;
            lblStatHoursValue.Text = "124h";
            //
            // lblStatHoursLabel
            //
            lblStatHoursLabel.BackColor = Color.Transparent;
            lblStatHoursLabel.Font = new Font("Segoe UI", 8.5F);
            lblStatHoursLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblStatHoursLabel.Location = new Point(16, 88);
            lblStatHoursLabel.Name = "lblStatHoursLabel";
            lblStatHoursLabel.Size = new Size(220, 20);
            lblStatHoursLabel.TabIndex = 2;
            lblStatHoursLabel.Text = "Hours Worked";
            //
            // pnlCalendarCard
            //
            pnlCalendarCard.BackColor = Color.Transparent;
            pnlCalendarCard.BorderRadius = 16;
            pnlCalendarCard.Controls.Add(lblCalendarTitle);
            pnlCalendarCard.Controls.Add(flpSchedule);
            pnlCalendarCard.FillColor = Color.White;
            pnlCalendarCard.Location = new Point(30, 300);
            pnlCalendarCard.Name = "pnlCalendarCard";
            pnlCalendarCard.Size = new Size(900, 430);
            pnlCalendarCard.TabIndex = 6;
            //
            // lblCalendarTitle
            //
            lblCalendarTitle.BackColor = Color.Transparent;
            lblCalendarTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCalendarTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblCalendarTitle.Location = new Point(16, 14);
            lblCalendarTitle.Name = "lblCalendarTitle";
            lblCalendarTitle.Size = new Size(220, 24);
            lblCalendarTitle.TabIndex = 0;
            lblCalendarTitle.Text = "My Schedule";
            //
            // flpSchedule
            //
            flpSchedule.AutoScroll = true;
            flpSchedule.BackColor = Color.White;
            flpSchedule.FlowDirection = FlowDirection.TopDown;
            flpSchedule.Location = new Point(16, 52);
            flpSchedule.Name = "flpSchedule";
            flpSchedule.Size = new Size(868, 360);
            flpSchedule.TabIndex = 1;
            flpSchedule.WrapContents = false;
            //
            // pnlPendingRequestsCard
            //
            pnlPendingRequestsCard.BackColor = Color.Transparent;
            pnlPendingRequestsCard.BorderRadius = 16;
            pnlPendingRequestsCard.Controls.Add(lblPendingTitle);
            pnlPendingRequestsCard.Controls.Add(flpPendingRequests);
            pnlPendingRequestsCard.FillColor = Color.White;
            pnlPendingRequestsCard.Location = new Point(950, 300);
            pnlPendingRequestsCard.Name = "pnlPendingRequestsCard";
            pnlPendingRequestsCard.Size = new Size(500, 260);
            pnlPendingRequestsCard.TabIndex = 7;
            //
            // lblPendingTitle
            //
            lblPendingTitle.BackColor = Color.Transparent;
            lblPendingTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPendingTitle.Location = new Point(16, 14);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(240, 24);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Text = "Pending Requests";
            //
            // flpPendingRequests
            //
            flpPendingRequests.AutoScroll = true;
            flpPendingRequests.BackColor = Color.Transparent;
            flpPendingRequests.FlowDirection = FlowDirection.TopDown;
            flpPendingRequests.Location = new Point(12, 50);
            flpPendingRequests.Name = "flpPendingRequests";
            flpPendingRequests.Size = new Size(476, 200);
            flpPendingRequests.TabIndex = 1;
            flpPendingRequests.WrapContents = false;
            //
            // pnlProfileQuickView
            //
            pnlProfileQuickView.BackColor = Color.Transparent;
            pnlProfileQuickView.BorderRadius = 16;
            pnlProfileQuickView.Controls.Add(lblProfileQuickTitle);
            pnlProfileQuickView.Controls.Add(pnlQuickAvatar);
            pnlProfileQuickView.Controls.Add(lblQuickName);
            pnlProfileQuickView.Controls.Add(lblQuickSubtitle);
            pnlProfileQuickView.Controls.Add(pnlQuickStatBookings);
            pnlProfileQuickView.Controls.Add(pnlQuickStatRating);
            pnlProfileQuickView.Cursor = Cursors.Hand;
            pnlProfileQuickView.FillColor = Color.White;
            pnlProfileQuickView.Location = new Point(950, 580);
            pnlProfileQuickView.Name = "pnlProfileQuickView";
            pnlProfileQuickView.Size = new Size(500, 150);
            pnlProfileQuickView.TabIndex = 8;
            pnlProfileQuickView.Click += pnlProfileQuickView_Click;
            //
            // lblProfileQuickTitle
            //
            lblProfileQuickTitle.BackColor = Color.Transparent;
            lblProfileQuickTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProfileQuickTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblProfileQuickTitle.Location = new Point(16, 12);
            lblProfileQuickTitle.Name = "lblProfileQuickTitle";
            lblProfileQuickTitle.Size = new Size(200, 22);
            lblProfileQuickTitle.TabIndex = 0;
            lblProfileQuickTitle.Text = "My Profile";
            //
            // pnlQuickAvatar
            //
            pnlQuickAvatar.BackColor = Color.White;
            pnlQuickAvatar.BorderRadius = 16;
            pnlQuickAvatar.Controls.Add(lblQuickAvatarInitial);
            pnlQuickAvatar.FillColor = Color.FromArgb(222, 245, 244);
            pnlQuickAvatar.Location = new Point(16, 42);
            pnlQuickAvatar.Name = "pnlQuickAvatar";
            pnlQuickAvatar.Size = new Size(50, 50);
            pnlQuickAvatar.TabIndex = 1;
            //
            // lblQuickAvatarInitial
            //
            lblQuickAvatarInitial.BackColor = Color.Transparent;
            lblQuickAvatarInitial.Dock = DockStyle.Fill;
            lblQuickAvatarInitial.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuickAvatarInitial.ForeColor = Color.FromArgb(94, 200, 196);
            lblQuickAvatarInitial.Location = new Point(0, 0);
            lblQuickAvatarInitial.Name = "lblQuickAvatarInitial";
            lblQuickAvatarInitial.Size = new Size(50, 50);
            lblQuickAvatarInitial.TabIndex = 0;
            lblQuickAvatarInitial.Text = "E";
            lblQuickAvatarInitial.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblQuickName
            //
            lblQuickName.BackColor = Color.Transparent;
            lblQuickName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuickName.ForeColor = Color.FromArgb(60, 50, 45);
            lblQuickName.Location = new Point(80, 46);
            lblQuickName.Name = "lblQuickName";
            lblQuickName.Size = new Size(300, 24);
            lblQuickName.TabIndex = 2;
            lblQuickName.Text = "Emma Thompson";
            //
            // lblQuickSubtitle
            //
            lblQuickSubtitle.BackColor = Color.Transparent;
            lblQuickSubtitle.Font = new Font("Segoe UI", 8F);
            lblQuickSubtitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblQuickSubtitle.Location = new Point(80, 70);
            lblQuickSubtitle.Name = "lblQuickSubtitle";
            lblQuickSubtitle.Size = new Size(340, 20);
            lblQuickSubtitle.TabIndex = 3;
            lblQuickSubtitle.Text = "Babysitter · 3 yrs experience";
            //
            // pnlQuickStatBookings
            //
            pnlQuickStatBookings.BackColor = Color.White;
            pnlQuickStatBookings.BorderRadius = 12;
            pnlQuickStatBookings.Controls.Add(lblQuickBookingsValue);
            pnlQuickStatBookings.Controls.Add(lblQuickBookingsLabel);
            pnlQuickStatBookings.FillColor = Color.FromArgb(253, 238, 232);
            pnlQuickStatBookings.Location = new Point(16, 102);
            pnlQuickStatBookings.Name = "pnlQuickStatBookings";
            pnlQuickStatBookings.Size = new Size(230, 36);
            pnlQuickStatBookings.TabIndex = 4;
            //
            // lblQuickBookingsValue
            //
            lblQuickBookingsValue.BackColor = Color.Transparent;
            lblQuickBookingsValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuickBookingsValue.ForeColor = Color.FromArgb(232, 113, 74);
            lblQuickBookingsValue.Location = new Point(10, 8);
            lblQuickBookingsValue.Name = "lblQuickBookingsValue";
            lblQuickBookingsValue.Size = new Size(50, 20);
            lblQuickBookingsValue.TabIndex = 0;
            lblQuickBookingsValue.Text = "47";
            //
            // lblQuickBookingsLabel
            //
            lblQuickBookingsLabel.BackColor = Color.Transparent;
            lblQuickBookingsLabel.Font = new Font("Segoe UI", 8F);
            lblQuickBookingsLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblQuickBookingsLabel.Location = new Point(60, 9);
            lblQuickBookingsLabel.Name = "lblQuickBookingsLabel";
            lblQuickBookingsLabel.Size = new Size(120, 18);
            lblQuickBookingsLabel.TabIndex = 1;
            lblQuickBookingsLabel.Text = "Bookings";
            //
            // pnlQuickStatRating
            //
            pnlQuickStatRating.BackColor = Color.White;
            pnlQuickStatRating.BorderRadius = 12;
            pnlQuickStatRating.Controls.Add(lblQuickRatingValue);
            pnlQuickStatRating.Controls.Add(lblQuickRatingLabel);
            pnlQuickStatRating.FillColor = Color.FromArgb(222, 245, 244);
            pnlQuickStatRating.Location = new Point(256, 102);
            pnlQuickStatRating.Name = "pnlQuickStatRating";
            pnlQuickStatRating.Size = new Size(228, 36);
            pnlQuickStatRating.TabIndex = 5;
            //
            // lblQuickRatingValue
            //
            lblQuickRatingValue.BackColor = Color.Transparent;
            lblQuickRatingValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuickRatingValue.ForeColor = Color.FromArgb(94, 200, 196);
            lblQuickRatingValue.Location = new Point(10, 8);
            lblQuickRatingValue.Name = "lblQuickRatingValue";
            lblQuickRatingValue.Size = new Size(50, 20);
            lblQuickRatingValue.TabIndex = 0;
            lblQuickRatingValue.Text = "4.9";
            //
            // lblQuickRatingLabel
            //
            lblQuickRatingLabel.BackColor = Color.Transparent;
            lblQuickRatingLabel.Font = new Font("Segoe UI", 8F);
            lblQuickRatingLabel.ForeColor = Color.FromArgb(154, 136, 128);
            lblQuickRatingLabel.Location = new Point(60, 9);
            lblQuickRatingLabel.Name = "lblQuickRatingLabel";
            lblQuickRatingLabel.Size = new Size(120, 18);
            lblQuickRatingLabel.TabIndex = 1;
            lblQuickRatingLabel.Text = "Rating";
            //
            // BabysitterDashboardForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "BabysitterDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - Babysitter Dashboard";
            Load += BabysitterDashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            pnlQuickStatRating.ResumeLayout(false);
            pnlQuickStatBookings.ResumeLayout(false);
            pnlQuickAvatar.ResumeLayout(false);
            pnlProfileQuickView.ResumeLayout(false);
            pnlPendingRequestsCard.ResumeLayout(false);
            pnlCalendarCard.ResumeLayout(false);
            pnlStatHoursIcon.ResumeLayout(false);
            pnlStatHours.ResumeLayout(false);
            pnlStatRatingIcon.ResumeLayout(false);
            pnlStatRating.ResumeLayout(false);
            pnlStatBookingsIcon.ResumeLayout(false);
            pnlStatBookings.ResumeLayout(false);
            pnlStatMonthIcon.ResumeLayout(false);
            pnlStatMonth.ResumeLayout(false);
            pnlNotificationsDropdown.ResumeLayout(false);
            pnlWelcomeBanner.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnNavMyProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlWelcomeBanner;
        private System.Windows.Forms.Label lblGreeting;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        private System.Windows.Forms.Label lblRatingSummary;
        private Guna.UI2.WinForms.Guna2Button btnNotifications;
        private Guna.UI2.WinForms.Guna2Button btnMyProfileIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlNotificationsDropdown;
        private System.Windows.Forms.Label lblNotificationsTitle;
        private Guna.UI2.WinForms.Guna2Button btnMarkAllRead;
        private System.Windows.Forms.FlowLayoutPanel flpNotificationsList;
        private Guna.UI2.WinForms.Guna2Panel pnlStatMonth;
        private Guna.UI2.WinForms.Guna2Panel pnlStatMonthIcon;
        private System.Windows.Forms.Label lblStatMonthIcon;
        private System.Windows.Forms.Label lblStatMonthValue;
        private System.Windows.Forms.Label lblStatMonthLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlStatBookings;
        private Guna.UI2.WinForms.Guna2Panel pnlStatBookingsIcon;
        private System.Windows.Forms.Label lblStatBookingsIcon;
        private System.Windows.Forms.Label lblStatBookingsValue;
        private System.Windows.Forms.Label lblStatBookingsLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlStatRating;
        private Guna.UI2.WinForms.Guna2Panel pnlStatRatingIcon;
        private System.Windows.Forms.Label lblStatRatingIcon;
        private System.Windows.Forms.Label lblStatRatingValue;
        private System.Windows.Forms.Label lblStatRatingLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlStatHours;
        private Guna.UI2.WinForms.Guna2Panel pnlStatHoursIcon;
        private System.Windows.Forms.Label lblStatHoursIcon;
        private System.Windows.Forms.Label lblStatHoursValue;
        private System.Windows.Forms.Label lblStatHoursLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlCalendarCard;
        private System.Windows.Forms.Label lblCalendarTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlPendingRequestsCard;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.FlowLayoutPanel flpPendingRequests;
        private System.Windows.Forms.FlowLayoutPanel flpSchedule;
        private Guna.UI2.WinForms.Guna2Panel pnlProfileQuickView;
        private System.Windows.Forms.Label lblProfileQuickTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlQuickAvatar;
        private System.Windows.Forms.Label lblQuickAvatarInitial;
        private System.Windows.Forms.Label lblQuickName;
        private System.Windows.Forms.Label lblQuickSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlQuickStatBookings;
        private System.Windows.Forms.Label lblQuickBookingsValue;
        private System.Windows.Forms.Label lblQuickBookingsLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlQuickStatRating;
        private System.Windows.Forms.Label lblQuickRatingValue;
        private System.Windows.Forms.Label lblQuickRatingLabel;
    }
}
