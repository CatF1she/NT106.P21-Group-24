namespace Do_An
{
    partial class Leaderboard
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
            panelMyInfo = new Panel();
            txtMyMatchWon = new Label();
            txtMyMatchPlayed = new Label();
            txtMyRank = new Label();
            picMyRank = new PictureBox();
            panel4 = new Panel();
            label2 = new Label();
            txtMyUsermame = new Label();
            picMyAvatar = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            panelPlayerRanking = new Panel();
            flowpanelPlayerRanking = new FlowLayoutPanel();
            panelMyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyRank).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyAvatar).BeginInit();
            panel3.SuspendLayout();
            panelPlayerRanking.SuspendLayout();
            SuspendLayout();
            // 
            // panelMyInfo
            // 
            panelMyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelMyInfo.BackColor = Color.White;
            panelMyInfo.Controls.Add(txtMyMatchWon);
            panelMyInfo.Controls.Add(txtMyMatchPlayed);
            panelMyInfo.Controls.Add(txtMyRank);
            panelMyInfo.Controls.Add(picMyRank);
            panelMyInfo.Controls.Add(panel4);
            panelMyInfo.Controls.Add(txtMyUsermame);
            panelMyInfo.Controls.Add(picMyAvatar);
            panelMyInfo.Controls.Add(panel3);
            panelMyInfo.Location = new Point(12, 12);
            panelMyInfo.Name = "panelMyInfo";
            panelMyInfo.Size = new Size(233, 426);
            panelMyInfo.TabIndex = 0;
            // 
            // txtMyMatchWon
            // 
            txtMyMatchWon.AutoSize = true;
            txtMyMatchWon.Location = new Point(72, 103);
            txtMyMatchWon.Name = "txtMyMatchWon";
            txtMyMatchWon.Size = new Size(75, 15);
            txtMyMatchWon.TabIndex = 6;
            txtMyMatchWon.Text = "Match Won: ";
            // 
            // txtMyMatchPlayed
            // 
            txtMyMatchPlayed.AutoSize = true;
            txtMyMatchPlayed.Location = new Point(72, 86);
            txtMyMatchPlayed.Name = "txtMyMatchPlayed";
            txtMyMatchPlayed.Size = new Size(85, 15);
            txtMyMatchPlayed.TabIndex = 6;
            txtMyMatchPlayed.Text = "Match Played: ";
            // 
            // txtMyRank
            // 
            txtMyRank.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMyRank.AutoSize = true;
            txtMyRank.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMyRank.Location = new Point(43, 331);
            txtMyRank.Name = "txtMyRank";
            txtMyRank.Size = new Size(76, 30);
            txtMyRank.TabIndex = 5;
            txtMyRank.Text = "Rank: ";
            // 
            // picMyRank
            // 
            picMyRank.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picMyRank.BackColor = Color.White;
            picMyRank.Image = Properties.Resources.Bronze;
            picMyRank.Location = new Point(43, 178);
            picMyRank.Name = "picMyRank";
            picMyRank.Size = new Size(150, 150);
            picMyRank.SizeMode = PictureBoxSizeMode.StretchImage;
            picMyRank.TabIndex = 4;
            picMyRank.TabStop = false;
            picMyRank.Resize += picMyRank_Resize;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.DarkBlue;
            panel4.Controls.Add(label2);
            panel4.Location = new Point(16, 124);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 48);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(38, 13);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 0;
            label2.Text = "Current Rank";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMyUsermame
            // 
            txtMyUsermame.AutoSize = true;
            txtMyUsermame.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtMyUsermame.Location = new Point(72, 65);
            txtMyUsermame.Name = "txtMyUsermame";
            txtMyUsermame.Size = new Size(83, 21);
            txtMyUsermame.TabIndex = 2;
            txtMyUsermame.Text = "Username";
            // 
            // picMyAvatar
            // 
            picMyAvatar.BackColor = Color.White;
            picMyAvatar.BorderStyle = BorderStyle.FixedSingle;
            picMyAvatar.Image = Properties.Resources.user1;
            picMyAvatar.Location = new Point(16, 68);
            picMyAvatar.Name = "picMyAvatar";
            picMyAvatar.Size = new Size(50, 50);
            picMyAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picMyAvatar.TabIndex = 1;
            picMyAvatar.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.DarkBlue;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(16, 14);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 48);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(56, 10);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 0;
            label1.Text = "My Info";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelPlayerRanking
            // 
            panelPlayerRanking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPlayerRanking.BackColor = Color.White;
            panelPlayerRanking.Controls.Add(flowpanelPlayerRanking);
            panelPlayerRanking.Location = new Point(271, 12);
            panelPlayerRanking.Name = "panelPlayerRanking";
            panelPlayerRanking.Size = new Size(517, 426);
            panelPlayerRanking.TabIndex = 1;
            // 
            // flowpanelPlayerRanking
            // 
            flowpanelPlayerRanking.AutoScroll = true;
            flowpanelPlayerRanking.Dock = DockStyle.Fill;
            flowpanelPlayerRanking.FlowDirection = FlowDirection.TopDown;
            flowpanelPlayerRanking.Location = new Point(0, 0);
            flowpanelPlayerRanking.Name = "flowpanelPlayerRanking";
            flowpanelPlayerRanking.Size = new Size(517, 426);
            flowpanelPlayerRanking.TabIndex = 0;
            flowpanelPlayerRanking.WrapContents = false;
            // 
            // Leaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelPlayerRanking);
            Controls.Add(panelMyInfo);
            Name = "Leaderboard";
            Text = "Leaderboard";
            Load += Leaderboard_Load;
            panelMyInfo.ResumeLayout(false);
            panelMyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyRank).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyAvatar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelPlayerRanking.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMyInfo;
        private PictureBox picMyAvatar;
        private Panel panel3;
        private Label label1;
        private Panel panelPlayerRanking;
        private Label txtMyUsermame;
        private Panel panel4;
        private Label label2;
        private Label txtMyRank;
        private PictureBox picMyRank;
        private FlowLayoutPanel flowpanelPlayerRanking;
        private Label txtMyMatchWon;
        private Label txtMyMatchPlayed;
    }
}