﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
