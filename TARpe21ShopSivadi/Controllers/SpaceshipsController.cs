using Microsoft.AspNetCore.Mvc;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.Models.Spaceship;

namespace TARpe21ShopSivadi.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe21ShopSivadiContext _context;
        public SpaceshipsController(TARpe21ShopSivadiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
        public IActionResult Add()
        {
            return View("Edit");
        }
    }
}
