namespace Do_An
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
            SuspendLayout();
            // 
            // panelChessBoard
            // 
            panelChessBoard.BorderStyle = BorderStyle.FixedSingle;
            panelChessBoard.Location = new Point(1, 16);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(751, 751);
            panelChessBoard.TabIndex = 0;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(panelChessBoard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion
        public Panel panelChessBoard;
    }
}
