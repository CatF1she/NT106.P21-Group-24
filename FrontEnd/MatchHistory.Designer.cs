namespace Do_An
{
    partial class MatchHistory
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panelHeader = new Panel();
            labelSummary = new Label();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            flowLayoutPanelMoveList = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanelMoveList, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            panelHeader.Controls.Add(labelSummary);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(btnMaximize);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Cursor = Cursors.Hand;
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 1;
            panelHeader.MouseDown += PanelHeader_MouseDown;
            // 
            // labelSummary
            // 
            labelSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelSummary.AutoSize = true;
            labelSummary.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelSummary.ForeColor = SystemColors.Control;
            labelSummary.Location = new Point(0, 23);
            labelSummary.Margin = new Padding(0);
            labelSummary.Name = "labelSummary";
            labelSummary.Size = new Size(156, 37);
            labelSummary.TabIndex = 9;
            labelSummary.Text = "Why I win?";
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
            // flowLayoutPanelMoveList
            // 
            flowLayoutPanelMoveList.AutoScroll = true;
            flowLayoutPanelMoveList.Dock = DockStyle.Fill;
            flowLayoutPanelMoveList.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelMoveList.Location = new Point(0, 60);
            flowLayoutPanelMoveList.Margin = new Padding(0);
            flowLayoutPanelMoveList.Name = "flowLayoutPanelMoveList";
            flowLayoutPanelMoveList.Size = new Size(800, 390);
            flowLayoutPanelMoveList.TabIndex = 2;
            flowLayoutPanelMoveList.WrapContents = false;
            // 
            // MatchHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MatchHistory";
            Text = "MatchHistory";
            tableLayoutPanel1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelHeader;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;
        private FlowLayoutPanel flowLayoutPanelMoveList;
        private Label labelSummary;
    }
}