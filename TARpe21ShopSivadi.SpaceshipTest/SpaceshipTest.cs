using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using Xunit;

namespace TARpe21ShopSivadi.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Test Name";
            spaceship.Description = "Test Description";
            spaceship.PassengerCount = 4;
            spaceship.CrewCount = 4;
            spaceship.CargoWeight = 3000;
            spaceship.MaxSpeedInVaccuum = 0;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test Manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 1;
            spaceship.Type = "test Type";
            spaceship.EnginePower = 9001;
            spaceship.FuelConsumptionPerDay = 4000;
            spaceship.MaintenanceCount = 0;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var created = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship.Id);
            Assert.Equal(result, created);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("a4d40bc2-3a35-4ec4-b9b6-4f4ceea1cdcc");

            //Spaceship spaceship = MockSpaceshipData();
            SpaceshipDto spaceship = MockSpaceshipData();

            // update data
            spaceship.Id = Guid.Parse("a4d40bc2-3a35-4ec4-b9b6-4f4ceea1cdcc");
            spaceship.Name = "Edit Test Name";
            spaceship.Description = "Test Description";
            spaceship.PassengerCount = 400;
            spaceship.CrewCount = 4;
            spaceship.CargoWeight = 3000;
            spaceship.MaxSpeedInVaccuum = 0;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test Manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 1;
            spaceship.Type = "test Type";
            spaceship.EnginePower = 9001;
            spaceship.FuelConsumptionPerDay = 4000;
            spaceship.MaintenanceCount = 0;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Update(spaceship);

            // spaceship id is the same before update
            Assert.Equal(spaceship.Id, guid);
            // spaceship field value does not match old value
            Assert.DoesNotMatch(spaceship.Name, result.Name);
            // spaceship field value get updated
            Assert.NotEqual(spaceship.PassengerCount, result.PassengerCount);
        }
        //[Fact]
        //public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        //{

        //}
        public SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Test Name";
            dto.Description = "Test Description";
            dto.PassengerCount = 4;
            dto.CrewCount = 4;
            dto.CargoWeight = 3000;
            dto.MaxSpeedInVaccuum = 0;
            dto.BuiltAtDate = DateTime.Now;
            dto.MaidenLaunch = DateTime.Now;
            dto.Manufacturer = "Test Manufacturer";
            dto.IsSpaceshipPreviouslyOwned = true;
            dto.FullTripsCount = 1;
            dto.Type = "test Type";
            dto.EnginePower = 9001;
            dto.FuelConsumptionPerDay = 4000;
            dto.MaintenanceCount = 0;
            dto.LastMaintenance = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            return dto;
        }
        public SpaceshipDto MockSpaceshipDtoData(Spaceship domain)
        {
            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = domain.Name;
            dto.Description = domain.Description;
            dto.PassengerCount = domain.PassengerCount;
            dto.CrewCount = domain.CrewCount;
            dto.CargoWeight = domain.CargoWeight;
            dto.MaxSpeedInVaccuum = domain.MaxSpeedInVaccuum;
            dto.BuiltAtDate = domain.BuiltAtDate;
            dto.MaidenLaunch = domain.MaidenLaunch;
            dto.Manufacturer = domain.Manufacturer;
            dto.IsSpaceshipPreviouslyOwned = domain.IsSpaceshipPreviouslyOwned;
            dto.FullTripsCount = domain.FullTripsCount;
            dto.Type = domain.Type;
            dto.EnginePower = domain.EnginePower;
            dto.FuelConsumptionPerDay = domain.FuelConsumptionPerDay;
            dto.MaintenanceCount = domain.MaintenanceCount;
            dto.LastMaintenance = domain.LastMaintenance;
            dto.CreatedAt = domain.CreatedAt;
            dto.ModifiedAt = domain.ModifiedAt;

            return dto;
        }
    }
}
