namespace Meraki_Project
{
    partial class AdminDashboardForm
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

            // ===== Top navbar (logo + Logout only) =====
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.picNavLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblNavBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();

            // ===== Sidebar =====
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.btnSidebarOverview = new Guna.UI2.WinForms.Guna2Button();
            this.btnSidebarUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnSidebarBookings = new Guna.UI2.WinForms.Guna2Button();
            this.btnSidebarReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnSidebarSettings = new Guna.UI2.WinForms.Guna2Button();

            // ===== Main content =====
            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();

            // ----- KPI cards -----
            this.pnlKpiParents = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpiParentsIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiParentsIcon = new System.Windows.Forms.Label();
            this.lblKpiParentsValue = new System.Windows.Forms.Label();
            this.lblKpiParentsLabel = new System.Windows.Forms.Label();
            this.pnlKpiBabysitters = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpiBabysittersIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiBabysittersIcon = new System.Windows.Forms.Label();
            this.lblKpiBabysittersValue = new System.Windows.Forms.Label();
            this.lblKpiBabysittersLabel = new System.Windows.Forms.Label();
            this.pnlKpiBookings = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpiBookingsIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiBookingsIcon = new System.Windows.Forms.Label();
            this.lblKpiBookingsValue = new System.Windows.Forms.Label();
            this.lblKpiBookingsLabel = new System.Windows.Forms.Label();
            this.pnlKpiRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpiRevenueIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiRevenueIcon = new System.Windows.Forms.Label();
            this.lblKpiRevenueValue = new System.Windows.Forms.Label();
            this.lblKpiRevenueLabel = new System.Windows.Forms.Label();

            // ----- Chart placeholders (visual only - real charting wired up later) -----
            this.pnlBookingsChart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBookingsChartTitle = new System.Windows.Forms.Label();
            this.barJan = new Guna.UI2.WinForms.Guna2Panel();
            this.barFeb = new Guna.UI2.WinForms.Guna2Panel();
            this.barMar = new Guna.UI2.WinForms.Guna2Panel();
            this.barApr = new Guna.UI2.WinForms.Guna2Panel();
            this.barMay = new Guna.UI2.WinForms.Guna2Panel();
            this.barJun = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBarJan = new System.Windows.Forms.Label();
            this.lblBarFeb = new System.Windows.Forms.Label();
            this.lblBarMar = new System.Windows.Forms.Label();
            this.lblBarApr = new System.Windows.Forms.Label();
            this.lblBarMay = new System.Windows.Forms.Label();
            this.lblBarJun = new System.Windows.Forms.Label();
            this.pnlRevenueChart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRevenueChartTitle = new System.Windows.Forms.Label();
            this.revJan = new Guna.UI2.WinForms.Guna2Panel();
            this.revFeb = new Guna.UI2.WinForms.Guna2Panel();
            this.revMar = new Guna.UI2.WinForms.Guna2Panel();
            this.revApr = new Guna.UI2.WinForms.Guna2Panel();
            this.revMay = new Guna.UI2.WinForms.Guna2Panel();
            this.revJun = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRevJan = new System.Windows.Forms.Label();
            this.lblRevFeb = new System.Windows.Forms.Label();
            this.lblRevMar = new System.Windows.Forms.Label();
            this.lblRevApr = new System.Windows.Forms.Label();
            this.lblRevMay = new System.Windows.Forms.Label();
            this.lblRevJun = new System.Windows.Forms.Label();

            // ----- User management table -----
            this.pnlUserTableCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserTableTitle = new System.Windows.Forms.Label();
            this.tbSearchUsers = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJoined = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlPageBackground.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlKpiParents.SuspendLayout();
            this.pnlKpiBabysitters.SuspendLayout();
            this.pnlKpiBookings.SuspendLayout();
            this.pnlKpiRevenue.SuspendLayout();
            this.pnlUserTableCard.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlPageBackground
            // 
            this.pnlPageBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageBackground.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlPageBackground.FillColor2 = System.Drawing.Color.FromArgb(225, 240, 239);
            this.pnlPageBackground.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlPageBackground.Name = "pnlPageBackground";
            this.pnlPageBackground.Size = new System.Drawing.Size(1280, 800);
            this.pnlPageBackground.Controls.Add(this.pnlContent);
            this.pnlPageBackground.Controls.Add(this.pnlSidebar);
            this.pnlPageBackground.Controls.Add(this.pnlNavbar);

            // 
            // pnlNavbar (logo + Logout only - Admin uses sidebar for navigation)
            // 
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.FillColor = System.Drawing.Color.White;
            this.pnlNavbar.BackColor = System.Drawing.Color.White;
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1280, 64);

            // 
            // picNavLogo
            // 
            this.picNavLogo.Location = new System.Drawing.Point(20, 12);
            this.picNavLogo.Name = "picNavLogo";
            this.picNavLogo.Size = new System.Drawing.Size(40, 40);
            this.picNavLogo.BorderRadius = 10;
            this.picNavLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // lblNavBrand
            // 
            this.lblNavBrand.Location = new System.Drawing.Point(68, 20);
            this.lblNavBrand.Name = "lblNavBrand";
            this.lblNavBrand.Size = new System.Drawing.Size(100, 24);
            this.lblNavBrand.Text = "<div style=\"color:#E8714A;font-weight:bold;font-size:12pt;\">Meraki</div>";

            // 
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.BorderThickness = 0;
            this.btnLogout.ShadowDecoration.Enabled = false;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(224, 90, 90);
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 232, 232);
            this.btnLogout.Location = new System.Drawing.Point(1160, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 36);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BorderRadius = 16;
            this.pnlSidebar.FillColor = System.Drawing.Color.White;
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlSidebar.Location = new System.Drawing.Point(20, 84);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 420);

            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Location = new System.Drawing.Point(16, 16);
            this.lblSidebarTitle.Size = new System.Drawing.Size(160, 22);
            this.lblSidebarTitle.Text = "Admin Panel";
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnSidebarOverview (active)
            // 
            this.btnSidebarOverview.BorderRadius = 10;
            this.btnSidebarOverview.BorderThickness = 0;
            this.btnSidebarOverview.ShadowDecoration.Enabled = false;
            this.btnSidebarOverview.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnSidebarOverview.BackColor = System.Drawing.Color.White;
            this.btnSidebarOverview.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.btnSidebarOverview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSidebarOverview.HoverState.FillColor = System.Drawing.Color.FromArgb(250, 226, 216);
            this.btnSidebarOverview.Location = new System.Drawing.Point(12, 56);
            this.btnSidebarOverview.Name = "btnSidebarOverview";
            this.btnSidebarOverview.Size = new System.Drawing.Size(176, 40);
            this.btnSidebarOverview.Text = "Overview";
            this.btnSidebarOverview.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSidebarOverview.Click += new System.EventHandler(this.btnSidebarOverview_Click);

            // 
            // btnSidebarUsers
            // 
            this.btnSidebarUsers.BorderRadius = 10;
            this.btnSidebarUsers.BorderThickness = 0;
            this.btnSidebarUsers.ShadowDecoration.Enabled = false;
            this.btnSidebarUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnSidebarUsers.BackColor = System.Drawing.Color.White;
            this.btnSidebarUsers.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnSidebarUsers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSidebarUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnSidebarUsers.Location = new System.Drawing.Point(12, 102);
            this.btnSidebarUsers.Name = "btnSidebarUsers";
            this.btnSidebarUsers.Size = new System.Drawing.Size(176, 40);
            this.btnSidebarUsers.Text = "Users";
            this.btnSidebarUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSidebarUsers.Click += new System.EventHandler(this.btnSidebarUsers_Click);

            // 
            // btnSidebarBookings
            // 
            this.btnSidebarBookings.BorderRadius = 10;
            this.btnSidebarBookings.BorderThickness = 0;
            this.btnSidebarBookings.ShadowDecoration.Enabled = false;
            this.btnSidebarBookings.FillColor = System.Drawing.Color.Transparent;
            this.btnSidebarBookings.BackColor = System.Drawing.Color.White;
            this.btnSidebarBookings.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnSidebarBookings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSidebarBookings.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnSidebarBookings.Location = new System.Drawing.Point(12, 148);
            this.btnSidebarBookings.Name = "btnSidebarBookings";
            this.btnSidebarBookings.Size = new System.Drawing.Size(176, 40);
            this.btnSidebarBookings.Text = "Bookings";
            this.btnSidebarBookings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSidebarBookings.Click += new System.EventHandler(this.btnSidebarBookings_Click);

            // 
            // btnSidebarReports
            // 
            this.btnSidebarReports.BorderRadius = 10;
            this.btnSidebarReports.BorderThickness = 0;
            this.btnSidebarReports.ShadowDecoration.Enabled = false;
            this.btnSidebarReports.FillColor = System.Drawing.Color.Transparent;
            this.btnSidebarReports.BackColor = System.Drawing.Color.White;
            this.btnSidebarReports.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnSidebarReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSidebarReports.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnSidebarReports.Location = new System.Drawing.Point(12, 194);
            this.btnSidebarReports.Name = "btnSidebarReports";
            this.btnSidebarReports.Size = new System.Drawing.Size(176, 40);
            this.btnSidebarReports.Text = "Reports";
            this.btnSidebarReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSidebarReports.Click += new System.EventHandler(this.btnSidebarReports_Click);

            // 
            // btnSidebarSettings
            // 
            this.btnSidebarSettings.BorderRadius = 10;
            this.btnSidebarSettings.BorderThickness = 0;
            this.btnSidebarSettings.ShadowDecoration.Enabled = false;
            this.btnSidebarSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSidebarSettings.BackColor = System.Drawing.Color.White;
            this.btnSidebarSettings.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.btnSidebarSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSidebarSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.btnSidebarSettings.Location = new System.Drawing.Point(12, 240);
            this.btnSidebarSettings.Name = "btnSidebarSettings";
            this.btnSidebarSettings.Size = new System.Drawing.Size(176, 40);
            this.btnSidebarSettings.Text = "Settings";
            this.btnSidebarSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSidebarSettings.Click += new System.EventHandler(this.btnSidebarSettings_Click);

            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = false;
            this.pnlContent.FillColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlContent.FillColor2 = System.Drawing.Color.FromArgb(225, 240, 239);
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlContent.Location = new System.Drawing.Point(236, 84);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1024, 780);

            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Location = new System.Drawing.Point(4, 4);
            this.lblPageTitle.Size = new System.Drawing.Size(300, 26);
            this.lblPageTitle.Text = "Admin Dashboard";
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.Location = new System.Drawing.Point(4, 32);
            this.lblPageSubtitle.Size = new System.Drawing.Size(300, 20);
            this.lblPageSubtitle.Text = "Welcome back, Administrator";
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPageSubtitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlKpiParents
            // 
            this.pnlKpiParents.BorderRadius = 16;
            this.pnlKpiParents.FillColor = System.Drawing.Color.White;
            this.pnlKpiParents.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlKpiParents.Location = new System.Drawing.Point(4, 64);
            this.pnlKpiParents.Name = "pnlKpiParents";
            this.pnlKpiParents.Size = new System.Drawing.Size(240, 130);
            this.pnlKpiParents.Controls.Add(this.pnlKpiParentsIcon);
            this.pnlKpiParents.Controls.Add(this.lblKpiParentsValue);
            this.pnlKpiParents.Controls.Add(this.lblKpiParentsLabel);

            // 
            // pnlKpiParentsIcon
            // 
            this.pnlKpiParentsIcon.BorderRadius = 24;
            this.pnlKpiParentsIcon.FillColor = System.Drawing.Color.FromArgb(253, 226, 220);
            this.pnlKpiParentsIcon.BackColor = System.Drawing.Color.White;
            this.pnlKpiParentsIcon.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiParentsIcon.Size = new System.Drawing.Size(48, 48);
            this.pnlKpiParentsIcon.Controls.Add(this.lblKpiParentsIcon);

            // 
            // lblKpiParentsIcon
            // 
            this.lblKpiParentsIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiParentsIcon.Text = "P";
            this.lblKpiParentsIcon.ForeColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.lblKpiParentsIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiParentsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiParentsIcon.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiParentsValue
            // 
            this.lblKpiParentsValue.Location = new System.Drawing.Point(20, 76);
            this.lblKpiParentsValue.Size = new System.Drawing.Size(160, 30);
            this.lblKpiParentsValue.Text = "1,284";
            this.lblKpiParentsValue.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblKpiParentsValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiParentsValue.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiParentsLabel
            // 
            this.lblKpiParentsLabel.Location = new System.Drawing.Point(20, 106);
            this.lblKpiParentsLabel.Size = new System.Drawing.Size(200, 20);
            this.lblKpiParentsLabel.Text = "Total Parents";
            this.lblKpiParentsLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblKpiParentsLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiParentsLabel.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlKpiBabysitters
            // 
            this.pnlKpiBabysitters.BorderRadius = 16;
            this.pnlKpiBabysitters.FillColor = System.Drawing.Color.White;
            this.pnlKpiBabysitters.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlKpiBabysitters.Location = new System.Drawing.Point(256, 64);
            this.pnlKpiBabysitters.Name = "pnlKpiBabysitters";
            this.pnlKpiBabysitters.Size = new System.Drawing.Size(240, 130);
            this.pnlKpiBabysitters.Controls.Add(this.pnlKpiBabysittersIcon);
            this.pnlKpiBabysitters.Controls.Add(this.lblKpiBabysittersValue);
            this.pnlKpiBabysitters.Controls.Add(this.lblKpiBabysittersLabel);

            // 
            // pnlKpiBabysittersIcon
            // 
            this.pnlKpiBabysittersIcon.BorderRadius = 24;
            this.pnlKpiBabysittersIcon.FillColor = System.Drawing.Color.FromArgb(222, 245, 244);
            this.pnlKpiBabysittersIcon.BackColor = System.Drawing.Color.White;
            this.pnlKpiBabysittersIcon.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiBabysittersIcon.Size = new System.Drawing.Size(48, 48);
            this.pnlKpiBabysittersIcon.Controls.Add(this.lblKpiBabysittersIcon);

            // 
            // lblKpiBabysittersIcon
            // 
            this.lblKpiBabysittersIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiBabysittersIcon.Text = "B";
            this.lblKpiBabysittersIcon.ForeColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.lblKpiBabysittersIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiBabysittersIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiBabysittersIcon.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiBabysittersValue
            // 
            this.lblKpiBabysittersValue.Location = new System.Drawing.Point(20, 76);
            this.lblKpiBabysittersValue.Size = new System.Drawing.Size(160, 30);
            this.lblKpiBabysittersValue.Text = "342";
            this.lblKpiBabysittersValue.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblKpiBabysittersValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiBabysittersValue.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiBabysittersLabel
            // 
            this.lblKpiBabysittersLabel.Location = new System.Drawing.Point(20, 106);
            this.lblKpiBabysittersLabel.Size = new System.Drawing.Size(200, 20);
            this.lblKpiBabysittersLabel.Text = "Babysitters";
            this.lblKpiBabysittersLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblKpiBabysittersLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiBabysittersLabel.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlKpiBookings
            // 
            this.pnlKpiBookings.BorderRadius = 16;
            this.pnlKpiBookings.FillColor = System.Drawing.Color.White;
            this.pnlKpiBookings.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlKpiBookings.Location = new System.Drawing.Point(508, 64);
            this.pnlKpiBookings.Name = "pnlKpiBookings";
            this.pnlKpiBookings.Size = new System.Drawing.Size(240, 130);
            this.pnlKpiBookings.Controls.Add(this.pnlKpiBookingsIcon);
            this.pnlKpiBookings.Controls.Add(this.lblKpiBookingsValue);
            this.pnlKpiBookings.Controls.Add(this.lblKpiBookingsLabel);

            // 
            // pnlKpiBookingsIcon
            // 
            this.pnlKpiBookingsIcon.BorderRadius = 24;
            this.pnlKpiBookingsIcon.FillColor = System.Drawing.Color.FromArgb(255, 244, 217);
            this.pnlKpiBookingsIcon.BackColor = System.Drawing.Color.White;
            this.pnlKpiBookingsIcon.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiBookingsIcon.Size = new System.Drawing.Size(48, 48);
            this.pnlKpiBookingsIcon.Controls.Add(this.lblKpiBookingsIcon);

            // 
            // lblKpiBookingsIcon
            // 
            this.lblKpiBookingsIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiBookingsIcon.Text = "C";
            this.lblKpiBookingsIcon.ForeColor = System.Drawing.Color.FromArgb(255, 209, 102);
            this.lblKpiBookingsIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiBookingsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiBookingsIcon.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiBookingsValue
            // 
            this.lblKpiBookingsValue.Location = new System.Drawing.Point(20, 76);
            this.lblKpiBookingsValue.Size = new System.Drawing.Size(160, 30);
            this.lblKpiBookingsValue.Text = "891";
            this.lblKpiBookingsValue.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblKpiBookingsValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiBookingsValue.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiBookingsLabel
            // 
            this.lblKpiBookingsLabel.Location = new System.Drawing.Point(20, 106);
            this.lblKpiBookingsLabel.Size = new System.Drawing.Size(200, 20);
            this.lblKpiBookingsLabel.Text = "Bookings This Month";
            this.lblKpiBookingsLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblKpiBookingsLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiBookingsLabel.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlKpiRevenue
            // 
            this.pnlKpiRevenue.BorderRadius = 16;
            this.pnlKpiRevenue.FillColor = System.Drawing.Color.White;
            this.pnlKpiRevenue.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlKpiRevenue.Location = new System.Drawing.Point(760, 64);
            this.pnlKpiRevenue.Name = "pnlKpiRevenue";
            this.pnlKpiRevenue.Size = new System.Drawing.Size(240, 130);
            this.pnlKpiRevenue.Controls.Add(this.pnlKpiRevenueIcon);
            this.pnlKpiRevenue.Controls.Add(this.lblKpiRevenueValue);
            this.pnlKpiRevenue.Controls.Add(this.lblKpiRevenueLabel);

            // 
            // pnlKpiRevenueIcon
            // 
            this.pnlKpiRevenueIcon.BorderRadius = 24;
            this.pnlKpiRevenueIcon.FillColor = System.Drawing.Color.FromArgb(253, 225, 225);
            this.pnlKpiRevenueIcon.BackColor = System.Drawing.Color.White;
            this.pnlKpiRevenueIcon.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiRevenueIcon.Size = new System.Drawing.Size(48, 48);
            this.pnlKpiRevenueIcon.Controls.Add(this.lblKpiRevenueIcon);

            // 
            // lblKpiRevenueIcon
            // 
            this.lblKpiRevenueIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiRevenueIcon.Text = "$";
            this.lblKpiRevenueIcon.ForeColor = System.Drawing.Color.FromArgb(224, 90, 90);
            this.lblKpiRevenueIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiRevenueIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiRevenueIcon.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiRevenueValue
            // 
            this.lblKpiRevenueValue.Location = new System.Drawing.Point(20, 76);
            this.lblKpiRevenueValue.Size = new System.Drawing.Size(180, 30);
            this.lblKpiRevenueValue.Text = "$42,800";
            this.lblKpiRevenueValue.ForeColor = System.Drawing.Color.FromArgb(60, 50, 45);
            this.lblKpiRevenueValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiRevenueValue.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKpiRevenueLabel
            // 
            this.lblKpiRevenueLabel.Location = new System.Drawing.Point(20, 106);
            this.lblKpiRevenueLabel.Size = new System.Drawing.Size(200, 20);
            this.lblKpiRevenueLabel.Text = "Revenue";
            this.lblKpiRevenueLabel.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblKpiRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKpiRevenueLabel.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlBookingsChart (visual placeholder card - wire up a real chart control later)
            // 
            this.pnlBookingsChart.BorderRadius = 16;
            this.pnlBookingsChart.FillColor = System.Drawing.Color.White;
            this.pnlBookingsChart.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlBookingsChart.Location = new System.Drawing.Point(4, 208);
            this.pnlBookingsChart.Name = "pnlBookingsChart";
            this.pnlBookingsChart.Size = new System.Drawing.Size(496, 200);
            this.pnlBookingsChart.Controls.Add(this.lblBookingsChartTitle);

            // 
            // Monthly Bookings bars (static fake data: 65,78,90,110,125,145 - chart area ~140px tall)
            // 
            this.barJan.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barJan.BackColor = System.Drawing.Color.White;
            this.barJan.BorderRadius = 4;
            this.barJan.Location = new System.Drawing.Point(40, 116);
            this.barJan.Size = new System.Drawing.Size(36, 63);
            this.lblBarJan.Text = "Jan";
            this.lblBarJan.Location = new System.Drawing.Point(34, 182);
            this.lblBarJan.Size = new System.Drawing.Size(48, 18);
            this.lblBarJan.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarJan.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarJan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarJan.BackColor = System.Drawing.Color.Transparent;

            this.barFeb.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barFeb.BackColor = System.Drawing.Color.White;
            this.barFeb.BorderRadius = 4;
            this.barFeb.Location = new System.Drawing.Point(112, 104);
            this.barFeb.Size = new System.Drawing.Size(36, 75);
            this.lblBarFeb.Text = "Feb";
            this.lblBarFeb.Location = new System.Drawing.Point(106, 182);
            this.lblBarFeb.Size = new System.Drawing.Size(48, 18);
            this.lblBarFeb.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarFeb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarFeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarFeb.BackColor = System.Drawing.Color.Transparent;

            this.barMar.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barMar.BackColor = System.Drawing.Color.White;
            this.barMar.BorderRadius = 4;
            this.barMar.Location = new System.Drawing.Point(184, 92);
            this.barMar.Size = new System.Drawing.Size(36, 87);
            this.lblBarMar.Text = "Mar";
            this.lblBarMar.Location = new System.Drawing.Point(178, 182);
            this.lblBarMar.Size = new System.Drawing.Size(48, 18);
            this.lblBarMar.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarMar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarMar.BackColor = System.Drawing.Color.Transparent;

            this.barApr.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barApr.BackColor = System.Drawing.Color.White;
            this.barApr.BorderRadius = 4;
            this.barApr.Location = new System.Drawing.Point(256, 72);
            this.barApr.Size = new System.Drawing.Size(36, 107);
            this.lblBarApr.Text = "Apr";
            this.lblBarApr.Location = new System.Drawing.Point(250, 182);
            this.lblBarApr.Size = new System.Drawing.Size(48, 18);
            this.lblBarApr.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarApr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarApr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarApr.BackColor = System.Drawing.Color.Transparent;

            this.barMay.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barMay.BackColor = System.Drawing.Color.White;
            this.barMay.BorderRadius = 4;
            this.barMay.Location = new System.Drawing.Point(328, 58);
            this.barMay.Size = new System.Drawing.Size(36, 121);
            this.lblBarMay.Text = "May";
            this.lblBarMay.Location = new System.Drawing.Point(322, 182);
            this.lblBarMay.Size = new System.Drawing.Size(48, 18);
            this.lblBarMay.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarMay.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarMay.BackColor = System.Drawing.Color.Transparent;

            this.barJun.FillColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.barJun.BackColor = System.Drawing.Color.White;
            this.barJun.BorderRadius = 4;
            this.barJun.Location = new System.Drawing.Point(400, 38);
            this.barJun.Size = new System.Drawing.Size(36, 141);
            this.lblBarJun.Text = "Jun";
            this.lblBarJun.Location = new System.Drawing.Point(394, 182);
            this.lblBarJun.Size = new System.Drawing.Size(48, 18);
            this.lblBarJun.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBarJun.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarJun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarJun.BackColor = System.Drawing.Color.Transparent;

            this.pnlBookingsChart.Controls.Add(this.barJan);
            this.pnlBookingsChart.Controls.Add(this.barFeb);
            this.pnlBookingsChart.Controls.Add(this.barMar);
            this.pnlBookingsChart.Controls.Add(this.barApr);
            this.pnlBookingsChart.Controls.Add(this.barMay);
            this.pnlBookingsChart.Controls.Add(this.barJun);
            this.pnlBookingsChart.Controls.Add(this.lblBarJan);
            this.pnlBookingsChart.Controls.Add(this.lblBarFeb);
            this.pnlBookingsChart.Controls.Add(this.lblBarMar);
            this.pnlBookingsChart.Controls.Add(this.lblBarApr);
            this.pnlBookingsChart.Controls.Add(this.lblBarMay);
            this.pnlBookingsChart.Controls.Add(this.lblBarJun);

            // 
            // lblBookingsChartTitle
            // 
            this.lblBookingsChartTitle.Location = new System.Drawing.Point(16, 14);
            this.lblBookingsChartTitle.Size = new System.Drawing.Size(300, 22);
            this.lblBookingsChartTitle.Text = "Monthly Bookings";
            this.lblBookingsChartTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblBookingsChartTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBookingsChartTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlRevenueChart
            // 
            this.pnlRevenueChart.BorderRadius = 16;
            this.pnlRevenueChart.FillColor = System.Drawing.Color.White;
            this.pnlRevenueChart.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlRevenueChart.Location = new System.Drawing.Point(508, 208);
            this.pnlRevenueChart.Name = "pnlRevenueChart";
            this.pnlRevenueChart.Size = new System.Drawing.Size(496, 200);
            this.pnlRevenueChart.Controls.Add(this.lblRevenueChartTitle);

            // 
            // Revenue Trend bars (static fake data: 3200,4100,3800,5200,4900,6100 - chart area ~140px tall)
            // 
            this.revJan.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revJan.BackColor = System.Drawing.Color.White;
            this.revJan.BorderRadius = 4;
            this.revJan.Location = new System.Drawing.Point(40, 109);
            this.revJan.Size = new System.Drawing.Size(36, 70);
            this.lblRevJan.Text = "Jan";
            this.lblRevJan.Location = new System.Drawing.Point(34, 182);
            this.lblRevJan.Size = new System.Drawing.Size(48, 18);
            this.lblRevJan.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevJan.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevJan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevJan.BackColor = System.Drawing.Color.Transparent;

            this.revFeb.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revFeb.BackColor = System.Drawing.Color.White;
            this.revFeb.BorderRadius = 4;
            this.revFeb.Location = new System.Drawing.Point(112, 89);
            this.revFeb.Size = new System.Drawing.Size(36, 90);
            this.lblRevFeb.Text = "Feb";
            this.lblRevFeb.Location = new System.Drawing.Point(106, 182);
            this.lblRevFeb.Size = new System.Drawing.Size(48, 18);
            this.lblRevFeb.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevFeb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevFeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevFeb.BackColor = System.Drawing.Color.Transparent;

            this.revMar.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revMar.BackColor = System.Drawing.Color.White;
            this.revMar.BorderRadius = 4;
            this.revMar.Location = new System.Drawing.Point(184, 96);
            this.revMar.Size = new System.Drawing.Size(36, 83);
            this.lblRevMar.Text = "Mar";
            this.lblRevMar.Location = new System.Drawing.Point(178, 182);
            this.lblRevMar.Size = new System.Drawing.Size(48, 18);
            this.lblRevMar.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevMar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevMar.BackColor = System.Drawing.Color.Transparent;

            this.revApr.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revApr.BackColor = System.Drawing.Color.White;
            this.revApr.BorderRadius = 4;
            this.revApr.Location = new System.Drawing.Point(256, 65);
            this.revApr.Size = new System.Drawing.Size(36, 114);
            this.lblRevApr.Text = "Apr";
            this.lblRevApr.Location = new System.Drawing.Point(250, 182);
            this.lblRevApr.Size = new System.Drawing.Size(48, 18);
            this.lblRevApr.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevApr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevApr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevApr.BackColor = System.Drawing.Color.Transparent;

            this.revMay.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revMay.BackColor = System.Drawing.Color.White;
            this.revMay.BorderRadius = 4;
            this.revMay.Location = new System.Drawing.Point(328, 72);
            this.revMay.Size = new System.Drawing.Size(36, 107);
            this.lblRevMay.Text = "May";
            this.lblRevMay.Location = new System.Drawing.Point(322, 182);
            this.lblRevMay.Size = new System.Drawing.Size(48, 18);
            this.lblRevMay.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevMay.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevMay.BackColor = System.Drawing.Color.Transparent;

            this.revJun.FillColor = System.Drawing.Color.FromArgb(94, 200, 196);
            this.revJun.BackColor = System.Drawing.Color.White;
            this.revJun.BorderRadius = 4;
            this.revJun.Location = new System.Drawing.Point(400, 38);
            this.revJun.Size = new System.Drawing.Size(36, 141);
            this.lblRevJun.Text = "Jun";
            this.lblRevJun.Location = new System.Drawing.Point(394, 182);
            this.lblRevJun.Size = new System.Drawing.Size(48, 18);
            this.lblRevJun.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevJun.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevJun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevJun.BackColor = System.Drawing.Color.Transparent;

            this.pnlRevenueChart.Controls.Add(this.revJan);
            this.pnlRevenueChart.Controls.Add(this.revFeb);
            this.pnlRevenueChart.Controls.Add(this.revMar);
            this.pnlRevenueChart.Controls.Add(this.revApr);
            this.pnlRevenueChart.Controls.Add(this.revMay);
            this.pnlRevenueChart.Controls.Add(this.revJun);
            this.pnlRevenueChart.Controls.Add(this.lblRevJan);
            this.pnlRevenueChart.Controls.Add(this.lblRevFeb);
            this.pnlRevenueChart.Controls.Add(this.lblRevMar);
            this.pnlRevenueChart.Controls.Add(this.lblRevApr);
            this.pnlRevenueChart.Controls.Add(this.lblRevMay);
            this.pnlRevenueChart.Controls.Add(this.lblRevJun);

            // 
            // lblRevenueChartTitle
            // 
            this.lblRevenueChartTitle.Location = new System.Drawing.Point(16, 14);
            this.lblRevenueChartTitle.Size = new System.Drawing.Size(300, 22);
            this.lblRevenueChartTitle.Text = "Revenue Trend";
            this.lblRevenueChartTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblRevenueChartTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRevenueChartTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // pnlUserTableCard
            // 
            this.pnlUserTableCard.BorderRadius = 16;
            this.pnlUserTableCard.FillColor = System.Drawing.Color.White;
            this.pnlUserTableCard.BackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.pnlUserTableCard.Location = new System.Drawing.Point(4, 424);
            this.pnlUserTableCard.Name = "pnlUserTableCard";
            this.pnlUserTableCard.Size = new System.Drawing.Size(1000, 300);
            this.pnlUserTableCard.Controls.Add(this.lblUserTableTitle);
            this.pnlUserTableCard.Controls.Add(this.tbSearchUsers);
            this.pnlUserTableCard.Controls.Add(this.dgvUsers);

            // 
            // lblUserTableTitle
            // 
            this.lblUserTableTitle.Location = new System.Drawing.Point(16, 14);
            this.lblUserTableTitle.Size = new System.Drawing.Size(220, 22);
            this.lblUserTableTitle.Text = "User Management";
            this.lblUserTableTitle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.lblUserTableTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserTableTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // tbSearchUsers
            // 
            this.tbSearchUsers.BorderRadius = 10;
            this.tbSearchUsers.FillColor = System.Drawing.Color.FromArgb(247, 245, 242);
            this.tbSearchUsers.PlaceholderText = "Search users...";
            this.tbSearchUsers.Location = new System.Drawing.Point(770, 10);
            this.tbSearchUsers.Name = "tbSearchUsers";
            this.tbSearchUsers.Size = new System.Drawing.Size(214, 36);
            this.tbSearchUsers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 113, 74);
            this.tbSearchUsers.TextChanged += new System.EventHandler(this.tbSearchUsers_TextChanged);

            // 
            // dgvUsers (columns ready for data binding; no sample rows)
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(240, 235, 228);
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(154, 136, 128);
            this.dgvUsers.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsers.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 70, 65);
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(80, 70, 65);
            this.dgvUsers.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsers.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 70, 65);
            this.dgvUsers.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(253, 238, 232);
            this.dgvUsers.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(80, 70, 65);
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsers.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 70, 65);
            this.dgvUsers.RowTemplate.Height = 36;
            this.dgvUsers.Location = new System.Drawing.Point(16, 56);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(968, 230);
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colName,
                this.colRole,
                this.colEmail,
                this.colStatus,
                this.colJoined,
                this.colActions});
            // Sample/fake data for design preview only - replace with real data binding later
            // Sample/fake data is now added in AdminDashboardForm.cs (LoadSampleUsers),
            // since the VS Designer regenerates this file and would silently drop
            // any hand-typed Rows.Add() calls here on the next property edit.

            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 180;
            // 
            // colRole
            // 
            this.colRole.HeaderText = "Role";
            this.colRole.Name = "colRole";
            this.colRole.Width = 110;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 220;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 110;
            // 
            // colJoined
            // 
            this.colJoined.HeaderText = "Joined";
            this.colJoined.Name = "colJoined";
            this.colJoined.Width = 120;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "Actions";
            this.colActions.Name = "colActions";
            this.colActions.Width = 100;

            // 
            // pnlNavbar.Controls
            // 
            this.pnlNavbar.Controls.Add(this.picNavLogo);
            this.pnlNavbar.Controls.Add(this.lblNavBrand);
            this.pnlNavbar.Controls.Add(this.btnLogout);

            // 
            // pnlSidebar.Controls
            // 
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.btnSidebarOverview);
            this.pnlSidebar.Controls.Add(this.btnSidebarUsers);
            this.pnlSidebar.Controls.Add(this.btnSidebarBookings);
            this.pnlSidebar.Controls.Add(this.btnSidebarReports);
            this.pnlSidebar.Controls.Add(this.btnSidebarSettings);

            // 
            // pnlContent.Controls
            // 
            this.pnlContent.Controls.Add(this.lblPageTitle);
            this.pnlContent.Controls.Add(this.lblPageSubtitle);
            this.pnlContent.Controls.Add(this.pnlKpiParents);
            this.pnlContent.Controls.Add(this.pnlKpiBabysitters);
            this.pnlContent.Controls.Add(this.pnlKpiBookings);
            this.pnlContent.Controls.Add(this.pnlKpiRevenue);
            this.pnlContent.Controls.Add(this.pnlBookingsChart);
            this.pnlContent.Controls.Add(this.pnlRevenueChart);
            this.pnlContent.Controls.Add(this.pnlUserTableCard);

            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1280, 880);
            this.Controls.Add(this.pnlPageBackground);
            this.MinimumSize = new System.Drawing.Size(1100, 780);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meraki - Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picNavLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlUserTableCard.ResumeLayout(false);
            this.pnlKpiRevenue.ResumeLayout(false);
            this.pnlKpiBookings.ResumeLayout(false);
            this.pnlKpiBabysitters.ResumeLayout(false);
            this.pnlKpiParents.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlPageBackground.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlPageBackground;
        private Guna.UI2.WinForms.Guna2Panel pnlNavbar;
        private Guna.UI2.WinForms.Guna2PictureBox picNavLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNavBrand;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private Guna.UI2.WinForms.Guna2Button btnSidebarOverview;
        private Guna.UI2.WinForms.Guna2Button btnSidebarUsers;
        private Guna.UI2.WinForms.Guna2Button btnSidebarBookings;
        private Guna.UI2.WinForms.Guna2Button btnSidebarReports;
        private Guna.UI2.WinForms.Guna2Button btnSidebarSettings;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiParents;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiParentsIcon;
        private System.Windows.Forms.Label lblKpiParentsIcon;
        private System.Windows.Forms.Label lblKpiParentsValue;
        private System.Windows.Forms.Label lblKpiParentsLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiBabysitters;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiBabysittersIcon;
        private System.Windows.Forms.Label lblKpiBabysittersIcon;
        private System.Windows.Forms.Label lblKpiBabysittersValue;
        private System.Windows.Forms.Label lblKpiBabysittersLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiBookings;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiBookingsIcon;
        private System.Windows.Forms.Label lblKpiBookingsIcon;
        private System.Windows.Forms.Label lblKpiBookingsValue;
        private System.Windows.Forms.Label lblKpiBookingsLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiRevenue;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiRevenueIcon;
        private System.Windows.Forms.Label lblKpiRevenueIcon;
        private System.Windows.Forms.Label lblKpiRevenueValue;
        private System.Windows.Forms.Label lblKpiRevenueLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlBookingsChart;
        private System.Windows.Forms.Label lblBookingsChartTitle;
        private Guna.UI2.WinForms.Guna2Panel barJan;
        private Guna.UI2.WinForms.Guna2Panel barFeb;
        private Guna.UI2.WinForms.Guna2Panel barMar;
        private Guna.UI2.WinForms.Guna2Panel barApr;
        private Guna.UI2.WinForms.Guna2Panel barMay;
        private Guna.UI2.WinForms.Guna2Panel barJun;
        private System.Windows.Forms.Label lblBarJan;
        private System.Windows.Forms.Label lblBarFeb;
        private System.Windows.Forms.Label lblBarMar;
        private System.Windows.Forms.Label lblBarApr;
        private System.Windows.Forms.Label lblBarMay;
        private System.Windows.Forms.Label lblBarJun;
        private Guna.UI2.WinForms.Guna2Panel pnlRevenueChart;
        private System.Windows.Forms.Label lblRevenueChartTitle;
        private Guna.UI2.WinForms.Guna2Panel revJan;
        private Guna.UI2.WinForms.Guna2Panel revFeb;
        private Guna.UI2.WinForms.Guna2Panel revMar;
        private Guna.UI2.WinForms.Guna2Panel revApr;
        private Guna.UI2.WinForms.Guna2Panel revMay;
        private Guna.UI2.WinForms.Guna2Panel revJun;
        private System.Windows.Forms.Label lblRevJan;
        private System.Windows.Forms.Label lblRevFeb;
        private System.Windows.Forms.Label lblRevMar;
        private System.Windows.Forms.Label lblRevApr;
        private System.Windows.Forms.Label lblRevMay;
        private System.Windows.Forms.Label lblRevJun;
        private Guna.UI2.WinForms.Guna2Panel pnlUserTableCard;
        private System.Windows.Forms.Label lblUserTableTitle;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchUsers;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJoined;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActions;
    }
}