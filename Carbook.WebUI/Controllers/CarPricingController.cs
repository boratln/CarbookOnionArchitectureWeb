using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            TempData["title"] = "Paketler";
            TempData["desc"] = "Araç Fiyat Paketleri";
            return View();
        }
    }
}
