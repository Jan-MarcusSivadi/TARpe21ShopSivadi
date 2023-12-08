using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopSivadi.Core.Domain
{
    public class Car
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExteriorColor { get; set; } // what color is the exterior of car
        public string InteriorColor { get; set; } // what color is the interior of car
        public string WindowColor { get; set; } // what color are the windows
        public bool IsSteeringLeft { get; set; } // does the car have steering wheel on the left side
        public int NumOfSeats { get; set; } // number of seats, including passengers
        public int NumOfWheels { get; set; } // how many wheels does the car have
        public int PassengerCount { get; set; } // how many passengers can the car carry
        public bool HasConditioner { get; set; } // does the car have conditioner installed
        public bool HasHeatedSeats { get; set; } // does the car have seat heating system installed
        public bool HasTouchscreen { get; set; } // does the car have touchscreen
        public bool DoesHaveExtendedCab { get; set; } // does car come with extended cabinets
        public bool IsElectric { get; set; } // is the car electric
        public string Type { get; set; } // car type, f.e. truck, van,
        public string GearType { get; set; } // automatic or manual
        public bool IsTransmissionManual { get; set; } // is car transmission automatic or manual
        public string Engine { get; set; } // what engine does the car have
        public int EnginePower { get; set; } // car engine power in km
        public string Drive { get; set; } // AWD / 4WD drive for car
        public int MaxSpeed { get; set; } // maximum speed car can go
        public int FuelConsumptionPerHour { get; set; } // fuel consumed in an hour per kilometer
        public string Manufacturer { get; set; } // car manufacturer
        public bool IsCarPreviouslyOwned { get; set; } // is car previously owned
        public DateTime BuiltAtDate { get; set; } // the date this car was built at
        public int MaintenanceCount { get; set; } // how many maintenance sessions have been conducted on this car
        public DateTime LastMaintenance { get; set; } // when was the last maintenance performed
        public IEnumerable<FileToApi> FilesToApi { get; set; } = new List<FileToApi>(); //files to be added to the api

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
