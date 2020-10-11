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
using server.Helpers;
using server.Services.Auth;
using server.DataAccess.Repositories.AdminRepo;
using server.DataAccess.Repositories.AddressRepo;
using server.DataAccess.Repositories.CartItemRepo;
using server.DataAccess.Repositories.CategoryRepo;
using server.DataAccess.Repositories.OrderRepo;
using server.DataAccess.Repositories.ProductRepo;
using server.DataAccess.Repositories.UserRepo;
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

            services.AddControllers().AddNewtonsoftJson
            (
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // dependency injections
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // CORS
            services.AddCors(options => options.AddDefaultPolicy
            (
                builder => builder.WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            ));

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
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Online Shop API" });

                opt.AddSecurityDefinition
                (
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = @"Enter 'Bearer <token>'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    }
                );

                opt.AddSecurityRequirement
                (
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }

                    }
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS
            app.UseCors();

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
