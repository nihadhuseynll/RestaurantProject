using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
