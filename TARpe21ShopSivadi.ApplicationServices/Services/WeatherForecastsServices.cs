using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Dto.WeatherDtos;
using TARpe21ShopSivadi.Core.ServiceInterface;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TARpe21ShopSivadi.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        private async Task<Tuple<string, string>> GetLatLonByCity(string cityname, string apiKey)
        {
            var url = $"https://geocode.maps.co/search?q=${cityname}";
            int statusCode = 200;
            string lat = "";
            string lon = "";

            JObject joResponse;
            WebClient client = new WebClient();
            try
            {
                // send request
                string json = client.DownloadString(url);
                List<JObject> array = JsonConvert.DeserializeObject<List<JObject>>(json);
                JObject jsonObject = array[0];

                lat = (string)jsonObject.GetValue("lat");
                lon = (string)jsonObject.GetValue("lon");

                if (lat == "" || lat == "")
                {
                    return null;
                }
            }
            catch (WebException e)
            {
                // check e.Status as above etc..
                int errStatusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                Console.WriteLine("Status code: " + errStatusCode);
                statusCode = errStatusCode;
            }

            return Tuple.Create(lat, lon);
        }
        public async Task<(WeatherResultDto, int)> WeatherDetail(WeatherResultDto dto)
        {
            var apiKey = "083cda02bfad9bd51855a6a23e900b69";
            Tuple<string, string> geoResult = await GetLatLonByCity("Tallinn", apiKey).ConfigureAwait(false);
            string lat = geoResult.Item1;
            string lon = geoResult.Item2;
            Console.WriteLine("TEST:" + "lat: " + lat + " lon: " + lon);
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

            int statusCode = 200;
            WebClient client = new WebClient();
            try
            {
                // send request
                string json = client.DownloadString(url);
                object deserialized = JsonConvert.DeserializeObject<object>(json);
                JObject jsonObject = (JObject)deserialized;
                Console.WriteLine("API response.body: " + deserialized);

                //JArray weather = (JArray)jsonObject.GetValue("weather");
                //Console.WriteLine("jToken weather: " + weather);
                //lat = (string)jsonObject.GetValue("lat");
                //lon = (string)jsonObject.GetValue("lon");

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                Console.WriteLine("WEATHER API: " + weatherInfo);

                dto.Text = weatherInfo.Headline.Text;
                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;
            }
            catch (WebException e)
            {
                // check e.Status as above etc..
                int errStatusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                Console.WriteLine("Status code: " + errStatusCode);
                statusCode = errStatusCode;
            }

            //return (dto, statusCode);
            return (dto, 200);
        }
    }
}
