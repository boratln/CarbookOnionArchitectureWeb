using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
