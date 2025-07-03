using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Game : Form
    {
        private HubConnection? connection;
        private string gameId;
        private string playerId;
        private Image? xImage;
        private Image? oImage;

        public Game(string sessionId, ObjectId _playerId)
        {
            gameId = sessionId;
            playerId = _playerId.ToString();
            InitializeComponent();
            //enable double buffering for Game.cs and tablelayoutChessBoard
             typeof(TableLayoutPanel)
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(tableLayoutChessBoard, true, null);

            this.DoubleBuffered = true;
            DrawChessBoard();
            LoadImages();
            ConnectToSignalR();
        }

        private void LoadImages()
        {
            xImage = Image.FromFile("Resources/x.png");
            oImage = Image.FromFile("Resources/o.png");
        }

        private void DrawChessBoard()
        {
            tableLayoutChessBoard.SuspendLayout();
            tableLayoutChessBoard.Controls.Clear();
            tableLayoutChessBoard.ColumnCount = 25;
            tableLayoutChessBoard.RowCount = 25;
            tableLayoutChessBoard.ColumnStyles.Clear();
            tableLayoutChessBoard.RowStyles.Clear();

            for (int i = 0; i < 25; i++)
            {
                tableLayoutChessBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 25));
                tableLayoutChessBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 25));
            }

            for (int row = 0; row < 25; row++)
            {
                for (int col = 0; col < 25; col++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Tag = new Point(col, row),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.White
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                    btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                    btn.Click += async (sender, e) =>
                    {
                        if (sender is Button clicked && clicked.BackgroundImage == null && connection?.State == HubConnectionState.Connected)
                        {
                            Point pos = (Point)clicked.Tag;
                            await connection.InvokeAsync("MakeMove", gameId, pos.X, pos.Y, playerId);
                        }
                    };

                    tableLayoutChessBoard.Controls.Add(btn, col, row);
                }
            }

            tableLayoutChessBoard.ResumeLayout();
        }


        private async void ConnectToSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8000/gamehub?userId={playerId}")
                .WithAutomaticReconnect()
                .Build();

            connection.On<int, int, string>("ReceiveMove", (x, y, player) =>
            {
                Invoke(() =>
                {
                    var btn = GetButtonAt(x, y);
                    if (btn != null && btn.BackgroundImage == null)
                    {
                        btn.BackgroundImage = (player == "PlayerX") ? xImage : oImage;
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Enabled = false;
                    }
                });
            });

            connection.On<string>("GameWon", winner =>
            {
                Invoke(() =>
                {
                    MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisableAllButtons();
                });
            });

            try
            {
                await connection.StartAsync();
                await connection.InvokeAsync("JoinGame", gameId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Button? GetButtonAt(int x, int y)
        {
            foreach (Control ctrl in tableLayoutChessBoard.Controls)
            {
                if (ctrl is Button btn && btn.Tag is Point pt && pt.X == x && pt.Y == y)
                {
                    return btn;
                }
            }
            return null;
        }


        private void DisableAllButtons()
        {
            foreach (Control ctrl in tableLayoutChessBoard.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
