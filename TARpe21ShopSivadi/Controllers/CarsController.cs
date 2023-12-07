using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.Models.Car;

namespace TARpe21ShopSivadi.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe21ShopSivadiContext _context;
        public CarsController(TARpe21ShopSivadiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Type = x.Type,
                     PassengerCount = x.PassengerCount,
                     EnginePower = x.EnginePower,
                     Manufacturer = x.Manufacturer,
                });
            return View(result);
        }
    }
}
