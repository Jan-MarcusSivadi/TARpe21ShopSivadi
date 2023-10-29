using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace TARpe21ShopSivadi.ApplicationServices.Services
{
    public  class RealEstatesServices
    {
        private readonly TARpe21ShopSivadiContext _context;
        public RealEstatesServices(TARpe21ShopSivadiContext context)
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
