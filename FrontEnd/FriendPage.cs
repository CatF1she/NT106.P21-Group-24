using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using FrontEnd;
using BackEnd.Services;
using MongoDB.Bson;

namespace Do_An
{
    public partial class FriendPage : Form
    {
        private readonly ObjectId currentUserId;
        public FriendPage(ObjectId userID)
        {
            InitializeComponent();
            currentUserId = userID;
        }

        private List<User> allUsers = new List<User>();
        private System.Windows.Forms.Timer searchDelayTimer;

        private void LoadUsers()
        {
            try
            {
                var db = new DatabaseConnection();
                var userCollection = db.GetUsersCollection();

                // Lấy toàn bộ người dùng trừ chính mình
                var filter = Builders<BsonDocument>.Filter.Ne("_id", currentUserId);
                var bsonUsers = userCollection.Find(filter).ToList();

                // Chuyển từ BsonDocument sang User model
                allUsers = bsonUsers.Select(doc => new User
                {
                    Id = (ObjectId)doc["_id"],
                    Username = doc["username"].AsString,
                    MatchPlayed = doc.GetValue("MatchPlayed", 0).ToInt32(),
                    MatchWon = doc.GetValue("MatchWon", 0).ToInt32(),
                    ELO = doc.GetValue("ELO", 0).ToInt32()
                }).ToList();

                DisplayUsers(allUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }


        private void DisplayUsers(List<User> users)
        {
            FriendList.Controls.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                var card = new FriendCard();
                card.SetFriendData(users[i], currentUserId);
                card.Width = FriendList.Width - 25;
                // Xen kẽ màu nền
                card.BackColor = (i % 2 == 0) ? Color.LightGray : Color.White;
                FriendList.Controls.Add(card);
            }
        }


        private void FriendPage_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTheme();
            searchDelayTimer = new System.Windows.Forms.Timer();
            searchDelayTimer.Interval = 1000;
            searchDelayTimer.Tick += SearchDelayTimer_Tick;
        }

        private void SearchDelayTimer_Tick(object? sender, EventArgs e)
        {
            searchDelayTimer.Stop(); // Dừng timer

            string keyword = SearchBar.Text.Trim().ToLower();
            var filteredUsers = allUsers.Where(u => u.Username.ToLower().Contains(keyword)).ToList();
            DisplayUsers(filteredUsers);
        }

        private void FriendList_Resize(object sender, EventArgs e)
        {
            foreach (FriendCard card in FriendList.Controls)
            {
                card.Width = FriendList.ClientSize.Width - 25;
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
            picbtnSearch.BackColor = ThemeColor.PrimaryColor;
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            searchDelayTimer.Stop();
            searchDelayTimer.Start();
        }
    }
}
