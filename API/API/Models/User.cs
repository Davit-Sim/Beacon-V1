namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public ICollection<Interest> Interests { get; set; }
        // Navigation properties, e.g., EventsCreated, EventsJoined

        public ICollection<EventParticipant> EventsParticipated { get; set; }
        public ICollection<EventBookmark> EventBookmarks { get; set; }
        public ICollection<EventLike> EventLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
