using API.Models;
using System;

  public class Comment
{
    public int Id { get; set; } // Primary key
    public string Content { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; } = DateTime.UtcNow;

    public int EventId { get; set; } // Foreign key to Event
    public Event Event { get; set; }

    public int UserId { get; set; } // Foreign key to User
    public User User { get; set; }
}

