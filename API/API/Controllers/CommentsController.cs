using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CommentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("{eventId}")]
    [Authorize]
    public async Task<IActionResult> PostComment(int eventId, [FromBody] string content)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var comment = new Comment
        {
            Content = content,
            EventId = eventId,
            UserId = userId
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return Ok("Comment posted.");
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetComments(int eventId)
    {
        var comments = await _context.Comments
            .Where(c => c.EventId == eventId)
            .Include(c => c.User)
            .ToListAsync();

        return Ok(comments);
    }
}
