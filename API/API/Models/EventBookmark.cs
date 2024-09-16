using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class EventBookmark
{
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
