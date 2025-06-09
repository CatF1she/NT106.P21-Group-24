// =======================
// Updated Game.cs
// =======================

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
        private Image xImage;
        private Image oImage;

        public Game(string sessionId, ObjectId _playerId)
        {
            gameId = sessionId;
            playerId = _playerId.ToString();
            InitializeComponent();
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
            panelChessBoard.Controls.Clear();
            for (int i = 0; i < Constants.chessboard_height; i++)
            {
                for (int j = 0; j < Constants.chessboard_width; j++)
                {
                    Button btn = new Button
                    {
                        Width = Constants.chess_width,
                        Height = Constants.chess_height,
                        Location = new Point(j * Constants.chess_width, i * Constants.chess_height),
                        Tag = new Point(j, i)
                    };
                    btn.Click += async (sender, e) =>
                    {
                        var clicked = sender as Button;
                        if (clicked != null && clicked.BackgroundImage == null && connection?.State == HubConnectionState.Connected)
                        {
                            Point pos = (Point)clicked.Tag;
                            await connection.InvokeAsync("MakeMove", gameId, pos.X, pos.Y, playerId);
                        }
                    };
                    panelChessBoard.Controls.Add(btn);
                }
            }
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
            foreach (Control ctrl in panelChessBoard.Controls)
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
            foreach (Control ctrl in panelChessBoard.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}
