using BackEnd.Models;
using BackEnd.Services;
using FrontEnd;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public FriendCard()
        {
            InitializeComponent();
        }

        private ObjectId currentUserId;
        private ObjectId targetUserId;
        private string friendshipStatus = "none";
        public event Action<string, bool>? FriendActionClicked; // string: targetId, bool: isFriend

        public void SetFriendData(User user, ObjectId currentUserId)
        {
            this.currentUserId = currentUserId;
            this.targetUserId = user.Id;

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
            WinRate.Text = $"Win Rate: {user.WinRate}%";

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
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
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

            switch (friendshipStatus)
            {
                case "none":
                    var newFriend = new BsonDocument
                    {
                        { "User1Id", currentUserId },
                        { "User2Id", targetUserId },
                        { "status", "pending" }
                    };
                    friendships.InsertOne(newFriend);
                    friendshipStatus = "pending";
                    btnAction.Text = "Pending";
                    break;
                case "accepted":
                    friendships.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", existing["_id"]));
                    btnAction.Text = "Add Friend";
                    friendshipStatus = "none";
                    break;
                case "pending":
                    friendships.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", existing["_id"]));
                    btnAction.Text = "Add Friend";
                    friendshipStatus = "none";
                    break;
            }

            // Gửi event để form cha biết thay đổi
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
