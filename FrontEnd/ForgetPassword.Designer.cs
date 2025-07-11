﻿namespace FrontEnd
{
    using FrontEnd.Resources;
    partial class ForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            txtpassword = new TextBox();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            btnLogin = new Button();
            button1 = new Button();
            lbBack = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(96, 73);
            label1.Name = "label1";
            label1.Size = new Size(206, 24);
            label1.TabIndex = 3;
            label1.Text = "FORGET PASSWORD";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Do_An.Properties.Resources.logo;
            pictureBox1.Location = new Point(157, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(0, 64, 64);
            txtUsername.Location = new Point(85, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(251, 17);
            txtUsername.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Location = new Point(58, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 1);
            panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Do_An.Properties.Resources.user;
            pictureBox2.Location = new Point(58, 93);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // txtpassword
            // 
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.ForeColor = Color.FromArgb(0, 64, 64);
            txtpassword.Location = new Point(85, 146);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(140, 17);
            txtpassword.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Location = new Point(58, 176);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 1);
            panel2.TabIndex = 11;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(58, 139);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(21, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 64, 64);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(231, 146);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(105, 24);
            btnLogin.TabIndex = 16;
            btnLogin.Text = "GET OTP";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(108, 188);
            button1.Name = "button1";
            button1.Size = new Size(171, 25);
            button1.TabIndex = 17;
            button1.Text = "CHANGE PASSWORD";
            button1.UseVisualStyleBackColor = false;
            // 
            // lbBack
            // 
            lbBack.AutoSize = true;
            lbBack.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBack.ForeColor = Color.FromArgb(0, 64, 64);
            lbBack.Location = new Point(173, 216);
            lbBack.Name = "lbBack";
            lbBack.Size = new Size(52, 25);
            lbBack.TabIndex = 18;
            lbBack.Text = "Back";
            lbBack.Click += lbBack_Click;
            // 
            // ForgetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 250);
            Controls.Add(lbBack);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(txtpassword);
            Controls.Add(panel2);
            Controls.Add(pictureBox3);
            Controls.Add(txtUsername);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgetPassword";
            Text = "ForgetPassword";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private Panel panel1;
        private PictureBox pictureBox2;
        private TextBox txtpassword;
        private Panel panel2;
        private PictureBox pictureBox3;
        private Button btnLogin;
        private Button button1;
        private Label lbBack;
    }
}