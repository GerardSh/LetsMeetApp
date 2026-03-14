using Microsoft.EntityFrameworkCore;

using LetsMeetApp.Data;
using LetsMeetApp.Data.Models;
using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Shared;

using static LetsMeetApp.GCommon.SuccessMessages.EventParticipation;
using static LetsMeetApp.GCommon.ErrorMessages.EventParticipation;

public class EventParticipationService(LetsMeetDbContext dbContext) : IEventParticipationService
{
    public async Task<OperationResult> JoinEventAsync(string userId, Guid eventId)
    {
        Guid userIdGuid = Guid.Parse(userId);

        var result = new OperationResult();

        var @event = await dbContext.Events
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (@event == null)
        {
            result.Message = EventNotFound;
            return result;
        }

        if (@event.CreatorId == userIdGuid)
        {
            result.Message = CreatorCantJoinEvent;
            return result;
        }

        if (@event.Date <= DateTime.Now)
        {
            result.Message = CantJoinPastEvent;
            return result;
        }

        bool alreadyJoined = await dbContext.EventParticipations
            .AnyAsync(p => p.EventId == eventId && p.UserId == userIdGuid);

        if (alreadyJoined)
        {
            result.Message = AlreadyParticipating;
            return result;
        }

        var participation = new EventParticipation
        {
            EventId = eventId,
            UserId = userIdGuid,
            JoinedAt = DateTime.Now
        };

        await dbContext.EventParticipations.AddAsync(participation);
        await dbContext.SaveChangesAsync();

        result.Success = true;
        result.Message = JoinSuccess;
        return result;
    }

    public async Task<OperationResult> LeaveEventAsync(string userId, Guid eventId)
    {
        Guid userIdGuid = Guid.Parse(userId);

        var result = new OperationResult();

        var @event = await dbContext.Events
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (@event == null)
        {
            result.Message = EventNotFound;
            return result;
        }

        if (@event.CreatorId == userIdGuid)
        {
            result.Message = CreatorCantLeaveEvent;
            return result;
        }

        if (@event.Date <= DateTime.Now)
        {
            result.Message = CantLeavePastEvent;
            return result;
        }

        var participation = await dbContext.EventParticipations
            .FirstOrDefaultAsync(p => p.EventId == eventId && p.UserId == userIdGuid);

        if (participation == null)
        {
            result.Message = NotParticipating;
            return result;
        }

        dbContext.EventParticipations.Remove(participation);
        await dbContext.SaveChangesAsync();

        result.Success = true;
        result.Message = LeaveSuccess;
        return result;
    }
}
