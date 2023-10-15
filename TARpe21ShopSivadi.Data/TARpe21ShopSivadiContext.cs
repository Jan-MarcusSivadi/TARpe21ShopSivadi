﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain.Spaceship;

namespace TARpe21ShopSivadi.Data
{
    public class TARpe21ShopSivadiContext : DbContext
    {
        public TARpe21ShopSivadiContext(DbContextOptions<TARpe21ShopSivadiContext> options) : base(options) { }
        public DbSet<Spaceship> spaceships { get; set; }
    }
}