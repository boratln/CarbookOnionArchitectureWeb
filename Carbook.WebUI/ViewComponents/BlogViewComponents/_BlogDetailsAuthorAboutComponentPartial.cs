using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/Blogs/GetByBlogWithAuthor/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var getbyauthordto = new GetByBlogAndAuthorDto();
                getbyauthordto.getByBlogWithAuthorDto = JsonConvert.DeserializeObject<GetByBlogWithAuthorDto>(jsonData);
                return View(getbyauthordto);
            }
            return View();
        }
    }
}
