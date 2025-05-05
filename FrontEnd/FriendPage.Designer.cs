namespace Do_An
{
    partial class FriendPage
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
            FriendList = new FlowLayoutPanel();
            panelMenu = new Panel();
            picbtnSearch = new PictureBox();
            panel1 = new Panel();
            SearchBar = new TextBox();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // FriendList
            // 
            FriendList.AutoScroll = true;
            FriendList.Dock = DockStyle.Fill;
            FriendList.FlowDirection = FlowDirection.TopDown;
            FriendList.Location = new Point(0, 0);
            FriendList.Name = "FriendList";
            FriendList.Size = new Size(600, 291);
            FriendList.TabIndex = 5;
            FriendList.WrapContents = false;
            FriendList.Resize += FriendList_Resize;
            // 
            // panelMenu
            // 
            panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMenu.AutoScroll = true;
            panelMenu.Controls.Add(FriendList);
            panelMenu.Location = new Point(12, 48);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(600, 291);
            panelMenu.TabIndex = 6;
            // 
            // picbtnSearch
            // 
            picbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picbtnSearch.BackColor = SystemColors.ActiveCaption;
            picbtnSearch.Image = Properties.Resources.search_minimized;
            picbtnSearch.Location = new Point(582, 12);
            picbtnSearch.Name = "picbtnSearch";
            picbtnSearch.Size = new Size(30, 30);
            picbtnSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picbtnSearch.TabIndex = 7;
            picbtnSearch.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(SearchBar);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(564, 30);
            panel1.TabIndex = 8;
            // 
            // SearchBar
            // 
            SearchBar.BorderStyle = BorderStyle.None;
            SearchBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(3, 3);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(558, 22);
            SearchBar.TabIndex = 0;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // FriendPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 351);
            Controls.Add(panel1);
            Controls.Add(picbtnSearch);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FriendPage";
            Text = "Friends";
            Load += FriendPage_Load;
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picbtnSearch).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel FriendList;
        private Panel panelMenu;
        private PictureBox picbtnSearch;
        private Panel panel1;
        private TextBox SearchBar;
    }
}