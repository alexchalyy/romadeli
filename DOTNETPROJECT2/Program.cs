using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace TorysDeli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllersWithViews();
                    })
                    .Configure(app =>
                    {
                        app.UseRouting();
                        app.UseStaticFiles();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}"
                            );
                            endpoints.MapControllerRoute(
                                name: "menu",
                                pattern: "{controller=Menu}/{action=Menu}/{id?}"
                            );
                            endpoints.MapControllerRoute(
                                name: "aboutus",
                                pattern: "{controller=AboutUs}/{action=AboutUs}/{id?}"
                            );
                            endpoints.MapControllerRoute(
                                name: "contactus",
                                pattern: "{controller=ContactUs}/{action=ContactUs}/{id?}"
                            );
                        });
                    });
                })
                .Build();
            host.Run();
        }
    }
}
