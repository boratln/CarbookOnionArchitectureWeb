using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
