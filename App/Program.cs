using Microsoft.EntityFrameworkCore;
using MyRestaurantly.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RestaurantlyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "Admin",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Main}/{id?}"
          );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Main}/{id?}"
        );
});

app.Run();
