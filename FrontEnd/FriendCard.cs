using BackEnd.Models;
using FrontEnd;
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
    public partial class FriendCard : UserControl
    {
        public FriendCard()
        {
            InitializeComponent();
        }

        private string currentUserId;
        private string targetUserId;
        private bool isFriend;
        public event Action<string, bool>? FriendActionClicked; // string: targetId, bool: isFriend

        public void SetFriendData(User user, string currentUserId, bool isFriend)
        {
            this.currentUserId = currentUserId;
            this.targetUserId = user.Id;
            this.isFriend = isFriend;

            UserName.Text = $"{user.Username}";
            MatchPlayed.Text = $"Matches Played: {user.MatchPlayed}";
            MatchWon.Text = $"Matches Won: {user.MatchWon}";
            WinRate.Text = $"Win Rate: {user.WinRate}%";

            btnAction.Text = isFriend ? "Unfriend" : "Add Friend";
        }


        private void btnAction_Click(object sender, EventArgs e)
        {
            FriendActionClicked?.Invoke(targetUserId, isFriend);
        }

        private void FriendCard_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            UserName.ForeColor = ThemeColor.PrimaryColor;
            MatchPlayed.ForeColor = ThemeColor.SecondaryColor;
            MatchWon.ForeColor = ThemeColor.SecondaryColor;
            WinRate.ForeColor = ThemeColor.SecondaryColor;
        }
    }
}
