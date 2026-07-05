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
            // ===== Page root =====
            this.pnlPageBackground = new Guna.UI2.WinForms.Guna2GradientPanel();

            // ===== Navbar (Babysitter Home / My Profile / Logout only) =====
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnNavBabysitterHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavMyProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();

            // ===== Content =====
            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();

            // ----- Welcome banner -----
            this.pnlWelcomeBanner = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRatingSummary = new System.Windows.Forms.Label();
            this.btnNotifications = new Guna.UI2.WinForms.Guna2Button();
            this.btnMyProfileIcon = new Guna.UI2.WinForms.Guna2Button();

            // ----- Notifications dropdown (toggled by the bell) -----
            this.pnlNotificationsDropdown = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNotificationsTitle = new System.Windows.Forms.Label();
            this.btnMarkAllRead = new Guna.UI2.WinForms.Guna2Button();
            this.flpNotificationsList = new System.Windows.Forms.FlowLayoutPanel();

            // ----- Stat cards -----
            this.pnlStatMonth = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStatMonthIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatMonthIcon = new System.Windows.Forms.Label();
            this.lblStatMonthValue = new System.Windows.Forms.Label();
            this.lblStatMonthLabel = new System.Windows.Forms.Label();

            this.pnlStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStatBookingsIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatBookingsIcon = new System.Windows.Forms.Label();
            this.lblStatBookingsValue = new System.Windows.Forms.Label();
            this.lblStatBookingsLabel = new System.Windows.Forms.Label();

            this.pnlStatRating = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStatRatingIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatRatingIcon = new System.Windows.Forms.Label();
            this.lblStatRatingValue = new System.Windows.Forms.Label();
            this.lblStatRatingLabel = new System.Windows.Forms.Label();

            this.pnlStatHours = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStatHoursIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatHoursIcon = new System.Windows.Forms.Label();
            this.lblStatHoursValue = new System.Windows.Forms.Label();
            this.lblStatHoursLabel = new System.Windows.Forms.Label();

            // ----- Calendar card -----
            this.pnlCalendarCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCalendarTitle = new System.Windows.Forms.Label();
            this.btnCalPrev = new Guna.UI2.WinForms.Guna2Button();
            this.lblCalMonthYear = new System.Windows.Forms.Label();
            this.btnCalNext = new Guna.UI2.WinForms.Guna2Button();
            this.tlpCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.lblCalSun = new System.Windows.Forms.Label();
            this.lblCalMon = new System.Windows.Forms.Label();
            this.lblCalTue = new System.Windows.Forms.Label();
            this.lblCalWed = new System.Windows.Forms.Label();
            this.lblCalThu = new System.Windows.Forms.Label();
            this.lblCalFri = new System.Windows.Forms.Label();
            this.lblCalSat = new System.Windows.Forms.Label();

            // ----- Pending requests card -----
            this.pnlPendingRequestsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.flpPendingRequests = new System.Windows.Forms.FlowLayoutPanel();

            // ----- Profile quick view card -----
            this.pnlProfileQuickView = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfileQuickTitle = new System.Windows.Forms.Label();
            this.pnlQuickAvatar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQuickAvatarInitial = new System.Windows.Forms.Label();
            this.lblQuickName = new System.Windows.Forms.Label();
            this.lblQuickSubtitle = new System.Windows.Forms.Label();
            this.pnlQuickStatBookings = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQuickBookingsValue = new System.Windows.Forms.Label();
            this.lblQuickBookingsLabel = new System.Windows.Forms.Label();
            this.pnlQuickStatRating = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQuickRatingValue = new System.Windows.Forms.Label();
            this.lblQuickRatingLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).BeginInit();
            this.pnlPageBackground.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlWelcomeBanner.SuspendLayout();
            this.pnlNotificationsDropdown.SuspendLayout();
            this.pnlStatMonth.SuspendLayout();
            this.pnlStatBookings.SuspendLayout();
            this.pnlStatRating.SuspendLayout();
            this.pnlStatHours.SuspendLayout();
            this.pnlCalendarCard.SuspendLayout();
            this.pnlPendingRequestsCard.SuspendLayout();
            this.pnlProfileQuickView.SuspendLayout();
            this.pnlQuickAvatar.SuspendLayout();
            this.pnlQuickStatBookings.SuspendLayout();
            this.pnlQuickStatRating.SuspendLayout();
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

            this.btnNavBabysitterHome.BorderRadius = 8;
            this.btnNavBabysitterHome.BorderThickness = 0;
            this.btnNavBabysitterHome.ShadowDecoration.Enabled = false;
            this.btnNavBabysitterHome.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnNavBabysitterHome.BackColor = System.Drawing.Color.White;
            this.btnNavBabysitterHome.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnNavBabysitterHome.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnNavBabysitterHome.Location = new System.Drawing.Point(275, 18);
            this.btnNavBabysitterHome.Name = "btnNavBabysitterHome";
            this.btnNavBabysitterHome.Size = new System.Drawing.Size(160, 45);
            this.btnNavBabysitterHome.Text = "Babysitter Home";
            this.btnNavBabysitterHome.Click += new System.EventHandler(this.btnNavBabysitterHome_Click);

            this.btnNavMyProfile.BorderRadius = 8;
            this.btnNavMyProfile.BorderThickness = 0;
            this.btnNavMyProfile.ShadowDecoration.Enabled = false;
            this.btnNavMyProfile.FillColor = System.Drawing.Color.Transparent;
            this.btnNavMyProfile.BackColor = System.Drawing.Color.White;
            this.btnNavMyProfile.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnNavMyProfile.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnNavMyProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnNavMyProfile.Location = new System.Drawing.Point(445, 18);
            this.btnNavMyProfile.Name = "btnNavMyProfile";
            this.btnNavMyProfile.Size = new System.Drawing.Size(125, 45);
            this.btnNavMyProfile.Text = "My Profile";
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
            // pnlWelcomeBanner (teal gradient)
            //
            this.pnlWelcomeBanner.BorderRadius = 18;
            this.pnlWelcomeBanner.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.pnlWelcomeBanner.FillColor2 = System.Drawing.Color.FromArgb(125, 216, 213);
            this.pnlWelcomeBanner.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlWelcomeBanner.Location = new System.Drawing.Point(30, 30);
            this.pnlWelcomeBanner.Name = "pnlWelcomeBanner";
            this.pnlWelcomeBanner.Size = new System.Drawing.Size(1420, 120);

            this.lblGreeting.BackColor = System.Drawing.Color.Transparent;
            this.lblGreeting.ForeColor = System.Drawing.Color.White;
            this.lblGreeting.Location = new System.Drawing.Point(35, 20);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(250, 22);
            this.lblGreeting.Text = "Welcome back,";

            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(32, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(300, 33);
            this.lblUserName.Text = "<div style=\"color:white;font-weight:bold;font-size:14pt;\">Emma Thompson</div>";

            this.lblRatingSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblRatingSummary.ForeColor = System.Drawing.Color.White;
            this.lblRatingSummary.Location = new System.Drawing.Point(35, 82);
            this.lblRatingSummary.Name = "lblRatingSummary";
            this.lblRatingSummary.Size = new System.Drawing.Size(220, 22);
            this.lblRatingSummary.Text = "★ 4.9  ·  47 reviews";

            this.btnNotifications.BorderRadius = 22;
            this.btnNotifications.BorderThickness = 0;
            this.btnNotifications.ShadowDecoration.Enabled = false;
            this.btnNotifications.FillColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            this.btnNotifications.HoverState.FillColor = System.Drawing.Color.FromArgb(240, 250, 250);
            this.btnNotifications.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNotifications.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.btnNotifications.Location = new System.Drawing.Point(1250, 33);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(55, 55);
            this.btnNotifications.Text = "\U0001F514";
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);

            this.btnMyProfileIcon.BorderRadius = 22;
            this.btnMyProfileIcon.BorderThickness = 0;
            this.btnMyProfileIcon.ShadowDecoration.Enabled = false;
            this.btnMyProfileIcon.FillColor = System.Drawing.Color.White;
            this.btnMyProfileIcon.HoverState.FillColor = System.Drawing.Color.FromArgb(240, 250, 250);
            this.btnMyProfileIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnMyProfileIcon.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.btnMyProfileIcon.Location = new System.Drawing.Point(1325, 33);
            this.btnMyProfileIcon.Name = "btnMyProfileIcon";
            this.btnMyProfileIcon.Size = new System.Drawing.Size(55, 55);
            this.btnMyProfileIcon.Text = "\U0001F464";
            this.btnMyProfileIcon.Click += new System.EventHandler(this.btnMyProfileIcon_Click);

            this.pnlWelcomeBanner.Controls.Add(this.lblGreeting);
            this.pnlWelcomeBanner.Controls.Add(this.lblUserName);
            this.pnlWelcomeBanner.Controls.Add(this.lblRatingSummary);
            this.pnlWelcomeBanner.Controls.Add(this.btnNotifications);
            this.pnlWelcomeBanner.Controls.Add(this.btnMyProfileIcon);

            //
            // pnlNotificationsDropdown (hidden until the bell is clicked)
            //
            this.pnlNotificationsDropdown.BorderRadius = 16;
            this.pnlNotificationsDropdown.FillColor = System.Drawing.Color.White;
            this.pnlNotificationsDropdown.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlNotificationsDropdown.Location = new System.Drawing.Point(30, 160);
            this.pnlNotificationsDropdown.Name = "pnlNotificationsDropdown";
            this.pnlNotificationsDropdown.Size = new System.Drawing.Size(460, 220);
            this.pnlNotificationsDropdown.Visible = false;

            this.lblNotificationsTitle.Location = new System.Drawing.Point(16, 14);
            this.lblNotificationsTitle.Size = new System.Drawing.Size(200, 22);
            this.lblNotificationsTitle.Text = "Notifications";
            this.lblNotificationsTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotificationsTitle.BackColor = System.Drawing.Color.Transparent;

            this.btnMarkAllRead.BorderRadius = 6;
            this.btnMarkAllRead.BorderThickness = 0;
            this.btnMarkAllRead.ShadowDecoration.Enabled = false;
            this.btnMarkAllRead.FillColor = System.Drawing.Color.Transparent;
            this.btnMarkAllRead.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.btnMarkAllRead.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnMarkAllRead.Location = new System.Drawing.Point(320, 12);
            this.btnMarkAllRead.Name = "btnMarkAllRead";
            this.btnMarkAllRead.Size = new System.Drawing.Size(120, 26);
            this.btnMarkAllRead.Text = "Mark all read";
            this.btnMarkAllRead.Click += new System.EventHandler(this.btnMarkAllRead_Click);

            this.flpNotificationsList.Location = new System.Drawing.Point(12, 46);
            this.flpNotificationsList.Name = "flpNotificationsList";
            this.flpNotificationsList.Size = new System.Drawing.Size(436, 164);
            this.flpNotificationsList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNotificationsList.WrapContents = false;
            this.flpNotificationsList.AutoScroll = true;
            this.flpNotificationsList.BackColor = System.Drawing.Color.Transparent;

            this.pnlNotificationsDropdown.Controls.Add(this.lblNotificationsTitle);
            this.pnlNotificationsDropdown.Controls.Add(this.btnMarkAllRead);
            this.pnlNotificationsDropdown.Controls.Add(this.flpNotificationsList);

            //
            // Stat cards
            //
            SetupStatCard(this.pnlStatMonth, this.pnlStatMonthIcon, this.lblStatMonthIcon, this.lblStatMonthValue, this.lblStatMonthLabel,
                30, "$", System.Drawing.Color.FromArgb(232, 113, 74), System.Drawing.Color.FromArgb(253, 226, 220), "$480", "This Month");
            SetupStatCard(this.pnlStatBookings, this.pnlStatBookingsIcon, this.lblStatBookingsIcon, this.lblStatBookingsValue, this.lblStatBookingsLabel,
                390, "C", System.Drawing.Color.FromArgb(94, 200, 196), System.Drawing.Color.FromArgb(222, 245, 244), "47", "Total Bookings");
            SetupStatCard(this.pnlStatRating, this.pnlStatRatingIcon, this.lblStatRatingIcon, this.lblStatRatingValue, this.lblStatRatingLabel,
                750, "★", System.Drawing.Color.FromArgb(255, 209, 102), System.Drawing.Color.FromArgb(255, 244, 217), "4.9", "Avg. Rating");
            SetupStatCard(this.pnlStatHours, this.pnlStatHoursIcon, this.lblStatHoursIcon, this.lblStatHoursValue, this.lblStatHoursLabel,
                1110, "H", System.Drawing.Color.FromArgb(224, 90, 90), System.Drawing.Color.FromArgb(253, 225, 225), "124h", "Hours Worked");

            //
            // pnlCalendarCard
            //
            this.pnlCalendarCard.BorderRadius = 16;
            this.pnlCalendarCard.FillColor = System.Drawing.Color.White;
            this.pnlCalendarCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlCalendarCard.Location = new System.Drawing.Point(30, 430);
            this.pnlCalendarCard.Name = "pnlCalendarCard";
            this.pnlCalendarCard.Size = new System.Drawing.Size(900, 430);

            this.lblCalendarTitle.Location = new System.Drawing.Point(16, 14);
            this.lblCalendarTitle.Size = new System.Drawing.Size(220, 24);
            this.lblCalendarTitle.Text = "Booking Calendar";
            this.lblCalendarTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblCalendarTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCalendarTitle.BackColor = System.Drawing.Color.Transparent;

            this.btnCalPrev.BorderRadius = 8;
            this.btnCalPrev.BorderThickness = 0;
            this.btnCalPrev.ShadowDecoration.Enabled = false;
            this.btnCalPrev.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnCalPrev.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnCalPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalPrev.Location = new System.Drawing.Point(650, 12);
            this.btnCalPrev.Name = "btnCalPrev";
            this.btnCalPrev.Size = new System.Drawing.Size(36, 32);
            this.btnCalPrev.Text = "<";
            this.btnCalPrev.Click += new System.EventHandler(this.btnCalPrev_Click);

            this.lblCalMonthYear.Location = new System.Drawing.Point(692, 14);
            this.lblCalMonthYear.Size = new System.Drawing.Size(150, 26);
            this.lblCalMonthYear.Text = "June 2024";
            this.lblCalMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCalMonthYear.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblCalMonthYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCalMonthYear.BackColor = System.Drawing.Color.Transparent;

            this.btnCalNext.BorderRadius = 8;
            this.btnCalNext.BorderThickness = 0;
            this.btnCalNext.ShadowDecoration.Enabled = false;
            this.btnCalNext.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnCalNext.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnCalNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalNext.Location = new System.Drawing.Point(848, 12);
            this.btnCalNext.Name = "btnCalNext";
            this.btnCalNext.Size = new System.Drawing.Size(36, 32);
            this.btnCalNext.Text = ">";
            this.btnCalNext.Click += new System.EventHandler(this.btnCalNext_Click);

            //
            // tlpCalendar - 7 columns (Sun..Sat), 7 rows (1 header + 6 week rows).
            // Week rows 1-6 are populated at runtime in BabysitterDashboardForm.cs.
            //
            this.tlpCalendar.Location = new System.Drawing.Point(16, 56);
            this.tlpCalendar.Name = "tlpCalendar";
            this.tlpCalendar.Size = new System.Drawing.Size(868, 356);
            this.tlpCalendar.ColumnCount = 7;
            this.tlpCalendar.RowCount = 7;
            this.tlpCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tlpCalendar.BackColor = System.Drawing.Color.Transparent;
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));

            SetupDayHeaderLabel(this.lblCalSun, "Sun");
            SetupDayHeaderLabel(this.lblCalMon, "Mon");
            SetupDayHeaderLabel(this.lblCalTue, "Tue");
            SetupDayHeaderLabel(this.lblCalWed, "Wed");
            SetupDayHeaderLabel(this.lblCalThu, "Thu");
            SetupDayHeaderLabel(this.lblCalFri, "Fri");
            SetupDayHeaderLabel(this.lblCalSat, "Sat");
            this.tlpCalendar.Controls.Add(this.lblCalSun, 0, 0);
            this.tlpCalendar.Controls.Add(this.lblCalMon, 1, 0);
            this.tlpCalendar.Controls.Add(this.lblCalTue, 2, 0);
            this.tlpCalendar.Controls.Add(this.lblCalWed, 3, 0);
            this.tlpCalendar.Controls.Add(this.lblCalThu, 4, 0);
            this.tlpCalendar.Controls.Add(this.lblCalFri, 5, 0);
            this.tlpCalendar.Controls.Add(this.lblCalSat, 6, 0);

            this.pnlCalendarCard.Controls.Add(this.lblCalendarTitle);
            this.pnlCalendarCard.Controls.Add(this.btnCalPrev);
            this.pnlCalendarCard.Controls.Add(this.lblCalMonthYear);
            this.pnlCalendarCard.Controls.Add(this.btnCalNext);
            this.pnlCalendarCard.Controls.Add(this.tlpCalendar);

            //
            // pnlPendingRequestsCard
            //
            this.pnlPendingRequestsCard.BorderRadius = 16;
            this.pnlPendingRequestsCard.FillColor = System.Drawing.Color.White;
            this.pnlPendingRequestsCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlPendingRequestsCard.Location = new System.Drawing.Point(950, 430);
            this.pnlPendingRequestsCard.Name = "pnlPendingRequestsCard";
            this.pnlPendingRequestsCard.Size = new System.Drawing.Size(500, 260);

            this.lblPendingTitle.Location = new System.Drawing.Point(16, 14);
            this.lblPendingTitle.Size = new System.Drawing.Size(240, 24);
            this.lblPendingTitle.Text = "Pending Requests";
            this.lblPendingTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPendingTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingTitle.BackColor = System.Drawing.Color.Transparent;

            this.flpPendingRequests.Location = new System.Drawing.Point(12, 50);
            this.flpPendingRequests.Name = "flpPendingRequests";
            this.flpPendingRequests.Size = new System.Drawing.Size(476, 200);
            this.flpPendingRequests.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPendingRequests.WrapContents = false;
            this.flpPendingRequests.AutoScroll = true;
            this.flpPendingRequests.BackColor = System.Drawing.Color.Transparent;

            this.pnlPendingRequestsCard.Controls.Add(this.lblPendingTitle);
            this.pnlPendingRequestsCard.Controls.Add(this.flpPendingRequests);

            //
            // pnlProfileQuickView
            //
            this.pnlProfileQuickView.BorderRadius = 16;
            this.pnlProfileQuickView.FillColor = System.Drawing.Color.White;
            this.pnlProfileQuickView.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlProfileQuickView.Location = new System.Drawing.Point(950, 700);
            this.pnlProfileQuickView.Name = "pnlProfileQuickView";
            this.pnlProfileQuickView.Size = new System.Drawing.Size(500, 160);
            this.pnlProfileQuickView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlProfileQuickView.Click += new System.EventHandler(this.pnlProfileQuickView_Click);

            this.lblProfileQuickTitle.Location = new System.Drawing.Point(16, 14);
            this.lblProfileQuickTitle.Size = new System.Drawing.Size(200, 22);
            this.lblProfileQuickTitle.Text = "My Profile";
            this.lblProfileQuickTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblProfileQuickTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProfileQuickTitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlQuickAvatar.BorderRadius = 16;
            this.pnlQuickAvatar.FillColor = System.Drawing.Color.FromArgb(222, 245, 244);
            this.pnlQuickAvatar.Location = new System.Drawing.Point(16, 46);
            this.pnlQuickAvatar.Name = "pnlQuickAvatar";
            this.pnlQuickAvatar.Size = new System.Drawing.Size(55, 55);

            this.lblQuickAvatarInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuickAvatarInitial.Text = "E";
            this.lblQuickAvatarInitial.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.lblQuickAvatarInitial.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuickAvatarInitial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuickAvatarInitial.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuickAvatar.Controls.Add(this.lblQuickAvatarInitial);

            this.lblQuickName.Location = new System.Drawing.Point(85, 52);
            this.lblQuickName.Size = new System.Drawing.Size(300, 24);
            this.lblQuickName.Text = "Emma Thompson";
            this.lblQuickName.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblQuickName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuickName.BackColor = System.Drawing.Color.Transparent;

            this.lblQuickSubtitle.Location = new System.Drawing.Point(85, 78);
            this.lblQuickSubtitle.Size = new System.Drawing.Size(340, 20);
            this.lblQuickSubtitle.Text = "Babysitter · 3 yrs experience";
            this.lblQuickSubtitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblQuickSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblQuickSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlQuickStatBookings.BorderRadius = 12;
            this.pnlQuickStatBookings.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlQuickStatBookings.Location = new System.Drawing.Point(16, 112);
            this.pnlQuickStatBookings.Name = "pnlQuickStatBookings";
            this.pnlQuickStatBookings.Size = new System.Drawing.Size(230, 36);
            this.lblQuickBookingsValue.Location = new System.Drawing.Point(10, 8);
            this.lblQuickBookingsValue.Size = new System.Drawing.Size(50, 20);
            this.lblQuickBookingsValue.Text = "47";
            this.lblQuickBookingsValue.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.lblQuickBookingsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuickBookingsValue.BackColor = System.Drawing.Color.Transparent;
            this.lblQuickBookingsLabel.Location = new System.Drawing.Point(60, 9);
            this.lblQuickBookingsLabel.Size = new System.Drawing.Size(120, 18);
            this.lblQuickBookingsLabel.Text = "Bookings";
            this.lblQuickBookingsLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblQuickBookingsLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblQuickBookingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuickStatBookings.Controls.Add(this.lblQuickBookingsValue);
            this.pnlQuickStatBookings.Controls.Add(this.lblQuickBookingsLabel);

            this.pnlQuickStatRating.BorderRadius = 12;
            this.pnlQuickStatRating.FillColor = System.Drawing.Color.FromArgb(222, 245, 244);
            this.pnlQuickStatRating.Location = new System.Drawing.Point(256, 112);
            this.pnlQuickStatRating.Name = "pnlQuickStatRating";
            this.pnlQuickStatRating.Size = new System.Drawing.Size(228, 36);
            this.lblQuickRatingValue.Location = new System.Drawing.Point(10, 8);
            this.lblQuickRatingValue.Size = new System.Drawing.Size(50, 20);
            this.lblQuickRatingValue.Text = "4.9";
            this.lblQuickRatingValue.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.lblQuickRatingValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuickRatingValue.BackColor = System.Drawing.Color.Transparent;
            this.lblQuickRatingLabel.Location = new System.Drawing.Point(60, 9);
            this.lblQuickRatingLabel.Size = new System.Drawing.Size(120, 18);
            this.lblQuickRatingLabel.Text = "Rating";
            this.lblQuickRatingLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblQuickRatingLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblQuickRatingLabel.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuickStatRating.Controls.Add(this.lblQuickRatingValue);
            this.pnlQuickStatRating.Controls.Add(this.lblQuickRatingLabel);

            this.pnlProfileQuickView.Controls.Add(this.lblProfileQuickTitle);
            this.pnlProfileQuickView.Controls.Add(this.pnlQuickAvatar);
            this.pnlProfileQuickView.Controls.Add(this.lblQuickName);
            this.pnlProfileQuickView.Controls.Add(this.lblQuickSubtitle);
            this.pnlProfileQuickView.Controls.Add(this.pnlQuickStatBookings);
            this.pnlProfileQuickView.Controls.Add(this.pnlQuickStatRating);

            //
            // pnlNavbar.Controls
            //
            this.pnlNavbar.Controls.Add(this.picNavLogo);
            this.pnlNavbar.Controls.Add(this.lblNavBrand);
            this.pnlNavbar.Controls.Add(this.btnNavBabysitterHome);
            this.pnlNavbar.Controls.Add(this.btnNavMyProfile);
            this.pnlNavbar.Controls.Add(this.btnLogout);

            //
            // pnlContent.Controls
            //
            this.pnlContent.Controls.Add(this.pnlWelcomeBanner);
            this.pnlContent.Controls.Add(this.pnlNotificationsDropdown);
            this.pnlContent.Controls.Add(this.pnlStatMonth);
            this.pnlContent.Controls.Add(this.pnlStatBookings);
            this.pnlContent.Controls.Add(this.pnlStatRating);
            this.pnlContent.Controls.Add(this.pnlStatHours);
            this.pnlContent.Controls.Add(this.pnlCalendarCard);
            this.pnlContent.Controls.Add(this.pnlPendingRequestsCard);
            this.pnlContent.Controls.Add(this.pnlProfileQuickView);

            //
            // BabysitterDashboardForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.pnlPageBackground);
            this.MinimumSize = new System.Drawing.Size(1246, 738);
            this.Name = "BabysitterDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meraki - Babysitter Dashboard";
            this.Load += new System.EventHandler(this.BabysitterDashboardForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).EndInit();
            this.pnlQuickStatRating.ResumeLayout(false);
            this.pnlQuickStatBookings.ResumeLayout(false);
            this.pnlQuickAvatar.ResumeLayout(false);
            this.pnlProfileQuickView.ResumeLayout(false);
            this.pnlPendingRequestsCard.ResumeLayout(false);
            this.pnlCalendarCard.ResumeLayout(false);
            this.pnlStatHours.ResumeLayout(false);
            this.pnlStatRating.ResumeLayout(false);
            this.pnlStatBookings.ResumeLayout(false);
            this.pnlStatMonth.ResumeLayout(false);
            this.pnlNotificationsDropdown.ResumeLayout(false);
            this.pnlWelcomeBanner.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlPageBackground.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Small helper so the four near-identical stat cards aren't ~15 repeated
        // lines each - still built entirely inside InitializeComponent, just factored out.
        private void SetupStatCard(Guna.UI2.WinForms.Guna2Panel card, Guna.UI2.WinForms.Guna2Panel iconCircle,
            System.Windows.Forms.Label iconLabel, System.Windows.Forms.Label valueLabel, System.Windows.Forms.Label captionLabel,
            int x, string iconText, System.Drawing.Color iconColor, System.Drawing.Color iconBg, string value, string caption)
        {
            card.BorderRadius = 16;
            card.FillColor = System.Drawing.Color.White;
            card.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            card.Location = new System.Drawing.Point(x, 300);
            card.Size = new System.Drawing.Size(340, 110);

            iconCircle.BorderRadius = 18;
            iconCircle.FillColor = iconBg;
            iconCircle.Location = new System.Drawing.Point(16, 16);
            iconCircle.Size = new System.Drawing.Size(36, 36);

            iconLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            iconLabel.Text = iconText;
            iconLabel.ForeColor = iconColor;
            iconLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            iconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            iconLabel.BackColor = System.Drawing.Color.Transparent;
            iconCircle.Controls.Add(iconLabel);

            valueLabel.Location = new System.Drawing.Point(16, 58);
            valueLabel.Size = new System.Drawing.Size(200, 30);
            valueLabel.Text = value;
            valueLabel.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            valueLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            valueLabel.BackColor = System.Drawing.Color.Transparent;

            captionLabel.Location = new System.Drawing.Point(16, 88);
            captionLabel.Size = new System.Drawing.Size(220, 20);
            captionLabel.Text = caption;
            captionLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            captionLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            captionLabel.BackColor = System.Drawing.Color.Transparent;

            card.Controls.Add(iconCircle);
            card.Controls.Add(valueLabel);
            card.Controls.Add(captionLabel);
        }

        private static void SetupDayHeaderLabel(System.Windows.Forms.Label label, string text)
        {
            label.Text = text;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            label.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label.BackColor = System.Drawing.Color.Transparent;
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
        private Guna.UI2.WinForms.Guna2Button btnCalPrev;
        private System.Windows.Forms.Label lblCalMonthYear;
        private Guna.UI2.WinForms.Guna2Button btnCalNext;
        private System.Windows.Forms.TableLayoutPanel tlpCalendar;
        private System.Windows.Forms.Label lblCalSun;
        private System.Windows.Forms.Label lblCalMon;
        private System.Windows.Forms.Label lblCalTue;
        private System.Windows.Forms.Label lblCalWed;
        private System.Windows.Forms.Label lblCalThu;
        private System.Windows.Forms.Label lblCalFri;
        private System.Windows.Forms.Label lblCalSat;

        private Guna.UI2.WinForms.Guna2Panel pnlPendingRequestsCard;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.FlowLayoutPanel flpPendingRequests;

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
