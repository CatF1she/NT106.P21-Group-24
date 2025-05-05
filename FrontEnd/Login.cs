using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Resources
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Hide();
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
    }
}
