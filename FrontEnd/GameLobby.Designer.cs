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
            label1 = new Label();
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
            panelSearchBar.Controls.Add(picbtnSearch);
            panelSearchBar.Location = new Point(6, 12);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new Size(439, 30);
            panelSearchBar.TabIndex = 11;
            // 
            // SearchBar
            // 
            SearchBar.BorderStyle = BorderStyle.FixedSingle;
            SearchBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(119, 0);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(283, 29);
            SearchBar.TabIndex = 0;
            // 
            // picbtnSearch
            // 
            picbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picbtnSearch.BackColor = SystemColors.ActiveCaption;
            picbtnSearch.Image = Properties.Resources.search_minimized;
            picbtnSearch.Location = new Point(408, -2);
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
            panelRoomList.Name = "panelRoomList";
            panelRoomList.Size = new Size(439, 390);
            panelRoomList.TabIndex = 9;
            // 
            // RoomList
            // 
            RoomList.AutoScroll = true;
            RoomList.BorderStyle = BorderStyle.FixedSingle;
            RoomList.FlowDirection = FlowDirection.TopDown;
            RoomList.Location = new Point(0, 0);
            RoomList.Name = "RoomList";
            RoomList.Size = new Size(439, 390);
            RoomList.TabIndex = 5;
            RoomList.WrapContents = false;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateRoom.BackColor = Color.FromArgb(51, 51, 76);
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateRoom.ForeColor = Color.Gainsboro;
            btnCreateRoom.Location = new Point(168, 323);
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
            panelInfo.Location = new Point(451, 12);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(337, 426);
            panelInfo.TabIndex = 13;
            // 
            // PlayerList
            // 
            PlayerList.AutoScroll = true;
            PlayerList.BorderStyle = BorderStyle.FixedSingle;
            PlayerList.FlowDirection = FlowDirection.TopDown;
            PlayerList.Location = new Point(136, 268);
            PlayerList.Name = "PlayerList";
            PlayerList.Size = new Size(201, 49);
            PlayerList.TabIndex = 25;
            PlayerList.WrapContents = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 268);
            label2.Name = "label2";
            label2.Size = new Size(78, 24);
            label2.TabIndex = 23;
            label2.Text = "Players";
            // 
            // RoomCode
            // 
            RoomCode.BorderStyle = BorderStyle.FixedSingle;
            RoomCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomCode.Location = new Point(136, 237);
            RoomCode.Name = "RoomCode";
            RoomCode.ReadOnly = true;
            RoomCode.Size = new Size(201, 29);
            RoomCode.TabIndex = 18;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 242);
            label3.Name = "label3";
            label3.Size = new Size(121, 24);
            label3.TabIndex = 17;
            label3.Text = "Room Code";
            // 
            // buttonLeaveRoom
            // 
            buttonLeaveRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLeaveRoom.BackColor = Color.FromArgb(51, 51, 76);
            buttonLeaveRoom.FlatAppearance.BorderSize = 0;
            buttonLeaveRoom.FlatStyle = FlatStyle.Flat;
            buttonLeaveRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLeaveRoom.ForeColor = Color.Gainsboro;
            buttonLeaveRoom.Location = new Point(168, 376);
            buttonLeaveRoom.Name = "buttonLeaveRoom";
            buttonLeaveRoom.Size = new Size(165, 47);
            buttonLeaveRoom.TabIndex = 16;
            buttonLeaveRoom.Text = "Leave room";
            buttonLeaveRoom.UseVisualStyleBackColor = false;
            buttonLeaveRoom.Click += buttonLeaveRoom_Click;
            // 
            // buttonToggleReady
            // 
            buttonToggleReady.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToggleReady.BackColor = Color.FromArgb(51, 51, 76);
            buttonToggleReady.FlatAppearance.BorderSize = 0;
            buttonToggleReady.FlatStyle = FlatStyle.Flat;
            buttonToggleReady.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonToggleReady.ForeColor = Color.Gainsboro;
            buttonToggleReady.Location = new Point(3, 376);
            buttonToggleReady.Name = "buttonToggleReady";
            buttonToggleReady.Size = new Size(162, 47);
            buttonToggleReady.TabIndex = 15;
            buttonToggleReady.Text = "Ready";
            buttonToggleReady.UseVisualStyleBackColor = false;
            buttonToggleReady.Click += buttonToggleReady_Click;
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
            buttonJoinRoom.Click += buttonJoinRoom_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(113, 24);
            label1.TabIndex = 14;
            label1.Text = "Find Room";
            // 
            // GameLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(panelInfo);
            Controls.Add(panelSearchBar);
            Controls.Add(panelRoomList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameLobby";
            Text = "GameLobby";
            panelSearchBar.ResumeLayout(false);
            panelSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).EndInit();
            panelRoomList.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label1;
        private Button buttonToggleReady;
        private Button buttonLeaveRoom;
        private Label label3;
        private TextBox RoomCode;
        private Label label2;
        private FlowLayoutPanel PlayerList;
    }
}