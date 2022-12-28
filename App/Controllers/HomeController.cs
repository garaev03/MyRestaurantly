using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestaurantly.DAL;
using MyRestaurantly.Models;

namespace MyRestaurantly.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantlyDbContext _context;

        public HomeController(RestaurantlyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Main()
        {
            List<Category> categories= await _context.Categories
                .Include(x=>x.Menu).ThenInclude(x=>x.Ingredients)
                .OrderBy(x=>x.Id)
                .ToListAsync();
            return View(categories);
        }
    }
}
