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
            btnCreateRoom = new Button();
            panelInfo = new Panel();
            PlayerList = new FlowLayoutPanel();
            label2 = new Label();
            RoomCode = new TextBox();
            label3 = new Label();
            buttonLeaveRoom = new Button();
            buttonToggleReady = new Button();
            buttonJoinRoom = new Button();
            panelSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).BeginInit();
            panelRoomList.SuspendLayout();
            panelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearchBar
            // 
            panelSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearchBar.BackColor = Color.White;
            panelSearchBar.Controls.Add(SearchBar);
            panelSearchBar.Location = new Point(6, 10);
            panelSearchBar.Margin = new Padding(0);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new Size(751, 32);
            panelSearchBar.TabIndex = 11;
            // 
            // SearchBar
            // 
            SearchBar.Anchor = AnchorStyles.Top;
            SearchBar.BorderStyle = BorderStyle.FixedSingle;
            SearchBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(0, 1);
            SearchBar.Margin = new Padding(0);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(751, 29);
            SearchBar.TabIndex = 0;
            // 
            // picbtnSearch
            // 
            picbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picbtnSearch.BackColor = SystemColors.ActiveCaption;
            picbtnSearch.Image = Properties.Resources.search_minimized;
            picbtnSearch.Location = new Point(757, 10);
            picbtnSearch.Margin = new Padding(0);
            picbtnSearch.Name = "picbtnSearch";
            picbtnSearch.Size = new Size(31, 32);
            picbtnSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picbtnSearch.TabIndex = 10;
            picbtnSearch.TabStop = false;
            picbtnSearch.Click += picbtnSearch_Click;
            // 
            // panelRoomList
            // 
            panelRoomList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRoomList.AutoScroll = true;
            panelRoomList.Controls.Add(RoomList);
            panelRoomList.Location = new Point(6, 48);
            panelRoomList.Margin = new Padding(0);
            panelRoomList.Name = "panelRoomList";
            panelRoomList.Size = new Size(782, 305);
            panelRoomList.TabIndex = 9;
            // 
            // RoomList
            // 
            RoomList.AutoScroll = true;
            RoomList.BorderStyle = BorderStyle.FixedSingle;
            RoomList.FlowDirection = FlowDirection.TopDown;
            RoomList.Location = new Point(0, 0);
            RoomList.Margin = new Padding(0);
            RoomList.Name = "RoomList";
            RoomList.Size = new Size(782, 305);
            RoomList.TabIndex = 5;
            RoomList.WrapContents = false;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.Anchor = AnchorStyles.Bottom;
            btnCreateRoom.BackColor = Color.FromArgb(51, 51, 76);
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateRoom.ForeColor = Color.Gainsboro;
            btnCreateRoom.Location = new Point(617, 0);
            btnCreateRoom.Margin = new Padding(0);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(165, 47);
            btnCreateRoom.TabIndex = 12;
            btnCreateRoom.Text = "Create Room";
            btnCreateRoom.UseVisualStyleBackColor = false;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(PlayerList);
            panelInfo.Controls.Add(label2);
            panelInfo.Controls.Add(RoomCode);
            panelInfo.Controls.Add(label3);
            panelInfo.Controls.Add(buttonLeaveRoom);
            panelInfo.Controls.Add(buttonToggleReady);
            panelInfo.Controls.Add(buttonJoinRoom);
            panelInfo.Controls.Add(btnCreateRoom);
            panelInfo.Location = new Point(6, 353);
            panelInfo.Margin = new Padding(0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(782, 94);
            panelInfo.TabIndex = 13;
            // 
            // PlayerList
            // 
            PlayerList.Anchor = AnchorStyles.Bottom;
            PlayerList.AutoScroll = true;
            PlayerList.BackColor = SystemColors.Control;
            PlayerList.FlowDirection = FlowDirection.TopDown;
            PlayerList.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            PlayerList.ForeColor = Color.FromArgb(51, 51, 76);
            PlayerList.Location = new Point(143, 47);
            PlayerList.Margin = new Padding(0);
            PlayerList.Name = "PlayerList";
            PlayerList.Size = new Size(312, 47);
            PlayerList.TabIndex = 25;
            PlayerList.WrapContents = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(51, 51, 76);
            label2.Location = new Point(50, 59);
            label2.Name = "label2";
            label2.Size = new Size(90, 24);
            label2.TabIndex = 23;
            label2.Text = "Players: ";
            // 
            // RoomCode
            // 
            RoomCode.Anchor = AnchorStyles.Bottom;
            RoomCode.BorderStyle = BorderStyle.None;
            RoomCode.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            RoomCode.ForeColor = Color.FromArgb(51, 51, 76);
            RoomCode.Location = new Point(143, 17);
            RoomCode.Name = "RoomCode";
            RoomCode.ReadOnly = true;
            RoomCode.Size = new Size(98, 22);
            RoomCode.TabIndex = 18;
            RoomCode.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(51, 51, 76);
            label3.Location = new Point(10, 17);
            label3.Name = "label3";
            label3.Size = new Size(127, 24);
            label3.TabIndex = 17;
            label3.Text = "Room Code:";
            // 
            // buttonLeaveRoom
            // 
            buttonLeaveRoom.Anchor = AnchorStyles.Bottom;
            buttonLeaveRoom.BackColor = Color.FromArgb(51, 51, 76);
            buttonLeaveRoom.FlatAppearance.BorderSize = 0;
            buttonLeaveRoom.FlatStyle = FlatStyle.Flat;
            buttonLeaveRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLeaveRoom.ForeColor = Color.Gainsboro;
            buttonLeaveRoom.Location = new Point(617, 47);
            buttonLeaveRoom.Margin = new Padding(0);
            buttonLeaveRoom.Name = "buttonLeaveRoom";
            buttonLeaveRoom.Size = new Size(165, 47);
            buttonLeaveRoom.TabIndex = 16;
            buttonLeaveRoom.Text = "Leave room";
            buttonLeaveRoom.UseVisualStyleBackColor = false;
            buttonLeaveRoom.Click += buttonLeaveRoom_Click;
            // 
            // buttonToggleReady
            // 
            buttonToggleReady.Anchor = AnchorStyles.Bottom;
            buttonToggleReady.BackColor = Color.FromArgb(51, 51, 76);
            buttonToggleReady.FlatAppearance.BorderSize = 0;
            buttonToggleReady.FlatStyle = FlatStyle.Flat;
            buttonToggleReady.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonToggleReady.ForeColor = Color.Gainsboro;
            buttonToggleReady.Location = new Point(455, 47);
            buttonToggleReady.Margin = new Padding(0);
            buttonToggleReady.Name = "buttonToggleReady";
            buttonToggleReady.Size = new Size(162, 47);
            buttonToggleReady.TabIndex = 15;
            buttonToggleReady.Text = "Ready";
            buttonToggleReady.UseVisualStyleBackColor = false;
            buttonToggleReady.Click += buttonToggleReady_Click;
            // 
            // buttonJoinRoom
            // 
            buttonJoinRoom.Anchor = AnchorStyles.Bottom;
            buttonJoinRoom.BackColor = Color.FromArgb(51, 51, 76);
            buttonJoinRoom.FlatAppearance.BorderSize = 0;
            buttonJoinRoom.FlatStyle = FlatStyle.Flat;
            buttonJoinRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonJoinRoom.ForeColor = Color.Gainsboro;
            buttonJoinRoom.Location = new Point(455, 0);
            buttonJoinRoom.Margin = new Padding(0);
            buttonJoinRoom.Name = "buttonJoinRoom";
            buttonJoinRoom.Size = new Size(162, 47);
            buttonJoinRoom.TabIndex = 14;
            buttonJoinRoom.Text = "Join Room";
            buttonJoinRoom.UseVisualStyleBackColor = false;
            buttonJoinRoom.Click += buttonJoinRoom_Click;
            // 
            // GameLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(picbtnSearch);
            Controls.Add(panelInfo);
            Controls.Add(panelSearchBar);
            Controls.Add(panelRoomList);
            Margin = new Padding(0);
            Name = "GameLobby";
            Size = new Size(800, 450);
            panelSearchBar.ResumeLayout(false);
            panelSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).EndInit();
            panelRoomList.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearchBar;
        private TextBox SearchBar;
        private PictureBox picbtnSearch;
        private Panel panelRoomList;
        private FlowLayoutPanel RoomList;
        private Button btnCreateRoom;
        private Panel panelInfo;
        private Button buttonJoinRoom;
        private Button buttonToggleReady;
        private Button buttonLeaveRoom;
        private Label label3;
        private TextBox RoomCode;
        private Label label2;
        private FlowLayoutPanel PlayerList;
    }
}