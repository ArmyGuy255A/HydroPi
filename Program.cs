using Serilog;
using Serilog.Events;
using Serilog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using HydroPi.Services.Identity;

namespace HydroPi
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console()
            //    .CreateLogger();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information("Starting up HydroPi!");

            try
            {
                Log.Information("Starting Web Host");
                var host = CreateHostBuilder(args).Build();

                //using (var scope = host.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;
                //    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                //    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                //    var roleResult = IdentityDbValidator.ValidateRoles(roleManager).Result;

                //    var validateAdminsResult = IdentityDbValidator.ValidateUsersInAdminRole(userManager, roleManager).Result;



                //}

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.Build();
                })
                .UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
