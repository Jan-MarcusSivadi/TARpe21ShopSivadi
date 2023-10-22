using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;

namespace TARpe21ShopSivadi.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> GetUpdate(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> GetAsync(Guid id);
    }
}
