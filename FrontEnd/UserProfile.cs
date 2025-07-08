using BackEnd.Models;
using BackEnd.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FrontEnd
{
    public partial class UserProfile : Form
    {
        private ObjectId userId;

        public UserProfile(ObjectId userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private async void UserProfile_Load(object sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var users = db.GetUsersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            var user = users.Find(filter).FirstOrDefault();

            if (user != null)
            {
                lbUsername.Text = $"{user["username"]}";
                lbMatchNum.Text = $"{user.GetValue("MatchPlayed", 0)}";
                lbMatchWonNum.Text = $"{user.GetValue("MatchWon", 0)}";
                lbELO.Text = $"{user.GetValue("ELO", 0)}%";
                lbEmail.Text = $"Email: {user["email"]}";
                await LoadImageAsync(pictureBox1, $"{user.GetValue("profilePicture", "")}");
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

                    var stream = new MemoryStream(imageBytes); // do not dispose!
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
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private async Task LoadGameSessionsAsync(ObjectId playerId)
        {
            var db = new DatabaseConnection();
            var sessionsCollection = db.GetGameSessionsCollection();
            var usersCollection = db.GetUsersCollection();

            // Find sessions where user is X or O
            var filter = Builders<GameSession>.Filter.Or(
                Builders<GameSession>.Filter.Eq(gs => gs.PlayerXId, playerId.ToString()),
                Builders<GameSession>.Filter.Eq(gs => gs.PlayerOId, playerId.ToString())
            );

            var sessions = await sessionsCollection.Find(filter).ToListAsync();

            flowLayoutGames.Controls.Clear();

            foreach (var session in sessions)
            {
                // Determine opponent ID
                string opponentId = session.PlayerXId == playerId.ToString()
                    ? session.PlayerOId ?? "(waiting...)"
                    : session.PlayerXId;

                string opponentName = "Unknown";

                if (!string.IsNullOrWhiteSpace(opponentId) && opponentId != "(waiting...)")
                {
                    var userFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(opponentId));
                    var opponentDoc = await usersCollection.Find(userFilter).FirstOrDefaultAsync();

                    if (opponentDoc != null)
                        opponentName = opponentDoc.GetValue("username", "Unknown").AsString;
                }

                // Check win/lose
                bool didWin = session.WinnerPlayerId == playerId.ToString();
                bool isFinished = !string.IsNullOrWhiteSpace(session.WinnerPlayerId);

                var label = new Label
                {
                    AutoSize = false,
                    Width = flowLayoutGames.Width - 25,
                    Height = 60,
                    Padding = new Padding(8),
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    BackColor = isFinished ? (didWin ? Color.LightGreen : Color.LightCoral) : Color.LightGray,
                    Text = $"{(didWin ? "✅ You won" : (isFinished ? "❌ You lost" : "⏳ In Progress"))}\n" +
                           $"vs {opponentName} • Match ended at: {session.UpdatedAt.ToLocalTime():g}"
                };

                label.BorderStyle = BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleLeft;

                flowLayoutGames.Controls.Add(label);
            }
        }


    }
}
