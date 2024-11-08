using Carbook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async  Task<IActionResult> Index()
        {
			TempData["Navbar"] = "Anasayfa";
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
		public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationID)
		{
			TempData["bookpickdate"] = book_pick_date;
			TempData["bookoffdate"] = book_off_date;
			TempData["timepick"] = time_pick;
			TempData["timeoff"] = time_off;
			TempData["locationId"] = locationID;
			return RedirectToAction("Index", "RentACarList");
		}
	}
}
