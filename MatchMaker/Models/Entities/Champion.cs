namespace MatchMaker.Models.Entities
{
    public class Champion
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Type { get; set; }
        public DateOnly? ReleaseDate { get; set; }

        public ICollection<UserPreferences> UserPreferences { get; set; } = new List<UserPreferences>();

    }
}
