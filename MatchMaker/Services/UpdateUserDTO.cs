using MatchMaker.Models.Entities;

namespace MatchMaker.Services
{
    public class UpdateUserDTO
    {
        public required Guid Id { get; set; }
        public string? Bio { get; set; }
        public string? SummonerName { get; set; }
        public List<UserPreferencesDTO> Preferences { get; set; }
    }

    public class UserPreferencesDTO
    {
        public required int RoleId { get; set; }
        public required int LaneId { get; set; }
        public required int ChampionId { get; set; }
    }
}
