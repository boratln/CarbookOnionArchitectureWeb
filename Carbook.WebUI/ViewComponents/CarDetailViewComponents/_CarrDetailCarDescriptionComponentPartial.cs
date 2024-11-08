using Carbook.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarrDetailCarDescriptionComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarrDetailCarDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task <IViewComponentResult> InvokeAsync(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7076/api/CarDescriptions/GetCarDescriptionByCarId/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var value=JsonConvert.DeserializeObject<GetCarDescriptionByCarIdDto>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}
