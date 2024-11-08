using Carbook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailMainCarFeatureComponentPartial:ViewComponent
	{
		private IHttpClientFactory _httpClientFactory;

		public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async  Task<IViewComponentResult> InvokeAsync(int CarId)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7076/api/Cars/GetCarWithBrand/" + CarId);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<GetCarWithBrandByCarIdDto>(jsonData);
				return View(value);
			}
			return View(new GetCarWithBrandByCarIdDto());
		}
	}
}
