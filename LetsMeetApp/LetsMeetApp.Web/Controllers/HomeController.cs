using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using LetsMeetApp.Web.ViewModels.Shared;
using LetsMeetApp.Web.DemoData;

using static LetsMeetApp.GCommon.ErrorMessages.Controllers;

namespace LetsMeetApp.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger)
        : BaseController
    {

        [AllowAnonymous]
        public IActionResult Index()
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
                logger.LogError(e, GeneralError);
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
