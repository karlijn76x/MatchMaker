﻿namespace MatchMaker.Models.Entities
{
    public class Lane
    {
        public required int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<UserPreferences> UserPreferences { get; set; } = new List<UserPreferences>();

    }
}
