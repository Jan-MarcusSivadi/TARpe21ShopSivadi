using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            car.Description = dto.Description;
            car.ExteriorColor = dto.ExteriorColor;
            car.InteriorColor = dto.InteriorColor;
            car.WindowColor = dto.WindowColor;
            car.IsSteeringLeft = dto.IsSteeringLeft;
            car.NumOfSeats = dto.NumOfSeats;
            car.PassengerCount = dto.PassengerCount;
            car.HasConditioner = dto.HasConditioner;
            car.HasHeatedSeats = dto.HasHeatedSeats;
            car.HasTouchscreen = dto.HasTouchscreen;
            car.DoesHaveExtendedCab = dto.DoesHaveExtendedCab;
            car.IsElectric = dto.IsElectric;
            car.Type = dto.Type;
            car.GearType = dto.GearType;
            car.IsTransmissionManual = dto.IsTransmissionManual;
            car.Engine = dto.Engine;
            car.EnginePower = dto.EnginePower;
            car.Drive = dto.Drive;
            car.MaxSpeed = dto.MaxSpeed;
            car.FuelConsumptionPerHour = dto.FuelConsumptionPerHour;
            car.Manufacturer = dto.Manufacturer;
            car.IsCarPreviouslyOwned = dto.IsCarPreviouslyOwned;
            car.BuiltAtDate = dto.BuiltAtDate;
            car.MaintenanceCount = dto.MaintenanceCount;
            car.LastMaintenance = dto.LastMaintenance;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = dto.ModifiedAt;
            // TODO: upload images

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ExteriorColor = dto.ExteriorColor,
                InteriorColor = dto.InteriorColor,
                WindowColor = dto.WindowColor,
                IsSteeringLeft = dto.IsSteeringLeft,
                NumOfSeats = dto.NumOfSeats,
                PassengerCount = dto.PassengerCount,
                HasConditioner = dto.HasConditioner,
                HasHeatedSeats = dto.HasHeatedSeats,
                HasTouchscreen = dto.HasTouchscreen,
                DoesHaveExtendedCab = dto.DoesHaveExtendedCab,
                IsElectric = dto.IsElectric,
                Type = dto.Type,
                GearType = dto.GearType,
                IsTransmissionManual = dto.IsTransmissionManual,
                Engine = dto.Engine,
                EnginePower = dto.EnginePower,
                Drive = dto.Drive,
                MaxSpeed = dto.MaxSpeed,
                FuelConsumptionPerHour = dto.FuelConsumptionPerHour,
                Manufacturer = dto.Manufacturer,
                IsCarPreviouslyOwned = dto.IsCarPreviouslyOwned,
                BuiltAtDate = dto.BuiltAtDate,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };
            // update images

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}
