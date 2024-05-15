using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Data.Models
{
    public class DataAccess
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
    }
}
