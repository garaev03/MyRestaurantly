using Microsoft.AspNetCore.Mvc;

namespace MyRestaurantly.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
