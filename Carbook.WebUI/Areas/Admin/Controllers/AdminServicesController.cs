using Carbook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminServices")]
    public class AdminServicesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminServicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/Servicess");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateServices")]
        public IActionResult CreateServices()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateServices")]
        public async Task<IActionResult> CreateServices(CreateServiceDto createServicesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServicesDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7076/api/Servicess", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminServices", new { area = "Admin" });
            }
            return View();

        }
        [Route("DeleteServices/{id}")]

        public async Task<IActionResult> DeleteServices(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7076/api/Servicess/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminServices", new { area = "Admin" });

            }
            return RedirectToAction("Index", "AdminServices", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(int id)
        {
            HttpContext.Session.SetInt32("Servicesid", id);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7076/api/Servicess/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateServicesDto>(jsonData);

                return View(value);
            }
            return View(new UpdateServicesDto());
        }
        [HttpPost]
        [Route("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(UpdateServicesDto updateServicesDto)
        {
            int id = (int)HttpContext.Session.GetInt32("Servicesid");

            updateServicesDto.ServicesId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServicesDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7076/api/Servicess", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                HttpContext.Session.Remove("Servicesid");
                return RedirectToAction("Index", "AdminServices", new { area = "Admin" });

            }
            return RedirectToAction("Index", "AdminServices", new { area = "Admin" });

        }
    }
}
