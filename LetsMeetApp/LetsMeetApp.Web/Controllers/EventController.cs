using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;

using static LetsMeetApp.GCommon.ErrorMessages.Event;

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

                TempData["SuccessMessage"] = result.Message;
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
                    return RedirectToAction(nameof(Index));
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
                    if (result.Message == EventNotFoundNoPermissionOrExpired)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }

                    model.Categories = await categoryService.GetCategoriesDropdownAsync(userId);

                    return View(model);
                }

                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string userId = GetUserId()!;

                EventDeleteViewModel? deleteModel = await eventService
                    .GetEventForDeletingAsync(userId!, id);

                if (deleteModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(deleteModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(EventDeleteInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }

                string userId = GetUserId()!;

                var result = await eventService.DeleteEventAsync(userId, model.Id);

                if (!result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
