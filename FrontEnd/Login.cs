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

using BackEnd.Services;

namespace FrontEnd.Resources
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public class AuthService
        {
            private readonly IMongoCollection<BsonDocument> usersCollection;

            public AuthService()
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                usersCollection = dbConnection.GetUsersCollection();
            }

            public bool AuthenticateUser(string username, string password)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("username", username) &
                             Builders<BsonDocument>.Filter.Eq("password", password);

                var user = usersCollection.Find(filter).FirstOrDefault();
                return user != null;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthService auth = new AuthService();
            string username = txtUsername.Text;
            string password = txtpassword.Text;

            if (auth.AuthenticateUser(username, password))
            {
                new MainMenu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect!");
            }
        }


        private void ForgetPassword_Click(object sender, EventArgs e)
        {
            new ForgetPassword().Show();
            this.Hide();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
        }

        private void lbSignIn_Click(object sender, EventArgs e)
        {
            new Signin().Show();
            this.Hide();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                btnLogin.PerformClick();
            }
        }

    }
}
