using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatisticts")]
    public class AdminStatistictsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatistictsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
