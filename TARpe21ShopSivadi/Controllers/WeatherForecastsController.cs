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

            var serviceResult = await _weatherForecastServices.WeatherDetail(dto);
            int statusCode = serviceResult.Item2;
            await Console.Out.WriteLineAsync("STATUS CODE: " + statusCode);
            if (statusCode == 503)
            {
                await Console.Out.WriteLineAsync("Rate limit reached.");
            }

            WeatherViewModel vm = new();

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPrecipitation = dto.DayHasPrecipitation;
            vm.DayPrecipitationType = dto.DayPrecipitationType;
            vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            vm.NightPrecipitationType = dto.NightPrecipitationType;
            vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;

            return View(vm);

        }
    }
}
