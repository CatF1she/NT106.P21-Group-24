namespace FrontEnd.Resources
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            btnLogin = new Button();
            lbClear = new Label();
            lbExit = new Label();
            txtUsername = new TextBox();
            txtpassword = new TextBox();
            lbSignIn = new Label();
            ForgetPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Do_An.Properties.Resources.logo;
            pictureBox1.Location = new Point(64, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 143);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(83, 115);
            label1.Name = "label1";
            label1.Size = new Size(114, 36);
            label1.TabIndex = 1;
            label1.Text = "LOG IN";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Do_An.Properties.Resources.user;
            pictureBox2.Location = new Point(30, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Location = new Point(30, 195);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 1);
            panel1.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(30, 225);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(21, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Location = new Point(30, 262);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 1);
            panel2.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 64, 64);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 35);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lbClear
            // 
            lbClear.AutoSize = true;
            lbClear.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClear.ForeColor = Color.FromArgb(0, 64, 64);
            lbClear.Location = new Point(180, 279);
            lbClear.Name = "lbClear";
            lbClear.Size = new Size(86, 16);
            lbClear.TabIndex = 5;
            lbClear.Text = "Clear fields";
            lbClear.Click += lbClear_Click;
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbExit.ForeColor = Color.FromArgb(0, 64, 64);
            lbExit.Location = new Point(128, 378);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(32, 16);
            lbExit.TabIndex = 5;
            lbExit.Text = "Exit";
            lbExit.Click += lbExit_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(0, 64, 64);
            txtUsername.Location = new Point(57, 165);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(209, 17);
            txtUsername.TabIndex = 10;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.White;
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.ForeColor = Color.FromArgb(0, 64, 64);
            txtpassword.Location = new Point(57, 232);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(209, 17);
            txtpassword.TabIndex = 11;
            txtpassword.KeyDown += txtpassword_KeyDown;
            // 
            // lbSignIn
            // 
            lbSignIn.AutoSize = true;
            lbSignIn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSignIn.ForeColor = Color.FromArgb(0, 64, 64);
            lbSignIn.Location = new Point(47, 295);
            lbSignIn.Name = "lbSignIn";
            lbSignIn.Size = new Size(219, 16);
            lbSignIn.TabIndex = 7;
            lbSignIn.Text = "Don't have an account? Sign in";
            lbSignIn.Click += lbSignIn_Click;
            // 
            // ForgetPassword
            // 
            ForgetPassword.AutoSize = true;
            ForgetPassword.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForgetPassword.ForeColor = Color.FromArgb(0, 64, 64);
            ForgetPassword.Location = new Point(143, 311);
            ForgetPassword.Name = "ForgetPassword";
            ForgetPassword.Size = new Size(123, 16);
            ForgetPassword.TabIndex = 8;
            ForgetPassword.Text = "Forget pasword?";
            ForgetPassword.Click += ForgetPassword_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(292, 429);
            Controls.Add(ForgetPassword);
            Controls.Add(lbSignIn);
            Controls.Add(txtpassword);
            Controls.Add(txtUsername);
            Controls.Add(lbExit);
            Controls.Add(lbClear);
            Controls.Add(btnLogin);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Button btnLogin;
        private Label lbClear;
        private Label lbExit;
        private TextBox txtUsername;
        private TextBox txtpassword;
        private Label lbSignIn;
        private Label ForgetPassword;
    }
}