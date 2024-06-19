using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavBarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
