namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Location { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = null!;

        public string CreatorFullName { get; set; } = null!;

        public bool IsCreator { get; set; }
    }
}
