using Carbook.Dto.BrandDtos;
using Carbook.Dto.SignUpDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Controllers
{
	public class SignUpController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SignUpController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public IActionResult CreateAppUser()
		{
			return View();
		}
		[HttpPost]
		public async  Task<IActionResult> CreateAppUser(CreateSignUpDto createSignUpDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSignUpDto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7076/api/SignUp", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return RedirectToAction("Index", "Default");
		}
	}
}
