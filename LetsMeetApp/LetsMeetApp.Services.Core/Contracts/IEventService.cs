using LetsMeetApp.Data.Models;
using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Services.Core.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetDemoEventsAsync();

        Task<EventIndexViewModel> GetIndexEventsAsync(string userId, EventsFilterViewModel filter);

        Task<Event?> GetByIdAsync(Guid id);
    }
}
