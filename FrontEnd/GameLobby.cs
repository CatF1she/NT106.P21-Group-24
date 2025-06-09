using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEnd;

namespace Do_An
{
    public partial class GameLobby : Form
    {
        private HubConnection? _connection;
        private ObjectId? _userId;
        private string? _currentGameCode;
        private string? _selectedGameCode;

        public GameLobby(ObjectId userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await ConnectToSignalR();
        }
        private async Task ConnectToSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8000/gamehub?userId={_userId}")
                .WithAutomaticReconnect()
                .Build();

            RegisterHandlers();

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        private void RegisterHandlers()
        {
            _connection.On<string>("StartGame", sessionId =>
            {
                Invoke(() =>
                {
                    var gameForm = new Game(sessionId, _userId!.Value);
                    gameForm.Show();
                    Hide();
                });
            });

            _connection.On<Dictionary<string, bool>>("UpdateReadyStatus", playerStatus =>
            {
                Invoke(() =>
                {
                    PlayerList.Controls.Clear();
                    foreach (var (name, ready) in playerStatus)
                    {
                        var label = new Label
                        {
                            Text = $"{name} - {(ready ? "✅ Ready" : "❌ Not Ready")}",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12)
                        };
                        PlayerList.Controls.Add(label);
                    }
                });
            });
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected) return;
            var code = await _connection.InvokeAsync<string>("CreateRoom");
            if (code != null)
            {
                _currentGameCode = code;
                RoomCode.Text = code;
            }
        }

        private async void buttonJoinRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected || _selectedGameCode == null) return;
            _currentGameCode = _selectedGameCode;
            RoomCode.Text = _selectedGameCode;
            await _connection.InvokeAsync("JoinWaitingRoom", _selectedGameCode);
        }

        private async void buttonToggleReady_Click(object sender, EventArgs e)
        {
            if (!IsConnected || string.IsNullOrEmpty(_currentGameCode)) return;
            await _connection.InvokeAsync("ToggleReady", _currentGameCode);
        }

        private async void buttonLeaveRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected || string.IsNullOrEmpty(_currentGameCode)) return;
            await _connection.InvokeAsync("LeaveWaitingRoom", _currentGameCode);
            _currentGameCode = null;
            RoomCode.Text = "";
            PlayerList.Controls.Clear();
        }

        private void HighlightRoom(Control roomPanel, string gameCode)
        {
            foreach (Control panel in RoomList.Controls)
                panel.BackColor = SystemColors.Control;
            roomPanel.BackColor = Color.LightBlue;
            _selectedGameCode = gameCode;
        }

        private void AddRoomToList(string gameCode)
        {
            var panel = new Panel { Height = 40, Width = RoomList.Width, Tag = gameCode };
            var label = new Label { Text = $"Room {gameCode}", AutoSize = true, Left = 10, Top = 10 };
            panel.Controls.Add(label);
            panel.Click += (_, __) => HighlightRoom(panel, gameCode);
            label.Click += (_, __) => HighlightRoom(panel, gameCode);
            RoomList.Controls.Add(panel);
        }

        public bool IsConnected => _connection?.State == HubConnectionState.Connected;
    }
}
