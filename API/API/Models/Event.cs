using API.Models;
using System.Diagnostics.Eventing.Reader;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Privacy { get; set; } = "Open"; // "Open" or "Private"
    public int AgeRangeStart { get; set; }
    public int AgeRangeEnd { get; set; }
    public int SlotsAvailable { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Motivation { get; set; } = string.Empty;
    public int OrganizerId { get; set; }
    public User Organizer { get; set; }
    // Navigation properties for participants, likes, bookmarks

    public ICollection<EventParticipant> Participants { get; set; }
    public ICollection<EventBookmark> EventBookmarks { get; set; }
    public ICollection<EventLike> EventLikes { get; set; }
    public ICollection<Comment> Comments { get; set; }

}
