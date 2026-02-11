using Ch6Lab.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FaqsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FAQsCS")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "topic_and_category", pattern: "{controller=Home}/{action=Index}/topic/{topic?}/category/{category?}");

app.MapControllerRoute(name: "category", pattern: "{controller=Home}/{action=Index}/category/{category?}");

app.MapControllerRoute( name: "topic", pattern: "{controller=Home}/{action=Index}/topic/{topic?}/{id?}/{slug?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
