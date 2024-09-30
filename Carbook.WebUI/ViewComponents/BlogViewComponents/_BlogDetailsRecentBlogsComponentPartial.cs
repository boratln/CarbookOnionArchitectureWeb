using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7076/api/Blogs/GetLast3BlogWithAuthor");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
