using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Do_An
{
    public partial class Change_User_Info : Form
    {
        private ObjectId userId;

        public Change_User_Info(ObjectId userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Change_User_Info_Load(object sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var users = db.GetUsersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            var user = users.Find(filter).FirstOrDefault();

            if (user != null)
            {
                txtUsername.Text = user["username"].AsString;
                txtEmail.Text = user["email"].AsString;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var users = db.GetUsersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userId);
            var currentUser = users.Find(filter).FirstOrDefault();
            if (currentUser == null)
            {
                MessageBox.Show("User information not found!");
                return;
            }

            // 1. Check Username
            string newUsername = txtUsername.Text.Trim();
            if (newUsername != currentUser["username"].AsString)
            {
                var usernameFilter = Builders<BsonDocument>.Filter.Eq("username", newUsername);
                var existingUser = users.Find(usernameFilter).FirstOrDefault();
                if (existingUser != null)
                {
                    MessageBox.Show("This username already exists. Please choose another username!");
                    txtUsername.Focus();
                    return;
                }
            }

            // 2. Check Email
            string newEmail = txtEmail.Text.Trim();
            if (newEmail != currentUser["email"].AsString)
            {
                var emailFilter = Builders<BsonDocument>.Filter.Eq("email", newEmail) &
                                  Builders<BsonDocument>.Filter.Ne("_id", userId); // Exclude self
                var existingEmail = users.Find(emailFilter).FirstOrDefault();
                if (existingEmail != null)
                {
                    MessageBox.Show("This email already exists. Please choose another email!");
                    txtEmail.Focus();
                    return;
                }
            }

            // 3. Check Password
            string newPassword = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            bool updatePassword = false;
            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Please enter both new password and confirm password!");
                    return;
                }
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Password confirmation does not match!");
                    return;
                }
                updatePassword = true;
            }

            // If valid, update info
            var update = Builders<BsonDocument>.Update
                .Set("username", newUsername)
                .Set("email", newEmail);
            if (updatePassword)
            {
                update = update.Set("password", newPassword);
            }
            users.UpdateOne(filter, update);
            MessageBox.Show("Information updated successfully!");
            this.Close();
        }
    }
}
