using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain.Spaceship;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;

namespace TARpe21ShopSivadi.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly TARpe21ShopSivadiContext _context;
        public SpaceshipsServices(TARpe21ShopSivadiContext context)
        {
            _context = context;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Name = dto.Name,
                Description = dto.Description,
                //Dimensions = dto.Dimensions,
                PassengerCount = dto.PassengerCount,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                MaxSpeedInVaccuum = dto.MaxSpeedInVaccuum,
                BuiltAtDate = dto.BuiltAtDate,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned,
                FullTripsCount = dto.FullTripsCount,
                Type = dto.Type,
                EnginePower = dto.EnginePower,
                FuelConsumptionPerDay = dto.FuelConsumptionPerDay,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };
            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
            
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {

            //var domain = new Spaceship()
            //{
            //    Name = dto.Name,
            //    Description = dto.Description,
            //    //Dimensions = dto.Dimensions,
            //    PassengerCount = dto.PassengerCount,
            //    CrewCount = dto.CrewCount,
            //    CargoWeight = dto.CargoWeight,
            //    MaxSpeedInVaccuum = dto.MaxSpeedInVaccuum,
            //    BuiltAtDate = dto.BuiltAtDate,
            //    MaidenLaunch = dto.MaidenLaunch,
            //    Manufacturer = dto.Manufacturer,
            //    IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned,
            //    FullTripsCount = dto.FullTripsCount,
            //    Type = dto.Type,
            //    EnginePower = dto.EnginePower,
            //    FuelConsumptionPerDay = dto.FuelConsumptionPerDay,
            //    MaintenanceCount = dto.MaintenanceCount,
            //    LastMaintenance = dto.LastMaintenance,
            //    CreatedAt = dto.CreatedAt,
            //    ModifiedAt = DateTime.Now,
            //};
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            // Update model fields based on SpaceshipDto
            spaceshipId.Name = dto.Name;
            spaceshipId.Description = dto.Description;
            spaceshipId.PassengerCount = dto.PassengerCount;
            spaceshipId.CrewCount = dto.CrewCount;
            spaceshipId.CargoWeight = dto.CargoWeight;
            spaceshipId.MaxSpeedInVaccuum = dto.MaxSpeedInVaccuum;
            spaceshipId.BuiltAtDate = dto.BuiltAtDate;
            spaceshipId.MaidenLaunch = dto.MaidenLaunch;
            spaceshipId.Manufacturer = dto.Manufacturer;
            spaceshipId.IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned;
            spaceshipId.FullTripsCount = dto.FullTripsCount;
            spaceshipId.Type = dto.Type;
            spaceshipId.EnginePower = dto.EnginePower;
            spaceshipId.FuelConsumptionPerDay = dto.FuelConsumptionPerDay;
            spaceshipId.MaintenanceCount = dto.MaintenanceCount;
            spaceshipId.LastMaintenance = dto.LastMaintenance;
            spaceshipId.CreatedAt = dto.CreatedAt;
            spaceshipId.ModifiedAt = DateTime.Now;

            _context.Spaceships.Update(spaceshipId);
            await _context.SaveChangesAsync();
            return spaceshipId;
        }
        public async Task<Spaceship> GetUpdate(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }
        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
