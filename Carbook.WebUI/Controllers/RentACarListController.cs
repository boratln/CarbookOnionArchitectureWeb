using Carbook.Dto.BrandDtos;
using Carbook.Dto.LocationDtos;
using Carbook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Carbook.WebUI.Controllers
{
    public class RentACarListController:Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async  Task<IActionResult> Index(int id)
		{
            TempData["title"] = "Araçlar";
            TempData["desc"] = "Müsait Olan Araçlarımız";
            var locationId = TempData["locationId"];
			id = int.Parse(locationId.ToString());
			ViewBag.locationId = locationId;
		
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7076/api/RentACars/{id}/true");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();
			
			
		

        }
    }
}
