using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Web.Controllers
{
    public class EventController(IEventService eventService,
        ICategoryService categoryService)
        : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(EventsFilterViewModel filter)
        {
            try
            {
                string userId = GetUserId()!;

                var model = await eventService.GetIndexEventsAsync(userId, filter);

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                string userId = GetUserId()!;

                var model = new EventCreateInputModel()
                {
                    Categories = await categoryService.GetCategoriesDropdownAsync(userId)
                };

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventCreateInputModel model)
        {
            try
            {
                string userId = GetUserId()!;

                if (!ModelState.IsValid)
                {
                    model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

                    return View(model);
                }

                bool addResult = await eventService.CreateEventAsync(userId, model);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while creating the event, please check all fields and if the date is not in the past!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(Guid id)
        {
            return View();
        }
    }
}
