namespace MatchMaker.Models.Entities
{
    public class Role
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UserPreferences> UserPreferences { get; set; } = new List<UserPreferences>();

    }
}
