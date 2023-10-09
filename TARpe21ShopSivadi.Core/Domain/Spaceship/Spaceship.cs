using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TARpe21ShopSivadi.Core.Domain.Spaceship
{
    public class Spaceship
    {
        [Key]
        public Guid? Id { get; set; } // globally unique identifier
        public string Name { get; set; } // ship name
        public string Description { get; set; } // ship description
        public int[] dimensions = new int[3];
        public int[] Dimensions   // contains an array of int with (x y z) values
        {
            get { return dimensions; }   // get method
            set { dimensions = value; }  // set method
        }
        public int PassengerCount { get; set; } // how many passenders does the ship carry
        public int CrewCount { get; set; } // how many crew members is needed to operate the ship 
        public int CargoWeight { get; set; } // how much cargo the ship is able to carry
        public int MaxSpeedInVaccuum { get; set; } // maximum speed after exiting atmosphere
        public DateTime BuiltAtDate { get; set; } // the date that this ship was built at
        public DateTime MaidenLaunch { get; set; } // the date this ship made its first voyage
        public string Manufacturer { get; set; } // company who manufarctured the spaceship
        public bool SpaceshipUsed { get; set; } // denotes if the ship has been previously owned or not, tldr; second hand identifier.
        public int FullTripsCount { get; set; } // how many round trips has the ship taken
        public string Type { get; set; } // bodytype, build type
        public int EnginePower { get; set; } // engine power in kilowatts
        public int FuelComsumptionPerDay { get; set; } // fuel consumed in a days worth of space traveled at maximum speed
        public int MaintenanceCount { get; set; } // how many maintenance sessions have been conducted on this ship
        public DateTime LastMaintenance { get; set; } // when was the last maintenance performed


        // only in database

        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified
    }
}
