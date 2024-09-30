using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7076/api/Blogs/GetLast3BlogWithAuthor");
            var data = response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLast3BlogDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
