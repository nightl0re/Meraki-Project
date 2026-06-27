using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class Form2 : Form
    {
        // Define your palette
        Color Primary = ColorTranslator.FromHtml("#E8713C");
        Color Background = ColorTranslator.FromHtml("#F2EDE4");
        Color Surface = ColorTranslator.FromHtml("#EDE8DF");
        Color TextBox = ColorTranslator.FromHtml("#FAF8F5");
        Color TextDark = ColorTranslator.FromHtml("#2C2C2C");
        Color TextHint = ColorTranslator.FromHtml("#A89F94");

        string role;
        string phone_number;
        string password;
        string name;
        string surname;
        string email;
        public Form2()
        {
            InitializeComponent();


            //Form Changes
            this.BackColor = Background;
            this.Resize += Form2_Resize;
            this.Font = new Font("Segoe UI", 9f, FontStyle.Regular);



            // Panel Changes
            panel_Registration.BackColor = Background;
            panel_Registration.Location = new Point(
                (this.ClientSize.Width - panel_Registration.Width) / 2,
                (this.ClientSize.Height - panel_Registration.Height) / 2);
            panel_Registration.Paint += panel_Registration_Paint;




            //Radio Button Changes
            foreach (RadioButton rb in new[] { rb_Parent, rb_Babysitter })
            {
                //rb.AutoSize = false;
                //rb.Height = 22;
                //rb.Width = 100;        // подстрой под текст
                rb.FlatStyle = FlatStyle.Flat;  // ← это ключевое! убирает дефолтный рендер
                rb.Paint += rb_Paint;
            }
            rb_Parent.BackColor = Surface;
            rb_Parent.ForeColor = TextDark;
            rb_Parent.FlatStyle = FlatStyle.Standard;
            rb_Babysitter.BackColor = Surface;
            rb_Babysitter.ForeColor = TextDark;

            rb_Babysitter.CheckedChanged += rb_CheckedChanged;
            rb_Parent.CheckedChanged += rb_CheckedChanged;


            //TextBox and Label Changes
            tb_Email.BackColor = TextBox;
            tb_Password.BackColor = TextBox;
            tb_PhoneNumber.BackColor = TextBox;
            tb_ConfirmPassword.BackColor = TextBox;
            lbl_MerakiTitle.ForeColor = Primary;


            // GroupBox Changes
            gb_PasswordSetup.Paint += gb_LoginDetails_Paint;
            gb_PersonalDetails.Paint += gb_LoginDetails_Paint;

            //Button Changes
            btn_CreateAccount.BackColor = Primary;
            btn_CreateAccount.ForeColor = Color.White;
            btn_CreateAccount.FlatStyle = FlatStyle.Flat;
            btn_CreateAccount.FlatAppearance.BorderSize = 0;        // removes border
            btn_CreateAccount.TabStop = false;                       // prevents focus outline
            btn_Cancel.BackColor = ColorTranslator.FromHtml("#E0DAD2");
            btn_Cancel.FlatStyle = FlatStyle.Flat;
            btn_Cancel.FlatAppearance.BorderSize = 0;        // removes border
            btn_Cancel.TabStop = false;

        }

        private void cb_Agreement_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            panel_Registration.Location = new Point(
                (this.ClientSize.Width - panel_Registration.Width) / 2,
                (this.ClientSize.Height - panel_Registration.Height) / 2);
        }

        private void panel_Registration_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            Color borderColor = ColorTranslator.FromHtml("#D9D3C8");

            Pen borderPen = new Pen(borderColor, 1.5f);
            e.Graphics.DrawRectangle(borderPen,
                0, 0,
                pnl.Width - 1,   // -1 so it doesn't get clipped
                pnl.Height - 1);
        }

        private void rb_Paint(object sender, PaintEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            // 1. Закрасить весь фон (перекрывает оригинальный кружок)
            e.Graphics.FillRectangle(
                new SolidBrush(ColorTranslator.FromHtml("#F2EDE4")),
                rb.ClientRectangle);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color outerRing = ColorTranslator.FromHtml("#2C2C2C");
            int size = 14;
            int x = 2;
            int y = (rb.Height - size) / 2;

            // 2. Нарисовать свой кружок
            e.Graphics.DrawEllipse(new Pen(outerRing, 1.5f), x, y, size, size);

            // 3. Оранжевая точка если выбран
            if (rb.Checked)
            {
                e.Graphics.FillEllipse(
                    new SolidBrush(ColorTranslator.FromHtml("#E8713C")),
                    x + 3, y + 3, size - 6, size - 6);
            }

            // 4. Текст вручную
            TextRenderer.DrawText(
                e.Graphics,
                rb.Text,
                rb.Font,
                new Rectangle(x + size + 6, 0, rb.Width, rb.Height), // весь height
                rb.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void gb_LoginDetails_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            Color borderColor = ColorTranslator.FromHtml("#D9D3C8");
            Color titleColor = ColorTranslator.FromHtml("#E8713C"); // orange label
            Color backColor = ColorTranslator.FromHtml("#EDE8DF");

            // Background
            e.Graphics.FillRectangle(new SolidBrush(Background), box.ClientRectangle);

            // Measure title text
            SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);

            // Draw border (skip top-left where title sits)
            int titleOffset = 10;
            Pen borderPen = new Pen(borderColor, 1.5f);

            // Top-left segment before text
            e.Graphics.DrawLine(borderPen, 0, 8, titleOffset, 8);
            // Top-right segment after text
            e.Graphics.DrawLine(borderPen, titleOffset + textSize.Width + 4, 8,
                                box.Width - 1, 8);
            // Left, bottom, right
            e.Graphics.DrawLine(borderPen, 0, 8, 0, box.Height - 1);
            e.Graphics.DrawLine(borderPen, 0, box.Height - 1, box.Width - 1, box.Height - 1);
            e.Graphics.DrawLine(borderPen, box.Width - 1, 8, box.Width - 1, box.Height - 1);

            // Draw title text in orange
            e.Graphics.DrawString(box.Text, box.Font,
                                  new SolidBrush(titleColor),
                                  titleOffset + 2, 0);
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                role = rb.Text;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?[0-9\s\-]{10,15}$");
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            


            if (tb_FirstName.Text.Length >= 2 && tb_LastName.Text.Length >= 2) {
                password = tb_Password.Text;

               
                    if (IsValidEmail(tb_Email.Text))
                    {
                        if (tb_Password.Text.Length >= 6)
                        {

                            if (tb_ConfirmPassword.Text == tb_Password.Text)
                            {


                                if (IsValidPhone(tb_PhoneNumber.Text))
                                {
                                    if (cb_Agreement.Checked)
                                    {
                                        phone_number = tb_PhoneNumber.Text;
                                        name = tb_FirstName.Text;
                                        surname = tb_LastName.Text;
                                        email = tb_Email.Text;
                                    MessageBox.Show("Account created successfully!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("You must agree to the terms and conditions.");
                                        cb_Agreement.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid phone number.");
                                    tb_PhoneNumber.Focus();
                                    return;
                                }


                            }
                            else
                            {
                                MessageBox.Show("Passwords do not match.");
                                tb_ConfirmPassword.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password must contain at least 6 characters.");
                            tb_Password.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email format.");
                        tb_Email.Focus();
                        return;
                    }
                

            }
            else
            {
                MessageBox.Show("Please enter a valid name and surname. Characters must be at least 2.");
                tb_FirstName.Focus();
                return;
            }

           
            
            
        }
    }
}
