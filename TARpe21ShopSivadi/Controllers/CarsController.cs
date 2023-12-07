using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.Models.Car;

namespace TARpe21ShopSivadi.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe21ShopSivadiContext _context;
        private readonly ICarsServices _carsServices;
        public CarsController(TARpe21ShopSivadiContext context, ICarsServices carsServices)
        {
            _context = context;
            _carsServices = carsServices;
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
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel viewModel = new();
            return View("CreateUpdate", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                PassengerCount = vm.PassengerCount,
                EnginePower= vm.EnginePower,
                Manufacturer = vm.Manufacturer,
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
