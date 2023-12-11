using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Utils;
using System.Text.Json.Serialization;

namespace TARpe21ShopSivadi.Core.Dto.WeatherDtos
{
    //[JsonConverter(typeof(JsonPathConverter))]
    public class WeatherRootDto
    {
        public DateTime EffectiveDate { get; set; }
        public int Dt { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public HeadlineDto Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; } 
        public string Name { get; set; }
    }
}
