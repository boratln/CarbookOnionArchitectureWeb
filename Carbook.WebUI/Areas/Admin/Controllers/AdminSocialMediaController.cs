using Carbook.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    public class AdminSocialMediasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSocialMediasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/SocialMedias");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediasDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediasDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7076/api/SocialMedias", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedias", new { area = "Admin" });
            }
            return View();

        }
        [Route("DeleteSocialMedia/{id}")]

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7076/api/SocialMedias/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedias", new { area = "Admin" });

            }
            return RedirectToAction("Index", "AdminSocialMedias", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            HttpContext.Session.SetInt32("SocialMediasid", id);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7076/api/SocialMedias/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);

                return View(value);
            }
            return View(new UpdateSocialMediaDto());
        }
        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediasDto)
        {
            int id = (int)HttpContext.Session.GetInt32("SocialMediasid");

            updateSocialMediasDto.SocialMediaId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediasDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7076/api/SocialMedias", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                HttpContext.Session.Remove("SocialMediasid");
                return RedirectToAction("Index", "AdminSocialMedias", new { area = "Admin" });

            }
            return RedirectToAction("Index", "AdminSocialMedias", new { area = "Admin" });

        }
    }
}
