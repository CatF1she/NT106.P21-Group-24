using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
namespace Do_An
{
    public partial class GameLobby : Form
    {
        private HubConnection? _connection;
        private ObjectId? _userId;
        private string? _currentGameCode;
        public GameLobby(ObjectId userId)
        {
            _userId = userId;
            InitializeComponent();
        }
        public async Task ConnectAsync()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8000/gamehub?userId={_userId}")
                .WithAutomaticReconnect()
                .Build();

            RegisterHandlers();
            await _connection.StartAsync();
        }

        private void RegisterHandlers()
        {
            _connection.On<string>("StartGame", sessionId =>
            {
                Console.WriteLine($"[SignalR] StartGame received: {sessionId}");
                // TODO: Launch Game.cs with sessionId
            });

            _connection.On<HashSet<string>>("UpdateReadyStatus", readyUsers =>
            {
                Console.WriteLine("[SignalR] Ready status updated:");
                foreach (var user in readyUsers)
                {
                    Console.WriteLine($" - {user} is ready");
                }
            });
        }

        public async Task JoinWaitingRoomAsync(string gameCode)
        {
            _currentGameCode = gameCode;
            await _connection.InvokeAsync("JoinWaitingRoom", gameCode);
        }

        public async Task LeaveWaitingRoomAsync()
        {
            if (!string.IsNullOrEmpty(_currentGameCode))
            {
                await _connection.InvokeAsync("LeaveWaitingRoom", _currentGameCode);
                _currentGameCode = null;
            }
        }

        public async Task ToggleReadyAsync()
        {
            if (!string.IsNullOrEmpty(_currentGameCode))
            {
                await _connection.InvokeAsync("ToggleReady", _currentGameCode);
            }
        }
        public bool IsConnected => _connection?.State == HubConnectionState.Connected;
    }
}
