namespace FrontEnd
{
    partial class Signin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signin));
            txtUsername = new TextBox();
            lbExit = new Label();
            lbClear = new Label();
            btnSignin = new Button();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtpassword = new TextBox();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            txtConfirmedPassword = new TextBox();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(0, 64, 64);
            txtUsername.Location = new Point(55, 165);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(209, 24);
            txtUsername.TabIndex = 19;
            txtUsername.KeyPress += txtUsername_KeyPress;
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbExit.ForeColor = Color.FromArgb(0, 64, 64);
            lbExit.Location = new Point(126, 402);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(32, 16);
            lbExit.TabIndex = 16;
            lbExit.Text = "Exit";
            lbExit.Click += lbExit_Click;
            // 
            // lbClear
            // 
            lbClear.AutoSize = true;
            lbClear.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClear.ForeColor = Color.FromArgb(0, 64, 64);
            lbClear.Location = new Point(178, 336);
            lbClear.Name = "lbClear";
            lbClear.Size = new Size(86, 16);
            lbClear.TabIndex = 17;
            lbClear.Text = "Clear fields";
            lbClear.Click += lbClear_Click;
            // 
            // btnSignin
            // 
            btnSignin.BackColor = Color.FromArgb(0, 64, 64);
            btnSignin.FlatAppearance.BorderSize = 0;
            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignin.ForeColor = Color.White;
            btnSignin.Location = new Point(28, 364);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(236, 35);
            btnSignin.TabIndex = 15;
            btnSignin.Text = "SIGN IN";
            btnSignin.UseVisualStyleBackColor = false;
            btnSignin.Click += btnSignin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Location = new Point(28, 195);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 1);
            panel1.TabIndex = 14;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Do_An.Properties.Resources.user;
            pictureBox2.Location = new Point(28, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(78, 116);
            label1.Name = "label1";
            label1.Size = new Size(123, 36);
            label1.TabIndex = 10;
            label1.Text = "SIGN IN";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Do_An.Properties.Resources.logo;
            pictureBox1.Location = new Point(62, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 143);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // txtpassword
            // 
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.ForeColor = Color.FromArgb(0, 64, 64);
            txtpassword.Location = new Point(55, 217);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(209, 24);
            txtpassword.TabIndex = 22;
            txtpassword.KeyPress += txtpassword_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Location = new Point(28, 247);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 1);
            panel2.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(28, 210);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(21, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // txtConfirmedPassword
            // 
            txtConfirmedPassword.BorderStyle = BorderStyle.None;
            txtConfirmedPassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConfirmedPassword.ForeColor = Color.FromArgb(0, 64, 64);
            txtConfirmedPassword.Location = new Point(55, 276);
            txtConfirmedPassword.Multiline = true;
            txtConfirmedPassword.Name = "txtConfirmedPassword";
            txtConfirmedPassword.PasswordChar = '*';
            txtConfirmedPassword.Size = new Size(209, 24);
            txtConfirmedPassword.TabIndex = 25;
            txtConfirmedPassword.KeyPress += txtConfirmedPassword_KeyPress;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Location = new Point(28, 306);
            panel3.Name = "panel3";
            panel3.Size = new Size(236, 1);
            panel3.TabIndex = 24;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(28, 269);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(21, 31);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 23;
            pictureBox4.TabStop = false;
            // 
            // Signin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(292, 425);
            Controls.Add(txtConfirmedPassword);
            Controls.Add(panel3);
            Controls.Add(pictureBox4);
            Controls.Add(txtpassword);
            Controls.Add(panel2);
            Controls.Add(pictureBox3);
            Controls.Add(txtUsername);
            Controls.Add(lbExit);
            Controls.Add(lbClear);
            Controls.Add(btnSignin);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Signin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signin";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private Label lbExit;
        private Label lbClear;
        private Button btnSignin;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtpassword;
        private Panel panel2;
        private PictureBox pictureBox3;
        private TextBox txtConfirmedPassword;
        private Panel panel3;
        private PictureBox pictureBox4;
    }
}