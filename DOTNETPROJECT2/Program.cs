using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace TorysDeli
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Seed roles and admin user
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    await SeedData.Initialize(services, userManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred seeding the database: {ex.Message}");
                }
            }

            // Configure the HTTP request pipeline
            Configure(app, app.Environment);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add MVC controllers with views
            services.AddControllersWithViews();

            // Configure Entity Framework with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity services
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(/* Your Authentication Configuration */);
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
        }

        private static void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure endpoint routing for MVC
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "menu",
                    pattern: "{controller=Menu}/{action=Menu}/{id?}");

                endpoints.MapControllerRoute(
                    name: "aboutus",
                    pattern: "{controller=AboutUs}/{action=AboutUs}/{id?}");

                endpoints.MapControllerRoute(
                    name: "contactus",
                    pattern: "{controller=ContactUs}/{action=ContactUs}/{id?}");

                endpoints.MapControllerRoute(
                    name: "account",
                    pattern: "{controller=Account}/{action=Register}/{id?}");
            });
        }
    }
}
