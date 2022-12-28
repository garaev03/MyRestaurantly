using Microsoft.EntityFrameworkCore;
using MyRestaurantly.Models;

namespace MyRestaurantly.DAL
{
    public class RestaurantlyDbContext : DbContext
    {
        public RestaurantlyDbContext(DbContextOptions<RestaurantlyDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
