using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/Blogs/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var getbyblogdto = new GetByBlogAndAuthorDto();
                getbyblogdto.getByBlogDto = JsonConvert.DeserializeObject<GetByBlogDto>(jsonData);

                
                return View(getbyblogdto);

            }
            return View();
        }
    }
}
