using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    // DbSet properties
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventParticipant> EventParticipants { get; set; }
    public DbSet<EventLike> EventLikes { get; set; }
    public DbSet<EventBookmark> EventBookmarks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // EventBookmark configuration
        modelBuilder.Entity<EventBookmark>()
            .HasKey(eb => new { eb.EventId, eb.UserId });

        modelBuilder.Entity<EventBookmark>()
            .HasOne(eb => eb.Event)
            .WithMany(e => e.EventBookmarks)
            .HasForeignKey(eb => eb.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventBookmark>()
            .HasOne(eb => eb.User)
            .WithMany(u => u.EventBookmarks)
            .HasForeignKey(eb => eb.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // EventLike configuration
        modelBuilder.Entity<EventLike>()
            .HasKey(el => new { el.EventId, el.UserId });

        modelBuilder.Entity<EventLike>()
            .HasOne(el => el.Event)
            .WithMany(e => e.EventLikes)
            .HasForeignKey(el => el.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventLike>()
            .HasOne(el => el.User)
            .WithMany(u => u.EventLikes)
            .HasForeignKey(el => el.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // EventParticipant configuration
        modelBuilder.Entity<EventParticipant>()
            .HasKey(ep => new { ep.EventId, ep.UserId });

        modelBuilder.Entity<EventParticipant>()
            .HasOne(ep => ep.Event)
            .WithMany(e => e.Participants)
            .HasForeignKey(ep => ep.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventParticipant>()
            .HasOne(ep => ep.User)
            .WithMany(u => u.EventsParticipated)
            .HasForeignKey(ep => ep.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Comment configuration
        modelBuilder.Entity<Comment>()
            .HasKey(c => c.Id); // Primary key

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Event)
            .WithMany(e => e.Comments)
            .HasForeignKey(c => c.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
