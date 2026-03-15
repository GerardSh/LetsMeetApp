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

        Task<EventDetailsViewModel?> GetEventDetailsAsync(string userId, Guid eventId);

        Task<EventEditInputModel?> GetEventForEditAsync(string userId, Guid eventId);

        Task<OperationResult> EditEventAsync(string userId, EventEditInputModel inputModel);

        Task<EventDeleteViewModel?> GetEventForDeletingAsync(string userId, Guid eventId);

        Task<OperationResult> DeleteEventAsync(string userId, Guid eventId);
    }
}
