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
using server.Services.Auth;
using server.Repositories.AddressRepo;
using server.Repositories.CartItemRepo;
using server.Repositories.CategoryRepo;
using server.Repositories.OrderRepo;
using server.Repositories.ProductRepo;
using server.Repositories.UserRepo;
// jwt authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            // AppSettings
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddControllers();

            // dependency injections
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // JWT authentication
            string jwtSecret = appSettingsSection.Get<AppSettings>().JwtSecret;
            services.AddSingleton<IAuthManager, AuthManager>();
            services.AddAuthentication
            (
                x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
            .AddJwtBearer
            (
                x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
            );

            // database
            services.AddDbContext<OnlineShopDbContext>
                    (
                        options => options.UseSqlServer
                        (
                            this.Configuration.GetConnectionString("DatabaseConnection")
                        )
                    );

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

            // JWT authentication
            app.UseAuthentication();

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
