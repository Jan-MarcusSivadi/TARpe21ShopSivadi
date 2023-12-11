using TARpe21ShopSivadi.Core.Dto.WeatherDtos;

namespace TARpe21ShopSivadi.Models.Weather
{
    public class WeatherViewModel
    {
        //public int EpochDate { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }

        public double TempMinValue { get; set; }
        public double TempMaxValue { get; set; }

        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public bool HasClouds { get; set; }
        public int Visibility { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public int Temp { get; set; }
        public double FeelsLike { get; set; }
        public int Timezone { get; set; }
        public string Location { get; set; }
    }
}
