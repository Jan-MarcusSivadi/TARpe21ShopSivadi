using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopSivadi.Core.Domain.Cars
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; } // globally unique identifier
        public string Name { get; set; } // car name
        public string Description { get; set; } // car description
        public int NumOfSeats { get; set; } // number of seats, including passengers
        public bool IsSteeringLeft { get; set; } // does the car have steering wheel on the left side
        public int PassengerCount { get; set; } // how many passengers can the car carry
        public bool HasTouchscreen { get; set; } // does the car have touchscreen
        public bool HasHeatedSeats { get; set; } // does the car have seat heating system installed
        public int WheelCount { get; set; } // how many wheels does the car have
        public bool DoesHaveExtendedCab { get; set; } // does car come with extended cabinets
        public bool IsCarElectric { get; set; } // is the car electric
        public string Type { get; set; } // car type, f.e. truck, van,
        public string ExteriorColor { get; set; } // what color is the exterior of car
        public string WindowColor { get; set; } // what color are the windows
        public string InteriorColor { get; set; } // what color is the interior of car
        public string Engine { get; set; } // what engine does the car have
        public int EnginePower { get; set; } // car engine power in km
        public string Drive { get; set; } // AWD / 4WD drive for car
        public bool IsTransmissionManual { get; set; } // is car transmission automatic or manual
        public int MaxSpeed { get; set; } // maximum speed car can go at
        public int FuelConsumptionPerHour { get; set; } // fuel consumed in an hour worth per kilometer
        public string Manufacturer { get; set; } // car manufacturer
        public bool IsCarPreviouslyOwned { get; set; } // is car previously owned/used
        public DateTime BuiltAtDate { get; set; } // the date this car was built at
        public int MaintenanceCount { get; set; } // how many maintenance sessions have been conducted on this car
        public DateTime LastMaintenance { get; set; } // when was the last maintenance performed


        // only in database

        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last
    }
}
