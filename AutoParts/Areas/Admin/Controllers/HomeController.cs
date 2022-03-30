using Microsoft.AspNetCore.Mvc;

namespace AutoParts.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
