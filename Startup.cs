using HydroPi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Identity.Core;
//using Microsoft.Extensions.Identity.Stores;
using AspNetCore.Identity.Mongo;
using HydroPi.Services.Identity;
using HydroPi.Services.MongoDb;
using Microsoft.AspNetCore.Authorization;
using Policy;
using HydroPi.Mailing;

namespace HydroPi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HydroPiDatabaseSettings>(
                Configuration.GetSection(nameof(HydroPiDatabaseSettings)));

            // Add Identity
            services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(identity =>
            {
                // other options
                identity.Password.RequireDigit = false;
                identity.Password.RequireLowercase = false;
                identity.Password.RequireNonAlphanumeric = false;
                identity.Password.RequireUppercase = false;
                identity.Password.RequiredLength = 1;
                identity.Password.RequiredUniqueChars = 0;
            },
            mongo =>
            {
                //Bind to the database settings in app config
                var databaseSettings = new HydroPiDatabaseSettings();
                Configuration.GetSection(nameof(HydroPiDatabaseSettings)).Bind(databaseSettings);

                mongo.ConnectionString = databaseSettings.IdentityConnectionString;
                // other options
            });

            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, HasClaimHandler>();

            // Add email sender
            services.AddSingleton<IEmailSender, EmailSender>();

            // Add MongoDb Collection Microservices
            services.AddSingleton<SensorService>();

            services.AddControllersWithViews();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
