using Microsoft.AspNetCore.Mvc;

namespace TARpe21ShopSivadi.Controllers
{
    public class WeatherForecastsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
