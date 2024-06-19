using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    } 
}
