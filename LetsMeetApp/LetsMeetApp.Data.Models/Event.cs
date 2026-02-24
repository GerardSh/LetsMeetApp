using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Data.Models
{
    public class Event
    {
        [Comment("Primary key for the Event table")]
        public Guid Id { get; set; }

        [Comment("Title of the event")]
        public string Title { get; set; } = null!;

        [Comment("Detailed description of the event")]
        public string Description { get; set; } = null!;

        [Comment("Date and time when the event occurs")]
        public DateTime Date { get; set; }

        [Comment("Location of the event")]
        public string Location { get; set; } = null!;

        [Comment("City of the event")]
        public string City { get; set; } = null!;

        [Comment("Country of the event")]
        public string Country { get; set; } = null!;

        [Comment("URL to the event's image")]
        public string? ImageUrl { get; set; }

        [Comment("Creator of the event")]
        public Guid CreatorId { get; set; }
        public ApplicationUser Creator { get; set; } = null!;

        [Comment("Category of the event")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<EventParticipation> Participants { get; set; }
            = new HashSet<EventParticipation>();
    }
}
