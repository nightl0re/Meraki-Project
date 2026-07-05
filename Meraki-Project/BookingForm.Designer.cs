namespace Meraki_Project
{
    partial class BookingForm
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

            // Step indicator
            this.pnlStepCircle1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepNum1 = new System.Windows.Forms.Label();
            this.lblStepCaption1 = new System.Windows.Forms.Label();
            this.pnlStepLine1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStepCircle2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepNum2 = new System.Windows.Forms.Label();
            this.lblStepCaption2 = new System.Windows.Forms.Label();
            this.pnlStepLine2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStepCircle3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepNum3 = new System.Windows.Forms.Label();
            this.lblStepCaption3 = new System.Windows.Forms.Label();
            this.pnlStepLine3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStepCircle4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepNum4 = new System.Windows.Forms.Label();
            this.lblStepCaption4 = new System.Windows.Forms.Label();

            // Step 0: date & time
            this.pnlStepDateTime = new System.Windows.Forms.Panel();
            this.pnlCalendarCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCalTitle = new System.Windows.Forms.Label();
            this.btnCalPrev = new Guna.UI2.WinForms.Guna2Button();
            this.lblCalMonthYear = new System.Windows.Forms.Label();
            this.btnCalNext = new Guna.UI2.WinForms.Guna2Button();
            this.tlpBookingCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.lblCalSun = new System.Windows.Forms.Label();
            this.lblCalMon = new System.Windows.Forms.Label();
            this.lblCalTue = new System.Windows.Forms.Label();
            this.lblCalWed = new System.Windows.Forms.Label();
            this.lblCalThu = new System.Windows.Forms.Label();
            this.lblCalFri = new System.Windows.Forms.Label();
            this.lblCalSat = new System.Windows.Forms.Label();
            this.pnlTimeSlotsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTimeSlotsTitle = new System.Windows.Forms.Label();
            this.flpTimeSlots = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDurationCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDurationTitle = new System.Windows.Forms.Label();
            this.flpDurations = new System.Windows.Forms.FlowLayoutPanel();

            // Step 1: babysitter
            this.pnlStepBabysitter = new System.Windows.Forms.Panel();
            this.flpBabysitterSelect = new System.Windows.Forms.FlowLayoutPanel();

            // Step 2: details
            this.pnlStepDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblChildCountCaption = new System.Windows.Forms.Label();
            this.btnDecChildren = new Guna.UI2.WinForms.Guna2Button();
            this.lblChildCount = new System.Windows.Forms.Label();
            this.btnIncChildren = new Guna.UI2.WinForms.Guna2Button();
            this.lblAddressCaption = new System.Windows.Forms.Label();
            this.tbAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotesCaption = new System.Windows.Forms.Label();
            this.tbNotes = new Guna.UI2.WinForms.Guna2TextBox();

            // Step 3: confirm
            this.pnlStepConfirm = new System.Windows.Forms.Panel();
            this.lblConfirmTitle = new System.Windows.Forms.Label();
            this.lblSumDate = new System.Windows.Forms.Label();
            this.lblSumTime = new System.Windows.Forms.Label();
            this.lblSumBabysitter = new System.Windows.Forms.Label();
            this.lblSumChildren = new System.Windows.Forms.Label();
            this.lblSumAddress = new System.Windows.Forms.Label();
            this.lblCostSitterLine = new System.Windows.Forms.Label();
            this.lblCostServiceFee = new System.Windows.Forms.Label();
            this.lblCostTotal = new System.Windows.Forms.Label();
            this.lblPaymentNote = new System.Windows.Forms.Label();

            // Bottom nav
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnContinue = new Guna.UI2.WinForms.Guna2Button();

            // Confirmation screen (replaces everything above once booked)
            this.pnlConfirmationScreen = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCheckCircle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCheckIcon = new System.Windows.Forms.Label();
            this.lblConfirmedTitle = new System.Windows.Forms.Label();
            this.lblConfirmedMessage = new System.Windows.Forms.Label();
            this.pnlConfirmedSummaryCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblConfirmedDate = new System.Windows.Forms.Label();
            this.lblConfirmedTime = new System.Windows.Forms.Label();
            this.lblConfirmedBabysitter = new System.Windows.Forms.Label();
            this.lblConfirmedTotal = new System.Windows.Forms.Label();
            this.btnBackToDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnNewBooking = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).BeginInit();
            this.pnlPageBackground.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStepDateTime.SuspendLayout();
            this.pnlCalendarCard.SuspendLayout();
            this.pnlTimeSlotsCard.SuspendLayout();
            this.pnlDurationCard.SuspendLayout();
            this.pnlStepBabysitter.SuspendLayout();
            this.pnlStepDetails.SuspendLayout();
            this.pnlStepConfirm.SuspendLayout();
            this.pnlConfirmationScreen.SuspendLayout();
            this.pnlCheckCircle.SuspendLayout();
            this.pnlConfirmedSummaryCard.SuspendLayout();
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
            SetupNavButton(this.btnNavFindBabysitter, "Find a Babysitter", 423, 162, false);
            this.btnNavFindBabysitter.Click += new System.EventHandler(this.btnNavFindBabysitter_Click);
            SetupNavButton(this.btnNavBookNow, "Book Now", 595, 125, true);
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
            this.lblPageTitle.Text = "Book a Babysitter";
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblPageSubtitle.Location = new System.Drawing.Point(30, 56);
            this.lblPageSubtitle.Size = new System.Drawing.Size(500, 22);
            this.lblPageSubtitle.Text = "Complete the steps below to schedule your booking";
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.BackColor = System.Drawing.Color.Transparent;

            //
            // Step indicator (4 circles + connecting lines)
            //
            SetupStepCircle(this.pnlStepCircle1, this.lblStepNum1, this.lblStepCaption1, 30, "1", "Select Date & Time", true);
            SetupStepCircle(this.pnlStepCircle2, this.lblStepNum2, this.lblStepCaption2, 390, "2", "Choose Babysitter", false);
            SetupStepCircle(this.pnlStepCircle3, this.lblStepNum3, this.lblStepCaption3, 750, "3", "Details", false);
            SetupStepCircle(this.pnlStepCircle4, this.lblStepNum4, this.lblStepCaption4, 1110, "4", "Confirm", false);

            this.pnlStepLine1.FillColor = System.Drawing.Color.FromArgb(230, 224, 218);
            this.pnlStepLine1.Location = new System.Drawing.Point(66, 106);
            this.pnlStepLine1.Size = new System.Drawing.Size(324, 3);
            this.pnlStepLine2.FillColor = System.Drawing.Color.FromArgb(230, 224, 218);
            this.pnlStepLine2.Location = new System.Drawing.Point(426, 106);
            this.pnlStepLine2.Size = new System.Drawing.Size(324, 3);
            this.pnlStepLine3.FillColor = System.Drawing.Color.FromArgb(230, 224, 218);
            this.pnlStepLine3.Location = new System.Drawing.Point(786, 106);
            this.pnlStepLine3.Size = new System.Drawing.Size(324, 3);

            //
            // pnlStepDateTime (step 0)
            //
            this.pnlStepDateTime.Location = new System.Drawing.Point(30, 180);
            this.pnlStepDateTime.Name = "pnlStepDateTime";
            this.pnlStepDateTime.Size = new System.Drawing.Size(1420, 700);
            this.pnlStepDateTime.BackColor = System.Drawing.Color.Transparent;

            this.pnlCalendarCard.BorderRadius = 16;
            this.pnlCalendarCard.FillColor = System.Drawing.Color.White;
            this.pnlCalendarCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlCalendarCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendarCard.Size = new System.Drawing.Size(700, 380);

            this.lblCalTitle.Location = new System.Drawing.Point(16, 14);
            this.lblCalTitle.Size = new System.Drawing.Size(200, 24);
            this.lblCalTitle.Text = "Select Date";
            this.lblCalTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblCalTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCalTitle.BackColor = System.Drawing.Color.Transparent;

            this.btnCalPrev.BorderRadius = 8;
            this.btnCalPrev.BorderThickness = 0;
            this.btnCalPrev.ShadowDecoration.Enabled = false;
            this.btnCalPrev.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnCalPrev.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnCalPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalPrev.Location = new System.Drawing.Point(560, 12);
            this.btnCalPrev.Size = new System.Drawing.Size(34, 32);
            this.btnCalPrev.Text = "<";
            this.btnCalPrev.Click += new System.EventHandler(this.btnCalPrev_Click);

            this.lblCalMonthYear.Location = new System.Drawing.Point(600, 14);
            this.lblCalMonthYear.Size = new System.Drawing.Size(130, 26);
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
            this.btnCalNext.Location = new System.Drawing.Point(650, 12);
            this.btnCalNext.Size = new System.Drawing.Size(34, 32);
            this.btnCalNext.Text = ">";
            this.btnCalNext.Click += new System.EventHandler(this.btnCalNext_Click);

            this.tlpBookingCalendar.Location = new System.Drawing.Point(16, 54);
            this.tlpBookingCalendar.Size = new System.Drawing.Size(668, 310);
            this.tlpBookingCalendar.ColumnCount = 7;
            this.tlpBookingCalendar.RowCount = 7;
            this.tlpBookingCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tlpBookingCalendar.BackColor = System.Drawing.Color.Transparent;
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.285714F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            this.tlpBookingCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));

            SetupDayHeaderLabel(this.lblCalSun, "Su");
            SetupDayHeaderLabel(this.lblCalMon, "Mo");
            SetupDayHeaderLabel(this.lblCalTue, "Tu");
            SetupDayHeaderLabel(this.lblCalWed, "We");
            SetupDayHeaderLabel(this.lblCalThu, "Th");
            SetupDayHeaderLabel(this.lblCalFri, "Fr");
            SetupDayHeaderLabel(this.lblCalSat, "Sa");
            this.tlpBookingCalendar.Controls.Add(this.lblCalSun, 0, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalMon, 1, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalTue, 2, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalWed, 3, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalThu, 4, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalFri, 5, 0);
            this.tlpBookingCalendar.Controls.Add(this.lblCalSat, 6, 0);

            this.pnlCalendarCard.Controls.Add(this.lblCalTitle);
            this.pnlCalendarCard.Controls.Add(this.btnCalPrev);
            this.pnlCalendarCard.Controls.Add(this.lblCalMonthYear);
            this.pnlCalendarCard.Controls.Add(this.btnCalNext);
            this.pnlCalendarCard.Controls.Add(this.tlpBookingCalendar);

            this.pnlTimeSlotsCard.BorderRadius = 16;
            this.pnlTimeSlotsCard.FillColor = System.Drawing.Color.White;
            this.pnlTimeSlotsCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlTimeSlotsCard.Location = new System.Drawing.Point(0, 395);
            this.pnlTimeSlotsCard.Size = new System.Drawing.Size(700, 140);
            this.pnlTimeSlotsCard.Visible = false;

            this.lblTimeSlotsTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTimeSlotsTitle.Size = new System.Drawing.Size(220, 22);
            this.lblTimeSlotsTitle.Text = "Select Start Time";
            this.lblTimeSlotsTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblTimeSlotsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimeSlotsTitle.BackColor = System.Drawing.Color.Transparent;

            this.flpTimeSlots.Location = new System.Drawing.Point(12, 46);
            this.flpTimeSlots.Size = new System.Drawing.Size(676, 86);
            this.flpTimeSlots.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpTimeSlots.WrapContents = true;
            this.flpTimeSlots.BackColor = System.Drawing.Color.Transparent;

            this.pnlTimeSlotsCard.Controls.Add(this.lblTimeSlotsTitle);
            this.pnlTimeSlotsCard.Controls.Add(this.flpTimeSlots);

            this.pnlDurationCard.BorderRadius = 16;
            this.pnlDurationCard.FillColor = System.Drawing.Color.White;
            this.pnlDurationCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlDurationCard.Location = new System.Drawing.Point(0, 550);
            this.pnlDurationCard.Size = new System.Drawing.Size(700, 110);
            this.pnlDurationCard.Visible = false;

            this.lblDurationTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDurationTitle.Size = new System.Drawing.Size(160, 22);
            this.lblDurationTitle.Text = "Duration";
            this.lblDurationTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblDurationTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDurationTitle.BackColor = System.Drawing.Color.Transparent;

            this.flpDurations.Location = new System.Drawing.Point(12, 46);
            this.flpDurations.Size = new System.Drawing.Size(676, 56);
            this.flpDurations.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpDurations.WrapContents = true;
            this.flpDurations.BackColor = System.Drawing.Color.Transparent;

            this.pnlDurationCard.Controls.Add(this.lblDurationTitle);
            this.pnlDurationCard.Controls.Add(this.flpDurations);

            this.pnlStepDateTime.Controls.Add(this.pnlCalendarCard);
            this.pnlStepDateTime.Controls.Add(this.pnlTimeSlotsCard);
            this.pnlStepDateTime.Controls.Add(this.pnlDurationCard);

            //
            // pnlStepBabysitter (step 1)
            //
            this.pnlStepBabysitter.Location = new System.Drawing.Point(30, 180);
            this.pnlStepBabysitter.Size = new System.Drawing.Size(1420, 500);
            this.pnlStepBabysitter.BackColor = System.Drawing.Color.Transparent;
            this.pnlStepBabysitter.Visible = false;

            this.flpBabysitterSelect.Location = new System.Drawing.Point(0, 0);
            this.flpBabysitterSelect.Size = new System.Drawing.Size(900, 500);
            this.flpBabysitterSelect.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBabysitterSelect.WrapContents = false;
            this.flpBabysitterSelect.AutoScroll = true;
            this.flpBabysitterSelect.BackColor = System.Drawing.Color.Transparent;

            this.pnlStepBabysitter.Controls.Add(this.flpBabysitterSelect);

            //
            // pnlStepDetails (step 2)
            //
            this.pnlStepDetails.Location = new System.Drawing.Point(30, 180);
            this.pnlStepDetails.Size = new System.Drawing.Size(1420, 420);
            this.pnlStepDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlStepDetails.Visible = false;

            this.lblDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDetailsTitle.Size = new System.Drawing.Size(300, 26);
            this.lblDetailsTitle.Text = "Booking Details";
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblChildCountCaption.Location = new System.Drawing.Point(0, 50);
            this.lblChildCountCaption.Size = new System.Drawing.Size(260, 22);
            this.lblChildCountCaption.Text = "Number of Children";
            this.lblChildCountCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblChildCountCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChildCountCaption.BackColor = System.Drawing.Color.Transparent;

            this.btnDecChildren.BorderRadius = 10;
            this.btnDecChildren.BorderThickness = 0;
            this.btnDecChildren.ShadowDecoration.Enabled = false;
            this.btnDecChildren.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnDecChildren.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnDecChildren.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecChildren.Location = new System.Drawing.Point(0, 80);
            this.btnDecChildren.Size = new System.Drawing.Size(44, 40);
            this.btnDecChildren.Text = "-";
            this.btnDecChildren.Click += new System.EventHandler(this.btnDecChildren_Click);

            this.lblChildCount.Location = new System.Drawing.Point(54, 80);
            this.lblChildCount.Size = new System.Drawing.Size(50, 40);
            this.lblChildCount.Text = "1";
            this.lblChildCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChildCount.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblChildCount.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblChildCount.BackColor = System.Drawing.Color.Transparent;

            this.btnIncChildren.BorderRadius = 10;
            this.btnIncChildren.BorderThickness = 0;
            this.btnIncChildren.ShadowDecoration.Enabled = false;
            this.btnIncChildren.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnIncChildren.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnIncChildren.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIncChildren.Location = new System.Drawing.Point(114, 80);
            this.btnIncChildren.Size = new System.Drawing.Size(44, 40);
            this.btnIncChildren.Text = "+";
            this.btnIncChildren.Click += new System.EventHandler(this.btnIncChildren_Click);

            this.lblAddressCaption.Location = new System.Drawing.Point(0, 150);
            this.lblAddressCaption.Size = new System.Drawing.Size(260, 22);
            this.lblAddressCaption.Text = "Address";
            this.lblAddressCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblAddressCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddressCaption.BackColor = System.Drawing.Color.Transparent;

            this.tbAddress.BorderRadius = 10;
            this.tbAddress.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.tbAddress.PlaceholderText = "123 Main St, City, State";
            this.tbAddress.Location = new System.Drawing.Point(0, 176);
            this.tbAddress.Size = new System.Drawing.Size(700, 44);
            this.tbAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 113, 74);

            this.lblNotesCaption.Location = new System.Drawing.Point(0, 238);
            this.lblNotesCaption.Size = new System.Drawing.Size(400, 22);
            this.lblNotesCaption.Text = "Special Instructions (optional)";
            this.lblNotesCaption.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblNotesCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotesCaption.BackColor = System.Drawing.Color.Transparent;

            this.tbNotes.BorderRadius = 10;
            this.tbNotes.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.tbNotes.PlaceholderText = "Allergies, bedtime routines, emergency contacts...";
            this.tbNotes.Multiline = true;
            this.tbNotes.Location = new System.Drawing.Point(0, 264);
            this.tbNotes.Size = new System.Drawing.Size(700, 100);
            this.tbNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 113, 74);

            this.pnlStepDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlStepDetails.Controls.Add(this.lblChildCountCaption);
            this.pnlStepDetails.Controls.Add(this.btnDecChildren);
            this.pnlStepDetails.Controls.Add(this.lblChildCount);
            this.pnlStepDetails.Controls.Add(this.btnIncChildren);
            this.pnlStepDetails.Controls.Add(this.lblAddressCaption);
            this.pnlStepDetails.Controls.Add(this.tbAddress);
            this.pnlStepDetails.Controls.Add(this.lblNotesCaption);
            this.pnlStepDetails.Controls.Add(this.tbNotes);

            //
            // pnlStepConfirm (step 3)
            //
            this.pnlStepConfirm.Location = new System.Drawing.Point(30, 180);
            this.pnlStepConfirm.Size = new System.Drawing.Size(1420, 420);
            this.pnlStepConfirm.BackColor = System.Drawing.Color.Transparent;
            this.pnlStepConfirm.Visible = false;

            this.lblConfirmTitle.Location = new System.Drawing.Point(0, 0);
            this.lblConfirmTitle.Size = new System.Drawing.Size(300, 26);
            this.lblConfirmTitle.Text = "Booking Summary";
            this.lblConfirmTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblConfirmTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblConfirmTitle.BackColor = System.Drawing.Color.Transparent;

            SetupSummaryRow(this.lblSumDate, 44);
            SetupSummaryRow(this.lblSumTime, 72);
            SetupSummaryRow(this.lblSumBabysitter, 100);
            SetupSummaryRow(this.lblSumChildren, 128);
            SetupSummaryRow(this.lblSumAddress, 156);

            SetupSummaryRow(this.lblCostSitterLine, 210);
            SetupSummaryRow(this.lblCostServiceFee, 236);

            this.lblCostTotal.Location = new System.Drawing.Point(0, 268);
            this.lblCostTotal.Size = new System.Drawing.Size(700, 26);
            this.lblCostTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCostTotal.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.lblCostTotal.BackColor = System.Drawing.Color.Transparent;

            this.lblPaymentNote.Location = new System.Drawing.Point(0, 320);
            this.lblPaymentNote.Size = new System.Drawing.Size(700, 40);
            this.lblPaymentNote.Text = "Payment will be processed after the babysitter confirms the booking.";
            this.lblPaymentNote.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPaymentNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPaymentNote.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);

            this.pnlStepConfirm.Controls.Add(this.lblConfirmTitle);
            this.pnlStepConfirm.Controls.Add(this.lblSumDate);
            this.pnlStepConfirm.Controls.Add(this.lblSumTime);
            this.pnlStepConfirm.Controls.Add(this.lblSumBabysitter);
            this.pnlStepConfirm.Controls.Add(this.lblSumChildren);
            this.pnlStepConfirm.Controls.Add(this.lblSumAddress);
            this.pnlStepConfirm.Controls.Add(this.lblCostSitterLine);
            this.pnlStepConfirm.Controls.Add(this.lblCostServiceFee);
            this.pnlStepConfirm.Controls.Add(this.lblCostTotal);
            this.pnlStepConfirm.Controls.Add(this.lblPaymentNote);

            //
            // Bottom nav buttons
            //
            this.btnBack.BorderRadius = 10;
            this.btnBack.BorderThickness = 0;
            this.btnBack.ShadowDecoration.Enabled = false;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBack.Location = new System.Drawing.Point(30, 910);
            this.btnBack.Size = new System.Drawing.Size(140, 48);
            this.btnBack.Text = "< Back";
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.btnContinue.BorderRadius = 10;
            this.btnContinue.BorderThickness = 0;
            this.btnContinue.ShadowDecoration.Enabled = false;
            this.btnContinue.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnContinue.Location = new System.Drawing.Point(180, 910);
            this.btnContinue.Size = new System.Drawing.Size(1270, 48);
            this.btnContinue.Text = "Continue >";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);

            //
            // pnlConfirmationScreen (shown instead of everything above once booked)
            //
            this.pnlConfirmationScreen.FillColor = System.Drawing.Color.Transparent;
            this.pnlConfirmationScreen.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlConfirmationScreen.Location = new System.Drawing.Point(450, 60);
            this.pnlConfirmationScreen.Size = new System.Drawing.Size(500, 620);
            this.pnlConfirmationScreen.Visible = false;

            this.pnlCheckCircle.BorderRadius = 40;
            this.pnlCheckCircle.FillColor = System.Drawing.Color.FromArgb(222, 245, 244);
            this.pnlCheckCircle.Location = new System.Drawing.Point(210, 0);
            this.pnlCheckCircle.Size = new System.Drawing.Size(80, 80);
            this.lblCheckIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckIcon.Text = "✓";
            this.lblCheckIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckIcon.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCheckIcon.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.lblCheckIcon.BackColor = System.Drawing.Color.Transparent;
            this.pnlCheckCircle.Controls.Add(this.lblCheckIcon);

            this.lblConfirmedTitle.Location = new System.Drawing.Point(0, 96);
            this.lblConfirmedTitle.Size = new System.Drawing.Size(500, 30);
            this.lblConfirmedTitle.Text = "Booking Confirmed!";
            this.lblConfirmedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConfirmedTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblConfirmedTitle.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblConfirmedTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblConfirmedMessage.Location = new System.Drawing.Point(20, 132);
            this.lblConfirmedMessage.Size = new System.Drawing.Size(460, 44);
            this.lblConfirmedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConfirmedMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmedMessage.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblConfirmedMessage.BackColor = System.Drawing.Color.Transparent;

            this.pnlConfirmedSummaryCard.BorderRadius = 16;
            this.pnlConfirmedSummaryCard.FillColor = System.Drawing.Color.White;
            this.pnlConfirmedSummaryCard.Location = new System.Drawing.Point(0, 190);
            this.pnlConfirmedSummaryCard.Size = new System.Drawing.Size(500, 200);

            SetupConfirmedRow(this.lblConfirmedDate, 16);
            SetupConfirmedRow(this.lblConfirmedTime, 48);
            SetupConfirmedRow(this.lblConfirmedBabysitter, 80);
            this.lblConfirmedTotal.Location = new System.Drawing.Point(16, 130);
            this.lblConfirmedTotal.Size = new System.Drawing.Size(468, 26);
            this.lblConfirmedTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblConfirmedTotal.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.lblConfirmedTotal.BackColor = System.Drawing.Color.Transparent;

            this.pnlConfirmedSummaryCard.Controls.Add(this.lblConfirmedDate);
            this.pnlConfirmedSummaryCard.Controls.Add(this.lblConfirmedTime);
            this.pnlConfirmedSummaryCard.Controls.Add(this.lblConfirmedBabysitter);
            this.pnlConfirmedSummaryCard.Controls.Add(this.lblConfirmedTotal);

            this.btnBackToDashboard.BorderRadius = 10;
            this.btnBackToDashboard.BorderThickness = 0;
            this.btnBackToDashboard.ShadowDecoration.Enabled = false;
            this.btnBackToDashboard.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnBackToDashboard.ForeColor = System.Drawing.Color.White;
            this.btnBackToDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackToDashboard.Location = new System.Drawing.Point(0, 410);
            this.btnBackToDashboard.Size = new System.Drawing.Size(240, 48);
            this.btnBackToDashboard.Text = "Back to Dashboard";
            this.btnBackToDashboard.Click += new System.EventHandler(this.btnBackToDashboard_Click);

            this.btnNewBooking.BorderRadius = 10;
            this.btnNewBooking.BorderThickness = 0;
            this.btnNewBooking.ShadowDecoration.Enabled = false;
            this.btnNewBooking.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.btnNewBooking.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnNewBooking.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNewBooking.Location = new System.Drawing.Point(260, 410);
            this.btnNewBooking.Size = new System.Drawing.Size(240, 48);
            this.btnNewBooking.Text = "New Booking";
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);

            this.pnlConfirmationScreen.Controls.Add(this.pnlCheckCircle);
            this.pnlConfirmationScreen.Controls.Add(this.lblConfirmedTitle);
            this.pnlConfirmationScreen.Controls.Add(this.lblConfirmedMessage);
            this.pnlConfirmationScreen.Controls.Add(this.pnlConfirmedSummaryCard);
            this.pnlConfirmationScreen.Controls.Add(this.btnBackToDashboard);
            this.pnlConfirmationScreen.Controls.Add(this.btnNewBooking);

            //
            // pnlContent.Controls
            //
            this.pnlContent.Controls.Add(this.lblPageTitle);
            this.pnlContent.Controls.Add(this.lblPageSubtitle);
            this.pnlContent.Controls.Add(this.pnlStepCircle1);
            this.pnlContent.Controls.Add(this.lblStepCaption1);
            this.pnlContent.Controls.Add(this.pnlStepLine1);
            this.pnlContent.Controls.Add(this.pnlStepCircle2);
            this.pnlContent.Controls.Add(this.lblStepCaption2);
            this.pnlContent.Controls.Add(this.pnlStepLine2);
            this.pnlContent.Controls.Add(this.pnlStepCircle3);
            this.pnlContent.Controls.Add(this.lblStepCaption3);
            this.pnlContent.Controls.Add(this.pnlStepLine3);
            this.pnlContent.Controls.Add(this.pnlStepCircle4);
            this.pnlContent.Controls.Add(this.lblStepCaption4);
            this.pnlContent.Controls.Add(this.pnlStepDateTime);
            this.pnlContent.Controls.Add(this.pnlStepBabysitter);
            this.pnlContent.Controls.Add(this.pnlStepDetails);
            this.pnlContent.Controls.Add(this.pnlStepConfirm);
            this.pnlContent.Controls.Add(this.btnBack);
            this.pnlContent.Controls.Add(this.btnContinue);
            this.pnlContent.Controls.Add(this.pnlConfirmationScreen);

            //
            // BookingForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.pnlPageBackground);
            this.MinimumSize = new System.Drawing.Size(1246, 738);
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meraki - Book a Babysitter";
            this.Load += new System.EventHandler(this.BookingForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).EndInit();
            this.pnlConfirmedSummaryCard.ResumeLayout(false);
            this.pnlCheckCircle.ResumeLayout(false);
            this.pnlConfirmationScreen.ResumeLayout(false);
            this.pnlStepConfirm.ResumeLayout(false);
            this.pnlStepDetails.ResumeLayout(false);
            this.pnlStepBabysitter.ResumeLayout(false);
            this.pnlDurationCard.ResumeLayout(false);
            this.pnlTimeSlotsCard.ResumeLayout(false);
            this.pnlCalendarCard.ResumeLayout(false);
            this.pnlStepDateTime.ResumeLayout(false);
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

        private static void SetupStepCircle(Guna.UI2.WinForms.Guna2Panel circle, System.Windows.Forms.Label num,
            System.Windows.Forms.Label caption, int x, string number, string captionText, bool active)
        {
            circle.BorderRadius = 18;
            circle.FillColor = active ? System.Drawing.Color.FromArgb(232, 113, 74) : System.Drawing.Color.FromArgb(247, 245, 242);
            circle.Location = new System.Drawing.Point(x, 90);
            circle.Size = new System.Drawing.Size(36, 36);
            num.Dock = System.Windows.Forms.DockStyle.Fill;
            num.Text = number;
            num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            num.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            num.ForeColor = active ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(154, 136, 128);
            num.BackColor = System.Drawing.Color.Transparent;
            circle.Controls.Add(num);

            caption.Location = new System.Drawing.Point(x - 20, 130);
            caption.Size = new System.Drawing.Size(340, 20);
            caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            caption.Text = captionText;
            caption.Font = new System.Drawing.Font("Segoe UI", 8F, active ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            caption.ForeColor = active ? System.Drawing.Color.FromArgb(232, 113, 74) : System.Drawing.Color.FromArgb(154, 136, 128);
            caption.BackColor = System.Drawing.Color.Transparent;
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

        private static void SetupSummaryRow(System.Windows.Forms.Label label, int y)
        {
            label.Location = new System.Drawing.Point(0, y);
            label.Size = new System.Drawing.Size(700, 24);
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            label.BackColor = System.Drawing.Color.Transparent;
        }

        private static void SetupConfirmedRow(System.Windows.Forms.Label label, int y)
        {
            label.Location = new System.Drawing.Point(16, y);
            label.Size = new System.Drawing.Size(468, 24);
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            label.BackColor = System.Drawing.Color.Transparent;
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

        private Guna.UI2.WinForms.Guna2Panel pnlStepCircle1;
        private System.Windows.Forms.Label lblStepNum1;
        private System.Windows.Forms.Label lblStepCaption1;
        private Guna.UI2.WinForms.Guna2Panel pnlStepLine1;
        private Guna.UI2.WinForms.Guna2Panel pnlStepCircle2;
        private System.Windows.Forms.Label lblStepNum2;
        private System.Windows.Forms.Label lblStepCaption2;
        private Guna.UI2.WinForms.Guna2Panel pnlStepLine2;
        private Guna.UI2.WinForms.Guna2Panel pnlStepCircle3;
        private System.Windows.Forms.Label lblStepNum3;
        private System.Windows.Forms.Label lblStepCaption3;
        private Guna.UI2.WinForms.Guna2Panel pnlStepLine3;
        private Guna.UI2.WinForms.Guna2Panel pnlStepCircle4;
        private System.Windows.Forms.Label lblStepNum4;
        private System.Windows.Forms.Label lblStepCaption4;

        private System.Windows.Forms.Panel pnlStepDateTime;
        private Guna.UI2.WinForms.Guna2Panel pnlCalendarCard;
        private System.Windows.Forms.Label lblCalTitle;
        private Guna.UI2.WinForms.Guna2Button btnCalPrev;
        private System.Windows.Forms.Label lblCalMonthYear;
        private Guna.UI2.WinForms.Guna2Button btnCalNext;
        private System.Windows.Forms.TableLayoutPanel tlpBookingCalendar;
        private System.Windows.Forms.Label lblCalSun;
        private System.Windows.Forms.Label lblCalMon;
        private System.Windows.Forms.Label lblCalTue;
        private System.Windows.Forms.Label lblCalWed;
        private System.Windows.Forms.Label lblCalThu;
        private System.Windows.Forms.Label lblCalFri;
        private System.Windows.Forms.Label lblCalSat;
        private Guna.UI2.WinForms.Guna2Panel pnlTimeSlotsCard;
        private System.Windows.Forms.Label lblTimeSlotsTitle;
        private System.Windows.Forms.FlowLayoutPanel flpTimeSlots;
        private Guna.UI2.WinForms.Guna2Panel pnlDurationCard;
        private System.Windows.Forms.Label lblDurationTitle;
        private System.Windows.Forms.FlowLayoutPanel flpDurations;

        private System.Windows.Forms.Panel pnlStepBabysitter;
        private System.Windows.Forms.FlowLayoutPanel flpBabysitterSelect;

        private System.Windows.Forms.Panel pnlStepDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblChildCountCaption;
        private Guna.UI2.WinForms.Guna2Button btnDecChildren;
        private System.Windows.Forms.Label lblChildCount;
        private Guna.UI2.WinForms.Guna2Button btnIncChildren;
        private System.Windows.Forms.Label lblAddressCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbAddress;
        private System.Windows.Forms.Label lblNotesCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbNotes;

        private System.Windows.Forms.Panel pnlStepConfirm;
        private System.Windows.Forms.Label lblConfirmTitle;
        private System.Windows.Forms.Label lblSumDate;
        private System.Windows.Forms.Label lblSumTime;
        private System.Windows.Forms.Label lblSumBabysitter;
        private System.Windows.Forms.Label lblSumChildren;
        private System.Windows.Forms.Label lblSumAddress;
        private System.Windows.Forms.Label lblCostSitterLine;
        private System.Windows.Forms.Label lblCostServiceFee;
        private System.Windows.Forms.Label lblCostTotal;
        private System.Windows.Forms.Label lblPaymentNote;

        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnContinue;

        private Guna.UI2.WinForms.Guna2Panel pnlConfirmationScreen;
        private Guna.UI2.WinForms.Guna2Panel pnlCheckCircle;
        private System.Windows.Forms.Label lblCheckIcon;
        private System.Windows.Forms.Label lblConfirmedTitle;
        private System.Windows.Forms.Label lblConfirmedMessage;
        private Guna.UI2.WinForms.Guna2Panel pnlConfirmedSummaryCard;
        private System.Windows.Forms.Label lblConfirmedDate;
        private System.Windows.Forms.Label lblConfirmedTime;
        private System.Windows.Forms.Label lblConfirmedBabysitter;
        private System.Windows.Forms.Label lblConfirmedTotal;
        private Guna.UI2.WinForms.Guna2Button btnBackToDashboard;
        private Guna.UI2.WinForms.Guna2Button btnNewBooking;
    }
}
