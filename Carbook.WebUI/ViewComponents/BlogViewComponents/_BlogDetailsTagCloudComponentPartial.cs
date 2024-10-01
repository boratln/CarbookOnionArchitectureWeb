using Carbook.Dto.BlogDtos;
using Carbook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/TagClouds/GetTagCloudByBlogId/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
