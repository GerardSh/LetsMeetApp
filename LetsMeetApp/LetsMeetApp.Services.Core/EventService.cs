using Microsoft.EntityFrameworkCore;

using LetsMeetApp.Data;
using LetsMeetApp.Data.Models;
using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Services.Core
{
    public class EventService(LetsMeetDbContext dbContext) : IEventService
    {
        public async Task<IEnumerable<EventViewModel>> GetDemoEventsAsync()
        {
            var firstDemoId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var secondDemoId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");


            var demoEvents = await dbContext.Events
                            .AsNoTracking()
                            .Where(e => e.Id == firstDemoId || e.Id == secondDemoId)
                            .OrderBy(e => e.Date)
                            .Select(e => new EventViewModel
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Description = e.Description,
                                Date = e.Date,
                                Location = e.Location,
                                City = e.City,
                                Country = e.Country,
                                ImageUrl = e.ImageUrl,
                                CategoryName = e.Category.Name,
                                CreatorFullName = $"{e.Creator.FirstName} {e.Creator.LastName}",
                                ParticipantsCount = e.Participants.Count
                            })
                            .ToListAsync();

            return demoEvents;
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await dbContext.Events
                .Include(e => e.Category)
                .Include(e => e.Creator)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EventIndexViewModel> GetIndexEventsAsync(string userId, EventsFilterViewModel filter)
        {
            var userIdGuid = Guid.Parse(userId);

            var userEvent = await dbContext.Events
                .AsNoTracking()
                .Where(e =>
                    e.CreatorId == userIdGuid ||
                    e.Participants.Any(p => p.UserId == userIdGuid))
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    Location = e.Location,
                    City = e.City,
                    Country = e.Country,
                    ImageUrl = e.ImageUrl,
                    CategoryName = e.Category.Name,
                    CreatorFullName = $"{e.Creator.FirstName} {e.Creator.LastName}",
                    ParticipantsCount = e.Participants.Count,
                    IsCreator = e.CreatorId == userIdGuid
                })
                .OrderBy(e => e.Date)
                .ToListAsync();

            var discoverEventsQuery = dbContext.Events
                .AsNoTracking()
                .Where(e =>
                    e.CreatorId != userIdGuid &&
                    !e.Participants.Any(p => p.UserId == userIdGuid));

            if (filter.EventsNearMe)
            {
                var userCity = await dbContext.Users
               .AsNoTracking()
               .Where(u => u.Id == userIdGuid)
               .Select(u => u.City)
               .FirstOrDefaultAsync();

                if (userCity != null)
                {
                    discoverEventsQuery = discoverEventsQuery
                        .AsNoTracking()
                        .Where(e => e.City == userCity);
                }
            }

            var discoverEvents = await discoverEventsQuery
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    Location = e.Location,
                    City = e.City,
                    Country = e.Country,
                    ImageUrl = e.ImageUrl,
                    CategoryName = e.Category.Name,
                    CreatorFullName = $"{e.Creator.FirstName} {e.Creator.LastName}",
                    ParticipantsCount = e.Participants.Count,
                    IsCreator = false
                })
                .OrderBy(e => e.Date)
                .ToListAsync();

            var indexModel = new EventIndexViewModel
            {
                MyEvents = userEvent,
                DiscoverEvents = discoverEvents,
                Filter = filter
            };

            return indexModel;
        }
    }
}
