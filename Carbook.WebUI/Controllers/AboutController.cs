using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
			TempData["Navbar"] = "Hakkımızda";

			TempData["title"] = "Hakkımızda";
            TempData["desc"] = "Site Hakkında";
            return View();
        }
    }
}
