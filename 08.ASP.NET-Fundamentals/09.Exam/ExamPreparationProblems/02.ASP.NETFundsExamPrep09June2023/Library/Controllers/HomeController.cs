namespace Library.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Book");
        }

        return View();
    }
}