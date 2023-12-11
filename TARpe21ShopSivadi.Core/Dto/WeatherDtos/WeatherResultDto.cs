using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopSivadi.Core.Dto.WeatherDtos
{
    public class WeatherResultDto
    {
        public DateTime EffectiveDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public int Visibility { get; set; }

        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }

        public int CloudsAll { get; set; }

        public string Location { get; set; }

        //public DateTime EffectiveDate { get; set; }
        //public int EffectiveEpochDate { get; set; }
        //public string Text { get; set; }
        //public string Category { get; set; }

        //public double TempMinValue { get; set; }
        //public double TempMaxValue { get; set; }

        //public int DayIcon { get; set; }

        //public DateTime EffectiveDate { get; set; }
        //public int EffectiveEpochDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public int EndEpochDate { get; set; }
        //public DateTime DailyForecastsDay { get; set; }
        //public int DailyForecastsEpochDate { get; set; }
        //public bool DayHasPrecipitation { get; set; }
        //public string DayIconPhrase { get; set; }
        //public string DayPrecipitationType { get; set; }
        //public string DayPrecipitationIntensity { get; set; }

        //public int NightIcon { get; set; }
        //public bool NightHasPrecipitation { get; set; }
        //public string NightIconPhrase { get; set; }
        //public string NightPrecipitationType { get; set; }
        //public string NightPrecipitationIntensity { get; set; }
    }
}
