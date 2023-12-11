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
        private async Task<Tuple<string, string, string, int>> GetLatLonByCity(string cityname, string apiKey)
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

            return Tuple.Create(lat, lon, cityname, statusCode);
        }
        public async Task<(WeatherResultDto, int)> WeatherDetail(WeatherResultDto dto, string cityname)
        {
            var apiKey = "083cda02bfad9bd51855a6a23e900b69";
            Tuple<string, string, string, int> geoResult = await GetLatLonByCity(cityname, apiKey).ConfigureAwait(false);
            string lat = geoResult.Item1;
            string lon = geoResult.Item2;
            string loactionCityname = geoResult.Item3;
            int locationStatusCode = geoResult.Item4;
            int statusCode = locationStatusCode;

            Console.WriteLine("TEST:" + "lat: " + lat + " lon: " + lon);
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

            WebClient client = new WebClient();
            try
            {
                // send request
                string json = client.DownloadString(url);
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);
                //object deserialized = JsonConvert.DeserializeObject<object>(json);
                //JObject jsonObject = (JObject)deserialized;
                //Console.WriteLine("API response.body: " + deserialized);

                //JArray weather = (JArray)jsonObject.GetValue("weather");
                //Console.WriteLine("jToken weather: " + weather);
                //lat = (string)jsonObject.GetValue("lat");
                //lon = (string)jsonObject.GetValue("lon");

                Console.WriteLine("main: " + weatherInfo.Weather[0].Main);
                Console.WriteLine("description: " + weatherInfo.Weather[0].Description);
                Console.WriteLine("icon: " + weatherInfo.Weather[0].Icon);
                Console.WriteLine("temp: " + weatherInfo.Main.Temp);
                Console.WriteLine("feels_like: " + weatherInfo.Main.Feels_Like);
                Console.WriteLine("temp_min: " + weatherInfo.Main.Temp_Min);
                Console.WriteLine("temp_max: " + weatherInfo.Main.Temp_Max);
                Console.WriteLine("pressure: " + weatherInfo.Main.Pressure);
                Console.WriteLine("humidity: " + weatherInfo.Main.Humidity);
                Console.WriteLine("visibility: " + weatherInfo.Visibility);
                Console.WriteLine("wind speed: " + weatherInfo.Wind.Speed);
                Console.WriteLine("wind deg: " + weatherInfo.Wind.Deg);
                Console.WriteLine("clouds %: " + weatherInfo.Clouds.All);

                // convert from UNIX time to DateTime format
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Dt);
                weatherInfo.EffectiveDate = dateTimeOffset.UtcDateTime;

                Console.WriteLine("date: " + weatherInfo.EffectiveDate);
                Console.WriteLine("location: " + weatherInfo.Name);

                // convert API data to DTO for frontend
                dto.EpochDate = weatherInfo.Dt;
                dto.EffectiveDate = weatherInfo.EffectiveDate;
                dto.Category = weatherInfo.Weather[0].Main;
                dto.Description = weatherInfo.Weather[0].Description;
                dto.Icon = weatherInfo.Weather[0].Icon;
                dto.Temp = weatherInfo.Main.Temp;
                dto.Temp_Min = weatherInfo.Main.Temp_Min;
                dto.Temp_Max = weatherInfo.Main.Temp_Max;
                dto.Feels_Like = weatherInfo.Main.Feels_Like;
                dto.Pressure = weatherInfo.Main.Pressure;
                dto.Humidity = weatherInfo.Main.Humidity;
                dto.Visibility = weatherInfo.Visibility;
                dto.WindSpeed = weatherInfo.Wind.Speed;
                dto.WindDeg = weatherInfo.Wind.Deg;
                dto.CloudsAll = weatherInfo.Clouds.All;
                dto.Location = weatherInfo.Name;
                dto.City = loactionCityname;
            }
            catch (WebException e)
            {
                // check e.Status as above etc..
                int errStatusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                Console.WriteLine("Status code: " + errStatusCode);
                statusCode = errStatusCode;
            }

            return (dto, statusCode);
        }
    }
}
