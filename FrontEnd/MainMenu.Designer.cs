namespace FrontEnd.Resources
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            panelMenu = new Panel();
            btnFriends = new Button();
            btnSettings = new Button();
            btnProfile = new Button();
            btnLeaderboard = new Button();
            btnPlay = new Button();
            panelLogo = new Panel();
            lbTitle = new Label();
            panelTitleBar = new Panel();
            btnClose = new Button();
            btnMaximize = new Button();
            btnMinimize = new Button();
            label1 = new Label();
            panelDesktopPane = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(btnFriends);
            panelMenu.Controls.Add(btnSettings);
            panelMenu.Controls.Add(btnProfile);
            panelMenu.Controls.Add(btnLeaderboard);
            panelMenu.Controls.Add(btnPlay);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(160, 450);
            panelMenu.TabIndex = 0;
            // 
            // btnFriends
            // 
            btnFriends.Dock = DockStyle.Top;
            btnFriends.FlatAppearance.BorderSize = 0;
            btnFriends.FlatStyle = FlatStyle.Flat;
            btnFriends.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFriends.ForeColor = Color.Gainsboro;
            btnFriends.Image = (Image)resources.GetObject("btnFriends.Image");
            btnFriends.ImageAlign = ContentAlignment.MiddleLeft;
            btnFriends.Location = new Point(0, 195);
            btnFriends.Name = "btnFriends";
            btnFriends.Padding = new Padding(6, 0, 0, 0);
            btnFriends.Size = new Size(160, 45);
            btnFriends.TabIndex = 5;
            btnFriends.Text = "Friends";
            btnFriends.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFriends.UseVisualStyleBackColor = true;
            btnFriends.Click += btnFriends_Click;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.Gainsboro;
            btnSettings.Image = Properties.Resources.setting;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 405);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(6, 0, 0, 0);
            btnSettings.Size = new Size(160, 45);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Top;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProfile.ForeColor = Color.Gainsboro;
            btnProfile.Image = (Image)resources.GetObject("btnProfile.Image");
            btnProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfile.Location = new Point(0, 150);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(6, 0, 0, 0);
            btnProfile.Size = new Size(160, 45);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Profile";
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLeaderboard
            // 
            btnLeaderboard.Dock = DockStyle.Top;
            btnLeaderboard.FlatAppearance.BorderSize = 0;
            btnLeaderboard.FlatStyle = FlatStyle.Flat;
            btnLeaderboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLeaderboard.ForeColor = Color.Gainsboro;
            btnLeaderboard.Image = (Image)resources.GetObject("btnLeaderboard.Image");
            btnLeaderboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnLeaderboard.Location = new Point(0, 105);
            btnLeaderboard.Name = "btnLeaderboard";
            btnLeaderboard.Padding = new Padding(6, 0, 0, 0);
            btnLeaderboard.Size = new Size(160, 45);
            btnLeaderboard.TabIndex = 2;
            btnLeaderboard.Text = "Leaderboard";
            btnLeaderboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLeaderboard.UseVisualStyleBackColor = true;
            btnLeaderboard.Click += btnLeaderboard_Click;
            // 
            // btnPlay
            // 
            btnPlay.Dock = DockStyle.Top;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.ForeColor = Color.Gainsboro;
            btnPlay.Image = (Image)resources.GetObject("btnPlay.Image");
            btnPlay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlay.Location = new Point(0, 60);
            btnPlay.Name = "btnPlay";
            btnPlay.Padding = new Padding(6, 0, 0, 0);
            btnPlay.Size = new Size(160, 45);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play";
            btnPlay.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(lbTitle);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(160, 60);
            panelLogo.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.LightGray;
            lbTitle.Location = new Point(52, 25);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(43, 21);
            lbTitle.TabIndex = 2;
            lbTitle.Text = "Caro";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Controls.Add(btnMaximize);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(160, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(640, 60);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(602, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 29);
            btnClose.TabIndex = 5;
            btnClose.Text = "O";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaximize.ForeColor = Color.White;
            btnMaximize.Location = new Point(564, 3);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(35, 29);
            btnMaximize.TabIndex = 4;
            btnMaximize.Text = "O";
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(523, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(35, 29);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "O";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(302, 20);
            label1.Name = "label1";
            label1.Size = new Size(74, 26);
            label1.TabIndex = 2;
            label1.Text = "HOME";
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Location = new Point(160, 60);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(640, 390);
            panelDesktopPane.TabIndex = 2;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(panelDesktopPane);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainMenu";
            Text = "MainMenu";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private Button btnPlay;
        private Button btnSettings;
        private Button btnProfile;
        private Button btnLeaderboard;
        private Panel panelTitleBar;
        private Label label1;
        private Label lbTitle;
        private Button btnMinimize;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnFriends;
        private Panel panelDesktopPane;
    }
}