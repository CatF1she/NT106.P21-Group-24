using BackEnd.Models;
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
    public partial class FriendCard : UserControl
    {
        private HubConnection? _connection;
        private ObjectId currentUserId;
        private ObjectId targetUserId;
        private string friendshipStatus = "none";
        public event Action<string, bool>? FriendActionClicked;

        public FriendCard()
        {
            InitializeComponent();
            this.MinimumSize = new Size(524, 53); // Đảm bảo card không bị co lại
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.PerformLayout();
        }

        private async Task ConnectToSignalR()
        {
            if (_connection?.State == HubConnectionState.Connected) return;

            _connection = new HubConnectionBuilder()
                .WithUrl($"https://nt106-p21-group-24.onrender.com/friendhub?userId={currentUserId}")
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

            _connection.On<string>("FriendRequestAccepted", (accepterId) =>
            {
                if (accepterId == targetUserId.ToString() && IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            friendshipStatus = "accepted";
                            btnAction.Text = "Unfriend";
                            FriendActionClicked?.Invoke(targetUserId.ToString(), true);
                        }
                    }));
                }
            });

            _connection.On<string>("FriendRequestRejected", (rejecterId) =>
            {
                if (rejecterId == targetUserId.ToString() && IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            friendshipStatus = "none";
                            btnAction.Text = "Add Friend";
                            FriendActionClicked?.Invoke(targetUserId.ToString(), false);
                        }
                    }));
                }
            });
        }

        public async void SetFriendData(User user, ObjectId currentUserId)
        {
            this.currentUserId = currentUserId;
            this.targetUserId = user.Id;

            await ConnectToSignalR();

            var db = new DatabaseConnection();
            var friendships = db.GetFriendShipsCollection();

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1Id", currentUserId),
                    Builders<BsonDocument>.Filter.Eq("User2Id", targetUserId)
                ),
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1Id", targetUserId),
                    Builders<BsonDocument>.Filter.Eq("User2Id", currentUserId)
                )
            );

            var existing = friendships.Find(filter).FirstOrDefault();
            if (existing != null && existing.Contains("status"))
            {
                friendshipStatus = existing["status"].AsString;
            }
            else
            {
                friendshipStatus = "none";
            }

            UserName.Text = $"{user.Username}";
            MatchPlayed.Text = $"Matches Played: {user.MatchPlayed}";
            MatchWon.Text = $"Matches Won: {user.MatchWon}";
            WinRate.Text = $"Win Rate: {user.ELO}%";

            switch (friendshipStatus)
            {
                case "none":
                    btnAction.Text = "Add Friend";
                    break;
                case "pending":
                    btnAction.Text = "Pending";
                    break;
                case "accepted":
                    btnAction.Text = "Unfriend";
                    break;
            }

            // Cập nhật avatar giống Leaderboard (fix lỗi GDI+)
            if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
            {
                try
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(user.ProfilePictureUrl);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            var ms = new System.IO.MemoryStream(imageBytes); // KHÔNG dispose!
                            UserAvatar.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            UserAvatar.Image = Properties.Resources.user;
                        }
                    }
                }
                catch
                {
                    UserAvatar.Image = Properties.Resources.user;
                }
            }
            else
            {
                UserAvatar.Image = Properties.Resources.user;
            }
            if (UserAvatar.Image == null)
            {
                UserAvatar.Image = Properties.Resources.user;
            }
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (_connection?.State != HubConnectionState.Connected)
            {
                MessageBox.Show("Not connected to friend service. Please try again.");
                return;
            }

            switch (friendshipStatus)
            {
                case "none":
                    await _connection.InvokeAsync("SendFriendRequest", targetUserId.ToString());
                    friendshipStatus = "pending";
                    btnAction.Text = "Pending";
                    break;

                case "accepted":
                    var db = new DatabaseConnection();
                    var friendships = db.GetFriendShipsCollection();
                    var filter = Builders<BsonDocument>.Filter.Or(
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("User1Id", currentUserId),
                            Builders<BsonDocument>.Filter.Eq("User2Id", targetUserId)
                        ),
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("User1Id", targetUserId),
                            Builders<BsonDocument>.Filter.Eq("User2Id", currentUserId)
                        )
                    );
                    friendships.DeleteOne(filter);
                    btnAction.Text = "Add Friend";
                    friendshipStatus = "none";
                    break;

                case "pending":
                    var dbConn = new DatabaseConnection();
                    var friendshipsColl = dbConn.GetFriendShipsCollection();
                    var pendingFilter = Builders<BsonDocument>.Filter.Or(
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("User1Id", currentUserId),
                            Builders<BsonDocument>.Filter.Eq("User2Id", targetUserId)
                        ),
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("User1Id", targetUserId),
                            Builders<BsonDocument>.Filter.Eq("User2Id", currentUserId)
                        )
                    );
                    friendshipsColl.DeleteOne(pendingFilter);
                    btnAction.Text = "Add Friend";
                    friendshipStatus = "none";
                    break;
            }

            FriendActionClicked?.Invoke(targetUserId.ToString(), friendshipStatus == "accepted");
        }

        private void FriendCard_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
            UserName.ForeColor = ThemeColor.PrimaryColor;
            MatchPlayed.ForeColor = ThemeColor.SecondaryColor;
            MatchWon.ForeColor = ThemeColor.SecondaryColor;
            WinRate.ForeColor = ThemeColor.SecondaryColor;
        }
    }
}
