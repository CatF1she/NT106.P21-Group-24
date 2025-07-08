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
    }
}
