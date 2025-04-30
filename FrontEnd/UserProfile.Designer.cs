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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            listView1 = new ListView();
            Date = new ColumnHeader();
            Opponent = new ColumnHeader();
            Type = new ColumnHeader();
            Result = new ColumnHeader();
            Replay = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(250, 47);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(359, 47);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 2;
            label2.Text = "Nguyen Van A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(304, 98);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 3;
            label3.Text = "ELO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label4.Location = new Point(359, 98);
            label4.Name = "label4";
            label4.Size = new Size(56, 25);
            label4.TabIndex = 4;
            label4.Text = "2000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label5.Location = new Point(165, 73);
            label5.Name = "label5";
            label5.Size = new Size(188, 25);
            label5.TabIndex = 5;
            label5.Text = "Number of matches:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label6.Location = new Point(359, 73);
            label6.Name = "label6";
            label6.Size = new Size(45, 25);
            label6.TabIndex = 6;
            label6.Text = "200";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label7.Location = new Point(53, 152);
            label7.Name = "label7";
            label7.Size = new Size(135, 25);
            label7.TabIndex = 8;
            label7.Text = "Match History";
            // 
            // listView1
            // 
            listView1.AllowColumnReorder = true;
            listView1.AutoArrange = false;
            listView1.Columns.AddRange(new ColumnHeader[] { Date, Opponent, Type, Result, Replay });
            listView1.Location = new Point(53, 180);
            listView1.Name = "listView1";
            listView1.Size = new Size(441, 97);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Date
            // 
            Date.Text = "Date";
            Date.Width = 150;
            // 
            // Opponent
            // 
            Opponent.Text = "Opponent";
            Opponent.Width = 120;
            // 
            // Type
            // 
            Type.Text = "X/O";
            Type.Width = 46;
            // 
            // Result
            // 
            Result.Text = "Result";
            // 
            // Replay
            // 
            Replay.Text = "Replay";
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "UserProfile";
            Text = "UserProfile";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListView listView1;
        private ColumnHeader Date;
        private ColumnHeader Opponent;
        private ColumnHeader Type;
        private ColumnHeader Result;
        private ColumnHeader Replay;
    }
}