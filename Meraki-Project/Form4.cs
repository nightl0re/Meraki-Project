using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Meraki_Project
{
    public partial class Form4 : Form
    {
        Color orange = Color.FromArgb(231, 111, 69);
        Guna2Button prev_button;
        string role = "";

        public Form4()
        {
            InitializeComponent();

            this.Resize += Form4_Resize;
            prev_button = btnParent;
            role = btnParent.Text;
            btnParent.FillColor = Color.White;
            btnParent.ForeColor = orange;

            // Set the form's background shadows

            gunaPanel.ShadowDecoration.Enabled = true;
            gunaPanel.ShadowDecoration.Color = Color.FromArgb(1, 100, 100, 100);
            gunaPanel.ShadowDecoration.Depth = 2;
            gunaPanel.ShadowDecoration.BorderRadius = 24;


            // Setting roles button event handlers

            btnBabysitter.Click += guna2Button1_Click;
            btnAdmin.Click += guna2Button1_Click;
            prev_button = btnParent;

            // Configure the register link label

            lblRegisterLink.Text =
    "<span style=\"color:#9A8880;\">Don't have an account? </span>" +
    "<a href=\"register\" style=\"color:#5BB8A8;font-weight:bold;\">Create Account</a>";
            lblRegisterLink.LinkClicked += (s, e) =>
            {
                if (e.Link == "Register")
                {
                    //this.Hide();
                }
            };


            // textbox for password
            tbPassword.UseSystemPasswordChar = true;





            // Textbox changing
            foreach (var txt in new[] { tbEmail, tbPassword })
            {
                txt.FocusedState.BorderColor = ColorTranslator.FromHtml("#E07050");
                txt.HoverState.BorderColor = ColorTranslator.FromHtml("#E07050");
                txt.BorderThickness = 1;
            }
        }



        // Resize event for the form to re-center buttons when the form size changes
        private void Form4_Resize(object? sender, EventArgs e)
        {
            CenterButtonsInContainer();
            CenterPanel();
        }

        // Method to center buttons of roles in the container
        private void CenterButtonsInContainer()
        {
            // Your 3 buttons — change names to match yours
            Guna2Button[] buttons = { btnParent, btnBabysitter, btnAdmin };

            int gap = 3;
            int totalWidth = 0;

            // Calculate total width of all buttons + gaps
            foreach (var btn in buttons)
            {
                totalWidth += btn.Width;
                SyncHoverState(btn); // Ensure hover state matches the default state
                btn.Cursor = Cursors.Hand;

            }
            totalWidth += gap * (buttons.Length - 1);
            // Starting X to center the group inside the container
            int startX = (containerRoles.Width - totalWidth) / 2;
            int currentX = startX;

            // Vertical center
            int centerY = (containerRoles.Height - buttons[0].Height) / 2;

            // Position each button
            foreach (var btn in buttons)
            {
                btn.Location = new Point(currentX, centerY);
                currentX += btn.Width + gap;
            }
        }


        private void SyncHoverState(Guna2Button btn)
        {
            btn.HoverState.FillColor = btn.FillColor;
            btn.HoverState.ForeColor = btn.ForeColor;
            btn.HoverState.BorderColor = btn.BorderColor;
        }



        // Loading event for the form to center buttons initially
        private void Form4_Load(object sender, EventArgs e)
        {
            CenterButtonsInContainer();
            CenterPanel();
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        // Clicks on the roles buttons to change their colors and set the role variable
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            // Ensure hover state matches the default state
            if (prev_button != btn)
            {
                btn.FillColor = Color.White;
                btn.ForeColor = orange;
                role = btn.Text;
                prev_button.FillColor = Color.FromArgb(253, 240, 235);
                prev_button.ForeColor = Color.FromArgb(154, 136, 128);
                SyncHoverState(prev_button);
                SyncHoverState(btn);
                prev_button = btn;

            }
        }

        private void CenterPanel()
        {
            gunaPanel.Location = new Point(
                (this.ClientSize.Width - gunaPanel.Width) / 2,
                (this.ClientSize.Height - gunaPanel.Height) / 2
            );
        }


        private bool isPasswordVisible = false;

        private void tbPassword_IconRightClick(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.IconRight = Properties.Resources.eye_closed; // swap to "open eye" icon
            }

            else
            {
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.IconRight = Properties.Resources.eye_open; // swap back to "closed eye" icon
            }
        }

    }

}
