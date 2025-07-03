using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackEnd.Hubs
{
    public class FriendHub : Hub
    {
        private readonly DatabaseConnection _db;

        public FriendHub(DatabaseConnection db)
        {
            _db = db;
        }

        private string? GetUserId()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"].ToString();
            Console.WriteLine($"[Debug] Extracted userId: {userId}");
            return userId;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();
            if (userId != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            }
            await base.OnConnectedAsync();
        }

        public async Task SendFriendRequest(string targetUserId)
        {
            var senderId = GetUserId();
            if (senderId == null) return;

            var friendships = _db.GetFriendShipsCollection();
            var users = _db.GetUsersCollection();

            // Get sender's username
            var senderFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(senderId));
            var sender = await users.Find(senderFilter).FirstOrDefaultAsync();
            if (sender == null) return;

            var senderUsername = sender["username"].AsString;

            // Create friend request
            var newFriend = new BsonDocument
            {
                { "User1Id", ObjectId.Parse(senderId) },
                { "User2Id", ObjectId.Parse(targetUserId) },
                { "status", "pending" }
            };

            await friendships.InsertOneAsync(newFriend);

            // Send real-time notification to target user
            await Clients.Group(targetUserId).SendAsync("ReceiveFriendRequest", 
                newFriend["_id"].AsObjectId.ToString(),
                senderId,
                senderUsername);
        }

        public async Task AcceptFriendRequest(string requestId)
        {
            var userId = GetUserId();
            if (userId == null) return;

            var friendships = _db.GetFriendShipsCollection();
            
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(requestId));
            var update = Builders<BsonDocument>.Update.Set("status", "accepted");
            
            var request = await friendships.FindOneAndUpdateAsync(filter, update);
            
            if (request != null)
            {
                var senderId = request["User1Id"].AsObjectId.ToString();
                // Notify the original sender that their request was accepted
                await Clients.Group(senderId).SendAsync("FriendRequestAccepted", userId);
            }
        }

        public async Task RejectFriendRequest(string requestId)
        {
            var userId = GetUserId();
            if (userId == null) return;

            var friendships = _db.GetFriendShipsCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(requestId));
            
            var request = await friendships.FindOneAndDeleteAsync(filter);
            
            if (request != null)
            {
                var senderId = request["User1Id"].AsObjectId.ToString();
                // Notify the original sender that their request was rejected
                await Clients.Group(senderId).SendAsync("FriendRequestRejected", userId);
            }
        }
    }
} 