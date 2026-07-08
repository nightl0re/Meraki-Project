namespace Meraki_Project
{
    partial class BabysitterProfileForm
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
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            pnlProfileHeaderCard = new Guna.UI2.WinForms.Guna2Panel();
            pnlAvatar = new Guna.UI2.WinForms.Guna2Panel();
            lblAvatarInitial = new Label();
            lblName = new Label();
            lblMeta = new Label();
            lblRatingSummary = new Label();
            lblRate = new Label();
            btnBookNow = new Guna.UI2.WinForms.Guna2Button();
            btnTabAbout = new Guna.UI2.WinForms.Guna2Button();
            btnTabReviews = new Guna.UI2.WinForms.Guna2Button();
            btnTabWrite = new Guna.UI2.WinForms.Guna2Button();
            pnlTabAbout = new Guna.UI2.WinForms.Guna2Panel();
            lblAboutTitle = new Label();
            lblBio = new Label();
            lblSkillsTitle = new Label();
            flpSkills = new FlowLayoutPanel();
            pnlTabReviews = new Guna.UI2.WinForms.Guna2Panel();
            flpReviews = new FlowLayoutPanel();
            pnlTabWrite = new Guna.UI2.WinForms.Guna2Panel();
            lblWriteTitle = new Label();
            lblWriteSubtitle = new Label();
            lblOverallCaption = new Label();
            btnStar1 = new Guna.UI2.WinForms.Guna2Button();
            btnStar2 = new Guna.UI2.WinForms.Guna2Button();
            btnStar3 = new Guna.UI2.WinForms.Guna2Button();
            btnStar4 = new Guna.UI2.WinForms.Guna2Button();
            btnStar5 = new Guna.UI2.WinForms.Guna2Button();
            lblCommentCaption = new Label();
            tbComment = new Guna.UI2.WinForms.Guna2TextBox();
            btnSubmitReview = new Guna.UI2.WinForms.Guna2Button();
            lblCannotReview = new Label();
            ((System.ComponentModel.ISupportInitialize)picNavLogo).BeginInit();
            pnlPageBackground.SuspendLayout();
            pnlNavbar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlProfileHeaderCard.SuspendLayout();
            pnlAvatar.SuspendLayout();
            pnlTabAbout.SuspendLayout();
            pnlTabReviews.SuspendLayout();
            pnlTabWrite.SuspendLayout();
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
            pnlNavbar.Controls.Add(btnBack);
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
            // btnBack
            //
            btnBack.BackColor = Color.White;
            btnBack.BorderRadius = 8;
            btnBack.FillColor = Color.FromArgb(247, 245, 242);
            btnBack.Font = new Font("Segoe UI", 8.5F);
            btnBack.ForeColor = Color.FromArgb(154, 136, 128);
            btnBack.Location = new Point(1330, 18);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 2;
            btnBack.Text = "<   Back";
            btnBack.Click += btnBack_Click;
            //
            // pnlContent
            //
            pnlContent.BackColor = Color.FromArgb(253, 238, 232);
            pnlContent.Controls.Add(pnlProfileHeaderCard);
            pnlContent.Controls.Add(btnTabAbout);
            pnlContent.Controls.Add(btnTabReviews);
            pnlContent.Controls.Add(btnTabWrite);
            pnlContent.Controls.Add(pnlTabAbout);
            pnlContent.Controls.Add(pnlTabReviews);
            pnlContent.Controls.Add(pnlTabWrite);
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
            pnlProfileHeaderCard.BorderThickness = 1;
            pnlProfileHeaderCard.BorderColor = Color.FromArgb(238, 230, 224);
            pnlProfileHeaderCard.Controls.Add(pnlAvatar);
            pnlProfileHeaderCard.Controls.Add(lblName);
            pnlProfileHeaderCard.Controls.Add(lblMeta);
            pnlProfileHeaderCard.Controls.Add(lblRatingSummary);
            pnlProfileHeaderCard.Controls.Add(lblRate);
            pnlProfileHeaderCard.Controls.Add(btnBookNow);
            pnlProfileHeaderCard.FillColor = Color.White;
            pnlProfileHeaderCard.Location = new Point(30, 24);
            pnlProfileHeaderCard.Name = "pnlProfileHeaderCard";
            pnlProfileHeaderCard.Size = new Size(1440, 150);
            pnlProfileHeaderCard.TabIndex = 0;
            //
            // pnlAvatar
            //
            pnlAvatar.BackColor = Color.Transparent;
            pnlAvatar.BorderRadius = 24;
            pnlAvatar.Controls.Add(lblAvatarInitial);
            pnlAvatar.FillColor = Color.FromArgb(253, 238, 232);
            pnlAvatar.Location = new Point(24, 25);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(100, 100);
            pnlAvatar.TabIndex = 0;
            //
            // lblAvatarInitial
            //
            lblAvatarInitial.BackColor = Color.Transparent;
            lblAvatarInitial.Dock = DockStyle.Fill;
            lblAvatarInitial.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblAvatarInitial.ForeColor = Color.FromArgb(232, 113, 74);
            lblAvatarInitial.Location = new Point(0, 0);
            lblAvatarInitial.Name = "lblAvatarInitial";
            lblAvatarInitial.Size = new Size(100, 100);
            lblAvatarInitial.TabIndex = 0;
            lblAvatarInitial.Text = "?";
            lblAvatarInitial.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblName
            //
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(60, 50, 45);
            lblName.Location = new Point(150, 28);
            lblName.Name = "lblName";
            lblName.Size = new Size(560, 32);
            lblName.TabIndex = 1;
            lblName.Text = "Babysitter";
            //
            // lblMeta
            //
            lblMeta.BackColor = Color.Transparent;
            lblMeta.Font = new Font("Segoe UI", 9.5F);
            lblMeta.ForeColor = Color.FromArgb(154, 136, 128);
            lblMeta.Location = new Point(150, 64);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(700, 24);
            lblMeta.TabIndex = 2;
            lblMeta.Text = "Location · Experience";
            //
            // lblRatingSummary
            //
            lblRatingSummary.BackColor = Color.Transparent;
            lblRatingSummary.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRatingSummary.ForeColor = Color.FromArgb(255, 179, 71);
            lblRatingSummary.Location = new Point(150, 94);
            lblRatingSummary.Name = "lblRatingSummary";
            lblRatingSummary.Size = new Size(400, 24);
            lblRatingSummary.TabIndex = 3;
            lblRatingSummary.Text = "★ No reviews yet";
            //
            // lblRate
            //
            lblRate.BackColor = Color.Transparent;
            lblRate.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRate.ForeColor = Color.FromArgb(232, 113, 74);
            lblRate.Location = new Point(1140, 28);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(276, 34);
            lblRate.TabIndex = 4;
            lblRate.Text = "$15/hr";
            lblRate.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnBookNow
            //
            btnBookNow.BackColor = Color.Transparent;
            btnBookNow.BorderRadius = 10;
            btnBookNow.FillColor = Color.FromArgb(232, 113, 74);
            btnBookNow.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBookNow.ForeColor = Color.White;
            btnBookNow.Location = new Point(1196, 78);
            btnBookNow.Name = "btnBookNow";
            btnBookNow.Size = new Size(220, 48);
            btnBookNow.TabIndex = 5;
            btnBookNow.Text = "Book Now";
            btnBookNow.Click += btnBookNow_Click;
            //
            // btnTabAbout
            //
            btnTabAbout.BackColor = Color.Transparent;
            btnTabAbout.BorderRadius = 10;
            btnTabAbout.FillColor = Color.FromArgb(232, 113, 74);
            btnTabAbout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabAbout.ForeColor = Color.White;
            btnTabAbout.Location = new Point(30, 192);
            btnTabAbout.Name = "btnTabAbout";
            btnTabAbout.Size = new Size(150, 44);
            btnTabAbout.TabIndex = 1;
            btnTabAbout.Text = "About";
            btnTabAbout.Click += btnTabAbout_Click;
            //
            // btnTabReviews
            //
            btnTabReviews.BackColor = Color.Transparent;
            btnTabReviews.BorderRadius = 10;
            btnTabReviews.FillColor = Color.White;
            btnTabReviews.Font = new Font("Segoe UI", 9.5F);
            btnTabReviews.ForeColor = Color.FromArgb(154, 136, 128);
            btnTabReviews.Location = new Point(190, 192);
            btnTabReviews.Name = "btnTabReviews";
            btnTabReviews.Size = new Size(180, 44);
            btnTabReviews.TabIndex = 2;
            btnTabReviews.Text = "Reviews";
            btnTabReviews.Click += btnTabReviews_Click;
            //
            // btnTabWrite
            //
            btnTabWrite.BackColor = Color.Transparent;
            btnTabWrite.BorderRadius = 10;
            btnTabWrite.FillColor = Color.White;
            btnTabWrite.Font = new Font("Segoe UI", 9.5F);
            btnTabWrite.ForeColor = Color.FromArgb(154, 136, 128);
            btnTabWrite.Location = new Point(380, 192);
            btnTabWrite.Name = "btnTabWrite";
            btnTabWrite.Size = new Size(200, 44);
            btnTabWrite.TabIndex = 3;
            btnTabWrite.Text = "✏ Write Review";
            btnTabWrite.Click += btnTabWrite_Click;
            //
            // pnlTabAbout
            //
            pnlTabAbout.BackColor = Color.Transparent;
            pnlTabAbout.BorderRadius = 16;
            pnlTabAbout.BorderThickness = 1;
            pnlTabAbout.BorderColor = Color.FromArgb(238, 230, 224);
            pnlTabAbout.Controls.Add(lblAboutTitle);
            pnlTabAbout.Controls.Add(lblBio);
            pnlTabAbout.Controls.Add(lblSkillsTitle);
            pnlTabAbout.Controls.Add(flpSkills);
            pnlTabAbout.FillColor = Color.White;
            pnlTabAbout.Location = new Point(30, 252);
            pnlTabAbout.Name = "pnlTabAbout";
            pnlTabAbout.Size = new Size(1440, 520);
            pnlTabAbout.TabIndex = 4;
            //
            // lblAboutTitle
            //
            lblAboutTitle.BackColor = Color.Transparent;
            lblAboutTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAboutTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblAboutTitle.Location = new Point(24, 20);
            lblAboutTitle.Name = "lblAboutTitle";
            lblAboutTitle.Size = new Size(300, 28);
            lblAboutTitle.TabIndex = 0;
            lblAboutTitle.Text = "About";
            //
            // lblBio
            //
            lblBio.BackColor = Color.Transparent;
            lblBio.Font = new Font("Segoe UI", 10F);
            lblBio.ForeColor = Color.FromArgb(120, 108, 100);
            lblBio.Location = new Point(24, 56);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(1390, 80);
            lblBio.TabIndex = 1;
            lblBio.Text = "Bio";
            //
            // lblSkillsTitle
            //
            lblSkillsTitle.BackColor = Color.Transparent;
            lblSkillsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSkillsTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblSkillsTitle.Location = new Point(24, 152);
            lblSkillsTitle.Name = "lblSkillsTitle";
            lblSkillsTitle.Size = new Size(300, 28);
            lblSkillsTitle.TabIndex = 2;
            lblSkillsTitle.Text = "Skills";
            //
            // flpSkills
            //
            flpSkills.BackColor = Color.Transparent;
            flpSkills.Location = new Point(22, 188);
            flpSkills.Name = "flpSkills";
            flpSkills.Size = new Size(1394, 70);
            flpSkills.TabIndex = 3;
            //
            // pnlTabReviews
            //
            pnlTabReviews.BackColor = Color.Transparent;
            pnlTabReviews.BorderRadius = 16;
            pnlTabReviews.BorderThickness = 1;
            pnlTabReviews.BorderColor = Color.FromArgb(238, 230, 224);
            pnlTabReviews.Controls.Add(flpReviews);
            pnlTabReviews.FillColor = Color.White;
            pnlTabReviews.Location = new Point(30, 252);
            pnlTabReviews.Name = "pnlTabReviews";
            pnlTabReviews.Size = new Size(1440, 520);
            pnlTabReviews.TabIndex = 5;
            pnlTabReviews.Visible = false;
            //
            // flpReviews
            //
            flpReviews.AutoScroll = true;
            flpReviews.BackColor = Color.White;
            flpReviews.FlowDirection = FlowDirection.TopDown;
            flpReviews.Location = new Point(20, 20);
            flpReviews.Name = "flpReviews";
            flpReviews.Size = new Size(1400, 480);
            flpReviews.TabIndex = 0;
            flpReviews.WrapContents = false;
            //
            // pnlTabWrite
            //
            pnlTabWrite.BackColor = Color.Transparent;
            pnlTabWrite.BorderRadius = 16;
            pnlTabWrite.BorderThickness = 1;
            pnlTabWrite.BorderColor = Color.FromArgb(238, 230, 224);
            pnlTabWrite.Controls.Add(lblWriteTitle);
            pnlTabWrite.Controls.Add(lblWriteSubtitle);
            pnlTabWrite.Controls.Add(lblOverallCaption);
            pnlTabWrite.Controls.Add(btnStar1);
            pnlTabWrite.Controls.Add(btnStar2);
            pnlTabWrite.Controls.Add(btnStar3);
            pnlTabWrite.Controls.Add(btnStar4);
            pnlTabWrite.Controls.Add(btnStar5);
            pnlTabWrite.Controls.Add(lblCommentCaption);
            pnlTabWrite.Controls.Add(tbComment);
            pnlTabWrite.Controls.Add(btnSubmitReview);
            pnlTabWrite.Controls.Add(lblCannotReview);
            pnlTabWrite.FillColor = Color.White;
            pnlTabWrite.Location = new Point(30, 252);
            pnlTabWrite.Name = "pnlTabWrite";
            pnlTabWrite.Size = new Size(1440, 520);
            pnlTabWrite.TabIndex = 6;
            pnlTabWrite.Visible = false;
            //
            // lblWriteTitle
            //
            lblWriteTitle.BackColor = Color.Transparent;
            lblWriteTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWriteTitle.ForeColor = Color.FromArgb(60, 50, 45);
            lblWriteTitle.Location = new Point(24, 20);
            lblWriteTitle.Name = "lblWriteTitle";
            lblWriteTitle.Size = new Size(600, 28);
            lblWriteTitle.TabIndex = 0;
            lblWriteTitle.Text = "Write a Review";
            //
            // lblWriteSubtitle
            //
            lblWriteSubtitle.BackColor = Color.Transparent;
            lblWriteSubtitle.Font = new Font("Segoe UI", 9F);
            lblWriteSubtitle.ForeColor = Color.FromArgb(154, 136, 128);
            lblWriteSubtitle.Location = new Point(24, 50);
            lblWriteSubtitle.Name = "lblWriteSubtitle";
            lblWriteSubtitle.Size = new Size(700, 22);
            lblWriteSubtitle.TabIndex = 1;
            lblWriteSubtitle.Text = "Share your experience to help other parents in the community.";
            //
            // lblOverallCaption
            //
            lblOverallCaption.BackColor = Color.Transparent;
            lblOverallCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOverallCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblOverallCaption.Location = new Point(24, 92);
            lblOverallCaption.Name = "lblOverallCaption";
            lblOverallCaption.Size = new Size(300, 22);
            lblOverallCaption.TabIndex = 2;
            lblOverallCaption.Text = "Overall Rating *";
            //
            // btnStar1
            //
            btnStar1.BackColor = Color.Transparent;
            btnStar1.BorderRadius = 8;
            btnStar1.FillColor = Color.White;
            btnStar1.Font = new Font("Segoe UI", 18F);
            btnStar1.ForeColor = Color.FromArgb(200, 190, 185);
            btnStar1.Location = new Point(24, 118);
            btnStar1.Name = "btnStar1";
            btnStar1.Size = new Size(50, 50);
            btnStar1.TabIndex = 3;
            btnStar1.Tag = "1";
            btnStar1.Text = "☆";
            btnStar1.Click += btnStar_Click;
            //
            // btnStar2
            //
            btnStar2.BackColor = Color.Transparent;
            btnStar2.BorderRadius = 8;
            btnStar2.FillColor = Color.White;
            btnStar2.Font = new Font("Segoe UI", 18F);
            btnStar2.ForeColor = Color.FromArgb(200, 190, 185);
            btnStar2.Location = new Point(80, 118);
            btnStar2.Name = "btnStar2";
            btnStar2.Size = new Size(50, 50);
            btnStar2.TabIndex = 4;
            btnStar2.Tag = "2";
            btnStar2.Text = "☆";
            btnStar2.Click += btnStar_Click;
            //
            // btnStar3
            //
            btnStar3.BackColor = Color.Transparent;
            btnStar3.BorderRadius = 8;
            btnStar3.FillColor = Color.White;
            btnStar3.Font = new Font("Segoe UI", 18F);
            btnStar3.ForeColor = Color.FromArgb(200, 190, 185);
            btnStar3.Location = new Point(136, 118);
            btnStar3.Name = "btnStar3";
            btnStar3.Size = new Size(50, 50);
            btnStar3.TabIndex = 5;
            btnStar3.Tag = "3";
            btnStar3.Text = "☆";
            btnStar3.Click += btnStar_Click;
            //
            // btnStar4
            //
            btnStar4.BackColor = Color.Transparent;
            btnStar4.BorderRadius = 8;
            btnStar4.FillColor = Color.White;
            btnStar4.Font = new Font("Segoe UI", 18F);
            btnStar4.ForeColor = Color.FromArgb(200, 190, 185);
            btnStar4.Location = new Point(192, 118);
            btnStar4.Name = "btnStar4";
            btnStar4.Size = new Size(50, 50);
            btnStar4.TabIndex = 6;
            btnStar4.Tag = "4";
            btnStar4.Text = "☆";
            btnStar4.Click += btnStar_Click;
            //
            // btnStar5
            //
            btnStar5.BackColor = Color.Transparent;
            btnStar5.BorderRadius = 8;
            btnStar5.FillColor = Color.White;
            btnStar5.Font = new Font("Segoe UI", 18F);
            btnStar5.ForeColor = Color.FromArgb(200, 190, 185);
            btnStar5.Location = new Point(248, 118);
            btnStar5.Name = "btnStar5";
            btnStar5.Size = new Size(50, 50);
            btnStar5.TabIndex = 7;
            btnStar5.Tag = "5";
            btnStar5.Text = "☆";
            btnStar5.Click += btnStar_Click;
            //
            // lblCommentCaption
            //
            lblCommentCaption.BackColor = Color.Transparent;
            lblCommentCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCommentCaption.ForeColor = Color.FromArgb(60, 50, 45);
            lblCommentCaption.Location = new Point(24, 188);
            lblCommentCaption.Name = "lblCommentCaption";
            lblCommentCaption.Size = new Size(300, 22);
            lblCommentCaption.TabIndex = 8;
            lblCommentCaption.Text = "Your Review";
            //
            // tbComment
            //
            tbComment.BorderRadius = 10;
            tbComment.DefaultText = "";
            tbComment.FillColor = Color.FromArgb(247, 245, 242);
            tbComment.FocusedState.BorderColor = Color.FromArgb(232, 113, 74);
            tbComment.Font = new Font("Segoe UI", 9.5F);
            tbComment.Location = new Point(24, 214);
            tbComment.Multiline = true;
            tbComment.Name = "tbComment";
            tbComment.PlaceholderText = "Tell other parents about your experience. Was the babysitter punctual? How did the children respond? Would you book again?";
            tbComment.SelectedText = "";
            tbComment.Size = new Size(900, 140);
            tbComment.TabIndex = 9;
            //
            // btnSubmitReview
            //
            btnSubmitReview.BackColor = Color.Transparent;
            btnSubmitReview.BorderRadius = 10;
            btnSubmitReview.FillColor = Color.FromArgb(232, 113, 74);
            btnSubmitReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmitReview.ForeColor = Color.White;
            btnSubmitReview.Location = new Point(24, 372);
            btnSubmitReview.Name = "btnSubmitReview";
            btnSubmitReview.Size = new Size(240, 48);
            btnSubmitReview.TabIndex = 10;
            btnSubmitReview.Text = "Submit Review";
            btnSubmitReview.Click += btnSubmitReview_Click;
            //
            // lblCannotReview
            //
            lblCannotReview.BackColor = Color.Transparent;
            lblCannotReview.Font = new Font("Segoe UI", 10F);
            lblCannotReview.ForeColor = Color.FromArgb(154, 136, 128);
            lblCannotReview.Location = new Point(24, 92);
            lblCannotReview.Name = "lblCannotReview";
            lblCannotReview.Size = new Size(900, 30);
            lblCannotReview.TabIndex = 11;
            lblCannotReview.Text = "You can write a review after a finished booking with this babysitter.";
            lblCannotReview.Visible = false;
            //
            // BabysitterProfileForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 900);
            Controls.Add(pnlPageBackground);
            MinimumSize = new Size(1246, 738);
            Name = "BabysitterProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meraki - Babysitter Profile";
            Load += BabysitterProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)picNavLogo).EndInit();
            pnlTabWrite.ResumeLayout(false);
            pnlTabReviews.ResumeLayout(false);
            pnlTabAbout.ResumeLayout(false);
            pnlAvatar.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlProfileHeaderCard;
        private Guna.UI2.WinForms.Guna2Panel pnlAvatar;
        private System.Windows.Forms.Label lblAvatarInitial;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblRatingSummary;
        private System.Windows.Forms.Label lblRate;
        private Guna.UI2.WinForms.Guna2Button btnBookNow;
        private Guna.UI2.WinForms.Guna2Button btnTabAbout;
        private Guna.UI2.WinForms.Guna2Button btnTabReviews;
        private Guna.UI2.WinForms.Guna2Button btnTabWrite;
        private Guna.UI2.WinForms.Guna2Panel pnlTabAbout;
        private System.Windows.Forms.Label lblAboutTitle;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Label lblSkillsTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSkills;
        private Guna.UI2.WinForms.Guna2Panel pnlTabReviews;
        private System.Windows.Forms.FlowLayoutPanel flpReviews;
        private Guna.UI2.WinForms.Guna2Panel pnlTabWrite;
        private System.Windows.Forms.Label lblWriteTitle;
        private System.Windows.Forms.Label lblWriteSubtitle;
        private System.Windows.Forms.Label lblOverallCaption;
        private Guna.UI2.WinForms.Guna2Button btnStar1;
        private Guna.UI2.WinForms.Guna2Button btnStar2;
        private Guna.UI2.WinForms.Guna2Button btnStar3;
        private Guna.UI2.WinForms.Guna2Button btnStar4;
        private Guna.UI2.WinForms.Guna2Button btnStar5;
        private System.Windows.Forms.Label lblCommentCaption;
        private Guna.UI2.WinForms.Guna2TextBox tbComment;
        private Guna.UI2.WinForms.Guna2Button btnSubmitReview;
        private System.Windows.Forms.Label lblCannotReview;
    }
}
