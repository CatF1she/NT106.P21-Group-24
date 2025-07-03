using Amazon.Runtime.Internal.Util;
using BackEnd.Services;
using FrontEnd;
using Microsoft.AspNetCore.SignalR.Client;
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
        private HubConnection? _connection;
        private ObjectId currentUserId;

        public NotificationPage(ObjectId currentUserId)
        {
            InitializeComponent();
            this.currentUserId = currentUserId;
            this.Load += NotificationPage_Load;
        }

        private async void NotificationPage_Load(object sender, EventArgs e)
        {
            await ConnectToSignalR();
            LoadNotifications();
        }

        private async Task ConnectToSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8000/friendhub?userId={currentUserId}")
                .WithAutomaticReconnect()
                .Build();

            RegisterHandlers();

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection to friend service failed: " + ex.Message);
            }
        }

        private void RegisterHandlers()
        {
            if (_connection == null) return;

            _connection.On<string, string, string>("ReceiveFriendRequest", (requestId, senderId, senderName) =>
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        var notification = new Notification();
                        notification.SetFriendRequest(
                            ObjectId.Parse(requestId),
                            senderId,
                            senderName,
                            currentUserId.ToString()
                        );
                        notification.FriendAccepted += (id) => { /* Handle friend acceptance if needed */ };
                        if (!panelNotifications.IsDisposed)
                        {
                            panelNotifications.Controls.Add(notification);
                        }
                    }));
                }
            });
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
                string senderId = req["User1Id"].AsObjectId.ToString();

                var notification = new Notification();
                notification.SetFriendRequest(
                    req["_id"].AsObjectId,
                    senderId,
                    senderName,
                    currentUserId.ToString()
                );
                notification.FriendAccepted += (id) => { /* Handle friend acceptance if needed */ };
                panelNotifications.Controls.Add(notification);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_connection != null)
            {
                _connection.StopAsync().Wait();
                _connection.DisposeAsync().AsTask().Wait();
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
