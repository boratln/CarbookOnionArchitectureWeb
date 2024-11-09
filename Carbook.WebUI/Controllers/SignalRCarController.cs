using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
