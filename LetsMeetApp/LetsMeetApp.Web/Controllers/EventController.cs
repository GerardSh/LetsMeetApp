using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Web.Controllers
{
    public class EventController(IEventService eventService,
        ICategoryService categoryService)
        : BaseController
    {
        public async Task<IActionResult> Index(EventsFilterViewModel filter)
        {
            string userId = GetUserId()!;

            var model = await eventService.GetIndexEventsAsync(userId, filter);

            return View(model);
        }

        public IActionResult Details(Guid id)
        {
            return View();
        }
    }
}
