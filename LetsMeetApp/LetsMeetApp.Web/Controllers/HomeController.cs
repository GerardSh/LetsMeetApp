using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Web.ViewModels.Shared;
using LetsMeetApp.Web.DemoData;


namespace LetsMeetApp.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger,
        LetsMeetApp.Services.Core.Contracts.IEventService eventService)
        : BaseController
    {

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    return RedirectToAction(nameof(Index), "Event");
                }

                return View(DemoEventsProvider.GetDemoEvents());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
