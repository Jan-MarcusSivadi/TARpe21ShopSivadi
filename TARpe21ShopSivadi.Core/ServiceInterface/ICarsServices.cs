using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;

namespace TARpe21ShopSivadi.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> GetAsync(Guid id);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
    }
}
