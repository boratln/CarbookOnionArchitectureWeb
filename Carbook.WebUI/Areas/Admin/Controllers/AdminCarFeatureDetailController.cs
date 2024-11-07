using Carbook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
     
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/CarFeature/GetCarFeatureByCarId/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarFeatureByCarIdDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpPost("Index/{id}")]
        public async Task<IActionResult> Index(List<CarFeatureByCarIdDto> carFeatureByCarIdDto)
        {
            foreach(var data in carFeatureByCarIdDto)
            {
                if (data.Available)
                {
                    var client=_httpClientFactory.CreateClient();
                     client.GetAsync("https://localhost:7076/api/CarFeature/CarFeatureChangeAvaliableToTrue/" + data.CarFeatureId);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                     client.GetAsync("https://localhost:7076/api/CarFeature/CarFeatureChangeAvaliableToFalse/" + data.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
