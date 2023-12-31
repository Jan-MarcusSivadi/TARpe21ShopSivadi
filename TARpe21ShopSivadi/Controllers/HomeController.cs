﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TARpe21ShopSivadi.ApplicationServices.Services;
using TARpe21ShopSivadi.Core.Dto.WeatherDtos;
using TARpe21ShopSivadi.Models;

namespace TARpe21ShopSivadi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
