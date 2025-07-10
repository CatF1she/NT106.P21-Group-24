using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
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
                var bsonUsers = users.Find(Builders<BsonDocument>.Filter.Empty).ToList();

                var userList = bsonUsers.Select(doc => new
                {
                    Id = doc["_id"].AsObjectId,
                    Username = doc.GetValue("username", "").AsString,
                    MatchPlayed = doc.GetValue("MatchPlayed", 0).ToInt32(),
                    MatchWon = doc.GetValue("MatchWon", 0).ToInt32(),
                    ProfilePicture = doc.GetValue("profilePicture", "").AsString,
                    Score = doc.GetValue("MatchWon", 0).ToInt32() * 3 +
                            (doc.GetValue("MatchPlayed", 0).ToInt32() - doc.GetValue("MatchWon", 0).ToInt32())
                }).OrderByDescending(u => u.Score).ToList();

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

                        txtMyUsermame.Text = user.Username;
                        txtMyRank.Text = $"Rank: {myRank}";
                        txtMyMatchPlayed.Text = $"Match Played: {user.MatchPlayed}";
                        txtMyMatchWon.Text = $"Match Won: {user.MatchWon}";

                        await LoadImageAsync(picMyAvatar, user.ProfilePicture);

                        if (user.Score > 100)
                            picMyRank.Image = Properties.Resources.Gold;
                        else if (user.Score >= 50)
                            picMyRank.Image = Properties.Resources.Silver;
                        else
                            picMyRank.Image = Properties.Resources.Bronze;
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

        private async void LoadCurrentUserInfo()
        {
            try
            {
                var db = new DatabaseConnection();
                var users = db.GetUsersCollection();
                var filter = Builders<BsonDocument>.Filter.Eq("_id", currentUserId);
                var userDoc = users.Find(filter).FirstOrDefault();

                if (userDoc != null)
                {
                    txtMyUsermame.Text = userDoc.GetValue("username", "").AsString;
                    txtMyRank.Text = $"Rank: {userDoc.GetValue("ELO", 0).ToInt32()}";

                    var profilePicture = userDoc.GetValue("profilePicture", "").AsString;
                    await LoadImageAsync(picMyAvatar, profilePicture);
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

        private async Task LoadImageAsync(PictureBox pictureBox, string? url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    using var httpClient = new HttpClient();
                    var imageBytes = await httpClient.GetByteArrayAsync(url);

                    var stream = new MemoryStream(imageBytes); // do not dispose!
                    pictureBox.Image = Image.FromStream(stream);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (ImageAnimator.CanAnimate(pictureBox.Image))
                        ImageAnimator.Animate(pictureBox.Image, (s, e) => pictureBox.Invalidate());

                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Image Load Error] {ex.Message}");
            }

            pictureBox.Image = Properties.Resources.user1;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
