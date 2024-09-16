using API.Models;

public class Interest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; }
    public ICollection<Event> Events { get; set; }
}