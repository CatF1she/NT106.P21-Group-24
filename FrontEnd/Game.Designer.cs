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
            button1 = new Button();
            SuspendLayout();
            // 
            // panelChessBoard
            // 
            panelChessBoard.Location = new Point(0, 18);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(750, 750);
            panelChessBoard.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(872, 132);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "LMAO";
            button1.UseVisualStyleBackColor = true;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(button1);
            Controls.Add(panelChessBoard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion
        public Panel panelChessBoard;
        private Button button1;
    }
}
