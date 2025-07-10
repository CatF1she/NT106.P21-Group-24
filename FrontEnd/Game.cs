using BackEnd.Models;
using FrontEnd.Resources;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
using MongoDB.Bson;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace FrontEnd
{
    public partial class Game : Form
    {
        private HubConnection? connection;
        private string gameId;
        private string playerId;
        private ObjectId userId;
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
            userId = _playerId;
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
            if (playerId == _playerX.Id)
            {
                AmIPlayerX = true;
                labelPlayerName.Text = _playerX.Username + "'s game";
            }
            else labelPlayerName.Text = _playerO.Username + "'s game";
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
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Image Load Error] {ex.Message}");
            }

            pictureBox.Image = Image.FromFile("Resources/o.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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
                    turnTimer?.Stop();
                    DisableAllButtons();
                    MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
            this.Close();
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

                if (connection != null && connection.State == HubConnectionState.Connected)
                {
                    try
                    {
                        await connection.InvokeAsync("MakeMove", gameId, 69, 69, playerId);
                    }
                    catch (ObjectDisposedException)
                    {
                        // Ignore — this happens if form was closed while timer fired
                    }
                }

                return;
            }

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

        private const int WM_NCHITTEST = 0x84;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTBOTTOMLEFT = 16;
        private const int HTTOPRIGHT = 14;
        private const int HTTOPLEFT = 13;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTBOTTOM = 15;
        private const int BORDER_WIDTH = 8;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                Point cursor = PointToClient(Cursor.Position);
                Cursor newCursor = Cursors.Default;

                if (cursor.X <= BORDER_WIDTH)
                {
                    if (cursor.Y <= BORDER_WIDTH)
                    {
                        m.Result = (IntPtr)HTTOPLEFT;
                        newCursor = Cursors.SizeNWSE;
                    }
                    else if (cursor.Y >= Height - BORDER_WIDTH)
                    {
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                        newCursor = Cursors.SizeNESW;
                    }
                    else
                    {
                        m.Result = (IntPtr)HTLEFT;
                        newCursor = Cursors.SizeWE;
                    }
                }
                else if (cursor.X >= Width - BORDER_WIDTH)
                {
                    if (cursor.Y <= BORDER_WIDTH)
                    {
                        m.Result = (IntPtr)HTTOPRIGHT;
                        newCursor = Cursors.SizeNESW;
                    }
                    else if (cursor.Y >= Height - BORDER_WIDTH)
                    {
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                        newCursor = Cursors.SizeNWSE;
                    }
                    else
                    {
                        m.Result = (IntPtr)HTRIGHT;
                        newCursor = Cursors.SizeWE;
                    }
                }
                else if (cursor.Y <= BORDER_WIDTH)
                {
                    m.Result = (IntPtr)HTTOP;
                    newCursor = Cursors.SizeNS;
                }
                else if (cursor.Y >= Height - BORDER_WIDTH)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                    newCursor = Cursors.SizeNS;
                }

                Cursor.Current = newCursor;
            }
        }
        protected override async void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (connection != null)
            {
                try
                {
                    await connection.StopAsync();
                    await connection.DisposeAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error disconnecting: " + ex.Message);
                }
            }

            var mainMenu = new MainMenu(userId);
            mainMenu.Show();
        }




    }

}
