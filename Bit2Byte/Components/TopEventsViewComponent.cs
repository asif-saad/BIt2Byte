using Microsoft.AspNetCore.Mvc;

namespace Bit2Byte.Components
{
    public class TopEventsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
