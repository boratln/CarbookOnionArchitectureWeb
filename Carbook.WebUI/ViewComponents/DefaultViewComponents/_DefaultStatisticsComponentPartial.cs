using Carbook.Dto.StatistictsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task <IViewComponentResult> InvokeAsync()
		{
			var model = new ResultStatisticDto();
			#region CarCount
			var client = _httpClientFactory.CreateClient();
			var responseMessage1 = await client.GetAsync("https://localhost:7076/api/Statisticts/GetCarCount");
			if (responseMessage1.IsSuccessStatusCode)
			{
				var data = await responseMessage1.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);
				model.CarCount = jsonData.CarCount;
			}
			#endregion
			#region LocationCount
			var client5 = _httpClientFactory.CreateClient();
			var responseMessage5 = await client5.GetAsync("https://localhost:7076/api/Statisticts/GetLocationCount");
			if (responseMessage5.IsSuccessStatusCode)
			{
				var data = await responseMessage5.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

				model.LocationCount = jsonData.LocationCount;
			}
			#endregion
			#region BrandCount
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:7076/api/Statisticts/GetBrandCount");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var data = await responseMessage4.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

				model.BrandCount = jsonData.BrandCount;
			}
			#endregion
			#region CarCountByFuelElectric
			var client13 = _httpClientFactory.CreateClient();
			var responseMessage13 = await client13.GetAsync("https://localhost:7076/api/Statisticts/GetCarCountByFuelElectric");
			if (responseMessage13.IsSuccessStatusCode)
			{
				var data = await responseMessage13.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

				model.CarCountByFuelElectric = jsonData.CarCountByFuelElectric;
			}
			#endregion
			return View(model);
		}
	}
}
