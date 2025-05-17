namespace Do_An
{
    partial class NotificationPage
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
            btnNotificationFriends = new Button();
            panelNotifications = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnNotificationFriends
            // 
            btnNotificationFriends.BackColor = Color.FromArgb(51, 51, 76);
            btnNotificationFriends.FlatAppearance.BorderSize = 0;
            btnNotificationFriends.FlatStyle = FlatStyle.Flat;
            btnNotificationFriends.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNotificationFriends.ForeColor = Color.Gainsboro;
            btnNotificationFriends.Location = new Point(12, 12);
            btnNotificationFriends.Name = "btnNotificationFriends";
            btnNotificationFriends.Size = new Size(119, 33);
            btnNotificationFriends.TabIndex = 7;
            btnNotificationFriends.Text = "Friends";
            btnNotificationFriends.UseVisualStyleBackColor = false;
            // 
            // panelNotifications
            // 
            panelNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelNotifications.AutoScroll = true;
            panelNotifications.FlowDirection = FlowDirection.TopDown;
            panelNotifications.Location = new Point(12, 51);
            panelNotifications.Name = "panelNotifications";
            panelNotifications.Size = new Size(776, 387);
            panelNotifications.TabIndex = 8;
            // 
            // NotificationPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelNotifications);
            Controls.Add(btnNotificationFriends);
            Name = "NotificationPage";
            Text = "Notification";
            Load += Notification_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnNotificationFriends;
        private FlowLayoutPanel panelNotifications;
    }
}