using BackEnd.Services;
using FrontEnd;
using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Do_An
{
    public partial class Notification : UserControl
    {
        private HubConnection? _connection;
        public event Action<ObjectId>? FriendAccepted;
        private ObjectId requestId;
        private string senderName;
        private string senderId;

        public Notification()
        {
            InitializeComponent();
            btnAccept.Click += btnAccept_Click;
            btnRefuse.Click += btnRefuse_Click;
        }

        private async Task ConnectToSignalR(string userId)
        {
            if (_connection?.State == HubConnectionState.Connected) return;

            _connection = new HubConnectionBuilder()
                .WithUrl($"https://nt106-p21-group-24.onrender.com/friendhub?userId={userId}")
                .WithAutomaticReconnect()
                .Build();

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            MessageBox.Show("Connection to friend service failed: " + ex.Message);
                        }
                    }));
                }
            }
        }

        public async void SetFriendRequest(ObjectId requestId, string senderId, string senderName, string currentUserId)
        {
            this.requestId = requestId;
            this.senderName = senderName;
            this.senderId = senderId;
            lblMessage.Text = $"{senderName} wants to make friend with you.";

            await ConnectToSignalR(currentUserId);
        }

        private async void btnAccept_Click(object? sender, EventArgs e)
        {
            if (_connection?.State != HubConnectionState.Connected)
            {
                MessageBox.Show("Not connected to friend service. Please try again.");
                return;
            }

            try
            {
                await _connection.InvokeAsync("AcceptFriendRequest", requestId.ToString());
                FriendAccepted?.Invoke(requestId);
                if (!IsDisposed)
                {
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            MessageBox.Show("Failed to accept friend request: " + ex.Message);
                        }
                    }));
                }
            }
        }

        private async void btnRefuse_Click(object? sender, EventArgs e)
        {
            if (_connection?.State != HubConnectionState.Connected)
            {
                MessageBox.Show("Not connected to friend service. Please try again.");
                return;
            }

            try
            {
                await _connection.InvokeAsync("RejectFriendRequest", requestId.ToString());
                if (!IsDisposed)
                {
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            MessageBox.Show("Failed to reject friend request: " + ex.Message);
                        }
                    }));
                }
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
            lblMessage.ForeColor = ThemeColor.SecondaryColor;
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
