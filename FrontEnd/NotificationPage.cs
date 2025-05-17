using Amazon.Runtime.Internal.Util;
using BackEnd.Services;
using FrontEnd;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An
{
    public partial class NotificationPage : Form
    {
        private ObjectId currentUserId; // truyền vào khi khởi tạo

        public NotificationPage(ObjectId currentUserId)
        {
            InitializeComponent();
            this.currentUserId = currentUserId;
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            var db = new DatabaseConnection();
            var friendships = db.GetFriendShipsCollection();
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("User2Id", currentUserId),
                Builders<BsonDocument>.Filter.Eq("status", "pending")
            );
            var requests = friendships.Find(filter).ToList();

            foreach (var req in requests)
            {
                var users = db.GetUsersCollection();
                var sender = users.Find(Builders<BsonDocument>.Filter.Eq("_id", req["User1Id"])).FirstOrDefault();
                string senderName = sender != null && sender.Contains("username") ? sender["username"].AsString : "Unknown";

                var notification = new Notification();
                notification.SetFriendRequest(req["_id"].AsObjectId, senderName);
                notification.FriendAccepted += (id) => { /* Cập nhật lại giao diện nếu cần */ };
                panelNotifications.Controls.Add(notification);
            }
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }

}
