namespace Meraki_Project
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel_Registration = new Panel();
            label4 = new Label();
            cb_Agreement = new CheckBox();
            gb_PasswordSetup = new GroupBox();
            tb_ConfirmPassword = new TextBox();
            lbl_ConfirmPassword = new Label();
            tb_Password = new TextBox();
            lbl_Password = new Label();
            label5 = new Label();
            btn_Cancel = new Button();
            gb_PersonalDetails = new GroupBox();
            tb_LastName = new TextBox();
            lbl_LastName = new Label();
            tb_FirstName = new TextBox();
            lbl_FirstName = new Label();
            tb_PhoneNumber = new TextBox();
            lbl_PhoneNumber = new Label();
            tb_Email = new TextBox();
            lbl_email = new Label();
            btn_CreateAccount = new Button();
            gb_Role = new GroupBox();
            rb_Babysitter = new RadioButton();
            rb_Parent = new RadioButton();
            lbl_MerakiTitle = new Label();
            pictureBox1 = new PictureBox();
            panel_Registration.SuspendLayout();
            gb_PasswordSetup.SuspendLayout();
            gb_PersonalDetails.SuspendLayout();
            gb_Role.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_Registration
            // 
            panel_Registration.BackColor = Color.WhiteSmoke;
            panel_Registration.Controls.Add(label4);
            panel_Registration.Controls.Add(cb_Agreement);
            panel_Registration.Controls.Add(gb_PasswordSetup);
            panel_Registration.Controls.Add(label5);
            panel_Registration.Controls.Add(btn_Cancel);
            panel_Registration.Controls.Add(gb_PersonalDetails);
            panel_Registration.Controls.Add(btn_CreateAccount);
            panel_Registration.Controls.Add(gb_Role);
            panel_Registration.Controls.Add(lbl_MerakiTitle);
            panel_Registration.Controls.Add(pictureBox1);
            panel_Registration.ImeMode = ImeMode.On;
            panel_Registration.Location = new Point(123, 12);
            panel_Registration.Name = "panel_Registration";
            panel_Registration.Size = new Size(546, 896);
            panel_Registration.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.LightGray;
            label4.Location = new Point(38, 799);
            label4.Name = "label4";
            label4.Size = new Size(458, 1);
            label4.TabIndex = 8;
            label4.Text = "label4";
            // 
            // cb_Agreement
            // 
            cb_Agreement.AutoSize = true;
            cb_Agreement.Location = new Point(38, 751);
            cb_Agreement.Name = "cb_Agreement";
            cb_Agreement.Size = new Size(242, 24);
            cb_Agreement.TabIndex = 7;
            cb_Agreement.Text = "I agree to Terms and Conditions";
            cb_Agreement.UseVisualStyleBackColor = true;
            cb_Agreement.CheckedChanged += cb_Agreement_CheckedChanged;
            // 
            // gb_PasswordSetup
            // 
            gb_PasswordSetup.Controls.Add(tb_ConfirmPassword);
            gb_PasswordSetup.Controls.Add(lbl_ConfirmPassword);
            gb_PasswordSetup.Controls.Add(tb_Password);
            gb_PasswordSetup.Controls.Add(lbl_Password);
            gb_PasswordSetup.Location = new Point(38, 524);
            gb_PasswordSetup.Name = "gb_PasswordSetup";
            gb_PasswordSetup.Size = new Size(458, 208);
            gb_PasswordSetup.TabIndex = 5;
            gb_PasswordSetup.TabStop = false;
            gb_PasswordSetup.Text = "Password Setup";
            // 
            // tb_ConfirmPassword
            // 
            tb_ConfirmPassword.Location = new Point(20, 154);
            tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            tb_ConfirmPassword.PasswordChar = '*';
            tb_ConfirmPassword.PlaceholderText = "Password";
            tb_ConfirmPassword.Size = new Size(415, 27);
            tb_ConfirmPassword.TabIndex = 3;
            tb_ConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lbl_ConfirmPassword
            // 
            lbl_ConfirmPassword.AutoSize = true;
            lbl_ConfirmPassword.BackColor = Color.Transparent;
            lbl_ConfirmPassword.Location = new Point(20, 121);
            lbl_ConfirmPassword.Name = "lbl_ConfirmPassword";
            lbl_ConfirmPassword.Size = new Size(127, 20);
            lbl_ConfirmPassword.TabIndex = 2;
            lbl_ConfirmPassword.Text = "Confirm Password";
            // 
            // tb_Password
            // 
            tb_Password.Location = new Point(20, 71);
            tb_Password.Name = "tb_Password";
            tb_Password.Size = new Size(415, 27);
            tb_Password.TabIndex = 1;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.BackColor = Color.Transparent;
            lbl_Password.Location = new Point(19, 39);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(70, 20);
            lbl_Password.TabIndex = 0;
            lbl_Password.Text = "Password";
            // 
            // label5
            // 
            label5.BackColor = Color.LightGray;
            label5.Location = new Point(38, 118);
            label5.Name = "label5";
            label5.Size = new Size(458, 1);
            label5.TabIndex = 5;
            label5.Text = "label5";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(369, 829);
            btn_Cancel.Margin = new Padding(0);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(127, 39);
            btn_Cancel.TabIndex = 6;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // gb_PersonalDetails
            // 
            gb_PersonalDetails.Controls.Add(tb_LastName);
            gb_PersonalDetails.Controls.Add(lbl_LastName);
            gb_PersonalDetails.Controls.Add(tb_FirstName);
            gb_PersonalDetails.Controls.Add(lbl_FirstName);
            gb_PersonalDetails.Controls.Add(tb_PhoneNumber);
            gb_PersonalDetails.Controls.Add(lbl_PhoneNumber);
            gb_PersonalDetails.Controls.Add(tb_Email);
            gb_PersonalDetails.Controls.Add(lbl_email);
            gb_PersonalDetails.Location = new Point(38, 221);
            gb_PersonalDetails.Name = "gb_PersonalDetails";
            gb_PersonalDetails.Size = new Size(458, 297);
            gb_PersonalDetails.TabIndex = 4;
            gb_PersonalDetails.TabStop = false;
            gb_PersonalDetails.Text = "Personal Information";
            // 
            // tb_LastName
            // 
            tb_LastName.Location = new Point(235, 82);
            tb_LastName.Name = "tb_LastName";
            tb_LastName.PlaceholderText = "Rusl";
            tb_LastName.Size = new Size(200, 27);
            tb_LastName.TabIndex = 7;
            // 
            // lbl_LastName
            // 
            lbl_LastName.AutoSize = true;
            lbl_LastName.BackColor = Color.Transparent;
            lbl_LastName.Location = new Point(235, 50);
            lbl_LastName.Name = "lbl_LastName";
            lbl_LastName.Size = new Size(82, 20);
            lbl_LastName.TabIndex = 6;
            lbl_LastName.Text = "Last Name:";
            // 
            // tb_FirstName
            // 
            tb_FirstName.Location = new Point(19, 82);
            tb_FirstName.Name = "tb_FirstName";
            tb_FirstName.PlaceholderText = "John";
            tb_FirstName.Size = new Size(201, 27);
            tb_FirstName.TabIndex = 5;
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.BackColor = Color.Transparent;
            lbl_FirstName.Location = new Point(19, 50);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(83, 20);
            lbl_FirstName.TabIndex = 4;
            lbl_FirstName.Text = "First Name:";
            // 
            // tb_PhoneNumber
            // 
            tb_PhoneNumber.Location = new Point(19, 247);
            tb_PhoneNumber.Name = "tb_PhoneNumber";
            tb_PhoneNumber.PasswordChar = '*';
            tb_PhoneNumber.PlaceholderText = "+998 (99) 000-00-00";
            tb_PhoneNumber.Size = new Size(415, 27);
            tb_PhoneNumber.TabIndex = 3;
            tb_PhoneNumber.UseSystemPasswordChar = true;
            // 
            // lbl_PhoneNumber
            // 
            lbl_PhoneNumber.AutoSize = true;
            lbl_PhoneNumber.BackColor = Color.Transparent;
            lbl_PhoneNumber.Location = new Point(20, 210);
            lbl_PhoneNumber.Name = "lbl_PhoneNumber";
            lbl_PhoneNumber.Size = new Size(108, 20);
            lbl_PhoneNumber.TabIndex = 2;
            lbl_PhoneNumber.Text = "Phone Number";
            // 
            // tb_Email
            // 
            tb_Email.Location = new Point(20, 167);
            tb_Email.Name = "tb_Email";
            tb_Email.PlaceholderText = "john@gmail.com";
            tb_Email.Size = new Size(415, 27);
            tb_Email.TabIndex = 1;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Location = new Point(20, 135);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(46, 20);
            lbl_email.TabIndex = 0;
            lbl_email.Text = "Email";
            lbl_email.Click += lbl_email_Click;
            // 
            // btn_CreateAccount
            // 
            btn_CreateAccount.Location = new Point(38, 829);
            btn_CreateAccount.Margin = new Padding(0);
            btn_CreateAccount.Name = "btn_CreateAccount";
            btn_CreateAccount.Size = new Size(316, 39);
            btn_CreateAccount.TabIndex = 5;
            btn_CreateAccount.Text = "Create Account";
            btn_CreateAccount.UseVisualStyleBackColor = true;
            btn_CreateAccount.Click += btn_CreateAccount_Click;
            // 
            // gb_Role
            // 
            gb_Role.Controls.Add(rb_Babysitter);
            gb_Role.Controls.Add(rb_Parent);
            gb_Role.Location = new Point(38, 131);
            gb_Role.Name = "gb_Role";
            gb_Role.Size = new Size(458, 84);
            gb_Role.TabIndex = 3;
            gb_Role.TabStop = false;
            gb_Role.Text = "Account Type";
            // 
            // rb_Babysitter
            // 
            rb_Babysitter.AutoSize = true;
            rb_Babysitter.BackColor = Color.Transparent;
            rb_Babysitter.Location = new Point(157, 41);
            rb_Babysitter.Name = "rb_Babysitter";
            rb_Babysitter.Size = new Size(141, 24);
            rb_Babysitter.TabIndex = 1;
            rb_Babysitter.TabStop = true;
            rb_Babysitter.Text = "I am a Babysitter";
            rb_Babysitter.UseVisualStyleBackColor = false;
            // 
            // rb_Parent
            // 
            rb_Parent.AutoSize = true;
            rb_Parent.BackColor = Color.Transparent;
            rb_Parent.Location = new Point(20, 41);
            rb_Parent.Name = "rb_Parent";
            rb_Parent.Size = new Size(116, 24);
            rb_Parent.TabIndex = 0;
            rb_Parent.TabStop = true;
            rb_Parent.Text = "I am a Parent";
            rb_Parent.UseVisualStyleBackColor = false;
            // 
            // lbl_MerakiTitle
            // 
            lbl_MerakiTitle.AutoSize = true;
            lbl_MerakiTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MerakiTitle.Location = new Point(109, 60);
            lbl_MerakiTitle.Name = "lbl_MerakiTitle";
            lbl_MerakiTitle.Size = new Size(332, 31);
            lbl_MerakiTitle.TabIndex = 1;
            lbl_MerakiTitle.Text = "Meraki - New User Registration";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 977);
            Controls.Add(panel_Registration);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            panel_Registration.ResumeLayout(false);
            panel_Registration.PerformLayout();
            gb_PasswordSetup.ResumeLayout(false);
            gb_PasswordSetup.PerformLayout();
            gb_PersonalDetails.ResumeLayout(false);
            gb_PersonalDetails.PerformLayout();
            gb_Role.ResumeLayout(false);
            gb_Role.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Registration;
        private Label label5;
        private GroupBox gb_PersonalDetails;
        private Button btn_Cancel;
        private Button btn_CreateAccount;
        private TextBox tb_PhoneNumber;
        private Label lbl_PhoneNumber;
        private TextBox tb_Email;
        private Label lbl_email;
        private GroupBox gb_Role;
        private RadioButton rb_Babysitter;
        private RadioButton rb_Parent;
        private Label lbl_MerakiTitle;
        private PictureBox pictureBox1;
        private GroupBox gb_PasswordSetup;
        private TextBox tb_ConfirmPassword;
        private Label lbl_ConfirmPassword;
        private TextBox tb_Password;
        private Label lbl_Password;
        private CheckBox cb_Agreement;
        private Label label4;
        private TextBox tb_FirstName;
        private Label lbl_FirstName;
        private Label lbl_LastName;
        private TextBox tb_LastName;
    }
}