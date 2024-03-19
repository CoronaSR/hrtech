using Microsoft.EntityFrameworkCore;
using HR_Tech.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebEssentials.AspNetCore.Pwa;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddServiceWorker(new PwaOptions {
            Strategy = ServiceWorkerStrategy.CustomStrategy,
            CustomServiceWorkerStrategyFileName = "service-worker.js",
            OfflineRoute = "offline.html",
            RoutesToIgnore = ""
        });

        builder.Services.AddDbContext<HRContextDB>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Usuarios}/{action=Login}/{id?}");

        CreateDbIfNotExists(app);

        app.Run();
    }

    private static void CreateDbIfNotExists(IHost host) {
        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            try {
                var context = services.GetRequiredService<HRContextDB>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex) {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}