using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Data.Models
{
    [Comment("Extended Identity user with application-specific properties")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(string firstName,
            string lastName,
            string city,
            DateTime birthDate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            City = city;
            BirthDate = birthDate;
        }

        [Comment("First name of the user")]
        public string FirstName { get; set; } = null!;

        [Comment("Last name of the user")]
        public string LastName { get; set; } = null!;

        [Comment("URL to the user's avatar image")]
        public string? AvatarUrl { get; set; }

        [Comment("Short description or bio")]
        public string? Bio { get; set; }

        [Comment("City or location of the user")]
        public string City { get; set; } = null!;

        [Comment("User's date of birth")]
        public DateTime BirthDate { get; set; }

        public ICollection<Event> CreatedEvents { get; set; }
            = new HashSet<Event>();

        public ICollection<Category> CreatedCategories { get; set; }
            = new HashSet<Category>();

        public ICollection<EventParticipation> JoinedEvents { get; set; }
            = new HashSet<EventParticipation>();
    }
}
