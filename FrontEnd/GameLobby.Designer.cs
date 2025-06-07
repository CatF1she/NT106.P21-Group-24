namespace Do_An
{
    partial class GameLobby
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
            panelSearchBar = new Panel();
            SearchBar = new TextBox();
            picbtnSearch = new PictureBox();
            panelRoomList = new Panel();
            RoomList = new FlowLayoutPanel();
            btnCreateGame = new Button();
            panel1 = new Panel();
            button1 = new Button();
            buttonToggleReady = new Button();
            buttonJoinRoom = new Button();
            lbTitle = new Label();
            panelSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).BeginInit();
            panelRoomList.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearchBar
            // 
            panelSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearchBar.BackColor = Color.White;
            panelSearchBar.Controls.Add(SearchBar);
            panelSearchBar.Location = new Point(135, 12);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new Size(274, 30);
            panelSearchBar.TabIndex = 11;
            // 
            // SearchBar
            // 
            SearchBar.BorderStyle = BorderStyle.None;
            SearchBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(3, 5);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(268, 22);
            SearchBar.TabIndex = 0;
            // 
            // picbtnSearch
            // 
            picbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picbtnSearch.BackColor = SystemColors.ActiveCaption;
            picbtnSearch.Image = Properties.Resources.search_minimized;
            picbtnSearch.Location = new Point(415, 12);
            picbtnSearch.Name = "picbtnSearch";
            picbtnSearch.Size = new Size(30, 30);
            picbtnSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picbtnSearch.TabIndex = 10;
            picbtnSearch.TabStop = false;
            // 
            // panelRoomList
            // 
            panelRoomList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRoomList.AutoScroll = true;
            panelRoomList.Controls.Add(RoomList);
            panelRoomList.Location = new Point(6, 48);
            panelRoomList.Name = "panelRoomList";
            panelRoomList.Size = new Size(439, 390);
            panelRoomList.TabIndex = 9;
            // 
            // RoomList
            // 
            RoomList.AutoScroll = true;
            RoomList.FlowDirection = FlowDirection.TopDown;
            RoomList.Location = new Point(0, 0);
            RoomList.Name = "RoomList";
            RoomList.Size = new Size(439, 390);
            RoomList.TabIndex = 5;
            RoomList.WrapContents = false;
            // 
            // btnCreateGame
            // 
            btnCreateGame.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateGame.BackColor = Color.FromArgb(51, 51, 76);
            btnCreateGame.FlatAppearance.BorderSize = 0;
            btnCreateGame.FlatStyle = FlatStyle.Flat;
            btnCreateGame.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateGame.ForeColor = Color.Gainsboro;
            btnCreateGame.Location = new Point(3, 376);
            btnCreateGame.Name = "btnCreateGame";
            btnCreateGame.Size = new Size(162, 47);
            btnCreateGame.TabIndex = 12;
            btnCreateGame.Text = "Create Game";
            btnCreateGame.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(buttonToggleReady);
            panel1.Controls.Add(buttonJoinRoom);
            panel1.Controls.Add(btnCreateGame);
            panel1.Location = new Point(451, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 426);
            panel1.TabIndex = 13;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(51, 51, 76);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Gainsboro;
            button1.Location = new Point(171, 323);
            button1.Name = "button1";
            button1.Size = new Size(165, 47);
            button1.TabIndex = 16;
            button1.Text = "Leave room";
            button1.UseVisualStyleBackColor = false;
            // 
            // buttonToggleReady
            // 
            buttonToggleReady.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToggleReady.BackColor = Color.FromArgb(51, 51, 76);
            buttonToggleReady.FlatAppearance.BorderSize = 0;
            buttonToggleReady.FlatStyle = FlatStyle.Flat;
            buttonToggleReady.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonToggleReady.ForeColor = Color.Gainsboro;
            buttonToggleReady.Location = new Point(171, 376);
            buttonToggleReady.Name = "buttonToggleReady";
            buttonToggleReady.Size = new Size(162, 47);
            buttonToggleReady.TabIndex = 15;
            buttonToggleReady.Text = "Ready";
            buttonToggleReady.UseVisualStyleBackColor = false;
            // 
            // buttonJoinRoom
            // 
            buttonJoinRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonJoinRoom.BackColor = Color.FromArgb(51, 51, 76);
            buttonJoinRoom.FlatAppearance.BorderSize = 0;
            buttonJoinRoom.FlatStyle = FlatStyle.Flat;
            buttonJoinRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonJoinRoom.ForeColor = Color.Gainsboro;
            buttonJoinRoom.Location = new Point(3, 323);
            buttonJoinRoom.Name = "buttonJoinRoom";
            buttonJoinRoom.Size = new Size(162, 47);
            buttonJoinRoom.TabIndex = 14;
            buttonJoinRoom.Text = "Join Room";
            buttonJoinRoom.UseVisualStyleBackColor = false;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.Black;
            lbTitle.Location = new Point(6, 15);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(123, 24);
            lbTitle.TabIndex = 14;
            lbTitle.Text = "Find Games";
            // 
            // GameLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbTitle);
            Controls.Add(panel1);
            Controls.Add(panelSearchBar);
            Controls.Add(picbtnSearch);
            Controls.Add(panelRoomList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameLobby";
            Text = "GameLobby";
            panelSearchBar.ResumeLayout(false);
            panelSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).EndInit();
            panelRoomList.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSearchBar;
        private TextBox SearchBar;
        private PictureBox picbtnSearch;
        private Panel panelRoomList;
        private FlowLayoutPanel RoomList;
        private Button btnCreateGame;
        private Panel panel1;
        private Button buttonJoinRoom;
        private Label lbTitle;
        private Button buttonToggleReady;
        private Button button1;
    }
}