namespace MatchMaker.Models.Entities
{
    public class UserPreferences
    {
        public required Guid UserId { get; set; }
        public User User { get; set; }
        public required int RoleId { get; set; }
        public Role Role { get; set; }
        public required int LaneId { get; set; }
        public Lane Lane { get; set; }
        public required int ChampionId { get; set; }
        public Champion Champion { get; set; }

    }
}
