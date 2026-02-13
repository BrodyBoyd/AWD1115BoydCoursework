using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeePal.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddRazorPages();

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
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "default",
    areaName: "Reviews",
    pattern: "reviews/{controller=Reviews}/{action=Index}/{id?}/{slug?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
app.MapRazorPages();
app.Run();
