using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            TempData["title"] = "İletişim";
            TempData["desc"] = "İletişim Bilgilerimiz";
            return View();
        }
    }
}
