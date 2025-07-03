using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEnd;
using BackEnd.Models;

namespace Do_An
{
    public partial class GameLobby : UserControl
    {
        private HubConnection? connection;
        private ObjectId? userId;
        private string? currentGameCode;
        private string? selectedGameCode;
        private bool isInGame = false;
        private bool colorswitch = false;
        public GameLobby(ObjectId _userId)
        {
            userId = _userId;
            InitializeComponent();
            LoadTheme();
            ConnectToSignalR();
        }
        private async void ConnectToSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8000/gamehub?userId={userId}")
                .WithAutomaticReconnect()
                .Build();
            RegisterHandlers();
            try
            {
                await connection.StartAsync();
                var rooms = await connection.InvokeAsync<List<string>>("GetActiveRooms");
                UpdateRoomList(rooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        private void RegisterHandlers()
        {
            connection.On<StartGameArgs>("StartGame", args =>
            {
                if (isInGame) return;
                isInGame = true;

                Invoke(() =>
                {
                    this.FindForm()?.Hide();

                    var gameForm = new Game(
                        args.SessionId,
                        userId!.Value,  
                        args.PlayerX,       
                        args.PlayerO        
                    );

                    gameForm.FormClosed += async (_, __) =>
                    {
                        isInGame = false;
                        this.FindForm()?.Show();
                        ResetLobby();
                        try
                        {
                            var rooms = await connection.InvokeAsync<List<string>>("GetActiveRooms");
                            UpdateRoomList(rooms);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to refresh rooms: " + ex.Message);
                        }
                    };
                    gameForm.Show();
                });
            });



            connection.On<Dictionary<string, bool>>("UpdateReadyStatus", playerStatus =>
            {
                Invoke(() =>
                {
                    PlayerList.Controls.Clear();
                    foreach (var (name, ready) in playerStatus)
                    {
                        var label = new Label
                        {
                            Text = $"{name} - {(ready ? "    Ready ✅" : "Not Ready ❌")}",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0)
                        };
                        PlayerList.Controls.Add(label);
                    }
                });
            });
            connection.On<string>("RoomCreated", roomCode =>
            {
                Invoke(() => AddRoomToList(roomCode));
            });
            connection.On<string>("RoomRemoved", roomCode =>
            {
                Invoke(() =>
                {
                    foreach (Control panel in RoomList.Controls)
                    {
                        if (panel.Tag?.ToString() == roomCode)
                        {
                            RoomList.Controls.Remove(panel);
                            break;
                        }
                    }

                    if (selectedGameCode == roomCode)
                    {
                        selectedGameCode = null;
                        RoomCode.Text = "";
                        PlayerList.Controls.Clear();
                    }
                });
            });

        }
        public void ResetLobby()
        {
            currentGameCode = null;
            selectedGameCode = null;
            RoomCode.Text = "";
            PlayerList.Controls.Clear();
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected) return;
            var code = await connection.InvokeAsync<string>("CreateRoom");
            if (code != null)
            {
                currentGameCode = code;
                RoomCode.Text = code;
            }
        }

        private async void buttonJoinRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected || selectedGameCode == null) return;
            currentGameCode = selectedGameCode;
            RoomCode.Text = selectedGameCode;
            await connection.InvokeAsync("JoinWaitingRoom", selectedGameCode);
        }

        private async void buttonToggleReady_Click(object sender, EventArgs e)
        {
            if (!IsConnected || string.IsNullOrEmpty(currentGameCode)) return;
            await connection.InvokeAsync("ToggleReady", currentGameCode);
        }

        private async void buttonLeaveRoom_Click(object sender, EventArgs e)
        {
            if (!IsConnected || string.IsNullOrEmpty(currentGameCode)) return;
            await connection.InvokeAsync("LeaveWaitingRoom", currentGameCode);
            currentGameCode = null;
            RoomCode.Text = "";
            PlayerList.Controls.Clear();
        }

        private void HighlightRoom(Control roomPanel, string gameCode)
        {
            foreach (Control panel in RoomList.Controls)
                panel.BackColor = SystemColors.Control;
            roomPanel.BackColor = Color.LightBlue;
            selectedGameCode = gameCode;
        }

        private void AddRoomToList(string gameCode)
        {
            var panel = new Panel { Height = 40, Width = RoomList.Width, Tag = gameCode };
            var label = new Label { Text = $"Room {gameCode}", AutoSize = true, Left = 10, Top = 10, Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0) };
            panel.Controls.Add(label);
            panel.Click += (_, __) => HighlightRoom(panel, gameCode);
            if (colorswitch) panel.BackColor = Color.LightGray;
            else panel.BackColor = Color.White;
            colorswitch = !colorswitch;
            label.Click += (_, __) => HighlightRoom(panel, gameCode);
            RoomList.Controls.Add(panel);
        }
        private void UpdateRoomList(List<string> roomCodes)
        {
            RoomList.Controls.Clear();
            foreach (var code in roomCodes)
            {
                AddRoomToList(code);
            }
        }

        private void picbtnSearch_Click(object sender, EventArgs e)
        {
            string searchCode = SearchBar.Text.Trim();

            if (string.IsNullOrEmpty(searchCode))
            {
                // Optionally show all rooms again or clear highlight
                MessageBox.Show("Please enter a room code to search.");
                return;
            }

            bool found = false;

            foreach (Control panel in RoomList.Controls)
            {
                string roomCode = panel.Tag?.ToString() ?? "";
                if (roomCode == searchCode)
                {
                    HighlightRoom(panel, roomCode);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show($"No room found with code: {searchCode}");
            }
        }
        private void LoadTheme()
        {
            Color color = ThemeColor.GetFunctionColor("GameLobby");
            ThemeColor.PrimaryColor = color;
            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
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
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
        }

        private void GameLobby_Load(object sender, EventArgs e)
        {

        }

        public bool IsConnected => connection?.State == HubConnectionState.Connected;
    }
}
