﻿using Carbook.Dto.CarDtos;
using Carbook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public CarController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async  Task<IActionResult> Index()
        {
            TempData["title"] = "Araçlar";
            TempData["desc"] = "Araçlarımız";
            var client=_httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/CarsPricings");
            if (responseMessage.IsSuccessStatusCode) { 
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
