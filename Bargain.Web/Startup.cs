using Bargain.Repositories;
using Bargain.Repositories.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bargain.Repositories.Interfaces;
using Bargain.Services;
using Bargain.Services.Interfaces;
using Bargain.Web.Helpers;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace Bargain.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            
            if (_env.IsDevelopment()) 
                services.AddCustomSwagger();
            
            services.AddControllersWithViews();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            
            // Database Connection String
            if (_env.IsDevelopment())
            {
                // In Memory
                services.AddDbContext<AppDbContext>(opt => 
                    opt.UseInMemoryDatabase("AppDbContext"));
            }
            else
            {
                // Sql Server
                services.AddDbContext<AppDbContext>(opt => 
                    opt.UseSqlServer(Configuration.GetConnectionString("SqlDbContext")));
            }
            
            // Dependency Injection Modules
            ConfigureDependencyInjection(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ISaveRepository, SaveRepository>();
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IMoviesService, MoviesService>();
        }
    }
}
