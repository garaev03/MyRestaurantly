using Microsoft.AspNetCore.Mvc;

namespace MyRestaurantly.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
