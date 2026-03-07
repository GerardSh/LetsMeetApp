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
        public async Task<IActionResult> PastEvents()
        {
            string userId = GetUserId()!;
            var userIdGuid = Guid.Parse(userId);

            var pastEvents = await eventService.GetPastEventsAsync(userId);

            return View(pastEvents);
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

                var result = await eventService.CreateEventAsync(userId, model);

                if (!result.Success)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }

                    model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string userId = GetUserId()!;

            var model = await eventService.GetEventDetailsAsync(userId, id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                string userId = GetUserId()!;

                var model = await eventService.GetEventForEditAsync(userId, id);

                if (model == null)
                {
                    return Unauthorized();
                }

                model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventEditInputModel model)
        {
            try
            {
                string userId = GetUserId()!;

                if (!ModelState.IsValid)
                {
                    model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

                    return View(model);
                }

                var result = await eventService.EditEventAsync(userId, model);

                if (!result.Success)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }

                    model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}