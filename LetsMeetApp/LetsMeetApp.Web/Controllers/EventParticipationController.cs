using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

public class EventParticipationController(IEventParticipationService participationService)
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
                return RedirectToAction("Index", "Event");
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index", "Event");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

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
                return RedirectToAction("Index", "Event");
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index", "Event");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return RedirectToAction("Index", "Event");
        }
    }
}
