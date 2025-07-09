namespace Do_An
{
    partial class PlayerRankingCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new Label();
            picRank = new PictureBox();
            picUserAvatar = new PictureBox();
            txtPlayed = new Label();
            txtWon = new Label();
            txtRank = new Label();
            panelScore = new Panel();
            txtUserScore = new Label();
            ((System.ComponentModel.ISupportInitialize)picRank).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).BeginInit();
            panelScore.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.AutoSize = true;
            txtUsername.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(107, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(78, 20);
            txtUsername.TabIndex = 2;
            txtUsername.Text = "Username";
            // 
            // picRank
            // 
            picRank.Location = new Point(3, 4);
            picRank.Name = "picRank";
            picRank.Size = new Size(46, 46);
            picRank.SizeMode = PictureBoxSizeMode.StretchImage;
            picRank.TabIndex = 3;
            picRank.TabStop = false;
            // 
            // picUserAvatar
            // 
            picUserAvatar.Image = Properties.Resources.user;
            picUserAvatar.Location = new Point(55, 4);
            picUserAvatar.Name = "picUserAvatar";
            picUserAvatar.Size = new Size(46, 46);
            picUserAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picUserAvatar.TabIndex = 4;
            picUserAvatar.TabStop = false;
            // 
            // txtPlayed
            // 
            txtPlayed.AutoSize = true;
            txtPlayed.Font = new Font("Segoe UI", 10F);
            txtPlayed.Location = new Point(107, 31);
            txtPlayed.Name = "txtPlayed";
            txtPlayed.Size = new Size(56, 19);
            txtPlayed.TabIndex = 5;
            txtPlayed.Text = "Played: ";
            // 
            // txtWon
            // 
            txtWon.Anchor = AnchorStyles.Left;
            txtWon.AutoSize = true;
            txtWon.Font = new Font("Segoe UI", 10F);
            txtWon.Location = new Point(184, 31);
            txtWon.Name = "txtWon";
            txtWon.Size = new Size(44, 19);
            txtWon.TabIndex = 6;
            txtWon.Text = "Won: ";
            // 
            // txtRank
            // 
            txtRank.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRank.BackColor = Color.Transparent;
            txtRank.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRank.Location = new Point(3, 5);
            txtRank.Name = "txtRank";
            txtRank.Size = new Size(46, 35);
            txtRank.TabIndex = 7;
            txtRank.Text = "0";
            txtRank.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelScore
            // 
            panelScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelScore.BackColor = Color.FromArgb(0, 150, 136);
            panelScore.Controls.Add(txtUserScore);
            panelScore.Location = new Point(435, 4);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(79, 46);
            panelScore.TabIndex = 8;
            // 
            // txtUserScore
            // 
            txtUserScore.AutoSize = true;
            txtUserScore.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserScore.ForeColor = Color.White;
            txtUserScore.Location = new Point(15, 11);
            txtUserScore.Name = "txtUserScore";
            txtUserScore.Size = new Size(56, 25);
            txtUserScore.TabIndex = 9;
            txtUserScore.Text = "0000";
            // 
            // PlayerRankingCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelScore);
            Controls.Add(txtRank);
            Controls.Add(txtWon);
            Controls.Add(txtPlayed);
            Controls.Add(picUserAvatar);
            Controls.Add(picRank);
            Controls.Add(txtUsername);
            Name = "PlayerRankingCard";
            Size = new Size(517, 53);
            ((System.ComponentModel.ISupportInitialize)picRank).EndInit();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).EndInit();
            panelScore.ResumeLayout(false);
            panelScore.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label txtUsername;
        private PictureBox picRank;
        private PictureBox picUserAvatar;
        private Label txtPlayed;
        private Label txtWon;
        private Label txtRank;
        private Panel panelScore;
        private Label txtUserScore;
    }
}
