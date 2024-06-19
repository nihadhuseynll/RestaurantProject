using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult UILayoutPage()
		{
			return View();
		}
	}
}
