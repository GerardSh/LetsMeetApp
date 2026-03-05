using LetsMeetApp.Data.Models;
using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Services.Core.Contracts
{
    public interface IEventService
    {
        Task<EventIndexViewModel> GetIndexEventsAsync(string userId, EventsFilterViewModel filter);

        Task<bool> CreateEventAsync(string userId, EventCreateInputModel inputModel);

        Task<Event?> GetByIdAsync(Guid id);
    }
}
