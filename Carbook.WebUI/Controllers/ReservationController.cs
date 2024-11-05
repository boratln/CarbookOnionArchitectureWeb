using Carbook.Dto.LocationDtos;
using Carbook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> Index(int id)
        {
            TempData["title"] = "Araç Kiralama";
            TempData["desc"] = "Araç Rezervasyon Formu";
            ViewBag.id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.LocationId.ToString()
                                            }).ToList();
            ViewBag.x = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto reservationDto)
        {
            if (reservationDto.Description == null)
            {
                reservationDto.Description = "";
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(reservationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7076/api/Reservations", content);
            var data = responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.mesaj = "Rezervasyonunuz alınmıştır";
                return RedirectToAction("Index", "Default" ,new {mesaj=ViewBag.mesaj});
            }
            return View();
        }
    }
}
