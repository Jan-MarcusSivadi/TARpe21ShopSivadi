using Microsoft.EntityFrameworkCore;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;
using TARpe21ShopSivadi.ApplicationServices.Services;

public class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<TARpe21ShopSivadiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
        builder.Services.AddScoped<IFilesServices, FilesServices>();
        builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
        builder.Services.AddScoped<IWeatherForecastsServices, WeatherForecastsServices>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}