namespace MatchMaker.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required string Region { get; set; }
        public string? SummonerName { get; set; }
        
    }
}
