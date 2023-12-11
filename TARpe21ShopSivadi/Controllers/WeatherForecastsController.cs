using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using TARpe21ShopSivadi.Core.Dto.WeatherDtos;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Models.Weather;

namespace TARpe21ShopSivadi.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;
        public WeatherForecastsController(IWeatherForecastsServices weatherForecastServices)
        {
            _weatherForecastServices = weatherForecastServices;
        }
        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> City()
        {
            WeatherResultDto dto = new();

            var serviceResult = await _weatherForecastServices.WeatherDetail(dto, "Tallinn");
            int statusCode = serviceResult.Item2;
            await Console.Out.WriteLineAsync("STATUS CODE: " + statusCode);
            if (statusCode == 503)
            {
                await Console.Out.WriteLineAsync("Rate limit reached.");
            }

            WeatherViewModel vm = new();

            vm.Date = dto.EffectiveDate;
            vm.Category = dto.Category;
            vm.Description = dto.Description;
            vm.Location = dto.Location;
            vm.Icon = dto.Icon;

            vm.FeelsLike = dto.Feels_Like;
            vm.Temp = (int)dto.Temp;
            vm.TempMinValue = dto.Temp_Min;
            vm.TempMaxValue = dto.Temp_Max;

            vm.Humidity = dto.Humidity;
            vm.Pressure = dto.Pressure;
            vm.WindSpeed = dto.WindSpeed;
            vm.WindDeg = dto.WindDeg;
            vm.HasClouds = (dto.CloudsAll / 2 >= 50);
            vm.Visibility = dto.Visibility;

            return View(vm);

        }
    }
}
