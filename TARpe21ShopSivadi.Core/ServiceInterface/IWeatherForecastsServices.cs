using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Dto.WeatherDtos;

namespace TARpe21ShopSivadi.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        public Task<(WeatherResultDto, int)> WeatherDetail(WeatherResultDto dto, string cityname);
    }
}
