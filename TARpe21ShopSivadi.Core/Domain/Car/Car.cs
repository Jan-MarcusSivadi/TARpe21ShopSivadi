using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopSivadi.Core.Domain.Car
{
    public class Car
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string GearType { get; set; }
        public bool HasConditioner { get; set; }
        public bool HasRadio { get; set; }
        public string WheelCount { get; set; }
        public int PassengerCount { get; set; }
        public DateTime BuiltAtDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsCarPreviouslyOwned { get; set; }
        public string Manufacturer { get; set; }
        public int EnginePower { get; set; }
        public int FuelConsuptionPerHour { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMainenance { get; set; }

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
