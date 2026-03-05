using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Web.DemoData
{
    public static class DemoEventsProvider
    {
        public static IEnumerable<EventViewModel> GetDemoEvents()
        {
            var DemoEvents = new List<EventViewModel>
            {
                new EventViewModel
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "Music Jam Session",
                    Description = "Join us for a relaxed evening of live music and good vibes.",
                    ImageUrl = "https://images.unsplash.com/photo-1524578471438-cdd96d68d82c",
                    Date = DateTime.UtcNow.Date.AddDays(3).AddHours(20).AddMinutes(00),
                    City = "Berlin",
                    Country = "Germany",
                    CategoryName = "Music",
                    ParticipantsCount = 12,
                    CreatorFullName = "LetsMeet Team"
                },
                new EventViewModel
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "Tech Meetup",
                    Description = "Discuss the latest in technology.",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1664299935896-8b7638a6f105",
                    Date = DateTime.UtcNow.Date.AddDays(6).AddHours(13).AddMinutes(30),
                    City = "Amsterdam",
                    Country = "Netherlands",
                    CategoryName = "Technology",
                    ParticipantsCount = 18,
                    CreatorFullName = "LetsMeet Team"
                }
            };

            return DemoEvents;
        }
    }
}
