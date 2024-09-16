using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateEvent(EventCreateDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var eventEntity = new Event
        {
            Name = dto.Name,
            Description = dto.Description,
            Privacy = dto.Privacy,
            AgeRangeStart = dto.AgeRangeStart,
            AgeRangeEnd = dto.AgeRangeEnd,
            SlotsAvailable = dto.SlotsAvailable,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Category = dto.Category,
            Motivation = dto.Motivation,
            OrganizerId = userId
        };

        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();

        return Ok(new { eventEntity.Id });
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents([FromQuery] EventFilterDto filterDto)
    {
        var events = _context.Events.AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(filterDto.Category))
            events = events.Where(e => e.Category == filterDto.Category);

        if (filterDto.AgeRangeStart.HasValue)
            events = events.Where(e => e.AgeRangeStart >= filterDto.AgeRangeStart.Value);

        if (filterDto.AgeRangeEnd.HasValue)
            events = events.Where(e => e.AgeRangeEnd <= filterDto.AgeRangeEnd.Value);

        // Apply sorting
        if (!string.IsNullOrEmpty(filterDto.SortBy))
        {
            switch (filterDto.SortBy.ToLower())
            {
                case "popularity":
                    // Implement sorting by popularity
                    break;
                case "date":
                    events = events.OrderBy(e => e.StartTime);
                    break;
                    // Add other cases
            }
        }

        var eventList = await events.ToListAsync();

        return Ok(eventList);
    }

    // Additional endpoints: GetEventById, UpdateEvent, DeleteEvent, etc.

    [HttpPost("{eventId}/like")]
    [Authorize]
    public async Task<IActionResult> LikeEvent(int eventId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var like = new EventLike
        {
            EventId = eventId,
            UserId = userId
        };

        _context.EventLikes.Add(like);
        await _context.SaveChangesAsync();

        return Ok("Event liked.");
    }

    [HttpPost("{eventId}/bookmark")]
    [Authorize]
    public async Task<IActionResult> BookmarkEvent(int eventId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var bookmark = new EventBookmark
        {
            EventId = eventId,
            UserId = userId
        };

        _context.EventBookmarks.Add(bookmark);
        await _context.SaveChangesAsync();

        return Ok("Event bookmarked.");
    }
}
