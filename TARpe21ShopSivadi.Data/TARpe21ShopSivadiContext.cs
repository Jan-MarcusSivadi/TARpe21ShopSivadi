using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain;

namespace TARpe21ShopSivadi.Data
{
    public class TARpe21ShopSivadiContext : DbContext
    {
        public TARpe21ShopSivadiContext(DbContextOptions<TARpe21ShopSivadiContext> options) : base(options) { }
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
    }
}
