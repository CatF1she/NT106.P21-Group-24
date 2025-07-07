using FrontEnd;
using FrontEnd.Resources;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An
{
    public partial class ClientSettings : Form
    {
        private ObjectId userId;
        public ClientSettings(ObjectId userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LoadTheme()
        {
            foreach (Control btn in this.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    Button button = (Button)btn;
                    button.BackColor = ThemeColor.PrimaryColor;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void ClientSettings_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void btnChangeUserInfo_Click(object sender, EventArgs e)
        {
            Change_User_Info change_User_Info = new Change_User_Info(userId);
            change_User_Info.ShowDialog();
        }
    }
}