using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class EventParticipantsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventParticipantsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("{eventId}/join")]
    [Authorize]
    public async Task<IActionResult> JoinEvent(int eventId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var eventEntity = await _context.Events.FindAsync(eventId);
        if (eventEntity == null)
            return NotFound("Event not found.");

        var existingParticipation = await _context.EventParticipants
            .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.UserId == userId);

        if (existingParticipation != null)
            return BadRequest("Already requested to join this event.");

        var participation = new EventParticipant
        {
            EventId = eventId,
            UserId = userId,
            Status = eventEntity.Privacy == "Open" ? "Approved" : "Pending"
        };

        _context.EventParticipants.Add(participation);
        await _context.SaveChangesAsync();

        return Ok("Join request submitted.");
    }

    // Additional endpoints to approve or reject participation requests
}
