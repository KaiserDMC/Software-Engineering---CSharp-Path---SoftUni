using CSRF_PasswordApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSRF_PasswordApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}