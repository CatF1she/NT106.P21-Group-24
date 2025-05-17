namespace FrontEnd
{
    partial class UserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lbUsername = new Label();
            Winrate = new Label();
            lbMatchWonNum = new Label();
            label5 = new Label();
            lbMatchNum = new Label();
            lbMatchWon = new Label();
            lbEmail = new Label();
            lbELO = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(202, 37);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbUsername.Location = new Point(396, 37);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(124, 25);
            lbUsername.TabIndex = 2;
            lbUsername.Text = "<Username>";
            // 
            // Winrate
            // 
            Winrate.AutoSize = true;
            Winrate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            Winrate.Location = new Point(202, 113);
            Winrate.Name = "Winrate";
            Winrate.Size = new Size(49, 25);
            Winrate.TabIndex = 3;
            Winrate.Text = "ELO:";
            // 
            // lbMatchWonNum
            // 
            lbMatchWonNum.AutoSize = true;
            lbMatchWonNum.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchWonNum.Location = new Point(396, 88);
            lbMatchWonNum.Name = "lbMatchWonNum";
            lbMatchWonNum.Size = new Size(23, 25);
            lbMatchWonNum.TabIndex = 4;
            lbMatchWonNum.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label5.Location = new Point(202, 63);
            label5.Name = "label5";
            label5.Size = new Size(188, 25);
            label5.TabIndex = 5;
            label5.Text = "Number of matches:";
            // 
            // lbMatchNum
            // 
            lbMatchNum.AutoSize = true;
            lbMatchNum.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchNum.Location = new Point(396, 63);
            lbMatchNum.Name = "lbMatchNum";
            lbMatchNum.Size = new Size(23, 25);
            lbMatchNum.TabIndex = 6;
            lbMatchNum.Text = "0";
            // 
            // lbMatchWon
            // 
            lbMatchWon.AutoSize = true;
            lbMatchWon.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchWon.Location = new Point(202, 88);
            lbMatchWon.Name = "lbMatchWon";
            lbMatchWon.Size = new Size(118, 25);
            lbMatchWon.TabIndex = 8;
            lbMatchWon.Text = "Match won: ";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbEmail.Location = new Point(53, 158);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(139, 25);
            lbEmail.TabIndex = 9;
            lbEmail.Text = "Email address: ";
            // 
            // lbELO
            // 
            lbELO.AutoSize = true;
            lbELO.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbELO.Location = new Point(396, 113);
            lbELO.Name = "lbELO";
            lbELO.Size = new Size(23, 25);
            lbELO.TabIndex = 10;
            lbELO.Text = "0";
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 390);
            Controls.Add(lbELO);
            Controls.Add(lbEmail);
            Controls.Add(lbMatchWon);
            Controls.Add(lbMatchNum);
            Controls.Add(label5);
            Controls.Add(lbMatchWonNum);
            Controls.Add(Winrate);
            Controls.Add(lbUsername);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserProfile";
            Text = "Profile";
            Load += UserProfile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label lbUsername;
        private Label Winrate;
        private Label lbMatchWonNum;
        private Label label5;
        private Label lbMatchNum;
        private Label lbMatchWon;
        private Label lbEmail;
        private Label lbELO;
    }
}