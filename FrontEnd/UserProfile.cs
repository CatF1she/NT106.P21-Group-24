using BackEnd.Models;
using BackEnd.Services;
using Do_An;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class UserProfile : Form
    {
        private ObjectId userId;

        public UserProfile(ObjectId userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Resize += (_, __) => AdjustLabelWidths();
        }

        private async void UserProfile_Load(object sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var users = db.GetUsersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            var user = await users.Find(filter).FirstOrDefaultAsync();

            if (user != null)
            {
                lbUsername.Text = $"{user["username"]}";
                lbMatchNum.Text = $"{user.GetValue("MatchPlayed", 0)}";
                lbMatchWonNum.Text = $"{user.GetValue("MatchWon", 0)}";
                int matchWon = user.GetValue("MatchWon", 0).ToInt32();
                int matchPlayed = user.GetValue("MatchPlayed", 1).ToInt32();
                int winRate = (matchPlayed == 0) ? 0 : (matchWon * 100 / matchPlayed);
                lbWinRate.Text = $"{winRate}%";
                lbEmail.Text = $"Email: {user["email"]}";
                await LoadImageAsync(pictureBox1, user.GetValue("profilePicture", "").AsString);
                await LoadGameSessionsAsync(userId);
            }
        }

        private async Task LoadImageAsync(PictureBox pictureBox, string? url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    using var httpClient = new HttpClient();
                    var imageBytes = await httpClient.GetByteArrayAsync(url);
                    var stream = new MemoryStream(imageBytes); // Do not dispose
                    pictureBox.Image = Image.FromStream(stream);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Image Load Error] {ex.Message}");
            }

            pictureBox.Image = Do_An.Properties.Resources.user;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private async Task LoadGameSessionsAsync(ObjectId playerId)
        {
            var db = new DatabaseConnection();
            var sessionsCollection = db.GetGameSessionsCollection();
            var usersCollection = db.GetUsersCollection();

            var filter = Builders<GameSession>.Filter.Or(
                Builders<GameSession>.Filter.Eq(gs => gs.PlayerXId, playerId.ToString()),
                Builders<GameSession>.Filter.Eq(gs => gs.PlayerOId, playerId.ToString())
            );

            var sessions = await sessionsCollection
            .Find(filter)
            .SortByDescending(s => s.UpdatedAt)
            .ToListAsync();

            flowLayoutGames.Controls.Clear();

            foreach (var session in sessions)
            {
                string opponentId = session.PlayerXId == playerId.ToString()
                    ? session.PlayerOId ?? ""
                    : session.PlayerXId;

                string opponentName = "Unknown";
                if (!string.IsNullOrWhiteSpace(opponentId) && ObjectId.TryParse(opponentId, out ObjectId oid))
                {
                    var userFilter = Builders<BsonDocument>.Filter.Eq("_id", oid);
                    var opponentDoc = await usersCollection.Find(userFilter).FirstOrDefaultAsync();
                    if (opponentDoc != null)
                        opponentName = opponentDoc.GetValue("username", "Unknown").AsString;
                }

                bool didWin = session.WinnerPlayerId == playerId.ToString();
                bool isFinished = !string.IsNullOrWhiteSpace(session.WinnerPlayerId);

                string statusText = didWin ? "✅ You won" : (isFinished ? "❌ You lost" : "⏳ In Progress");
                string matchInfo = $"vs {opponentName} • Match ended at: {session.UpdatedAt.ToLocalTime():g}";

                var label = CreateSessionLabel($"{statusText}\n{matchInfo}",
                    isFinished ? (didWin ? Color.LightGreen : Color.LightCoral) : Color.LightGray,
                    session.Id.ToString());

                flowLayoutGames.Controls.Add(label);
            }

            AdjustLabelWidths();
        }

        private Label CreateSessionLabel(string text, Color backColor, string sessionId)
        {
            var label = new Label
            {
                AutoSize = false,
                Height = 60,
                Width = flowLayoutGames.ClientSize.Width - 25,
                Font = new Font("Segoe UI", 10),
                BackColor = backColor,
                Text = text,
                BorderStyle = BorderStyle.None,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(1),
                Margin = new Padding(1),
                Cursor = Cursors.Hand,
                Tag = sessionId
            };

            label.Click += (sender, e) =>
            {
                if (sender is Label lbl && lbl.Tag is string id)
                {
                    new MatchHistory(userId, id).Show();
                }
            };

            return label;
        }


        private void AdjustLabelWidths()
        {
            foreach (Control ctrl in flowLayoutGames.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Width = flowLayoutGames.ClientSize.Width;
                }
            }
        }
    }
}
