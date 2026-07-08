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
            pnlStepCircle1 = new Guna.UI2.WinForms.Guna2Panel();
            lblStepNum1 = new Label();
            lblStepCaption1 = new Label();
            pnlStepLine1 = new Guna.UI2.WinForms.Guna2Panel();
            pnlStepCircle2 = new Guna.UI2.WinForms.Guna2Panel();
            lblStepNum2 = new Label();
            lblStepCaption2 = new Label();
            pnlStepLine2 = new Guna.UI2.WinForms.Guna2Panel();
            pnlStepCircle3 = new Guna.UI2.WinForms.Guna2Panel();
            lblStepNum3 = new Label();
            lblStepCaption3 = new Label();
            pnlStepLine3 = new Guna.UI2.WinForms.Guna2Panel();
            pnlStepCircle4 = new Guna.UI2.WinForms.Guna2Panel();
            lblStepNum4 = new Label();
            lblStepCaption4 = new Label();
            pnlStepDateTime = new Panel();
            pnlDateTimeCard = new Guna.UI2.WinForms.Guna2Panel();
            lblDateTimeTitle = new Label();
            lblMonthCaption = new Label();
            cbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            lblDayCaption = new Label();
            cbDay = new Guna.UI2.WinForms.Guna2ComboBox();
            lblYearCaption = new Label();
            cbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            lblStartTimeCaption = new Label();
            cbStartTime = new Guna.UI2.WinForms.Guna2ComboBox();
            lblDurationCaption = new Label();
            flpDurations = new FlowLayoutPanel();
            pnlStepBabysitter = new Panel();
            flpBabysitterSelect = new FlowLayoutPanel();
            pnlStepDetails = new Panel();
            pnlDetailsCard = new Guna.UI2.WinForms.Guna2Panel();
            lblDetailsTitle = new Label();
            lblChildCountCaption = new Label();
            btnDecChildren = new Guna.UI2.WinForms.Guna2Button();
            lblChildCount = new Label();
            btnIncChildren = new Guna.UI2.WinForms.Guna2Button();
            lblAddressCaption = new Label();
            tbAddress = new Guna.UI2.WinForms.Guna2TextBox();
            lblNotesCaption = new Label();
            tbNotes = new Guna.UI2.WinForms.Guna2TextBox();
            pnlStepConfirm = new Panel();
            pnlConfirmCard = new Guna.UI2.WinForms.Guna2Panel();
            lblConfirmTitle = new Label();
            lblSumDate = new Label();
            lblSumTime = new Label();
            lblSumBabysitter = new Label();
            lblSumChildren = new Label();
            lblSumAddress = new Label();
            lblCostSitterLine = new Label();
            lblCostServiceFee = new Label();
            lblCostTotal = new Label();
            lblPaymentNote = new Label();
            pnlBottomBar = new Guna.UI2.WinForms.Guna2Panel();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            btnContinue = new Guna.UI2.WinForms.Guna2Button();
            pnlConfirmationScreen = new Guna.UI2.WinForms.Guna2Panel();
            pnlCheckCircle = new Guna.UI2.WinForms.Guna2Panel();
            lblCheckIcon = new Label();
            lblConfirmedTitle = new Label();
            lblConfirmedMessage = new Label();
            pnlConfirmedSummaryCard = new Guna.UI2.WinForms.Guna2Panel();
            lblConfirmedDate = new Label();
            lblConfirmedTime = new Label();
            lblConfirmedBabysitter = new Label();
            lblConfirmedTotal = new Label();
            btnBackToDashboard = new Guna.UI2.WinForms.Guna2Button();
            btnNewBooking = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlStepCircle1.SuspendLayout();
            pnlStepCircle2.SuspendLayout();
            pnlStepCircle3.SuspendLayout();
            pnlStepCircle4.SuspendLayout();
            pnlStepDateTime.SuspendLayout();
            pnlDateTimeCard.SuspendLayout();
            pnlStepBabysitter.SuspendLayout();
            pnlStepDetails.SuspendLayout();
            pnlDetailsCard.SuspendLayout();
            pnlStepConfirm.SuspendLayout();
            pnlConfirmCard.SuspendLayout();
            pnlBottomBar.SuspendLayout();
            pnlConfirmationScreen.SuspendLayout();
            pnlCheckCircle.SuspendLayout();
            pnlConfirmedSummaryCard.SuspendLayout();
            SuspendLayout();
            //
            // pnlPageBackground
            //
            pnlPageBackground.Controls.Add(pnlBottomBar);
            pnlPageBackground.Controls.Add(pnlNavbar);
            pnlPageBackground.Controls.Add(pnlContent);
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
            btnNavFindBabysitter.FillColor = Color.Transparent;
            btnNavFindBabysitter.Font = new Font("Segoe UI", 8.5F);
            btnNavFindBabysitter.ForeColor = Color.FromArgb(154, 136, 128);
            btnNavFindBabysitter.HoverState.FillColor = Color.FromArgb(253, 238, 232);
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
            btnNavBookNow.FillColor = Color.FromArgb(253, 238, 232);
            btnNavBookNow.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNavBookNow.ForeColor = Color.FromArgb(232, 113, 74);
            btnNavBookNow.HoverState.FillColor = Color.FromArgb(250, 226, 216);
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
            // pnlBottomBar
            //
            pnlBottomBar.BackColor = Color.Transparent;
            pnlBottomBar.Controls.Add(btnBack);
            pnlBottomBar.Controls.Add(btnContinue);
            pnlBottomBar.Dock = DockStyle.Bottom;
            pnlBottomBar.FillColor = Color.White;
            pnlBottomBar.Location = new Point(0, 830);
            pnlBottomBar.Name = "pnlBottomBar";
            pnlBottomBar.Size = new Size(1500, 70);
            pnlBottomBar.TabIndex = 2;
            //
            // btnBack
            //
            btnBack.BackColor = Color.White;
            btnBack.BorderRadius = 10;
            btnBack.FillColor = Color.FromArgb(247, 245, 242);
            btnBack.Font = new Font("Segoe UI", 9.5F);
            btnBack.ForeColor = Color.FromArgb(154, 136, 128);
            btnBack.Location = new Point(30, 11);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 48);
            btnBack.TabIndex = 0;
            btnBack.Text = "< Back";
            btnBack.Visible = false;
            btnBack.Click += btnBack_Click;
            //
            // btnContinue
            //
            btnContinue.BackColor = Color.White;
            btnContinue.BorderRadius = 10;
            btnContinue.FillColor = Color.FromArgb(232, 113, 74);
            btnContinue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(214, 11);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(1256, 48);
            btnContinue.TabIndex = 1;
            btnContinue.Text = "Continue >";
            btnContinue.Click += btnContinue_Click;
            //
            // pnlContent
            //
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(pnlConfirmationScreen);
            pnlContent.Controls.Add(lblPageTitle);
            pnlContent.Controls.Add(lblPageSubtitle);
            pnlContent.Controls.Add(pnlStepCircle1);
            pnlContent.Controls.Add(lblStepCaption1);
            pnlContent.Controls.Add(pnlStepLine1);
            pnlContent.Controls.Add(pnlStepCircle2);
            pnlContent.Controls.Add(lblStepCaption2);
            pnlContent.Controls.Add(pnlStepLine2);
            pnlContent.Controls.Add(pnlStepCircle3);
            pnlContent.Controls.Add(lblStepCaption3);
            pnlContent.Controls.Add(pnlStepLine3);
            pnlContent.Controls.Add(pnlStepCircle4);
            pnlContent.Controls.Add(lblStepCaption4);
            pnlContent.Controls.Add(pnlStepDateTime);
            pnlContent.Controls.Add(pnlStepBabysitter);
            pnlContent.Controls.Add(pnlStepDetails);
            pnlContent.Controls.Add(pnlStepConfirm);
            pnlContent.FillColor = Color.FromArgb(253, 238, 232);
            pnlContent.FillColor2 = Color.FromArgb(225, 240, 239);
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1500, 750);
            pnlContent.TabIndex = 0;
            //
            // lblPageTitle
            //
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPageTitle.Location = new Point(30, 16);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(400, 30);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Book a Babysitter";
            //
            // lblPageSubtitle
            //
            lblPageSubtitle.BackColor = Color.Transparent;
            lblPageSubtitle.Font = new Font("Segoe UI", 9F);
            lblPageSubtitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblPageSubtitle.Location = new Point(30, 48);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(500, 22);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Complete the steps below to schedule your booking";
            //
            // pnlStepCircle1
            //
            pnlStepCircle1.BackColor = Color.Transparent;
            pnlStepCircle1.BorderRadius = 18;
            pnlStepCircle1.Controls.Add(lblStepNum1);
            pnlStepCircle1.FillColor = Color.FromArgb(232, 113, 74);
            pnlStepCircle1.Location = new Point(30, 84);
            pnlStepCircle1.Name = "pnlStepCircle1";
            pnlStepCircle1.Size = new Size(36, 36);
            pnlStepCircle1.TabIndex = 2;
            //
            // lblStepNum1
            //
            lblStepNum1.BackColor = Color.Transparent;
            lblStepNum1.Dock = DockStyle.Fill;
            lblStepNum1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStepNum1.ForeColor = Color.White;
            lblStepNum1.Location = new Point(0, 0);
            lblStepNum1.Name = "lblStepNum1";
            lblStepNum1.Size = new Size(36, 36);
            lblStepNum1.TabIndex = 0;
            lblStepNum1.Text = "1";
            lblStepNum1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStepCaption1
            //
            lblStepCaption1.BackColor = Color.Transparent;
            lblStepCaption1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStepCaption1.ForeColor = Color.FromArgb(232, 113, 74);
            lblStepCaption1.Location = new Point(74, 92);
            lblStepCaption1.Name = "lblStepCaption1";
            lblStepCaption1.Size = new Size(150, 20);
            lblStepCaption1.TabIndex = 3;
            lblStepCaption1.Text = "Select Date & Time";
            //
            // pnlStepLine1
            //
            pnlStepLine1.BackColor = Color.Transparent;
            pnlStepLine1.FillColor = Color.FromArgb(230, 224, 218);
            pnlStepLine1.Location = new Point(235, 100);
            pnlStepLine1.Name = "pnlStepLine1";
            pnlStepLine1.Size = new Size(145, 3);
            pnlStepLine1.TabIndex = 4;
            //
            // pnlStepCircle2
            //
            pnlStepCircle2.BackColor = Color.Transparent;
            pnlStepCircle2.BorderRadius = 18;
            pnlStepCircle2.Controls.Add(lblStepNum2);
            pnlStepCircle2.FillColor = Color.FromArgb(247, 245, 242);
            pnlStepCircle2.Location = new Point(390, 84);
            pnlStepCircle2.Name = "pnlStepCircle2";
            pnlStepCircle2.Size = new Size(36, 36);
            pnlStepCircle2.TabIndex = 5;
            //
            // lblStepNum2
            //
            lblStepNum2.BackColor = Color.Transparent;
            lblStepNum2.Dock = DockStyle.Fill;
            lblStepNum2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStepNum2.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepNum2.Location = new Point(0, 0);
            lblStepNum2.Name = "lblStepNum2";
            lblStepNum2.Size = new Size(36, 36);
            lblStepNum2.TabIndex = 0;
            lblStepNum2.Text = "2";
            lblStepNum2.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStepCaption2
            //
            lblStepCaption2.BackColor = Color.Transparent;
            lblStepCaption2.Font = new Font("Segoe UI", 8F);
            lblStepCaption2.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepCaption2.Location = new Point(434, 92);
            lblStepCaption2.Name = "lblStepCaption2";
            lblStepCaption2.Size = new Size(150, 20);
            lblStepCaption2.TabIndex = 6;
            lblStepCaption2.Text = "Choose Babysitter";
            //
            // pnlStepLine2
            //
            pnlStepLine2.BackColor = Color.Transparent;
            pnlStepLine2.FillColor = Color.FromArgb(230, 224, 218);
            pnlStepLine2.Location = new Point(595, 100);
            pnlStepLine2.Name = "pnlStepLine2";
            pnlStepLine2.Size = new Size(145, 3);
            pnlStepLine2.TabIndex = 7;
            //
            // pnlStepCircle3
            //
            pnlStepCircle3.BackColor = Color.Transparent;
            pnlStepCircle3.BorderRadius = 18;
            pnlStepCircle3.Controls.Add(lblStepNum3);
            pnlStepCircle3.FillColor = Color.FromArgb(247, 245, 242);
            pnlStepCircle3.Location = new Point(750, 84);
            pnlStepCircle3.Name = "pnlStepCircle3";
            pnlStepCircle3.Size = new Size(36, 36);
            pnlStepCircle3.TabIndex = 8;
            //
            // lblStepNum3
            //
            lblStepNum3.BackColor = Color.Transparent;
            lblStepNum3.Dock = DockStyle.Fill;
            lblStepNum3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStepNum3.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepNum3.Location = new Point(0, 0);
            lblStepNum3.Name = "lblStepNum3";
            lblStepNum3.Size = new Size(36, 36);
            lblStepNum3.TabIndex = 0;
            lblStepNum3.Text = "3";
            lblStepNum3.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStepCaption3
            //
            lblStepCaption3.BackColor = Color.Transparent;
            lblStepCaption3.Font = new Font("Segoe UI", 8F);
            lblStepCaption3.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepCaption3.Location = new Point(794, 92);
            lblStepCaption3.Name = "lblStepCaption3";
            lblStepCaption3.Size = new Size(150, 20);
            lblStepCaption3.TabIndex = 9;
            lblStepCaption3.Text = "Details";
            //
            // pnlStepLine3
            //
            pnlStepLine3.BackColor = Color.Transparent;
            pnlStepLine3.FillColor = Color.FromArgb(230, 224, 218);
            pnlStepLine3.Location = new Point(955, 100);
            pnlStepLine3.Name = "pnlStepLine3";
            pnlStepLine3.Size = new Size(145, 3);
            pnlStepLine3.TabIndex = 10;
            //
            // pnlStepCircle4
            //
            pnlStepCircle4.BackColor = Color.Transparent;
            pnlStepCircle4.BorderRadius = 18;
            pnlStepCircle4.Controls.Add(lblStepNum4);
            pnlStepCircle4.FillColor = Color.FromArgb(247, 245, 242);
            pnlStepCircle4.Location = new Point(1110, 84);
            pnlStepCircle4.Name = "pnlStepCircle4";
            pnlStepCircle4.Size = new Size(36, 36);
            pnlStepCircle4.TabIndex = 11;
            //
            // lblStepNum4
            //
            lblStepNum4.BackColor = Color.Transparent;
            lblStepNum4.Dock = DockStyle.Fill;
            lblStepNum4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStepNum4.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepNum4.Location = new Point(0, 0);
            lblStepNum4.Name = "lblStepNum4";
            lblStepNum4.Size = new Size(36, 36);
            lblStepNum4.TabIndex = 0;
            lblStepNum4.Text = "4";
            lblStepNum4.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblStepCaption4
            //
            lblStepCaption4.BackColor = Color.Transparent;
            lblStepCaption4.Font = new Font("Segoe UI", 8F);
            lblStepCaption4.ForeColor = Color.FromArgb(154, 136, 128);
            lblStepCaption4.Location = new Point(1154, 92);
            lblStepCaption4.Name = "lblStepCaption4";
            lblStepCaption4.Size = new Size(150, 20);
            lblStepCaption4.TabIndex = 12;
            lblStepCaption4.Text = "Confirm";
            //
            // pnlStepDateTime
            //
            pnlStepDateTime.BackColor = Color.Transparent;
            pnlStepDateTime.Controls.Add(pnlDateTimeCard);
            pnlStepDateTime.Location = new Point(30, 136);
            pnlStepDateTime.Name = "pnlStepDateTime";
            pnlStepDateTime.Size = new Size(1420, 610);
            pnlStepDateTime.TabIndex = 13;
            //
            // pnlDateTimeCard
            //
            pnlDateTimeCard.BackColor = Color.Transparent;
            pnlDateTimeCard.BorderRadius = 16;
            pnlDateTimeCard.BorderThickness = 1;
            pnlDateTimeCard.BorderColor = Color.FromArgb(238, 230, 224);
            pnlDateTimeCard.Controls.Add(lblDateTimeTitle);
            pnlDateTimeCard.Controls.Add(lblMonthCaption);
            pnlDateTimeCard.Controls.Add(cbMonth);
            pnlDateTimeCard.Controls.Add(lblDayCaption);
            pnlDateTimeCard.Controls.Add(cbDay);
            pnlDateTimeCard.Controls.Add(lblYearCaption);
            pnlDateTimeCard.Controls.Add(cbYear);
            pnlDateTimeCard.Controls.Add(lblStartTimeCaption);
            pnlDateTimeCard.Controls.Add(cbStartTime);
            pnlDateTimeCard.Controls.Add(lblDurationCaption);
            pnlDateTimeCard.Controls.Add(flpDurations);
            pnlDateTimeCard.FillColor = Color.White;
            pnlDateTimeCard.Location = new Point(0, 0);
            pnlDateTimeCard.Name = "pnlDateTimeCard";
            pnlDateTimeCard.Size = new Size(900, 470);
            pnlDateTimeCard.TabIndex = 0;
            //
            // lblDateTimeTitle
            //
            lblDateTimeTitle.BackColor = Color.Transparent;
            lblDateTimeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDateTimeTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblDateTimeTitle.Location = new Point(24, 20);
            lblDateTimeTitle.Name = "lblDateTimeTitle";
            lblDateTimeTitle.Size = new Size(400, 30);
            lblDateTimeTitle.TabIndex = 0;
            lblDateTimeTitle.Text = "Select Date && Time";
            //
            // lblMonthCaption
            //
            lblMonthCaption.BackColor = Color.Transparent;
            lblMonthCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMonthCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblMonthCaption.Location = new Point(24, 72);
            lblMonthCaption.Name = "lblMonthCaption";
            lblMonthCaption.Size = new Size(200, 22);
            lblMonthCaption.TabIndex = 1;
            lblMonthCaption.Text = "Month *";
            //
            // cbMonth
            //
            cbMonth.BackColor = Color.Transparent;
            cbMonth.BorderRadius = 8;
            cbMonth.DrawMode = DrawMode.OwnerDrawFixed;
            cbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonth.FillColor = Color.FromArgb(247, 245, 242);
            cbMonth.FocusedColor = Color.FromArgb(232, 113, 74);
            cbMonth.Font = new Font("Segoe UI", 9.5F);
            cbMonth.ForeColor = Color.FromArgb(60, 50, 45);
            cbMonth.ItemHeight = 34;
            cbMonth.Location = new Point(24, 96);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(266, 40);
            cbMonth.TabIndex = 2;
            cbMonth.SelectedIndexChanged += cbDate_Changed;
            //
            // lblDayCaption
            //
            lblDayCaption.BackColor = Color.Transparent;
            lblDayCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblDayCaption.Location = new Point(316, 72);
            lblDayCaption.Name = "lblDayCaption";
            lblDayCaption.Size = new Size(200, 22);
            lblDayCaption.TabIndex = 3;
            lblDayCaption.Text = "Day *";
            //
            // cbDay
            //
            cbDay.BackColor = Color.Transparent;
            cbDay.BorderRadius = 8;
            cbDay.DrawMode = DrawMode.OwnerDrawFixed;
            cbDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDay.FillColor = Color.FromArgb(247, 245, 242);
            cbDay.FocusedColor = Color.FromArgb(232, 113, 74);
            cbDay.Font = new Font("Segoe UI", 9.5F);
            cbDay.ForeColor = Color.FromArgb(60, 50, 45);
            cbDay.ItemHeight = 34;
            cbDay.Location = new Point(316, 96);
            cbDay.Name = "cbDay";
            cbDay.Size = new Size(266, 40);
            cbDay.TabIndex = 4;
            cbDay.SelectedIndexChanged += cbDate_Changed;
            //
            // lblYearCaption
            //
            lblYearCaption.BackColor = Color.Transparent;
            lblYearCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblYearCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblYearCaption.Location = new Point(608, 72);
            lblYearCaption.Name = "lblYearCaption";
            lblYearCaption.Size = new Size(200, 22);
            lblYearCaption.TabIndex = 5;
            lblYearCaption.Text = "Year *";
            //
            // cbYear
            //
            cbYear.BackColor = Color.Transparent;
            cbYear.BorderRadius = 8;
            cbYear.DrawMode = DrawMode.OwnerDrawFixed;
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYear.FillColor = Color.FromArgb(247, 245, 242);
            cbYear.FocusedColor = Color.FromArgb(232, 113, 74);
            cbYear.Font = new Font("Segoe UI", 9.5F);
            cbYear.ForeColor = Color.FromArgb(60, 50, 45);
            cbYear.ItemHeight = 34;
            cbYear.Location = new Point(608, 96);
            cbYear.Name = "cbYear";
            cbYear.Size = new Size(266, 40);
            cbYear.TabIndex = 6;
            cbYear.SelectedIndexChanged += cbDate_Changed;
            //
            // lblStartTimeCaption
            //
            lblStartTimeCaption.BackColor = Color.Transparent;
            lblStartTimeCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStartTimeCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblStartTimeCaption.Location = new Point(24, 160);
            lblStartTimeCaption.Name = "lblStartTimeCaption";
            lblStartTimeCaption.Size = new Size(200, 22);
            lblStartTimeCaption.TabIndex = 7;
            lblStartTimeCaption.Text = "Start Time *";
            //
            // cbStartTime
            //
            cbStartTime.BackColor = Color.Transparent;
            cbStartTime.BorderRadius = 8;
            cbStartTime.DrawMode = DrawMode.OwnerDrawFixed;
            cbStartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStartTime.FillColor = Color.FromArgb(247, 245, 242);
            cbStartTime.FocusedColor = Color.FromArgb(232, 113, 74);
            cbStartTime.Font = new Font("Segoe UI", 9.5F);
            cbStartTime.ForeColor = Color.FromArgb(60, 50, 45);
            cbStartTime.ItemHeight = 34;
            cbStartTime.Location = new Point(24, 184);
            cbStartTime.Name = "cbStartTime";
            cbStartTime.Size = new Size(850, 40);
            cbStartTime.TabIndex = 8;
            cbStartTime.SelectedIndexChanged += cbStartTime_Changed;
            //
            // lblDurationCaption
            //
            lblDurationCaption.BackColor = Color.Transparent;
            lblDurationCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDurationCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblDurationCaption.Location = new Point(24, 248);
            lblDurationCaption.Name = "lblDurationCaption";
            lblDurationCaption.Size = new Size(200, 22);
            lblDurationCaption.TabIndex = 9;
            lblDurationCaption.Text = "Duration *";
            //
            // flpDurations
            //
            flpDurations.BackColor = Color.Transparent;
            flpDurations.Location = new Point(24, 274);
            flpDurations.Name = "flpDurations";
            flpDurations.Size = new Size(850, 170);
            flpDurations.TabIndex = 10;
            //
            // pnlStepBabysitter
            //
            pnlStepBabysitter.BackColor = Color.Transparent;
            pnlStepBabysitter.Controls.Add(flpBabysitterSelect);
            pnlStepBabysitter.Location = new Point(30, 140);
            pnlStepBabysitter.Name = "pnlStepBabysitter";
            pnlStepBabysitter.Size = new Size(1420, 600);
            pnlStepBabysitter.TabIndex = 14;
            pnlStepBabysitter.Visible = false;
            //
            // flpBabysitterSelect
            //
            flpBabysitterSelect.AutoScroll = true;
            flpBabysitterSelect.BackColor = Color.Transparent;
            flpBabysitterSelect.FlowDirection = FlowDirection.TopDown;
            flpBabysitterSelect.Location = new Point(0, 0);
            flpBabysitterSelect.Name = "flpBabysitterSelect";
            flpBabysitterSelect.Size = new Size(900, 600);
            flpBabysitterSelect.TabIndex = 0;
            flpBabysitterSelect.WrapContents = false;
            //
            // pnlStepDetails
            //
            pnlStepDetails.BackColor = Color.Transparent;
            pnlStepDetails.Controls.Add(pnlDetailsCard);
            pnlStepDetails.Location = new Point(30, 140);
            pnlStepDetails.Name = "pnlStepDetails";
            pnlStepDetails.Size = new Size(1420, 480);
            pnlStepDetails.TabIndex = 15;
            pnlStepDetails.Visible = false;
            //
            // pnlDetailsCard
            //
            pnlDetailsCard.BackColor = Color.Transparent;
            pnlDetailsCard.BorderRadius = 16;
            pnlDetailsCard.Controls.Add(lblDetailsTitle);
            pnlDetailsCard.Controls.Add(lblChildCountCaption);
            pnlDetailsCard.Controls.Add(btnDecChildren);
            pnlDetailsCard.Controls.Add(lblChildCount);
            pnlDetailsCard.Controls.Add(btnIncChildren);
            pnlDetailsCard.Controls.Add(lblAddressCaption);
            pnlDetailsCard.Controls.Add(tbAddress);
            pnlDetailsCard.Controls.Add(lblNotesCaption);
            pnlDetailsCard.Controls.Add(tbNotes);
            pnlDetailsCard.FillColor = Color.White;
            pnlDetailsCard.Location = new Point(0, 0);
            pnlDetailsCard.Name = "pnlDetailsCard";
            pnlDetailsCard.Size = new Size(740, 440);
            pnlDetailsCard.TabIndex = 0;
            //
            // lblDetailsTitle
            //
            lblDetailsTitle.BackColor = Color.Transparent;
            lblDetailsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblDetailsTitle.Location = new Point(20, 16);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(300, 26);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Booking Details";
            //
            // lblChildCountCaption
            //
            lblChildCountCaption.BackColor = Color.Transparent;
            lblChildCountCaption.Font = new Font("Segoe UI", 9F);
            lblChildCountCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblChildCountCaption.Location = new Point(20, 58);
            lblChildCountCaption.Name = "lblChildCountCaption";
            lblChildCountCaption.Size = new Size(260, 22);
            lblChildCountCaption.TabIndex = 1;
            lblChildCountCaption.Text = "Number of Children";
            //
            // btnDecChildren
            //
            btnDecChildren.BackColor = Color.White;
            btnDecChildren.BorderRadius = 10;
            btnDecChildren.FillColor = Color.FromArgb(253, 238, 232);
            btnDecChildren.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDecChildren.ForeColor = Color.FromArgb(232, 113, 74);
            btnDecChildren.Location = new Point(20, 86);
            btnDecChildren.Name = "btnDecChildren";
            btnDecChildren.Size = new Size(44, 40);
            btnDecChildren.TabIndex = 2;
            btnDecChildren.Text = "-";
            btnDecChildren.Click += btnDecChildren_Click;
            //
            // lblChildCount
            //
            lblChildCount.BackColor = Color.Transparent;
            lblChildCount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblChildCount.ForeColor = Color.FromArgb(60, 50, 45);
            lblChildCount.Location = new Point(74, 86);
            lblChildCount.Name = "lblChildCount";
            lblChildCount.Size = new Size(50, 40);
            lblChildCount.TabIndex = 3;
            lblChildCount.Text = "1";
            lblChildCount.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnIncChildren
            //
            btnIncChildren.BackColor = Color.White;
            btnIncChildren.BorderRadius = 10;
            btnIncChildren.FillColor = Color.FromArgb(253, 238, 232);
            btnIncChildren.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIncChildren.ForeColor = Color.FromArgb(232, 113, 74);
            btnIncChildren.Location = new Point(134, 86);
            btnIncChildren.Name = "btnIncChildren";
            btnIncChildren.Size = new Size(44, 40);
            btnIncChildren.TabIndex = 4;
            btnIncChildren.Text = "+";
            btnIncChildren.Click += btnIncChildren_Click;
            //
            // lblAddressCaption
            //
            lblAddressCaption.BackColor = Color.Transparent;
            lblAddressCaption.Font = new Font("Segoe UI", 9F);
            lblAddressCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblAddressCaption.Location = new Point(20, 152);
            lblAddressCaption.Name = "lblAddressCaption";
            lblAddressCaption.Size = new Size(260, 22);
            lblAddressCaption.TabIndex = 5;
            lblAddressCaption.Text = "Address";
            //
            // tbAddress
            //
            tbAddress.BorderRadius = 10;
            tbAddress.DefaultText = "";
            tbAddress.FillColor = Color.FromArgb(247, 245, 242);
            tbAddress.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbAddress.Font = new Font("Segoe UI", 9F);
            tbAddress.Location = new Point(20, 178);
            tbAddress.Name = "tbAddress";
            tbAddress.PlaceholderText = "123 Main St, City, State";
            tbAddress.SelectedText = "";
            tbAddress.Size = new Size(700, 44);
            tbAddress.TabIndex = 6;
            //
            // lblNotesCaption
            //
            lblNotesCaption.BackColor = Color.Transparent;
            lblNotesCaption.Font = new Font("Segoe UI", 9F);
            lblNotesCaption.ForeColor = Color.FromArgb(154, 136, 128);
            lblNotesCaption.Location = new Point(20, 244);
            lblNotesCaption.Name = "lblNotesCaption";
            lblNotesCaption.Size = new Size(400, 22);
            lblNotesCaption.TabIndex = 7;
            lblNotesCaption.Text = "Special Instructions (optional)";
            //
            // tbNotes
            //
            tbNotes.BorderRadius = 10;
            tbNotes.DefaultText = "";
            tbNotes.FillColor = Color.FromArgb(247, 245, 242);
            tbNotes.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbNotes.Font = new Font("Segoe UI", 9F);
            tbNotes.Location = new Point(20, 270);
            tbNotes.Multiline = true;
            tbNotes.Name = "tbNotes";
            tbNotes.PlaceholderText = "Allergies, bedtime routines, emergency contacts...";
            tbNotes.SelectedText = "";
            tbNotes.Size = new Size(700, 140);
            tbNotes.TabIndex = 8;
            //
            // pnlStepConfirm
            //
            pnlStepConfirm.BackColor = Color.Transparent;
            pnlStepConfirm.Controls.Add(pnlConfirmCard);
            pnlStepConfirm.Location = new Point(30, 140);
            pnlStepConfirm.Name = "pnlStepConfirm";
            pnlStepConfirm.Size = new Size(1420, 500);
            pnlStepConfirm.TabIndex = 16;
            pnlStepConfirm.Visible = false;
            //
            // pnlConfirmCard
            //
            pnlConfirmCard.BackColor = Color.Transparent;
            pnlConfirmCard.BorderRadius = 16;
            pnlConfirmCard.Controls.Add(lblConfirmTitle);
            pnlConfirmCard.Controls.Add(lblSumDate);
            pnlConfirmCard.Controls.Add(lblSumTime);
            pnlConfirmCard.Controls.Add(lblSumBabysitter);
            pnlConfirmCard.Controls.Add(lblSumChildren);
            pnlConfirmCard.Controls.Add(lblSumAddress);
            pnlConfirmCard.Controls.Add(lblCostSitterLine);
            pnlConfirmCard.Controls.Add(lblCostServiceFee);
            pnlConfirmCard.Controls.Add(lblCostTotal);
            pnlConfirmCard.Controls.Add(lblPaymentNote);
            pnlConfirmCard.FillColor = Color.White;
            pnlConfirmCard.Location = new Point(0, 0);
            pnlConfirmCard.Name = "pnlConfirmCard";
            pnlConfirmCard.Size = new Size(740, 460);
            pnlConfirmCard.TabIndex = 0;
            //
            // lblConfirmTitle
            //
            lblConfirmTitle.BackColor = Color.Transparent;
            lblConfirmTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConfirmTitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblConfirmTitle.Location = new Point(20, 16);
            lblConfirmTitle.Name = "lblConfirmTitle";
            lblConfirmTitle.Size = new Size(300, 26);
            lblConfirmTitle.TabIndex = 0;
            lblConfirmTitle.Text = "Booking Summary";
            //
            // lblSumDate
            //
            lblSumDate.BackColor = Color.Transparent;
            lblSumDate.Font = new Font("Segoe UI", 9F);
            lblSumDate.ForeColor = Color.FromArgb(60, 50, 45);
            lblSumDate.Location = new Point(20, 56);
            lblSumDate.Name = "lblSumDate";
            lblSumDate.Size = new Size(700, 24);
            lblSumDate.TabIndex = 1;
            //
            // lblSumTime
            //
            lblSumTime.BackColor = Color.Transparent;
            lblSumTime.Font = new Font("Segoe UI", 9F);
            lblSumTime.ForeColor = Color.FromArgb(60, 50, 45);
            lblSumTime.Location = new Point(20, 84);
            lblSumTime.Name = "lblSumTime";
            lblSumTime.Size = new Size(700, 24);
            lblSumTime.TabIndex = 2;
            //
            // lblSumBabysitter
            //
            lblSumBabysitter.BackColor = Color.Transparent;
            lblSumBabysitter.Font = new Font("Segoe UI", 9F);
            lblSumBabysitter.ForeColor = Color.FromArgb(60, 50, 45);
            lblSumBabysitter.Location = new Point(20, 112);
            lblSumBabysitter.Name = "lblSumBabysitter";
            lblSumBabysitter.Size = new Size(700, 24);
            lblSumBabysitter.TabIndex = 3;
            //
            // lblSumChildren
            //
            lblSumChildren.BackColor = Color.Transparent;
            lblSumChildren.Font = new Font("Segoe UI", 9F);
            lblSumChildren.ForeColor = Color.FromArgb(60, 50, 45);
            lblSumChildren.Location = new Point(20, 140);
            lblSumChildren.Name = "lblSumChildren";
            lblSumChildren.Size = new Size(700, 24);
            lblSumChildren.TabIndex = 4;
            //
            // lblSumAddress
            //
            lblSumAddress.BackColor = Color.Transparent;
            lblSumAddress.Font = new Font("Segoe UI", 9F);
            lblSumAddress.ForeColor = Color.FromArgb(60, 50, 45);
            lblSumAddress.Location = new Point(20, 168);
            lblSumAddress.Name = "lblSumAddress";
            lblSumAddress.Size = new Size(700, 24);
            lblSumAddress.TabIndex = 5;
            //
            // lblCostSitterLine
            //
            lblCostSitterLine.BackColor = Color.Transparent;
            lblCostSitterLine.Font = new Font("Segoe UI", 9F);
            lblCostSitterLine.ForeColor = Color.FromArgb(60, 50, 45);
            lblCostSitterLine.Location = new Point(20, 222);
            lblCostSitterLine.Name = "lblCostSitterLine";
            lblCostSitterLine.Size = new Size(700, 24);
            lblCostSitterLine.TabIndex = 6;
            //
            // lblCostServiceFee
            //
            lblCostServiceFee.BackColor = Color.Transparent;
            lblCostServiceFee.Font = new Font("Segoe UI", 9F);
            lblCostServiceFee.ForeColor = Color.FromArgb(60, 50, 45);
            lblCostServiceFee.Location = new Point(20, 248);
            lblCostServiceFee.Name = "lblCostServiceFee";
            lblCostServiceFee.Size = new Size(700, 24);
            lblCostServiceFee.TabIndex = 7;
            //
            // lblCostTotal
            //
            lblCostTotal.BackColor = Color.Transparent;
            lblCostTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCostTotal.ForeColor = Color.FromArgb(232, 113, 74);
            lblCostTotal.Location = new Point(20, 282);
            lblCostTotal.Name = "lblCostTotal";
            lblCostTotal.Size = new Size(700, 26);
            lblCostTotal.TabIndex = 8;
            //
            // lblPaymentNote
            //
            lblPaymentNote.BackColor = Color.FromArgb(253, 238, 232);
            lblPaymentNote.Font = new Font("Segoe UI", 8.5F);
            lblPaymentNote.ForeColor = Color.FromArgb(154, 136, 128);
            lblPaymentNote.Location = new Point(20, 330);
            lblPaymentNote.Name = "lblPaymentNote";
            lblPaymentNote.Size = new Size(700, 40);
            lblPaymentNote.TabIndex = 9;
            lblPaymentNote.Text = "  Payment will be processed after the babysitter confirms the booking.";
            lblPaymentNote.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlConfirmationScreen
            //
            pnlConfirmationScreen.BackColor = Color.Transparent;
            pnlConfirmationScreen.BorderRadius = 16;
            pnlConfirmationScreen.Controls.Add(pnlCheckCircle);
            pnlConfirmationScreen.Controls.Add(lblConfirmedTitle);
            pnlConfirmationScreen.Controls.Add(lblConfirmedMessage);
            pnlConfirmationScreen.Controls.Add(pnlConfirmedSummaryCard);
            pnlConfirmationScreen.Controls.Add(btnBackToDashboard);
            pnlConfirmationScreen.Controls.Add(btnNewBooking);
            pnlConfirmationScreen.FillColor = Color.White;
            pnlConfirmationScreen.Location = new Point(450, 60);
            pnlConfirmationScreen.Name = "pnlConfirmationScreen";
            pnlConfirmationScreen.Size = new Size(500, 520);
            pnlConfirmationScreen.TabIndex = 17;
            pnlConfirmationScreen.Visible = false;
            //
            // pnlCheckCircle
            //
            pnlCheckCircle.BackColor = Color.White;
            pnlCheckCircle.BorderRadius = 40;
            pnlCheckCircle.Controls.Add(lblCheckIcon);
            pnlCheckCircle.FillColor = Color.FromArgb(222, 245, 244);
            pnlCheckCircle.Location = new Point(210, 30);
            pnlCheckCircle.Name = "pnlCheckCircle";
            pnlCheckCircle.Size = new Size(80, 80);
            pnlCheckCircle.TabIndex = 0;
            //
            // lblCheckIcon
            //
            lblCheckIcon.BackColor = Color.Transparent;
            lblCheckIcon.Dock = DockStyle.Fill;
            lblCheckIcon.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblCheckIcon.ForeColor = Color.FromArgb(94, 200, 196);
            lblCheckIcon.Location = new Point(0, 0);
            lblCheckIcon.Name = "lblCheckIcon";
            lblCheckIcon.Size = new Size(80, 80);
            lblCheckIcon.TabIndex = 0;
            lblCheckIcon.Text = "✓";
            lblCheckIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblConfirmedTitle
            //
            lblConfirmedTitle.BackColor = Color.Transparent;
            lblConfirmedTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblConfirmedTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblConfirmedTitle.Location = new Point(0, 126);
            lblConfirmedTitle.Name = "lblConfirmedTitle";
            lblConfirmedTitle.Size = new Size(500, 30);
            lblConfirmedTitle.TabIndex = 1;
            lblConfirmedTitle.Text = "Booking Confirmed!";
            lblConfirmedTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblConfirmedMessage
            //
            lblConfirmedMessage.BackColor = Color.Transparent;
            lblConfirmedMessage.Font = new Font("Segoe UI", 9F);
            lblConfirmedMessage.ForeColor = Color.FromArgb(154, 136, 128);
            lblConfirmedMessage.Location = new Point(20, 162);
            lblConfirmedMessage.Name = "lblConfirmedMessage";
            lblConfirmedMessage.Size = new Size(460, 44);
            lblConfirmedMessage.TabIndex = 2;
            lblConfirmedMessage.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlConfirmedSummaryCard
            //
            pnlConfirmedSummaryCard.BackColor = Color.White;
            pnlConfirmedSummaryCard.BorderRadius = 12;
            pnlConfirmedSummaryCard.Controls.Add(lblConfirmedDate);
            pnlConfirmedSummaryCard.Controls.Add(lblConfirmedTime);
            pnlConfirmedSummaryCard.Controls.Add(lblConfirmedBabysitter);
            pnlConfirmedSummaryCard.Controls.Add(lblConfirmedTotal);
            pnlConfirmedSummaryCard.FillColor = Color.FromArgb(247, 245, 242);
            pnlConfirmedSummaryCard.Location = new Point(30, 226);
            pnlConfirmedSummaryCard.Name = "pnlConfirmedSummaryCard";
            pnlConfirmedSummaryCard.Size = new Size(440, 170);
            pnlConfirmedSummaryCard.TabIndex = 3;
            //
            // lblConfirmedDate
            //
            lblConfirmedDate.BackColor = Color.Transparent;
            lblConfirmedDate.Font = new Font("Segoe UI", 9F);
            lblConfirmedDate.ForeColor = Color.FromArgb(60, 50, 45);
            lblConfirmedDate.Location = new Point(16, 16);
            lblConfirmedDate.Name = "lblConfirmedDate";
            lblConfirmedDate.Size = new Size(408, 24);
            lblConfirmedDate.TabIndex = 0;
            //
            // lblConfirmedTime
            //
            lblConfirmedTime.BackColor = Color.Transparent;
            lblConfirmedTime.Font = new Font("Segoe UI", 9F);
            lblConfirmedTime.ForeColor = Color.FromArgb(60, 50, 45);
            lblConfirmedTime.Location = new Point(16, 48);
            lblConfirmedTime.Name = "lblConfirmedTime";
            lblConfirmedTime.Size = new Size(408, 24);
            lblConfirmedTime.TabIndex = 1;
            //
            // lblConfirmedBabysitter
            //
            lblConfirmedBabysitter.BackColor = Color.Transparent;
            lblConfirmedBabysitter.Font = new Font("Segoe UI", 9F);
            lblConfirmedBabysitter.ForeColor = Color.FromArgb(60, 50, 45);
            lblConfirmedBabysitter.Location = new Point(16, 80);
            lblConfirmedBabysitter.Name = "lblConfirmedBabysitter";
            lblConfirmedBabysitter.Size = new Size(408, 24);
            lblConfirmedBabysitter.TabIndex = 2;
            //
            // lblConfirmedTotal
            //
            lblConfirmedTotal.BackColor = Color.Transparent;
            lblConfirmedTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConfirmedTotal.ForeColor = Color.FromArgb(232, 113, 74);
            lblConfirmedTotal.Location = new Point(16, 122);
            lblConfirmedTotal.Name = "lblConfirmedTotal";
            lblConfirmedTotal.Size = new Size(408, 26);
            lblConfirmedTotal.TabIndex = 3;
            //
            // btnBackToDashboard
            //
            btnBackToDashboard.BackColor = Color.White;
            btnBackToDashboard.BorderRadius = 10;
            btnBackToDashboard.FillColor = Color.FromArgb(232, 113, 74);
            btnBackToDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBackToDashboard.ForeColor = Color.White;
            btnBackToDashboard.Location = new Point(30, 420);
            btnBackToDashboard.Name = "btnBackToDashboard";
            btnBackToDashboard.Size = new Size(210, 48);
            btnBackToDashboard.TabIndex = 4;
            btnBackToDashboard.Text = "Back to Dashboard";
            btnBackToDashboard.Click += btnBackToDashboard_Click;
            //
            // btnNewBooking
            //
            btnNewBooking.BackColor = Color.White;
            btnNewBooking.BorderRadius = 10;
            btnNewBooking.FillColor = Color.FromArgb(247, 245, 242);
            btnNewBooking.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNewBooking.ForeColor = Color.FromArgb(154, 136, 128);
            btnNewBooking.Location = new Point(260, 420);
            btnNewBooking.Name = "btnNewBooking";
            btnNewBooking.Size = new Size(210, 48);
            btnNewBooking.TabIndex = 5;
            btnNewBooking.Text = "New Booking";
            btnNewBooking.Click += btnNewBooking_Click;
            //
            // BookingForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "BookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - Book a Babysitter";
            Load += BookingForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            pnlConfirmedSummaryCard.ResumeLayout(false);
            pnlCheckCircle.ResumeLayout(false);
            pnlConfirmationScreen.ResumeLayout(false);
            pnlBottomBar.ResumeLayout(false);
            pnlConfirmCard.ResumeLayout(false);
            pnlStepConfirm.ResumeLayout(false);
            pnlDetailsCard.ResumeLayout(false);
            pnlStepDetails.ResumeLayout(false);
            pnlStepBabysitter.ResumeLayout(false);
            pnlDateTimeCard.ResumeLayout(false);
            pnlStepDateTime.ResumeLayout(false);
            pnlStepCircle4.ResumeLayout(false);
            pnlStepCircle3.ResumeLayout(false);
            pnlStepCircle2.ResumeLayout(false);
            pnlStepCircle1.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Panel pnlDateTimeCard;
        private System.Windows.Forms.Label lblDateTimeTitle;
        private System.Windows.Forms.Label lblMonthCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonth;
        private System.Windows.Forms.Label lblDayCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbDay;
        private System.Windows.Forms.Label lblYearCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbYear;
        private System.Windows.Forms.Label lblStartTimeCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbStartTime;
        private System.Windows.Forms.Label lblDurationCaption;
        private System.Windows.Forms.FlowLayoutPanel flpDurations;
        private System.Windows.Forms.Panel pnlStepBabysitter;
        private System.Windows.Forms.FlowLayoutPanel flpBabysitterSelect;
        private System.Windows.Forms.Panel pnlStepDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlDetailsCard;
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
        private Guna.UI2.WinForms.Guna2Panel pnlConfirmCard;
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
        private Guna.UI2.WinForms.Guna2Panel pnlBottomBar;
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
