namespace Contacts.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        //if (User?.Identity?.IsAuthenticated ?? false)
        //{
        //    return RedirectToAction("All", "Contacts");
        //}

        return View();
    }
}