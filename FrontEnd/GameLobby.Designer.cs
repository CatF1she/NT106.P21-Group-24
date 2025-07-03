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
            RoomList = new FlowLayoutPanel();
            btnCreateRoom = new Button();
            panelInfo = new Panel();
            tableLayoutPanelInfo = new TableLayoutPanel();
            buttonJoinRoom = new Button();
            buttonLeaveRoom = new Button();
            label2 = new Label();
            PlayerList = new FlowLayoutPanel();
            buttonToggleReady = new Button();
            RoomCode = new TextBox();
            label3 = new Label();
            picbtnSearch = new PictureBox();
            tableLayoutPanelGameLobby = new TableLayoutPanel();
            tableLayoutPanelSearchBar = new TableLayoutPanel();
            SearchBar = new TextBox();
            panelInfo.SuspendLayout();
            tableLayoutPanelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).BeginInit();
            tableLayoutPanelGameLobby.SuspendLayout();
            tableLayoutPanelSearchBar.SuspendLayout();
            SuspendLayout();
            // 
            // RoomList
            // 
            RoomList.AutoScroll = true;
            RoomList.BorderStyle = BorderStyle.FixedSingle;
            RoomList.Dock = DockStyle.Fill;
            RoomList.FlowDirection = FlowDirection.TopDown;
            RoomList.Location = new Point(0, 30);
            RoomList.Margin = new Padding(0);
            RoomList.Name = "RoomList";
            RoomList.Size = new Size(800, 320);
            RoomList.TabIndex = 5;
            RoomList.WrapContents = false;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreateRoom.BackColor = Color.FromArgb(63, 81, 181);
            btnCreateRoom.Dock = DockStyle.Fill;
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateRoom.ForeColor = Color.Gainsboro;
            btnCreateRoom.Location = new Point(630, 0);
            btnCreateRoom.Margin = new Padding(0);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(170, 50);
            btnCreateRoom.TabIndex = 12;
            btnCreateRoom.Text = "Create Room";
            btnCreateRoom.UseVisualStyleBackColor = false;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(tableLayoutPanelInfo);
            panelInfo.Dock = DockStyle.Fill;
            panelInfo.Location = new Point(0, 350);
            panelInfo.Margin = new Padding(0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(800, 100);
            panelInfo.TabIndex = 13;
            // 
            // tableLayoutPanelInfo
            // 
            tableLayoutPanelInfo.ColumnCount = 4;
            tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanelInfo.Controls.Add(buttonJoinRoom, 2, 0);
            tableLayoutPanelInfo.Controls.Add(buttonLeaveRoom, 3, 1);
            tableLayoutPanelInfo.Controls.Add(label2, 0, 1);
            tableLayoutPanelInfo.Controls.Add(btnCreateRoom, 3, 0);
            tableLayoutPanelInfo.Controls.Add(PlayerList, 1, 1);
            tableLayoutPanelInfo.Controls.Add(buttonToggleReady, 2, 1);
            tableLayoutPanelInfo.Controls.Add(RoomCode, 1, 0);
            tableLayoutPanelInfo.Controls.Add(label3, 0, 0);
            tableLayoutPanelInfo.Dock = DockStyle.Fill;
            tableLayoutPanelInfo.Location = new Point(0, 0);
            tableLayoutPanelInfo.Margin = new Padding(0);
            tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
            tableLayoutPanelInfo.RowCount = 2;
            tableLayoutPanelInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelInfo.Size = new Size(800, 100);
            tableLayoutPanelInfo.TabIndex = 0;
            // 
            // buttonJoinRoom
            // 
            buttonJoinRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonJoinRoom.BackColor = Color.FromArgb(63, 81, 181);
            buttonJoinRoom.Dock = DockStyle.Fill;
            buttonJoinRoom.FlatAppearance.BorderSize = 0;
            buttonJoinRoom.FlatStyle = FlatStyle.Flat;
            buttonJoinRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonJoinRoom.ForeColor = Color.White;
            buttonJoinRoom.Location = new Point(460, 0);
            buttonJoinRoom.Margin = new Padding(0);
            buttonJoinRoom.Name = "buttonJoinRoom";
            buttonJoinRoom.Size = new Size(170, 50);
            buttonJoinRoom.TabIndex = 14;
            buttonJoinRoom.Text = "Join Room";
            buttonJoinRoom.UseVisualStyleBackColor = false;
            buttonJoinRoom.Click += buttonJoinRoom_Click;
            // 
            // buttonLeaveRoom
            // 
            buttonLeaveRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLeaveRoom.BackColor = Color.FromArgb(63, 81, 181);
            buttonLeaveRoom.Dock = DockStyle.Fill;
            buttonLeaveRoom.FlatAppearance.BorderSize = 0;
            buttonLeaveRoom.FlatStyle = FlatStyle.Flat;
            buttonLeaveRoom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLeaveRoom.ForeColor = Color.Gainsboro;
            buttonLeaveRoom.Location = new Point(630, 50);
            buttonLeaveRoom.Margin = new Padding(0);
            buttonLeaveRoom.Name = "buttonLeaveRoom";
            buttonLeaveRoom.Size = new Size(170, 50);
            buttonLeaveRoom.TabIndex = 16;
            buttonLeaveRoom.Text = "Leave room";
            buttonLeaveRoom.UseVisualStyleBackColor = false;
            buttonLeaveRoom.Click += buttonLeaveRoom_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(51, 51, 76);
            label2.Location = new Point(3, 76);
            label2.Name = "label2";
            label2.Size = new Size(144, 24);
            label2.TabIndex = 23;
            label2.Text = "Players: ";
            // 
            // PlayerList
            // 
            PlayerList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PlayerList.BackColor = SystemColors.Control;
            PlayerList.Dock = DockStyle.Fill;
            PlayerList.FlowDirection = FlowDirection.TopDown;
            PlayerList.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            PlayerList.ForeColor = Color.FromArgb(51, 51, 76);
            PlayerList.Location = new Point(150, 50);
            PlayerList.Margin = new Padding(0);
            PlayerList.Name = "PlayerList";
            PlayerList.Size = new Size(310, 50);
            PlayerList.TabIndex = 25;
            PlayerList.WrapContents = false;
            // 
            // buttonToggleReady
            // 
            buttonToggleReady.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonToggleReady.BackColor = Color.FromArgb(63, 81, 181);
            buttonToggleReady.Dock = DockStyle.Fill;
            buttonToggleReady.FlatAppearance.BorderSize = 0;
            buttonToggleReady.FlatStyle = FlatStyle.Flat;
            buttonToggleReady.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonToggleReady.ForeColor = Color.Gainsboro;
            buttonToggleReady.Location = new Point(460, 50);
            buttonToggleReady.Margin = new Padding(0);
            buttonToggleReady.Name = "buttonToggleReady";
            buttonToggleReady.Size = new Size(170, 50);
            buttonToggleReady.TabIndex = 15;
            buttonToggleReady.Text = "Ready";
            buttonToggleReady.UseVisualStyleBackColor = false;
            buttonToggleReady.Click += buttonToggleReady_Click;
            // 
            // RoomCode
            // 
            RoomCode.BorderStyle = BorderStyle.None;
            RoomCode.Dock = DockStyle.Bottom;
            RoomCode.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            RoomCode.ForeColor = Color.FromArgb(51, 51, 76);
            RoomCode.Location = new Point(153, 25);
            RoomCode.Name = "RoomCode";
            RoomCode.ReadOnly = true;
            RoomCode.Size = new Size(304, 22);
            RoomCode.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(51, 51, 76);
            label3.Location = new Point(3, 26);
            label3.Name = "label3";
            label3.Size = new Size(144, 24);
            label3.TabIndex = 17;
            label3.Text = "Room Code:";
            // 
            // picbtnSearch
            // 
            picbtnSearch.BackColor = SystemColors.ActiveCaption;
            picbtnSearch.Dock = DockStyle.Fill;
            picbtnSearch.Image = Properties.Resources.search_minimized;
            picbtnSearch.Location = new Point(770, 0);
            picbtnSearch.Margin = new Padding(0);
            picbtnSearch.Name = "picbtnSearch";
            picbtnSearch.Size = new Size(30, 30);
            picbtnSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picbtnSearch.TabIndex = 10;
            picbtnSearch.TabStop = false;
            picbtnSearch.Click += picbtnSearch_Click;
            // 
            // tableLayoutPanelGameLobby
            // 
            tableLayoutPanelGameLobby.ColumnCount = 1;
            tableLayoutPanelGameLobby.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelGameLobby.Controls.Add(RoomList, 0, 1);
            tableLayoutPanelGameLobby.Controls.Add(panelInfo, 0, 2);
            tableLayoutPanelGameLobby.Controls.Add(tableLayoutPanelSearchBar, 0, 0);
            tableLayoutPanelGameLobby.Dock = DockStyle.Fill;
            tableLayoutPanelGameLobby.Location = new Point(0, 0);
            tableLayoutPanelGameLobby.Margin = new Padding(0);
            tableLayoutPanelGameLobby.Name = "tableLayoutPanelGameLobby";
            tableLayoutPanelGameLobby.RowCount = 3;
            tableLayoutPanelGameLobby.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelGameLobby.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelGameLobby.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanelGameLobby.Size = new Size(800, 450);
            tableLayoutPanelGameLobby.TabIndex = 14;
            // 
            // tableLayoutPanelSearchBar
            // 
            tableLayoutPanelSearchBar.ColumnCount = 2;
            tableLayoutPanelSearchBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSearchBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSearchBar.Controls.Add(SearchBar, 0, 0);
            tableLayoutPanelSearchBar.Controls.Add(picbtnSearch, 1, 0);
            tableLayoutPanelSearchBar.Dock = DockStyle.Fill;
            tableLayoutPanelSearchBar.Location = new Point(0, 0);
            tableLayoutPanelSearchBar.Margin = new Padding(0);
            tableLayoutPanelSearchBar.Name = "tableLayoutPanelSearchBar";
            tableLayoutPanelSearchBar.RowCount = 1;
            tableLayoutPanelSearchBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSearchBar.Size = new Size(800, 30);
            tableLayoutPanelSearchBar.TabIndex = 0;
            // 
            // SearchBar
            // 
            SearchBar.BorderStyle = BorderStyle.FixedSingle;
            SearchBar.Dock = DockStyle.Fill;
            SearchBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(0, 0);
            SearchBar.Margin = new Padding(0);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(770, 29);
            SearchBar.TabIndex = 0;
            // 
            // GameLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelGameLobby);
            Margin = new Padding(0);
            Name = "GameLobby";
            Size = new Size(800, 450);
            Load += GameLobby_Load;
            panelInfo.ResumeLayout(false);
            tableLayoutPanelInfo.ResumeLayout(false);
            tableLayoutPanelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).EndInit();
            tableLayoutPanelGameLobby.ResumeLayout(false);
            tableLayoutPanelSearchBar.ResumeLayout(false);
            tableLayoutPanelSearchBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private PictureBox picbtnSearch;
        private TableLayoutPanel tableLayoutPanelGameLobby;
        private TableLayoutPanel tableLayoutPanelSearchBar;
        private TextBox SearchBar;
        private TableLayoutPanel tableLayoutPanelInfo;
    }
}