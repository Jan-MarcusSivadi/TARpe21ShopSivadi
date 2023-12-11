using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Utils;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace TARpe21ShopSivadi.Core.Dto.WeatherDtos
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class DailyForecastsDto
    {
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
    }
    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
    //public class Night
    //{
    //    [JsonPropertyName("Icon")]
    //    public int Icon { get; set; }
    //    [JsonPropertyName("IconPhrase")]
    //    public string IconPhrase { get; set; }
    //    [JsonPropertyName("HasPrecipitation")]
    //    public bool HasPrecipitation { get; set; }
    //    [JsonPropertyName("PrecipitationType")]
    //    public string PrecipitationType { get; set; }
    //    [JsonPropertyName("PrecipitationIntensity")]
    //    public string PrecipitationIntensity { get; set; }
    //}
    public class Day
    {
        [JsonProperty("weather.icon")]
        public int Icon { get; set; }
        [JsonProperty("wind.speed")]
        public int WindSpeed { get; set; }
        [JsonProperty("wind.deg")]
        public int WindDeg { get; set; }

        //[JsonPropertyName("IconPhrase")]
        //public string IconPhrase { get; set; }
        //[JsonPropertyName("HasPrecipitation")]
        //public bool HasPrecipitation { get; set; }
        //[JsonPropertyName("PrecipitationType")]
        //public string PrecipitationType { get; set; }
        //[JsonPropertyName("PrecipitationIntensity")]
        //public string PrecipitationIntensity { get; set; }
    }

    public class Maximum
    {
        [JsonProperty("main.temp_max")]
        public double Value { get; set; }

        //[JsonPropertyName("Unit")]
        //public string Unit { get; set; }
        //[JsonPropertyName("UnitType")]
        //public int UnitType { get; set; }
    }
    public class Minimum
    {
        [JsonProperty("main.temp_min")]
        public double Value { get; set; }

        //[JsonPropertyName("Unit")]
        //public string Unit { get; set; }
        //[JsonPropertyName("UnitType")]
        //public int UnitType { get; set; }
    }
}
