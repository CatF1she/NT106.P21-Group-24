using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using System.Net.Http;
using System.Net.Http.Json;
using System.IO;
using MongoDB.Driver;
using BackEnd.Services;

namespace Do_An
{
    public partial class Leaderboard : Form
    {
        private ObjectId currentUserId;
        public Leaderboard(ObjectId currentUserId)
        {
            InitializeComponent();
            this.currentUserId = currentUserId;
            flowpanelPlayerRanking.Resize += (s, e) =>
            {
                foreach (Control c in flowpanelPlayerRanking.Controls)
                    c.Width = flowpanelPlayerRanking.ClientSize.Width - 2;
            };
        }

        private async void Leaderboard_Load(object sender, EventArgs e)
        {
            await LoadLeaderboard();
        }

        private async Task LoadLeaderboard()
        {
            try
            {
                var db = new DatabaseConnection();
                var users = db.GetUsersCollection();
                var bsonUsers = users.Find(Builders<MongoDB.Bson.BsonDocument>.Filter.Empty).ToList();
                // Tính điểm và gom vào list
                var userList = bsonUsers.Select(doc => new
                {
                    Id = doc["_id"].AsObjectId,
                    Username = doc.GetValue("username", "").AsString,
                    MatchPlayed = doc.GetValue("MatchPlayed", 0).ToInt32(),
                    MatchWon = doc.GetValue("MatchWon", 0).ToInt32(),
                    ProfilePicture = doc.GetValue("profilePicture", "").AsString,
                    Score = doc.GetValue("MatchWon", 0).ToInt32() * 3 + (doc.GetValue("MatchPlayed", 0).ToInt32() - doc.GetValue("MatchWon", 0).ToInt32())
                }).OrderByDescending(u => u.Score).ToList();

                // Hiển thị danh sách lên flowpanelPlayerRanking
                flowpanelPlayerRanking.Controls.Clear();
                int rank = 1;
                int myRank = 0;
                foreach (var user in userList)
                {
                    var card = new PlayerRankingCard();
                    await card.SetPlayerInfo(user.Username, user.MatchPlayed, user.MatchWon, user.Score, rank, user.ProfilePicture);
                    card.BackColor = (rank % 2 == 0) ? Color.LightGray : Color.White;
                    flowpanelPlayerRanking.Controls.Add(card);
                    if (user.Id == currentUserId)
                    {
                        myRank = rank;
                        // Cập nhật panel MyInfo
                        txtMyUsermame.Text = user.Username;
                        txtMyRank.Text = $"Rank: {myRank}";
                        txtMyMatchPlayed.Text = $"Match Played: {user.MatchPlayed}";
                        txtMyMatchWon.Text = $"Match Won: {user.MatchWon}";
                        if (!string.IsNullOrEmpty(user.ProfilePicture))
                        {
                            try
                            {
                                using (var httpClient = new System.Net.Http.HttpClient())
                                {
                                    var imageBytes = httpClient.GetByteArrayAsync(user.ProfilePicture).Result;
                                    using (var ms = new MemoryStream(imageBytes))
                                    {
                                        picMyAvatar.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            catch
                            {
                                picMyAvatar.Image = Properties.Resources.user1;
                            }
                        }
                        else
                        {
                            picMyAvatar.Image = Properties.Resources.user1;
                        }
                        // Nếu vẫn null (lỗi định dạng ảnh), vẫn set mặc định
                        if (picMyAvatar.Image == null)
                        {
                            picMyAvatar.Image = Properties.Resources.user1;
                        }
                        // Đổi hình picMyRank dựa vào điểm
                        if (user.Score > 100)
                        {
                            picMyRank.Image = Properties.Resources.Gold;
                        }
                        else if (user.Score >= 50)
                        {
                            picMyRank.Image = Properties.Resources.Silver;
                        }
                        else
                        {
                            picMyRank.Image = Properties.Resources.Bronze;
                        }
                    }
                    rank++;
                }
                foreach (Control c in flowpanelPlayerRanking.Controls)
                    c.Width = flowpanelPlayerRanking.ClientSize.Width - 2;
                flowpanelPlayerRanking.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bảng xếp hạng: {ex.Message}");
            }
        }

        private void LoadCurrentUserInfo()
        {
            try
            {
                var db = new DatabaseConnection();
                var users = db.GetUsersCollection();
                var filter = Builders<MongoDB.Bson.BsonDocument>.Filter.Eq("_id", currentUserId);
                var userDoc = users.Find(filter).FirstOrDefault();
                if (userDoc != null)
                {
                    txtMyUsermame.Text = userDoc.GetValue("username", "").AsString;
                    txtMyRank.Text = $"Rank: {userDoc.GetValue("ELO", 0).ToInt32()}";
                    var profilePicture = userDoc.GetValue("profilePicture", "").AsString;
                    if (!string.IsNullOrEmpty(profilePicture))
                    {
                        try
                        {
                            using (var httpClient = new System.Net.Http.HttpClient())
                            {
                                var imageBytes = httpClient.GetByteArrayAsync(profilePicture).Result;
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    picMyAvatar.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        catch
                        {
                            picMyAvatar.Image = Properties.Resources.user1;
                        }
                    }
                    else
                    {
                        picMyAvatar.Image = Properties.Resources.user1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin người dùng: {ex.Message}");
            }
        }

        private void picMyRank_Resize(object sender, EventArgs e)
        {
            picMyAvatar.Size = new Size(panelMyInfo.Width - 83, panelMyInfo.Width - 83);
        }
    }
}
