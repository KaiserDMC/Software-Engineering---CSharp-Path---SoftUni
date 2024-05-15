using CSRF_PasswordApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSRF_PasswordApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Login()
            => View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model.Username != UserCredentials.Username
                || model.Password != UserCredentials.Password)
            {
                return RedirectToAction("Login");
            }

            return RedirectToAction("ChangePassword");
        }

        public IActionResult ChangePassword()
            => View();

        [HttpPost]
        public IActionResult ChangePassword(string newPass, string newPassConfirm)
        {
            if (string.IsNullOrEmpty(newPass) || newPassConfirm != newPass)
            {
                return RedirectToAction("Change");
            }

            UserCredentials.Password = newPass;

            TempData["message"] = "Password was changed successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
