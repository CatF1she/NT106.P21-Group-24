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

        private void UserProfile_Load(object sender, EventArgs e)
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
            }
        }
    }
}
