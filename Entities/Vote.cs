namespace Reddit.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsUpvote { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Post Post { get; set; }
    }

}
