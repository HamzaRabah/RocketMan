using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RocketMan.Application.Interfaces;
using RocketMan.Application.Services;
using RocketMan.Core.Configurations;
using RocketMan.Core.Interfaces;
using RocketMan.Core.Repositories;
using RocketMan.Core.Repositories.Base;
using RocketMan.Infrastructure.Data;
using RocketMan.Infrastructure.Logging;
using RocketMan.Infrastructure.Repositories;
using RocketMan.Infrastructure.Repositories.Base;
using RocketMan.Infrastructure.Services;
using RocketMan.Web.Interfaces;
using RocketMan.Web.Services;

namespace RocketMan.Web
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
            // rocket man dependencies
            ConfigureRocketManServices(services);


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureRocketManServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<RocketManSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped<ISpaceApiService, SpaceApiService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILaunchRepository, LaunchRepository>();
            services.AddScoped(typeof(IApplicationLogger<>), typeof(ApplicationLogger<>));

            // Add Application Layer
            services.AddScoped<ILaunchService, LaunchService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<ILaunchPageService, LaunchPageService>();
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<RocketManDbContext>(c =>
                c.UseInMemoryDatabase("RocketManDB"));

            //// use real database
        }
    }
}
