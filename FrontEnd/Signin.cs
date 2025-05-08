using BackEnd.Services;
using FrontEnd.Resources;
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

namespace FrontEnd
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtpassword.Text;
            string confirm = txtConfirmedPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            } 

            if (password != confirm)
            {
                MessageBox.Show("Password do not match!");
                return;
            }

            var user = new BsonDocument
            {
                {"username", username},
                {"password", password},
                {"MatchPlayed", 0 },
                {"MatchWon", 0 },
                {"ELO", 0 }
            };
            try
            {
                var db = new DatabaseConnection();
                var users = db.GetUsersCollection();

                var existingUser = users.Find(Builders<BsonDocument>.Filter.Eq("username", username)).FirstOrDefault();
                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists!");
                    return;
                }

                users.InsertOne(user);
                MessageBox.Show("Sign up successful!");
                this.Close();
                new Login().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during sign up: " + ex.Message);
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Login form = new Login();
            form.Show();
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtConfirmedPassword.Clear();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void txtConfirmedPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
