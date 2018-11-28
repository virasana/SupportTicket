using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ST.AppServicesLib;
using ST.SharedInterfacesLib;
using ST.SQLServerRepoLib;
using ST.Web.Data;
using ST.Web.Models;
using ST.Web.Services;

namespace ST.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Handle the case where it returns cyclically with an unclosed array! i.e. "[\\\ (unclosed"
            // See also the IgnoreJson attributes on the entities
            // https://stackoverflow.com/questions/48417166/rest-api-returns-bad-array-instead-of-json-object
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            services.AddCors(options => options.AddPolicy("AllowAnyOrigin",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            services.AddTransient<ISTRepo, SQLRepo>();
            services.AddTransient<ISTAppService<ISTRepo>, STAppService<ISTRepo>>();
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            #region Authentication

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SupportTicketCoreAuth")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            #endregion

            services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SupportTicketCoreAuth")
                    ));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ST/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors("AllowAnyOrigin");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ST}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()
                    .Database.Migrate();
                scope.ServiceProvider.GetRequiredService<ISTRepo>().Initialise();

            }

            loggerFactory.AddDebug();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            var logger = loggerFactory.CreateLogger("Default");
            var connString = $"{Environment.GetEnvironmentVariable("CONN_STRING")}";
            logger.Log(LogLevel.Information, $"*** CONN_STRING: '{connString}'");

            
        }
    }
}
