using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

using LetsMeetApp.Data;
using LetsMeetApp.Data.Models;
using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;

using static LetsMeetApp.GCommon.ValidationConstants.Event;


namespace LetsMeetApp.Services.Core
{
    public class EventService(LetsMeetDbContext dbContext,
        UserManager<ApplicationUser> userManager) : IEventService
    {
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

        public async Task<bool> CreateEventAsync(string userId, EventCreateInputModel inputModel)
        {
            bool operationResult = false;

            var userIdGuid = Guid.Parse(userId);

            ApplicationUser? user = await userManager
                .FindByIdAsync(userId);

            Category? categoryRef = await dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);

            bool isDateValid = DateTime
                .TryParseExact(inputModel.Date, EventDateFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime date);

            if (user != null && categoryRef != null && isDateValid && date.ToUniversalTime() > DateTime.UtcNow)
            {
                var @event = new Event
                {
                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    Date = date,
                    Location = inputModel.Location,
                    City = inputModel.City,
                    Country = inputModel.Country,
                    ImageUrl = inputModel.ImageUrl,
                    CreatorId = userIdGuid,
                    CategoryId = inputModel.CategoryId
                };

                await dbContext.Events.AddAsync(@event);
                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }
    }
}
