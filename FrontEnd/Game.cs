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
        private string gameId = "123456";
        private string playerId = "error";
        private Image xImage;
        private Image oImage;

        public Game(ObjectId _playerId)
        {
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
            Button oldButton = new Button() { Height = 0, Width = 0, Location = new Point(0, 0) };

            for (int i = 0; i < Constants.chessboard_height; i++)
            {
                for (int j = 0; j < Constants.chessboard_width; j++)
                {
                    Button btn = new Button
                    {
                        Width = Constants.chess_width,
                        Height = Constants.chess_height,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
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
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constants.chess_height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
            MessageBox.Show("Chessboard initalized!");
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
                        Console.WriteLine($"[ReceiveMove] {player} moved to ({x}, {y})");
                    }
                });
            });

            connection.On<string>("GameWon", winnerId =>
            {
                Invoke(() =>
                {
                    MessageBox.Show($"{winnerId} wins!");
                    DisableAllButtons();
                });
            });

            try
            {
                await connection.StartAsync();
                MessageBox.Show("Connected to SignalR Hub!");
                await connection.InvokeAsync("JoinGame", gameId);
                MessageBox.Show("JoinGame invoked successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
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
