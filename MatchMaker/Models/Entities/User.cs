namespace MatchMaker.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required string Region { get; set; }

        public required string Rank { get; set; }
        public string? Bio { get; set; }

        public string? SummonerName { get; set; }
        public ICollection<UserPreferences> UserPreferences { get; set; } = new List<UserPreferences>();


    }
}
