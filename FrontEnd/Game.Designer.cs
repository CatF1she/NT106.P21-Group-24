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
            tableLayoutChessBoard = new TableLayoutPanel();
            panelHeader = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            tableLayoutPanelMenu = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelPlayerOName = new Label();
            labelPlayerOWinRate = new Label();
            labelPlayerOMatchPlayed = new Label();
            pictureBoxPlayerO = new PictureBox();
            flowLayoutPanelGameStat = new FlowLayoutPanel();
            labelTimeRemaining = new Label();
            progressTurnTimer = new ProgressBar();
            labelCurrentTurn = new Label();
            flowLayoutPanelPlayerX = new FlowLayoutPanel();
            labelPlayerXName = new Label();
            labelPlayerXWinRate = new Label();
            labelPlayerXMatchPlayed = new Label();
            pictureBoxPlayerX = new PictureBox();
            tableLayoutPanelGame.SuspendLayout();
            panelHeader.SuspendLayout();
            tableLayoutPanelMenu.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerO).BeginInit();
            flowLayoutPanelGameStat.SuspendLayout();
            flowLayoutPanelPlayerX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerX).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelGame
            // 
            tableLayoutPanelGame.ColumnCount = 2;
            tableLayoutPanelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelGame.Controls.Add(tableLayoutChessBoard, 0, 1);
            tableLayoutPanelGame.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanelGame.Controls.Add(tableLayoutPanelMenu, 1, 1);
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
            // tableLayoutChessBoard
            // 
            tableLayoutChessBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutChessBoard.ColumnCount = 1;
            tableLayoutChessBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.Dock = DockStyle.Fill;
            tableLayoutChessBoard.Location = new Point(0, 60);
            tableLayoutChessBoard.Margin = new Padding(0);
            tableLayoutChessBoard.Name = "tableLayoutChessBoard";
            tableLayoutChessBoard.RowCount = 1;
            tableLayoutChessBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutChessBoard.Size = new Size(640, 390);
            tableLayoutChessBoard.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            tableLayoutPanelGame.SetColumnSpan(panelHeader, 2);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(btnMaximize);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Cursor = Cursors.Hand;
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(683, 0);
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
            btnMaximize.Location = new Point(724, 0);
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
            btnClose.Location = new Point(765, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 29);
            btnClose.TabIndex = 6;
            btnClose.Text = "O";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelMenu.ColumnCount = 2;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanelMenu.Controls.Add(pictureBoxPlayerO, 0, 1);
            tableLayoutPanelMenu.Controls.Add(flowLayoutPanelGameStat, 0, 2);
            tableLayoutPanelMenu.Controls.Add(flowLayoutPanelPlayerX, 1, 0);
            tableLayoutPanelMenu.Controls.Add(pictureBoxPlayerX, 0, 0);
            tableLayoutPanelMenu.Dock = DockStyle.Fill;
            tableLayoutPanelMenu.Location = new Point(640, 60);
            tableLayoutPanelMenu.Margin = new Padding(0);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 3;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Size = new Size(160, 390);
            tableLayoutPanelMenu.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labelPlayerOName);
            flowLayoutPanel1.Controls.Add(labelPlayerOWinRate);
            flowLayoutPanel1.Controls.Add(labelPlayerOMatchPlayed);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(52, 52);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(107, 50);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // labelPlayerOName
            // 
            labelPlayerOName.AutoSize = true;
            labelPlayerOName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerOName.Location = new Point(0, 0);
            labelPlayerOName.Margin = new Padding(0);
            labelPlayerOName.Name = "labelPlayerOName";
            labelPlayerOName.Size = new Size(56, 15);
            labelPlayerOName.TabIndex = 0;
            labelPlayerOName.Text = "Player O:";
            // 
            // labelPlayerOWinRate
            // 
            labelPlayerOWinRate.AutoSize = true;
            labelPlayerOWinRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerOWinRate.Location = new Point(0, 15);
            labelPlayerOWinRate.Margin = new Padding(0);
            labelPlayerOWinRate.Name = "labelPlayerOWinRate";
            labelPlayerOWinRate.Size = new Size(58, 15);
            labelPlayerOWinRate.TabIndex = 1;
            labelPlayerOWinRate.Text = "Win rate:";
            // 
            // labelPlayerOMatchPlayed
            // 
            labelPlayerOMatchPlayed.AutoSize = true;
            labelPlayerOMatchPlayed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerOMatchPlayed.Location = new Point(0, 30);
            labelPlayerOMatchPlayed.Margin = new Padding(0);
            labelPlayerOMatchPlayed.Name = "labelPlayerOMatchPlayed";
            labelPlayerOMatchPlayed.Size = new Size(87, 15);
            labelPlayerOMatchPlayed.TabIndex = 2;
            labelPlayerOMatchPlayed.Text = "Match played: ";
            // 
            // pictureBoxPlayerO
            // 
            pictureBoxPlayerO.Dock = DockStyle.Fill;
            pictureBoxPlayerO.Location = new Point(1, 52);
            pictureBoxPlayerO.Margin = new Padding(0);
            pictureBoxPlayerO.Name = "pictureBoxPlayerO";
            pictureBoxPlayerO.Size = new Size(50, 50);
            pictureBoxPlayerO.TabIndex = 3;
            pictureBoxPlayerO.TabStop = false;
            // 
            // flowLayoutPanelGameStat
            // 
            tableLayoutPanelMenu.SetColumnSpan(flowLayoutPanelGameStat, 2);
            flowLayoutPanelGameStat.Controls.Add(labelTimeRemaining);
            flowLayoutPanelGameStat.Controls.Add(progressTurnTimer);
            flowLayoutPanelGameStat.Controls.Add(labelCurrentTurn);
            flowLayoutPanelGameStat.Dock = DockStyle.Fill;
            flowLayoutPanelGameStat.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelGameStat.Location = new Point(1, 103);
            flowLayoutPanelGameStat.Margin = new Padding(0);
            flowLayoutPanelGameStat.Name = "flowLayoutPanelGameStat";
            flowLayoutPanelGameStat.Size = new Size(158, 286);
            flowLayoutPanelGameStat.TabIndex = 0;
            // 
            // labelTimeRemaining
            // 
            labelTimeRemaining.AutoSize = true;
            labelTimeRemaining.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTimeRemaining.Location = new Point(0, 0);
            labelTimeRemaining.Margin = new Padding(0);
            labelTimeRemaining.Name = "labelTimeRemaining";
            labelTimeRemaining.Size = new Size(100, 15);
            labelTimeRemaining.TabIndex = 1;
            labelTimeRemaining.Text = "Time remaining: ";
            // 
            // progressTurnTimer
            // 
            progressTurnTimer.Location = new Point(0, 15);
            progressTurnTimer.Margin = new Padding(0);
            progressTurnTimer.Maximum = 1000;
            progressTurnTimer.Name = "progressTurnTimer";
            progressTurnTimer.Size = new Size(100, 23);
            progressTurnTimer.TabIndex = 0;
            progressTurnTimer.Value = 1000;
            // 
            // labelCurrentTurn
            // 
            labelCurrentTurn.AutoSize = true;
            labelCurrentTurn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCurrentTurn.Location = new Point(0, 38);
            labelCurrentTurn.Margin = new Padding(0);
            labelCurrentTurn.Name = "labelCurrentTurn";
            labelCurrentTurn.Size = new Size(83, 15);
            labelCurrentTurn.TabIndex = 2;
            labelCurrentTurn.Text = "Current turn: ";
            // 
            // flowLayoutPanelPlayerX
            // 
            flowLayoutPanelPlayerX.Controls.Add(labelPlayerXName);
            flowLayoutPanelPlayerX.Controls.Add(labelPlayerXWinRate);
            flowLayoutPanelPlayerX.Controls.Add(labelPlayerXMatchPlayed);
            flowLayoutPanelPlayerX.Dock = DockStyle.Fill;
            flowLayoutPanelPlayerX.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelPlayerX.Location = new Point(52, 1);
            flowLayoutPanelPlayerX.Margin = new Padding(0);
            flowLayoutPanelPlayerX.Name = "flowLayoutPanelPlayerX";
            flowLayoutPanelPlayerX.Size = new Size(107, 50);
            flowLayoutPanelPlayerX.TabIndex = 1;
            // 
            // labelPlayerXName
            // 
            labelPlayerXName.AutoSize = true;
            labelPlayerXName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerXName.Location = new Point(0, 0);
            labelPlayerXName.Margin = new Padding(0);
            labelPlayerXName.Name = "labelPlayerXName";
            labelPlayerXName.Size = new Size(55, 15);
            labelPlayerXName.TabIndex = 0;
            labelPlayerXName.Text = "Player X:";
            // 
            // labelPlayerXWinRate
            // 
            labelPlayerXWinRate.AutoSize = true;
            labelPlayerXWinRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerXWinRate.Location = new Point(0, 15);
            labelPlayerXWinRate.Margin = new Padding(0);
            labelPlayerXWinRate.Name = "labelPlayerXWinRate";
            labelPlayerXWinRate.Size = new Size(58, 15);
            labelPlayerXWinRate.TabIndex = 1;
            labelPlayerXWinRate.Text = "Win rate:";
            // 
            // labelPlayerXMatchPlayed
            // 
            labelPlayerXMatchPlayed.AutoSize = true;
            labelPlayerXMatchPlayed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPlayerXMatchPlayed.Location = new Point(0, 30);
            labelPlayerXMatchPlayed.Margin = new Padding(0);
            labelPlayerXMatchPlayed.Name = "labelPlayerXMatchPlayed";
            labelPlayerXMatchPlayed.Size = new Size(87, 15);
            labelPlayerXMatchPlayed.TabIndex = 2;
            labelPlayerXMatchPlayed.Text = "Match played: ";
            // 
            // pictureBoxPlayerX
            // 
            pictureBoxPlayerX.Dock = DockStyle.Fill;
            pictureBoxPlayerX.Location = new Point(1, 1);
            pictureBoxPlayerX.Margin = new Padding(0);
            pictureBoxPlayerX.Name = "pictureBoxPlayerX";
            pictureBoxPlayerX.Size = new Size(50, 50);
            pictureBoxPlayerX.TabIndex = 2;
            pictureBoxPlayerX.TabStop = false;
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
            panelHeader.ResumeLayout(false);
            tableLayoutPanelMenu.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerO).EndInit();
            flowLayoutPanelGameStat.ResumeLayout(false);
            flowLayoutPanelGameStat.PerformLayout();
            flowLayoutPanelPlayerX.ResumeLayout(false);
            flowLayoutPanelPlayerX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerX).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelGame;
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnMinimize;
        private TableLayoutPanel tableLayoutChessBoard;
        private TableLayoutPanel tableLayoutPanelMenu;
        private FlowLayoutPanel flowLayoutPanelGameStat;
        private FlowLayoutPanel flowLayoutPanelPlayerX;
        private PictureBox pictureBoxPlayerO;
        private PictureBox pictureBoxPlayerX;
        private Label labelPlayerXName;
        private Label labelPlayerXWinRate;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelPlayerOName;
        private Label labelPlayerOWinRate;
        private Label labelPlayerOMatchPlayed;
        private Label labelPlayerXMatchPlayed;
        private Label labelTimeRemaining;
        private ProgressBar progressTurnTimer;
        private Label labelCurrentTurn;
    }
}
