using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult AddCar(Car car)
        {
            DataAccess.Cars.Add(car);

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult DeleteCar(string plateNumber)
        {
            var car = DataAccess.Cars.FirstOrDefault(x => x.PlateNumber == plateNumber);
            DataAccess.Cars.Remove(car);

            return Redirect("/");
        }
    }

}
