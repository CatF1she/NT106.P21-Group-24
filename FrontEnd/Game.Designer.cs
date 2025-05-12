namespace FrontEnd
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelChessBoard = new Panel();
            panelInfo = new Panel();
            panelChat = new Panel();
            SuspendLayout();
            // 
            // panelChessBoard
            // 
            panelChessBoard.Location = new Point(0, 18);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(750, 750);
            panelChessBoard.TabIndex = 0;
            // 
            // panelInfo
            // 
            panelInfo.Location = new Point(756, 18);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(256, 375);
            panelInfo.TabIndex = 1;
            // 
            // panelChat
            // 
            panelChat.Location = new Point(756, 399);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(256, 369);
            panelChat.TabIndex = 2;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(panelChat);
            Controls.Add(panelInfo);
            Controls.Add(panelChessBoard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion
        public Panel panelChessBoard;
        private Panel panelInfo;
        private Panel panelChat;
    }
}
