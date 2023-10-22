using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;

namespace TARpe21ShopSivadi.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
    }
}
