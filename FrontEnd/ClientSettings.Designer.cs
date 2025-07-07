namespace Do_An
{
    partial class ClientSettings
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSFX = new Do_An.FrontEnd.CustomControls.CustomToggleButton();
            btnBGM = new Do_An.FrontEnd.CustomControls.CustomToggleButton();
            btnChangeUserInfo = new Button();
            btnLogout = new Button();
            label4 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(87, 216);
            label1.Name = "label1";
            label1.Size = new Size(138, 21);
            label1.TabIndex = 0;
            label1.Text = "User Information:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(87, 67);
            label2.Name = "label2";
            label2.Size = new Size(108, 21);
            label2.TabIndex = 1;
            label2.Text = "Sound Effect:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(87, 122);
            label3.Name = "label3";
            label3.Size = new Size(149, 21);
            label3.TabIndex = 2;
            label3.Text = "Background Music:";
            // 
            // btnSFX
            // 
            btnSFX.AutoSize = true;
            btnSFX.Checked = true;
            btnSFX.CheckState = CheckState.Checked;
            btnSFX.Location = new Point(339, 66);
            btnSFX.MinimumSize = new Size(45, 22);
            btnSFX.Name = "btnSFX";
            btnSFX.Size = new Size(45, 22);
            btnSFX.TabIndex = 3;
            btnSFX.UseVisualStyleBackColor = true;
            // 
            // btnBGM
            // 
            btnBGM.AutoSize = true;
            btnBGM.Checked = true;
            btnBGM.CheckState = CheckState.Checked;
            btnBGM.Location = new Point(339, 124);
            btnBGM.MinimumSize = new Size(45, 22);
            btnBGM.Name = "btnBGM";
            btnBGM.Size = new Size(45, 22);
            btnBGM.TabIndex = 4;
            btnBGM.UseVisualStyleBackColor = true;
            // 
            // btnChangeUserInfo
            // 
            btnChangeUserInfo.BackColor = Color.FromArgb(51, 51, 76);
            btnChangeUserInfo.FlatAppearance.BorderSize = 0;
            btnChangeUserInfo.FlatStyle = FlatStyle.Flat;
            btnChangeUserInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangeUserInfo.ForeColor = Color.Gainsboro;
            btnChangeUserInfo.Location = new Point(292, 209);
            btnChangeUserInfo.Name = "btnChangeUserInfo";
            btnChangeUserInfo.Size = new Size(92, 33);
            btnChangeUserInfo.TabIndex = 8;
            btnChangeUserInfo.Text = "Change";
            btnChangeUserInfo.UseVisualStyleBackColor = false;
            btnChangeUserInfo.Click += btnChangeUserInfo_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(51, 51, 76);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Gainsboro;
            btnLogout.Location = new Point(87, 266);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(108, 33);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(87, 20);
            label4.Name = "label4";
            label4.Size = new Size(57, 21);
            label4.TabIndex = 10;
            label4.Text = "Sound";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(87, 187);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 3);
            panel2.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(87, 163);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 12;
            label5.Text = "User";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(87, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 3);
            panel1.TabIndex = 14;
            // 
            // ClientSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnLogout);
            Controls.Add(btnChangeUserInfo);
            Controls.Add(btnBGM);
            Controls.Add(btnSFX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ClientSettings";
            Text = "Client Settings";
            Load += ClientSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private FrontEnd.CustomControls.CustomToggleButton btnSFX;
        private FrontEnd.CustomControls.CustomToggleButton btnBGM;
        private Button btnChangeUserInfo;
        private Button btnLogout;
        private Label label4;
        private Panel panel2;
        private Label label5;
        private Panel panel1;
    }
}