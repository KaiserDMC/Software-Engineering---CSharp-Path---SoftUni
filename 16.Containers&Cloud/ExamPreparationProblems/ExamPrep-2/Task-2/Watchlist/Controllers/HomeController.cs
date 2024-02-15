using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watchlist.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Movies");
            }

            return View();
        }
    }
}