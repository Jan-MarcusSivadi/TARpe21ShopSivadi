using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;

namespace TARpe21ShopSivadi.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARpe21ShopSivadiContext _context;
        public CarsServices(TARpe21ShopSivadiContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.Name = dto.Name;
            car.Description = "";
            car.ExteriorColor = "black";
            car.InteriorColor = "white";
            car.WindowColor = "transparent";
            car.IsSteeringLeft = true;
            car.NumOfSeats = 4;
            car.PassengerCount = dto.PassengerCount;
            dto.HasConditioner = true;
            dto.HasHeatedSeats = false;
            dto.HasTouchscreen = false;
            dto.DoesHaveExtendedCab = false;
            dto.IsElectric = false;
            car.Type = dto.Type;
            car.GearType = "automatic";
            car.IsTransmissionManual = false;
            car.Engine = "yourEngineHere";
            car.EnginePower = dto.EnginePower;
            car.Drive = "AWD";
            car.MaxSpeed = 250;
            car.FuelConsumptionPerHour = 40;
            car.Manufacturer = dto.Manufacturer;
            car.IsCarPreviouslyOwned = false;
            car.BuiltAtDate = DateTime.Now;
            car.MaintenanceCount = 0;
            car.LastMaintenance = DateTime.Now;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = dto.ModifiedAt;
            // TODO: upload images

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
