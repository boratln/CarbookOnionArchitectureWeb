using Carbook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        

        public IActionResult Index()
        {
			TempData["Navbar"] = "Hizmetler";

			TempData["title"] = "Hizmetler";
            TempData["desc"] = "Hizmetlerimiz";
            return View();
        }
    }
}
