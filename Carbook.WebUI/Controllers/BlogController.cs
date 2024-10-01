using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace Carbook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> Index()
        {
            TempData["title"] = "Bloglar";
            TempData["desc"] = "Bloglarımız";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7076/api/Blogs/GetAllBlogWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            TempData["title"] = "Bloglar";
            TempData["desc"] = "Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7076/api/Blogs/"+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData= await responseMessage.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<GetByBlogDto>(jsonData);
            //    return View(value);
            //}
            var dto = new GetByBlogAndAuthorDto();

            return View(dto);
        }
    }
}
