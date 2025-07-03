namespace Do_An
{
    partial class Notification
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (_connection != null)
                {
                    _connection.StopAsync().Wait();
                    _connection.DisposeAsync().AsTask().Wait();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            btnRefuse = new Button();
            btnAccept = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(14, 11);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(43, 17);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            // 
            // btnRefuse
            // 
            btnRefuse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefuse.BackColor = Color.FromArgb(51, 51, 76);
            btnRefuse.FlatAppearance.BorderSize = 0;
            btnRefuse.FlatStyle = FlatStyle.Flat;
            btnRefuse.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefuse.ForeColor = Color.Gainsboro;
            btnRefuse.Location = new Point(466, 3);
            btnRefuse.Name = "btnRefuse";
            btnRefuse.Size = new Size(80, 34);
            btnRefuse.TabIndex = 6;
            btnRefuse.Text = "Refuse";
            btnRefuse.UseVisualStyleBackColor = false;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = Color.FromArgb(51, 51, 76);
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccept.ForeColor = Color.Gainsboro;
            btnAccept.Location = new Point(378, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(82, 34);
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // Notification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAccept);
            Controls.Add(btnRefuse);
            Controls.Add(lblMessage);
            Name = "Notification";
            Size = new Size(549, 42);
            Load += Notification_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private Button btnRefuse;
        private Button btnAccept;
    }
}
