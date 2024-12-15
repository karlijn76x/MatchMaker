namespace MatchMaker.Services
{
    public class AddUserDTO
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required string Region { get; set; }
        public required string Rank { get; set; }
        public string? SummonerName { get; set; }
    }
}
