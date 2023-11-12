using WebMvcAppInventory.Services.Interfaces;
using WebMvcAppInventory.Services;
using WebMvcAppInventory.Middlewares.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddSingleton<IDataProvider>(new FileDataProvider("Data/inventoryData.json"));

var app = builder.Build();

app.UseGlobalErrorMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
