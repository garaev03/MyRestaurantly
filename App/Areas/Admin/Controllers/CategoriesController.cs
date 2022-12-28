using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestaurantly.DAL;
using MyRestaurantly.Models;

namespace MyRestaurantly.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly RestaurantlyDbContext _context;

        public CategoriesController(RestaurantlyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            List<Category> categories = await _context.Categories
                .Include(x => x.Menu)
                .ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) { return View(); }
            bool checkExistence = await _context.Categories.AnyAsync(x => x.Name == category.Name);
            if (checkExistence)
            {
                ModelState.AddModelError("Name", "Name already exists!");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category EditedCategory)
        {
            if (ModelState.IsValid)
            {
                bool checkExistence = await _context.Categories.AnyAsync(x => x.Name == EditedCategory.Name);
                if (checkExistence)
                {
                    ModelState.AddModelError("Name", "Name already exists!");
                    return View();
                }
                Category category = await _context.Categories.FindAsync(EditedCategory.Id);
                //if (category == null) { }
                category.Name = EditedCategory.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction("All");
            }
            return View();
        }
    }
}
