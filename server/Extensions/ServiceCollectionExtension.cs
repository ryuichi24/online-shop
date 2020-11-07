using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using server.DataAccess;
using server.DataAccess.Repositories.AddressRepo;
using server.DataAccess.Repositories.AdminRepo;
using server.DataAccess.Repositories.CartItemRepo;
using server.DataAccess.Repositories.CategoryRepo;
using server.DataAccess.Repositories.OrderItemRepo;
using server.DataAccess.Repositories.OrderRepo;
using server.DataAccess.Repositories.ProductRepo;
using server.DataAccess.Repositories.UserRepo;
using server.Helpers;
using server.Services.Auth;
using server.Services.UserService;
using Services.AddressService;
using Services.AdminService;
using Services.CartItemService;
using Services.CategoryService;
using Services.OrderService;
using Services.ProductService;

namespace server.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static IServiceCollection SetupController(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson
            (
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            return services;
        }

        public static IServiceCollection SetupAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            return services;
        }

        public static IServiceCollection SetupCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy
            (
                builder => builder.WithOrigins(Environment.GetEnvironmentVariable("CLIENT_ORIGIN") ?? "http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            ));

            return services;
        }

        public static IServiceCollection SetupAuthentication(this IServiceCollection services, IConfigurationSection appSettingsSection)
        {
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

            return services;
        }

        public static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineShopDbContext>
                    (
                        options => options.UseSqlServer
                        (
                            configuration.GetConnectionString("DatabaseConnection")
                        )
                    );

            return services;
        }

        public static IServiceCollection SetupSwagger(this IServiceCollection services)
        {
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

            return services;
        }
    }
}
