using BackEnd.Models;
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
    public partial class FriendCard : UserControl
    {
        public FriendCard()
        {
            InitializeComponent();
        }

        private ObjectId currentUserId;
        private ObjectId targetUserId;
        private bool isFriend;
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
            if (existing != null && existing.Contains("status") && existing["status"].AsString == "accepted")
            {
                isFriend = true;
            }
            else
            {
                isFriend = false;
            }

            UserName.Text = $"{user.Username}";
            MatchPlayed.Text = $"Matches Played: {user.MatchPlayed}";
            MatchWon.Text = $"Matches Won: {user.MatchWon}";
            WinRate.Text = $"Win Rate: {user.WinRate}%";

            btnAction.Text = isFriend ? "Unfriend" : "Add Friend";
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

            if (existing == null)
            {
                var newFriend = new BsonDocument
                {
                    { "User1Id", currentUserId },
                    { "User2Id", targetUserId },
                    { "status", "pending" }
                };
                friendships.InsertOne(newFriend);
                MessageBox.Show("Friend requested successfully!");
                btnAction.Text = "Unfriend";
                isFriend = false;
            }
            else
            {
                friendships.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", existing["_id"]));
                MessageBox.Show("Unfriended successfully!");
                btnAction.Text = "Add Friend";
                isFriend = false;
            }

            // Gửi event để form cha biết thay đổi
            FriendActionClicked?.Invoke(targetUserId.ToString(), isFriend);
        }


        private void FriendCard_Load(object sender, EventArgs e)
        {
            LoadTheme();
            if (isFriend == true)
            {
                btnAction.Text = "Unfriend";
            }
            else
            {
                btnAction.Text = "Add Friend";
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
            UserName.ForeColor = ThemeColor.PrimaryColor;
            MatchPlayed.ForeColor = ThemeColor.SecondaryColor;
            MatchWon.ForeColor = ThemeColor.SecondaryColor;
            WinRate.ForeColor = ThemeColor.SecondaryColor;
        }
    }
}
