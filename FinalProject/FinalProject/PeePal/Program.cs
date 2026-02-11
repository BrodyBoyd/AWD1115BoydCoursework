using PeePal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "default",
    areaName: "Reviews",
    pattern: "reviews/{controller=Reviews}/{action=Index}/{id?}/{slug?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
app.MapRazorPages();
app.Run();
