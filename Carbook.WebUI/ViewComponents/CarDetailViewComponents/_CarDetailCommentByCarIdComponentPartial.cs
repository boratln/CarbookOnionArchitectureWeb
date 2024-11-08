using Carbook.Dto.CarFeatureDtos;
using Carbook.Dto.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentByCarIdComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCommentByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7076/api/Reviews/GetReviewsByCarId/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var client2 = _httpClientFactory.CreateClient();
				var responseMessage2 = await client2.GetAsync("https://localhost:7076/api/Reviews/GetReviewCountByCarId/" + id);
				if (responseMessage2.IsSuccessStatusCode)
				{
					var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
					var value=JsonConvert.DeserializeObject<GetReviewCountDto>(jsonData2);
					ViewBag.count = value.ReviewCount;
				}
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);
				return View(values);

			}
			
			return View();
		}
	}
}
