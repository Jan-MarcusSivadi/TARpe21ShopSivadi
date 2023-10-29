using Microsoft.AspNetCore.Mvc;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.Models.RealEstate;

namespace TARpe21ShopSivadi.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstates;
        private readonly TARpe21ShopSivadiContext _context;
        public RealEstatesController(IRealEstatesServices realEstates, TARpe21ShopSivadiContext context)
        {
            _realEstates = realEstates;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    SquareMeters = x.SquareMeters,
                    Price = x.Price,
                    IsPropertySold = x.IsPropertySold,
                });
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Country = vm.Country,
                SquareMeters = vm.SquareMeters,
                Price = vm.Price,
                PostalCode = vm.PostalCode,
                PhoneNumber = vm.PhoneNumber,
                FaxNumber = vm.FaxNumber,
                ListingDescription = vm.ListingDescription,
                BuildDate = vm.BuildDate,
                RoomCount = vm.RoomCount,
                FloorCount = vm.FloorCount,
                EstateFloor = vm.EstateFloor,
                Bathrooms = vm.Bathrooms,
                Bedrooms = vm.Bedrooms,
                DoesHaveParkingSpace = vm.DoesHaveParkingSpace,
                DoesHavePowerGridConnection = vm.DoesHavePowerGridConnection,
                DoesHaveWaterGridConnection = vm.DoesHaveWaterGridConnection,
                Type = (Core.Dto.EstateType)vm.Type
            };
            return View(dto);
        }
    }
}
