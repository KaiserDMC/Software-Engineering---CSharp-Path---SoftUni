using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLInjection_LoginApp.Data;
using SQLInjection_LoginApp.Models;
using System;
using System.Diagnostics;

namespace SQLInjection_LoginApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext data;
        public HomeController(AppDbContext context)
            => this.data = context;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Login(LoginModel user)
        {
            // Do not use pure SQL queries with "+" concatenation
            string sqlQuery =
                "SELECT * FROM Users WHERE username = '" + user.Username +
                "' AND Password = '" + user.Password + "'";

            var userExists = this.data.Users.FromSqlRaw(sqlQuery).Any();

            if (userExists)
            {
                TempData["message"] = $"You logged-in sucessfully with username {user.Username}!";
                TempData["success"] = "yes";
            }
            else
            {
                TempData["message"] = $"Unsuccessful login! Try again.";
            }

            return RedirectToAction("Index");
        }
    }
}