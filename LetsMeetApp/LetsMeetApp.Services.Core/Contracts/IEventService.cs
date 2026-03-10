using LetsMeetApp.Data.Models;
using LetsMeetApp.Web.ViewModels.Event;
using LetsMeetApp.Web.ViewModels.Shared;

namespace LetsMeetApp.Services.Core.Contracts
{
    public interface IEventService
    {
        Task<EventIndexViewModel> GetIndexEventsAsync(string userId, EventsFilterViewModel filter);

        Task<List<EventViewModel>> GetPastEventsAsync(string userId);

        Task<OperationResult> CreateEventAsync(string userId, EventCreateInputModel inputModel);

        Task<EventDetailsViewModel> GetEventDetailsAsync(string userId, Guid id);

        Task<EventEditInputModel?> GetEventForEditAsync(string userId, Guid id);

        Task<OperationResult> EditEventAsync(string userId, EventEditInputModel inputModel);

        Task<EventDeleteInputModel?> GetEventForDeletingAsync(string userId, Guid? eventId);

        Task<Event?> GetByIdAsync(Guid id);
    }
}
