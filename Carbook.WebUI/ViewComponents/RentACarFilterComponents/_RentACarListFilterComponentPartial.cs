using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarListFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            TempData["value"] = v;
            return View();
        }
    }
}
