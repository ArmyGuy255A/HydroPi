using HydroPi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HydroPi.Services.MongoDb;
using Microsoft.AspNetCore.Authorization;
using Policy;
using HydroPi.Mailing;
using Westwind.AspNetCore.LiveReload;
using System.IO;
using Microsoft.Extensions.FileProviders;
using HydroPi.Data;
using Microsoft.AspNetCore.Identity;
using System;
using HydroPi.Data.Contexts;
using HydroPi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HydroPi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment HostEnvironment { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.Configure<HydroPiDatabaseSettings>(
                Configuration.GetSection(nameof(HydroPiDatabaseSettings)));

            var databaseSettings = new HydroPiDatabaseSettings();
                Configuration.GetSection(nameof(HydroPiDatabaseSettings)).Bind(databaseSettings);

            // Add Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(databaseSettings.SQLiteConnectionString));

            services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlite(databaseSettings.SQLiteConnectionString));

            // Add Identity
            services.AddIdentity<HydroPiUser, HydroPiRole>(options =>
                    {
                        options.SignIn.RequireConfirmedEmail = false;
                    }
                )
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentityDbContext>();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            // Add Views
            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                //options. = true;
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            });

            // Add additional layout locations
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.PageViewLocationFormats.Add("/Pages/Shared/Layouts/{0}" + RazorViewEngine.ViewExtension);
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                //options.Cookie.HttpOnly = true;
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                //options.LoginPath = "/Identity/Account/Login";
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                //options.SlidingExpiration = true;
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            if (HostEnvironment.IsDevelopment())
            {
                // Add directory browser
                services.AddDirectoryBrowser();

                // Add developer exception page filter
                services.AddDatabaseDeveloperPageExceptionFilter();
            }

            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, HasClaimHandler>();

            // Add email sender
            services.AddSingleton<IEmailSender, EmailSender>();

            // Add MongoDb Collection Microservices
            services.AddSingleton<DataPointService>();

            // Add hot reloading
            services.AddLiveReload(config =>
            {
                config.LiveReloadEnabled = true;
                //config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath, ".."));
            });

            services.AddControllersWithViews();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable live reload middleware
            app.UseLiveReload();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    env.WebRootPath),
                    RequestPath = "/wwwroot"
            });

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
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
