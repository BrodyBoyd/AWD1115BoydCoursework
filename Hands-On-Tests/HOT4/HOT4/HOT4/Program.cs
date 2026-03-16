using HOT4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppointmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.MapAreaControllerRoute(name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Appointment}/{action=Index}/{id?}/{slug?}"
);

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");


app.Run();