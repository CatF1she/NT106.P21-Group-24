namespace BackEnd.Models
{
    public class PlayerInfo
    {
        public string Id { get; set; } = "";
        public string Username { get; set; } = "";
        public int MatchPlayed { get; set; }
        public int MatchWon { get; set; }
        public string? ProfilePic { get; set; }
    }
    public class StartGameArgs
    {
        public string SessionId { get; set; } = "";
        public PlayerInfo PlayerX { get; set; } = new();
        public PlayerInfo PlayerO { get; set; } = new();
    }
}
