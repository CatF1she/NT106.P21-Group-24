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
    public partial class PlayerRankingCard : UserControl
    {
        public PlayerRankingCard()
        {
            InitializeComponent();
            txtRank.Parent = picRank;
            this.MinimumSize = new Size(517, 53); // Đảm bảo card không bị co lại
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.PerformLayout();
        }

        public async Task SetPlayerInfo(string username, int matchPlayed, int matchWon, int score, int rank, string avatarUrl)
        {
            txtUsername.Text = username;
            txtPlayed.Text = $"Played: {matchPlayed}";
            txtWon.Text = $"Won: {matchWon}";
            txtUserScore.Text = score.ToString();
            txtRank.Text = rank.ToString();

            SetScoreStyle(score);
            SetRankStyle(rank);

            if (!string.IsNullOrEmpty(avatarUrl) && !avatarUrl.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(avatarUrl);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        using (var img = Image.FromStream(ms))
                        {
                            picUserAvatar.Image = new Bitmap(img);
                        }
                    }
                }
                catch
                {
                    picUserAvatar.Image = Properties.Resources.user;
                }
            }
            else
            {
                picUserAvatar.Image = Properties.Resources.user;
            }
            if (picUserAvatar.Image == null)
            {
                picUserAvatar.Image = Properties.Resources.user;
            }
        }

        private void SetScoreStyle(int score)
        {
            // Đổi màu panelScore dựa vào điểm
            if (score > 50)
            {
                panelScore.BackColor = Color.Gold; // Vàng
                txtUserScore.ForeColor = Color.Black;
            }
            else if (score >= 20)
            {
                panelScore.BackColor = Color.Silver; // Bạc
                txtUserScore.ForeColor = Color.Black;
            }
            else
            {
                panelScore.BackColor = Color.FromArgb(205, 127, 50); // Đồng
                txtUserScore.ForeColor = Color.White;
            }
        }

        private void SetRankStyle(int rank)
        {
            // Đổi hình picRank theo thứ hạng
            if (rank == 1)
            {
                picRank.Image = Properties.Resources._1st;
            }
            else if (rank == 2)
            {
                picRank.Image = Properties.Resources._2nd;
            }
            else if (rank == 3)
            {
                picRank.Image = Properties.Resources._3rd;
            }
        }
    }
}

