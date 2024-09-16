using API.Models;

public class EventParticipant
{
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"
}
