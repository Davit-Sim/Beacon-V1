public class EventCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Privacy { get; set; } = "Open";
    public int AgeRangeStart { get; set; }
    public int AgeRangeEnd { get; set; }
    public int SlotsAvailable { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Motivation { get; set; } = string.Empty;
}

public class EventDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // Include other fields needed for the event details view
}
