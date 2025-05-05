namespace Do_An
{
    partial class FriendCard
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
            UserAvatar = new PictureBox();
            UserName = new Label();
            MatchPlayed = new Label();
            MatchWon = new Label();
            WinRate = new Label();
            btnAction = new Button();
            ((System.ComponentModel.ISupportInitialize)UserAvatar).BeginInit();
            SuspendLayout();
            // 
            // UserAvatar
            // 
            UserAvatar.Image = Properties.Resources.user;
            UserAvatar.Location = new Point(3, 3);
            UserAvatar.Name = "UserAvatar";
            UserAvatar.Size = new Size(44, 44);
            UserAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            UserAvatar.TabIndex = 0;
            UserAvatar.TabStop = false;
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserName.Location = new Point(53, 3);
            UserName.Name = "UserName";
            UserName.Size = new Size(53, 21);
            UserName.TabIndex = 1;
            UserName.Text = "Name";
            // 
            // MatchPlayed
            // 
            MatchPlayed.AutoSize = true;
            MatchPlayed.Location = new Point(53, 32);
            MatchPlayed.Name = "MatchPlayed";
            MatchPlayed.Size = new Size(85, 15);
            MatchPlayed.TabIndex = 2;
            MatchPlayed.Text = "Match Played: ";
            // 
            // MatchWon
            // 
            MatchWon.AutoSize = true;
            MatchWon.Location = new Point(191, 32);
            MatchWon.Name = "MatchWon";
            MatchWon.Size = new Size(75, 15);
            MatchWon.TabIndex = 3;
            MatchWon.Text = "Match Won: ";
            // 
            // WinRate
            // 
            WinRate.AutoSize = true;
            WinRate.Location = new Point(308, 32);
            WinRate.Name = "WinRate";
            WinRate.Size = new Size(57, 15);
            WinRate.TabIndex = 4;
            WinRate.Text = "Win rate: ";
            // 
            // btnAction
            // 
            btnAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAction.BackColor = Color.FromArgb(51, 51, 76);
            btnAction.FlatAppearance.BorderSize = 0;
            btnAction.FlatStyle = FlatStyle.Flat;
            btnAction.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAction.ForeColor = Color.Gainsboro;
            btnAction.Location = new Point(390, 3);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(131, 47);
            btnAction.TabIndex = 5;
            btnAction.Text = "Add Friend";
            btnAction.UseVisualStyleBackColor = false;
            btnAction.Click += btnAction_Click;
            // 
            // FriendCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            Controls.Add(btnAction);
            Controls.Add(WinRate);
            Controls.Add(MatchWon);
            Controls.Add(MatchPlayed);
            Controls.Add(UserName);
            Controls.Add(UserAvatar);
            Name = "FriendCard";
            Size = new Size(524, 53);
            Load += FriendCard_Load;
            ((System.ComponentModel.ISupportInitialize)UserAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox UserAvatar;
        private Label UserName;
        private Label MatchPlayed;
        private Label MatchWon;
        private Label WinRate;
        private Button btnAction;
    }
}
