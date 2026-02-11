var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();
app.UseStaticFiles();
app.MapAreaControllerRoute(
    areaName: "Help",
    name: "default",
    pattern: "{controller=Home}/{action=Index}/help/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
