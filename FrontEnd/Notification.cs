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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Do_An
{
    public partial class Notification : UserControl
    {
        public event Action<ObjectId>? FriendAccepted;
        private ObjectId requestId;
        private string senderName;

        public Notification()
        {
            InitializeComponent();
            btnAccept.Click += btnAccept_Click;
            btnRefuse.Click += btnRefuse_Click;
        }

        public void SetFriendRequest(ObjectId requestId, string senderName)
        {
            this.requestId = requestId;
            this.senderName = senderName;
            lblMessage.Text = $"{senderName} wants to make friend with you.";
        }

        private void btnAccept_Click(object? sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var friendships = db.GetFriendShipsCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", requestId);
            var update = Builders<BsonDocument>.Update.Set("status", "accepted");
            friendships.UpdateOne(filter, update);

            FriendAccepted?.Invoke(requestId);
            this.Dispose();
        }

        private void btnRefuse_Click(object? sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var friendships = db.GetFriendShipsCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", requestId);
            friendships.DeleteOne(filter);

            this.Dispose();
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
            lblMessage.ForeColor = ThemeColor.SecondaryColor;
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
