using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using FrontEnd;

namespace Do_An
{
    public partial class FriendPage : Form
    {
        private readonly string currentUserId;

        public FriendPage()
        {
            InitializeComponent();
        }

        // DATABASE TEST, NHỚ XÓA SAU KHI LÀM
        public List<User> Users()
        {
            return new List<User>
            {
                new User
                {
                    Id = "1",
                    Username = "Isla",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,

                },
                new User
                {
                    Id = "2",
                    Username = "Helena",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id = "3",
                    Username = "Shimakaze",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id = "4",
                    Username = "London",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id = "5",
                    Username = "Javelin",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id="6",
                    Username = "Jessica",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id="6",
                    Username = "Miku",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
                new User
                {
                    Id="6",
                    Username = "Hina",
                    WinRate = 0,
                    MatchWon = 0,
                    MatchPlayed = 0,
                },
            };
        }
        // KẾT THÚC DATABASE TEST, NHỚ XÓA SAU KHI TEST
        private List<User> allUsers = new List<User>();

        private void LoadUsers()
        {
            allUsers = Users(); // Dữ liệu mẫu
            DisplayUsers(allUsers);
        }

        private void DisplayUsers(List<User> users)
        {
            FriendList.Controls.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                var card = new FriendCard();
                card.SetFriendData(users[i], currentUserId, false);
                card.Width = FriendList.Width - 25;
                // Xen kẽ màu nền
                card.BackColor = (i % 2 == 0) ? Color.LightGray : Color.White;
                FriendList.Controls.Add(card);
            }
        }


        private void FriendPage_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTheme();
        }
        private void FriendList_Resize(object sender, EventArgs e)
        {
            foreach (FriendCard card in FriendList.Controls)
            {
                card.Width = FriendList.ClientSize.Width - 25;
            }
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
            picbtnSearch.BackColor = ThemeColor.PrimaryColor;
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchBar.Text.Trim().ToLower();
            var filteredUsers = allUsers.Where(u => u.Username.ToLower().Contains(keyword)).ToList();
            DisplayUsers(filteredUsers);
        }
    }
}
