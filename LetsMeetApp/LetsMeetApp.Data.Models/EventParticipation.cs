using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Data.Models
{
    public class EventParticipation
    {
        [Comment("Primary key for the EventParticipation table")]
        public Guid Id { get; set; }

        [Comment("The event that the user has joined")]
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Comment("The user who joined the event")]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        [Comment("Date and time when the user joined the event")]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
