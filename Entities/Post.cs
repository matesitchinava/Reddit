namespace Reddit.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int CommunityId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Community Community { get; set; }
    }

}
