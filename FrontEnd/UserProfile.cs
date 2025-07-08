using BackEnd.Models;
using BackEnd.Services;
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
                lbELO.Text = $"{user.GetValue("ELO", 0)}%";
                lbEmail.Text = $"Email: {user["email"]}";
                await LoadImageAsync(pictureBox1, user.GetValue("profilePicture", "").AsString);
                await LoadGameSessionsAsync(userId);

                // Test label (also resizable)
                var testLabel = CreateSessionLabel("Test label", Color.LightBlue);
                flowLayoutGames.Controls.Add(testLabel);
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
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Image Load Error] {ex.Message}");
            }

            pictureBox.Image = Image.FromFile("Resources/x.png");
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

            var sessions = await sessionsCollection.Find(filter).ToListAsync();
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
                    isFinished ? (didWin ? Color.LightGreen : Color.LightCoral) : Color.LightGray);

                flowLayoutGames.Controls.Add(label);
            }

            AdjustLabelWidths();
        }

        private Label CreateSessionLabel(string text, Color backColor)
        {
            return new Label
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
                Margin = new Padding(1)
            };
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
