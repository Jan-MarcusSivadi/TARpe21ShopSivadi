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
                Description = vm.Description,
                ExteriorColor = vm.ExteriorColor,
                InteriorColor = vm.InteriorColor,
                WindowColor = vm.WindowColor,
                IsSteeringLeft = vm.IsSteeringLeft,
                NumOfSeats = vm.NumOfSeats,
                NumOfWheels = vm.NumOfWheels,
                PassengerCount = vm.PassengerCount,
                HasConditioner = vm.HasConditioner,
                HasHeatedSeats = vm.HasHeatedSeats,
                HasTouchscreen = vm.HasTouchscreen,
                DoesHaveExtendedCab = vm.DoesHaveExtendedCab,
                IsElectric = vm.IsElectric,
                Type = vm.Type,
                GearType = vm.GearType,
                IsTransmissionManual = vm.IsTransmissionManual,
                Engine = vm.Engine,
                EnginePower= vm.EnginePower,
                Drive = vm.Drive,
                MaxSpeed = vm.MaxSpeed,
                FuelConsumptionPerHour = vm.FuelConsumptionPerHour,
                Manufacturer = vm.Manufacturer,
                IsCarPreviouslyOwned = vm.IsCarPreviouslyOwned,
                BuiltAtDate = vm.BuiltAtDate,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
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
