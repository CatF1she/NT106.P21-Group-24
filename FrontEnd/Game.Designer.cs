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
            tableLayoutPanelGame = new TableLayoutPanel();
            panel1 = new Panel();
            panelClose = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            tableLayoutChessBoard = new TableLayoutPanel();
            tableLayoutPanelGame.SuspendLayout();
            panelClose.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelGame
            // 
            tableLayoutPanelGame.ColumnCount = 2;
            tableLayoutPanelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelGame.Controls.Add(panel1, 0, 0);
            tableLayoutPanelGame.Controls.Add(panelClose, 1, 0);
            tableLayoutPanelGame.Controls.Add(tableLayoutChessBoard, 0, 1);
            tableLayoutPanelGame.Dock = DockStyle.Fill;
            tableLayoutPanelGame.Location = new Point(0, 0);
            tableLayoutPanelGame.Margin = new Padding(0);
            tableLayoutPanelGame.Name = "tableLayoutPanelGame";
            tableLayoutPanelGame.RowCount = 2;
            tableLayoutPanelGame.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelGame.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelGame.Size = new Size(800, 450);
            tableLayoutPanelGame.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 81, 181);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 60);
            panel1.TabIndex = 1;
            // 
            // panelClose
            // 
            panelClose.BackColor = Color.FromArgb(63, 81, 181);
            panelClose.Controls.Add(btnMinimize);
            panelClose.Controls.Add(btnMaximize);
            panelClose.Controls.Add(btnClose);
            panelClose.Location = new Point(640, 0);
            panelClose.Margin = new Padding(0);
            panelClose.Name = "panelClose";
            panelClose.Size = new Size(160, 60);
            panelClose.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(43, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(35, 29);
            btnMinimize.TabIndex = 8;
            btnMinimize.Text = "O";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaximize.ForeColor = Color.White;
            btnMaximize.Location = new Point(84, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(35, 29);
            btnMaximize.TabIndex = 7;
            btnMaximize.Text = "O";
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(125, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 29);
            btnClose.TabIndex = 6;
            btnClose.Text = "O";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // tableLayoutChessBoard
            // 
            tableLayoutChessBoard.ColumnCount = 2;
            tableLayoutChessBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.Dock = DockStyle.Fill;
            tableLayoutChessBoard.Location = new Point(3, 63);
            tableLayoutChessBoard.Name = "tableLayoutChessBoard";
            tableLayoutChessBoard.RowCount = 2;
            tableLayoutChessBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.Size = new Size(634, 384);
            tableLayoutChessBoard.TabIndex = 2;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanelGame);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "Game";
            tableLayoutPanelGame.ResumeLayout(false);
            panelClose.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelGame;
        private Panel panelClose;
        private Panel panel1;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnMinimize;
        private TableLayoutPanel tableLayoutChessBoard;
    }
}
