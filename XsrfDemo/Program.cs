using MintPlayer.AspNetCore.XsrfForSpas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
builder.Services.AddSingleton<XsrfDemo.Stores.IWeatherForecastStore, XsrfDemo.Stores.WeatherForecastStore>();

var app = builder.Build();
await app.Services.GetRequiredService<XsrfDemo.Stores.IWeatherForecastStore>().SeedWithRandomForecasts();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
