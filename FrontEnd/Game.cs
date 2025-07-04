﻿using BackEnd.Models;
using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.InteropServices;

namespace FrontEnd
{
    public partial class Game : Form
    {
        private HubConnection? connection;
        private string gameId;
        private string playerId;
        private Image? xImage;
        private Image? oImage;
        private bool AmIPlayerX=false;
        private readonly PlayerInfo? _playerX;
        private readonly PlayerInfo? _playerO;
        private Timer turnTimer;
        private int timerIntervalMs = 100; // update every 100ms
        private int totalTurnTimeMs = 10000; // 10 seconds
        private int timeRemainingMs;
        public Game(string sessionId, ObjectId _playerId, PlayerInfo playerX, PlayerInfo playerO)
        {
            gameId = sessionId;
            playerId = _playerId.ToString();
            _playerX = playerX;
            _playerO = playerO;
            InitializeComponent();
            labelPlayerXName.Text = $"Player X: {_playerX.Username}";
            labelPlayerXWinRate.Text = $"Win rate: {_playerX.MatchWon*100/_playerX.MatchPlayed:0.##}%";
            labelPlayerXMatchPlayed.Text = $"Match Played: {_playerX.MatchPlayed}";
            labelPlayerOName.Text = $"Player O: {_playerO.Username}";
            labelPlayerOWinRate.Text = $"Win rate: {_playerO.MatchWon*100/_playerO.MatchPlayed:0.##}%";
            labelPlayerOMatchPlayed.Text = $"Played: {_playerO.MatchPlayed}";
            if (playerId == _playerX.Id) AmIPlayerX = true;
            //enable double buffering for Game.cs and tablelayoutChessBoard
            typeof(TableLayoutPanel)
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(tableLayoutChessBoard, true, null);

            this.DoubleBuffered = true;
            DrawChessBoard();
            LoadImages();
            ConnectToSignalR();
        }

        private async void LoadImages()
        {
            xImage = Image.FromFile("Resources/x.png");
            oImage = Image.FromFile("Resources/o.png");
            await LoadImageAsync(pictureBoxPlayerX, _playerX?.ProfilePic);
            await LoadImageAsync(pictureBoxPlayerO, _playerO?.ProfilePic);
        }
        private async Task LoadImageAsync(PictureBox pictureBox, string? url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    using var httpClient = new HttpClient();
                    var imageBytes = await httpClient.GetByteArrayAsync(url);

                    var stream = new MemoryStream(imageBytes); // do not dispose!
                    pictureBox.Image = Image.FromStream(stream);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Image Load Error] {ex.Message}");
            }

            pictureBox.Image = Image.FromFile("Resources/o.png");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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
                        BackColor = Color.White,
                        TabStop = false,
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
                    if (btn != null && btn.BackgroundImage == null && x != 69 && y != 69)
                    {
                        btn.BackgroundImage = (player == "PlayerX") ? xImage : oImage;
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Enabled = false;
                        // Highlight it
                        Color originalColor = btn.BackColor;
                        btn.BackColor = Color.LightYellow;

                        // Reset color after 1 second
                        var highlightTimer = new Timer { Interval = 1000 };
                        highlightTimer.Tick += (s, args) =>
                        {
                            btn.BackColor = originalColor;
                            highlightTimer.Stop();
                            highlightTimer.Dispose();
                        };
                        highlightTimer.Start();
                    }
                    string nextTurn = (player == "PlayerX") ? "Player O" : "Player X";
                    labelCurrentTurn.Text = $"{nextTurn}'s Turn";
                    if ((AmIPlayerX && nextTurn == "Player X") || (!AmIPlayerX && nextTurn == "Player O")) StartTurnTimer();
                    else
                    {
                        turnTimer?.Stop();
                        progressTurnTimer.Value= progressTurnTimer.Maximum;
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
        private void StartTurnTimer()
        {
            timeRemainingMs = totalTurnTimeMs;
            progressTurnTimer.Value = progressTurnTimer.Maximum;

            turnTimer?.Stop();
            turnTimer = new Timer();
            turnTimer.Interval = timerIntervalMs;
            turnTimer.Tick += TurnTimer_Tick;
            turnTimer.Start();
        }
        private async void TurnTimer_Tick(object? sender, EventArgs e)
        {
            timeRemainingMs -= timerIntervalMs;
            if (timeRemainingMs <= 0)
            {
                turnTimer.Stop();
                progressTurnTimer.Value = 0;

                // Send fake move to skip turn
                await connection.InvokeAsync("MakeMove", gameId, 69, 69, playerId);
                return;
            }

            // Update progress bar
            progressTurnTimer.Value = Math.Max(0, progressTurnTimer.Maximum * timeRemainingMs / totalTurnTimeMs);
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


    }

}
