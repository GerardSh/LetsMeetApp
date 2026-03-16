using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Services.Core.Contracts;

using static LetsMeetApp.GCommon.ErrorMessages.Controllers;

namespace LetsMeetApp.Web.Controllers
{
    public class EventParticipationController(ILogger<EventParticipationController> logger,
   IEventParticipationService participationService)
    : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Join(Guid id)
        {
            try
            {
                string userId = GetUserId()!;

                var result = await participationService.JoinEventAsync(userId, id);

                if (!result.Success)
                {
                    TempData["ErrorMessage"] = result.Message;
                }
                else
                {
                    TempData["SuccessMessage"] = result.Message;
                }

                return RedirectToAction("Index", "Event");

            }
            catch (Exception e)
            {
                logger.LogError(e, GeneralError);
                return RedirectToAction("Index", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(Guid id)
        {
            try
            {
                string userId = GetUserId()!;

                var result = await participationService.LeaveEventAsync(userId, id);

                if (!result.Success)
                {
                    TempData["ErrorMessage"] = result.Message;
                }
                else
                {
                    TempData["SuccessMessage"] = result.Message;
                }

                return RedirectToAction("Index", "Event");
            }
            catch (Exception e)
            {
                logger.LogError(e, GeneralError);
                return RedirectToAction("Index", "Event");
            }
        }
    }
}
