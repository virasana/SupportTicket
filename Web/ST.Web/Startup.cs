using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ST.AppServicesLib;
using ST.SharedInterfacesLib;
using ST.SQLServerRepoLib;
using ST.UsersRepoLib;
using ST.UserServiceLib;
using ST.Web.Services;

namespace ST.Web
{
    public class Startup
    {
        private readonly string _connectionStringAuth;
        private readonly string _connectionStringSupportTicket;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionStringSupportTicket = Environment.GetEnvironmentVariable(App.Constants.ConnStringSupportTicket);
            _connectionStringAuth = Environment.GetEnvironmentVariable(App.Constants.ConnStringAuth);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureJWT(services);

            ConfigureJson(services);

            ConfigureCors(services);

            ConfigureAppDI(services);

            services.AddDbContext<UsersDbContext>(c =>
                c.UseSqlServer(Environment.GetEnvironmentVariable(App.Constants.ConnStringAuth)));

            services.AddDbContext<SupportTicketDbContext>(c =>
                c.UseSqlServer(Environment.GetEnvironmentVariable(App.Constants.ConnStringSupportTicket)));

            services.AddMvc();


        }

        private void ConfigureJWT(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable(App.Constants.JWTSecret));
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAnyOrigin",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
        }

        private static void ConfigureJson(IServiceCollection services)
        {
            // Handle the case where it returns cyclically with an unclosed array! i.e. "[\\\ (unclosed"
            // See also the IgnoreJson attributes on the entities
            // https://stackoverflow.com/questions/48417166/rest-api-returns-bad-array-instead-of-json-object
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );
        }

        private static void ConfigureAppDI(IServiceCollection services)
        {
            services.AddScoped<ISTRepo, SQLRepo>();
            services.AddScoped<ISTUsersRepo, UsersRepo>();
            services.AddScoped<ISTAppService<ISTRepo>, STAppService<ISTRepo>>();
            services.AddScoped<IUserService<ISTUsersRepo>, UserService<ISTUsersRepo>>();
            services.AddScoped<ISTEnvironment, STEnvironment>();
        }

        private static void ConfigureApplicationCookie(IServiceCollection services)
        {
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ConfigureLogging(loggerFactory);

            ConfigureExceptionHandling(app, env);

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors("AllowAnyOrigin");

            ConfigureRoutes(app);

            InitialiseServices(app);
        }

        private void InitialiseServices(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ISTRepo>().Initialise(_connectionStringSupportTicket);
                scope.ServiceProvider.GetRequiredService<ISTUsersRepo>();
            }
        }

        private static void ConfigureRoutes(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ST}/{action=Index}/{id?}");
            });
        }

        private static void ConfigureExceptionHandling(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ST/Error");
            }
        }

        private void ConfigureLogging(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            var logger = loggerFactory.CreateLogger("Default");
        }
    }
}
