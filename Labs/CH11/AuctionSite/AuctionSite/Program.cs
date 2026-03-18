using AuctionSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using AuctionSite.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{controller=Listings}/{action=Index}/{id?}/{slug?}");


app.Run();