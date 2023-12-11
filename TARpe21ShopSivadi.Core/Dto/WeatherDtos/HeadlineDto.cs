using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using TARpe21ShopSivadi.Core.Utils;

namespace TARpe21ShopSivadi.Core.Dto.WeatherDtos
{
    //[JsonConverter(typeof(JsonPathConverter))]
    public class HeadlineDto
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        //[JsonProperty("main.pressure")]
        //public int Pressure { get; set; }
        //[JsonProperty("main.feels_like")]
        //public int FeelsLike { get; set; }
        //[JsonProperty("main.temp")]
        //public Temperature Temperature { get; set; }
        //[JsonProperty("weather.description")]
        //public string Text { get; set; }
        //[JsonProperty("weather.main")]
        //public string Category { get; set; }

        //[JsonPropertyName("EffectiveDate")]
        //public DateTime EffectiveDate { get; set; }
        //[JsonPropertyName("EffectiveEpochDate")]
        //public int EffectiveEpochDate { get; set; }

        //[JsonPropertyName("EndDate")]
        //public DateTime EndDate { get; set; }
        //[JsonPropertyName("EndEpochDate")]
        //public int EndEpochDate { get; set; }

        //public Temperature Temperature { get; set; }
        //public Day Day { get; set; }
        //public Night Night { get; set; }
        //public List<string> Sources { get; set; }
    }
}
