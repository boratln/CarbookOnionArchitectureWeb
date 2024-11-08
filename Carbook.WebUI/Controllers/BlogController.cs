using Carbook.Dto.BlogDtos;
using Carbook.Dto.CommentDtos;
using Carbook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

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
			TempData["Navbar"] = "Blog";

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
            HttpContext.Session.SetInt32("id", id);
   
            var dto = new GetByBlogAndAuthorDto();

            return View(dto);
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            var id = HttpContext.Session.GetInt32("id");
            var viewmodel = new GetByBlogAndAuthorDto
            {
                createCommentDto = new CreateCommentDto(),
                getByBlogDto = new GetByBlogDto(),
                getByBlogWithAuthorDto = new GetByBlogWithAuthorDto(),
            };
            return PartialView(viewmodel);
        }
        [HttpPost]
        public async  Task<IActionResult> AddComment(string name,string message,string id,string email)
        {
            var blogid = int.Parse(id);

            CreateCommentDto commentDto = new CreateCommentDto();
            commentDto.CommentText = message;
            commentDto.Name= name;
            commentDto.Email= email;
            commentDto.BlogId = blogid;
            commentDto.CreatedDate= DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(commentDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7076/api/Comments/AddComment", content);
            var data=await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
