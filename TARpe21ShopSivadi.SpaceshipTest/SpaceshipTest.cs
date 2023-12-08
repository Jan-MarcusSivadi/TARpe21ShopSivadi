using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SpaceshipDto spaceship = MockSpaceshipData();
            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var created = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)created.Id);
            Assert.Equal(result, created);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataOld()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            var updated = new SpaceshipDto();
            updated.Name = "Edit Test Name";
            updated.Description = "Test Description";
            updated.PassengerCount = 400;
            updated.CrewCount = 4;
            updated.CargoWeight = 3000;
            updated.MaxSpeedInVaccuum = 0;
            updated.BuiltAtDate = DateTime.Now;
            updated.MaidenLaunch = DateTime.Now;
            updated.Manufacturer = "Test Manufacturer";
            updated.IsSpaceshipPreviouslyOwned = true;
            updated.FullTripsCount = 1;
            updated.Type = "test Type";
            updated.EnginePower = 9001;
            updated.FuelConsumptionPerDay = 4000;
            updated.MaintenanceCount = 0;
            updated.LastMaintenance = DateTime.Now;
            updated.CreatedAt = DateTime.Now;
            updated.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Update(updated);

            // spaceship id is the same before update
            Assert.Equal(updated.Id, dto.Id);
            // spaceship field value does not match old value
            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            // spaceship field value get updated
            Assert.NotEqual(result.PassengerCount, createSpaceship.PassengerCount);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(update);

            // spaceship id is the same before update
            Assert.Equal(update.Id, dto.Id);
            // spaceship field value does not match old value
            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            // spaceship field value get updated
            Assert.NotEqual(result.PassengerCount, createSpaceship.PassengerCount);
        }
        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto updated = MockSpaceshipData();
            var result = await Svc<ISpaceshipsServices>().Update(updated);

            // spaceship id is the same before update
            Assert.Equal(updated.Id, dto.Id);
            // spaceship field value matches old value
            Assert.Matches(result.Name, createSpaceship.Name);
            // spaceship field value does not get updated
            Assert.Equal(result.PassengerCount, createSpaceship.PassengerCount);
        }
        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addspaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id, addspaceship.Id);
        }
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
        private SpaceshipDto MockUpdateSpaceship()
        {
            SpaceshipDto update = new()
            {
                Name = "Edit Test Name",
                Description = "Test Description",
                PassengerCount = 400,
                CrewCount = 4,
                CargoWeight = 3000,
                MaxSpeedInVaccuum = 0,
                BuiltAtDate = DateTime.Now,
                MaidenLaunch = DateTime.Now,
                Manufacturer = "Test Manufacturer",
                IsSpaceshipPreviouslyOwned = true,
                FullTripsCount = 1,
                Type = "test Type",
                EnginePower = 9001,
                FuelConsumptionPerDay = 4000,
                MaintenanceCount = 0,
                LastMaintenance = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return update;
        }
    }
}
