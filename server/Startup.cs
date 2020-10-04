using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
// swagger
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
// database
using server.DataAccess;
using Microsoft.EntityFrameworkCore;
using server.Repositories.AdminRepo;
using server.Helpers;

namespace server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // dependency injections
            services.AddScoped<AdminRepository>();

            // database
            services.AddDbContext<OnlineShopDbContext>
            (
                options => options.UseSqlServer
                (
                    this.Configuration.GetConnectionString("DatabaseConnection")
                )
            );

             // AppSettings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // swagger
            services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Online Shop API" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // swagger
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shop API"));
        }
    }
}
