namespace FrontEnd
{
    partial class UserProfile
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lbUsername = new Label();
            Winrate = new Label();
            lbMatchWonNum = new Label();
            label5 = new Label();
            lbMatchNum = new Label();
            lbMatchWon = new Label();
            lbEmail = new Label();
            lbELO = new Label();
            flowLayoutGames = new FlowLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(149, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbUsername.Location = new Point(343, 0);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(124, 25);
            lbUsername.TabIndex = 2;
            lbUsername.Text = "<Username>";
            // 
            // Winrate
            // 
            Winrate.AutoSize = true;
            Winrate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            Winrate.Location = new Point(149, 76);
            Winrate.Name = "Winrate";
            Winrate.Size = new Size(49, 25);
            Winrate.TabIndex = 3;
            Winrate.Text = "ELO:";
            // 
            // lbMatchWonNum
            // 
            lbMatchWonNum.AutoSize = true;
            lbMatchWonNum.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchWonNum.Location = new Point(343, 51);
            lbMatchWonNum.Name = "lbMatchWonNum";
            lbMatchWonNum.Size = new Size(23, 25);
            lbMatchWonNum.TabIndex = 4;
            lbMatchWonNum.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label5.Location = new Point(149, 26);
            label5.Name = "label5";
            label5.Size = new Size(157, 25);
            label5.TabIndex = 5;
            label5.Text = "Matches played: ";
            // 
            // lbMatchNum
            // 
            lbMatchNum.AutoSize = true;
            lbMatchNum.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchNum.Location = new Point(343, 26);
            lbMatchNum.Name = "lbMatchNum";
            lbMatchNum.Size = new Size(23, 25);
            lbMatchNum.TabIndex = 6;
            lbMatchNum.Text = "0";
            // 
            // lbMatchWon
            // 
            lbMatchWon.AutoSize = true;
            lbMatchWon.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbMatchWon.Location = new Point(149, 51);
            lbMatchWon.Name = "lbMatchWon";
            lbMatchWon.Size = new Size(118, 25);
            lbMatchWon.TabIndex = 8;
            lbMatchWon.Text = "Match won: ";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbEmail.Location = new Point(0, 101);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(139, 25);
            lbEmail.TabIndex = 9;
            lbEmail.Text = "Email address: ";
            // 
            // lbELO
            // 
            lbELO.AutoSize = true;
            lbELO.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbELO.Location = new Point(343, 76);
            lbELO.Name = "lbELO";
            lbELO.Size = new Size(23, 25);
            lbELO.TabIndex = 10;
            lbELO.Text = "0";
            // 
            // flowLayoutGames
            // 
            flowLayoutGames.AutoScroll = true;
            flowLayoutGames.Dock = DockStyle.Fill;
            flowLayoutGames.FlowDirection = FlowDirection.TopDown;
            flowLayoutGames.Location = new Point(0, 200);
            flowLayoutGames.Margin = new Padding(0);
            flowLayoutGames.Name = "flowLayoutGames";
            flowLayoutGames.Size = new Size(640, 190);
            flowLayoutGames.TabIndex = 11;
            flowLayoutGames.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbMatchWon);
            panel1.Controls.Add(lbMatchWonNum);
            panel1.Controls.Add(lbELO);
            panel1.Controls.Add(Winrate);
            panel1.Controls.Add(lbMatchNum);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(lbEmail);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 150);
            panel1.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutGames, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(640, 390);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label2.ImageAlign = ContentAlignment.BottomLeft;
            label2.Location = new Point(0, 150);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(640, 50);
            label2.TabIndex = 13;
            label2.Text = "Match history:";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 390);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserProfile";
            Text = "Profile";
            Load += UserProfile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label lbUsername;
        private Label Winrate;
        private Label lbMatchWonNum;
        private Label label5;
        private Label lbMatchNum;
        private Label lbMatchWon;
        private Label lbEmail;
        private Label lbELO;
        private FlowLayoutPanel flowLayoutGames;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
    }
}