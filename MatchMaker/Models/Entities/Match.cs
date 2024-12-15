namespace MatchMaker.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public MatchStatus Status { get; set; }
        public DateTime? MatchedDate { get; set; }

        public enum MatchStatus
        {
            Pending,
            Matched,
            Declined
        }
    }
}
