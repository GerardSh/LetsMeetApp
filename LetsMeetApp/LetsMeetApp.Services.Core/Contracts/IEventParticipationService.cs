using LetsMeetApp.Web.ViewModels.Shared;

namespace LetsMeetApp.Services.Core.Contracts
{
    public interface IEventParticipationService
    {
        Task<OperationResult> JoinEventAsync(string userId, Guid eventId);

        Task<OperationResult> LeaveEventAsync(string userId, Guid eventId);
    }
}
