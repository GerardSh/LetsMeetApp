using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Data.Models
{
    public class Category
    {
        [Comment("Primary key for the Category table")]
        public Guid Id { get; set; }

        [Comment("Name of the category")]
        public string Name { get; set; } = null!;

        [Comment("User who created this category; null = default category")]
        public Guid? CreatorId { get; set; }
        public ApplicationUser? Creator { get; set; }

        public ICollection<Event> Events { get; set; }
            = new HashSet<Event>();
    }
}
