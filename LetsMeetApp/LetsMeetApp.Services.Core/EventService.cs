using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

using LetsMeetApp.Data;
using LetsMeetApp.Data.Models;
using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;

using static LetsMeetApp.GCommon.ErrorMessages.Event;

using LetsMeetApp.Web.ViewModels.Shared;


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

        public async Task<EventIndexViewModel> GetIndexEventsAsync(string userId,
            EventsFilterViewModel filter)
        {
            var userIdGuid = Guid.Parse(userId);

            var userEvent = await dbContext.Events
                .AsNoTracking()
                .Where(e =>
                    (e.CreatorId == userIdGuid ||
                    e.Participants.Any(p => p.UserId == userIdGuid)) &&
                    e.Date > DateTime.Now)
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
                    !e.Participants.Any(p => p.UserId == userIdGuid) &&
                    e.Date > DateTime.Now);

            if (filter.EventsNearMe)
            {
                var userCity = await dbContext.Users
               .AsNoTracking()
               .Where(u => u.Id == userIdGuid)
               .Select(u => u.City)
               .FirstOrDefaultAsync();

                var userCountry = await dbContext.Users
               .AsNoTracking()
               .Where(u => u.Id == userIdGuid)
               .Select(u => u.Country)
               .FirstOrDefaultAsync();

                if (userCity != null && userCountry != null)
                {
                    discoverEventsQuery = discoverEventsQuery
                        .AsNoTracking()
                        .Where(e => e.City == userCity && e.Country == userCountry);
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

        public async Task<List<EventViewModel>> GetPastEventsAsync(string userId)
        {
            var userIdGuid = Guid.Parse(userId);

            var userEvents = await dbContext.Events
                .AsNoTracking()
                .Where(e =>
                    (e.CreatorId == userIdGuid ||
                     e.Participants.Any(p => p.UserId == userIdGuid)) &&
                     e.Date <= DateTime.Now)
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

            return userEvents;
        }

        public async Task<OperationResult> CreateEventAsync(string userId, EventCreateInputModel inputModel)
        {
            var result = new OperationResult();

            var userIdGuid = Guid.Parse(userId);

            ApplicationUser? user = await userManager
                .FindByIdAsync(userId);

            Category? category = await dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);

            if (category == null)
            {
                result.Errors.Add(nameof(inputModel.CategoryId), CategoryDoesNotExist);
            }

            DateTime minAllowedDate = DateTime.Now.AddMinutes(59);

            if (inputModel.Date <= minAllowedDate)
            {
                result.Errors.Add(nameof(inputModel.Date), PastEvent);
            }

            if (!string.IsNullOrWhiteSpace(inputModel.ImageUrl))
            {
                if (!Uri.TryCreate(inputModel.ImageUrl, UriKind.Absolute, out var uriResult) ||
                    !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    result.Errors.Add(nameof(inputModel.ImageUrl), ImageUrlNotValid);
                }
            }

            if (result.Errors.Count == 0)
            {
                var @event = new Event
                {
                    Title = inputModel.Title.Trim(),
                    Description = inputModel.Description.Trim(),
                    Date = inputModel.Date,
                    Location = inputModel.Location.Trim(),
                    City = inputModel.City.Trim(),
                    Country = inputModel.Country.Trim(),
                    ImageUrl = inputModel.ImageUrl,
                    CreatorId = userIdGuid,
                    CategoryId = inputModel.CategoryId
                };

                var participation = new EventParticipation
                {
                    Event = @event,
                    UserId = userIdGuid,
                    JoinedAt = DateTime.Now
                };

                @event.Participants.Add(participation);
                user!.CreatedEvents.Add(@event);
                user!.JoinedEvents.Add(participation);

                await dbContext.Events.AddAsync(@event);
                await dbContext.SaveChangesAsync();

                result.Success = true;
            }

            return result;
        }

        public async Task<EventDetailsViewModel?> GetEventDetailsAsync(string currentUserId,
            Guid eventId)
        {
            var userIdGuid = Guid.Parse(currentUserId);

            var @event = await dbContext.Events
                .Include(e => e.Category)
                .Include(e => e.Creator)
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (@event == null) return null;

            var model = new EventDetailsViewModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Date = @event.Date,
                Location = @event.Location,
                City = @event.City,
                Country = @event.Country,
                ImageUrl = @event.ImageUrl,
                CategoryName = @event.Category.Name,
                CreatorFullName = $"{@event.Creator.FirstName} {@event.Creator.LastName}",
                ParticipantsCount = @event.Participants.Count,
                IsCreator = @event.CreatorId == userIdGuid,
                HasJoined = @event.Participants.Any(p => p.UserId == userIdGuid)
            };

            return model;
        }

        public async Task<EventEditInputModel?> GetEventForEditAsync(string userId, Guid id)
        {
            var userIdGuid = Guid.Parse(userId);

            var @event = await dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (@event == null || @event.CreatorId != userIdGuid || @event.Date <= DateTime.Now)
            {
                return null;
            }

            var model = new EventEditInputModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Date = @event.Date,
                Location = @event.Location,
                City = @event.City,
                Country = @event.Country,
                ImageUrl = @event.ImageUrl,
                CategoryId = @event.CategoryId
            };


            return model;
        }

        public async Task<OperationResult> EditEventAsync(string userId, EventEditInputModel inputModel)
        {
            var result = new OperationResult();

            var userIdGuid = Guid.Parse(userId);

            var @event = await dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == inputModel.Id);

            if (@event == null || @event.CreatorId != userIdGuid || @event.Date <= DateTime.Now)
            {
                result.Message = EventNotFoundNoPermissionOrExpired;
                return result;
            }

            Category? category = await dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);

            if (category == null)
            {
                result.Errors.Add(nameof(inputModel.CategoryId), CategoryDoesNotExist);
            }

            DateTime minAllowedDate = DateTime.Now.AddMinutes(59);

            if (inputModel.Date <= minAllowedDate)
            {
                result.Errors.Add(nameof(inputModel.Date), PastEvent);
            }

            if (!string.IsNullOrWhiteSpace(inputModel.ImageUrl))
            {
                if (!Uri.TryCreate(inputModel.ImageUrl, UriKind.Absolute, out var uriResult) ||
                    !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    result.Errors.Add(nameof(inputModel.ImageUrl), "Invalid image URL.");
                }
            }

            if (result.Errors.Count == 0)
            {
                @event.Title = inputModel.Title;
                @event.Description = inputModel.Description;
                @event.Date = inputModel.Date;
                @event.Location = inputModel.Location;
                @event.City = inputModel.City;
                @event.Country = inputModel.Country;
                @event.ImageUrl = inputModel.ImageUrl;
                @event.CategoryId = inputModel.CategoryId;

                await dbContext.SaveChangesAsync();

                result.Success = true;
            }

            return result;
        }

        public async Task<EventDeleteInputModel?> GetEventForDeletingAsync(string userId, Guid? eventId)
        {
            EventDeleteInputModel? deleteModel = null;

            var userIdGuid = Guid.Parse(userId);

            if (eventId != null)
            {
                Event? @event = await dbContext
                    .Events
                    .Include(e => e.Creator)
                    .Include(e => e.Participants)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == eventId);

                if (@event != null &&
                   @event.CreatorId == userIdGuid)
                {
                    deleteModel = new EventDeleteInputModel()
                    {
                        Id = @event.Id,
                        Title = @event.Title,
                        Creator = @event.Creator.FirstName + " " + @event.Creator.LastName,
                        CreatorId = @event.CreatorId,
                        Participants = @event.Participants.Count
                    };
                }
            }

            return deleteModel;
        }
    }
}
