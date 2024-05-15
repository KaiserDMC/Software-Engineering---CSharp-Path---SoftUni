using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult IndexAbout()
        {
            ViewBag.Message = "This is an ASP.NET Core MVP app.";

            return View();
        }
    }
}
