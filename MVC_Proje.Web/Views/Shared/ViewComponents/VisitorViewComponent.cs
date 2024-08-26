using Microsoft.AspNetCore.Mvc;

namespace MVC_Proje.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
