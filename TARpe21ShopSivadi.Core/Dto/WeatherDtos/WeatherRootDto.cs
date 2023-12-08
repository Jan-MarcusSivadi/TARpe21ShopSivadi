using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARpe21ShopSivadi.Core.Dto.WeatherDtos
{
    public class WeatherRootDto
    {
        [JsonPropertyName("weather")]
        public List<DailyForecastsDto> DailyForecasts { get; set; }
        //public HeadlineDto Headline { get; set; }
        //public List<DailyForecastsDto> DailyForecasts { get; set; }
        //public int Severity { get; set; }
        //public string Text { get; set; }
        //public string Category { get; set; }
    }
}
