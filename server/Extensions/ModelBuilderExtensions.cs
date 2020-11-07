using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services.Auth;

namespace Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, IAuthManager authManager)
        {
            modelBuilder.Entity<Admin>().HasData
            (
                new Admin
                {
                    AdminId = 1,
                    Name = "admin",
                    Email = "admin@example.com",
                    Password = authManager.EncryptPassword("admin"),
                    Phone = "1234567890"
                }
            );

            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    UserId = 1,
                    FirstName = "Ryuichi",
                    LastName = "Nishi",
                    Email = "ryuichi@example.com",
                    Password = authManager.EncryptPassword("1234567"),
                    Phone = "0123456789"
                }
            );

            modelBuilder.Entity<Category>().HasData
            (
                new Category { Name = "camera", CategoryId = 1 },
                new Category { Name = "watch", CategoryId = 2 },
                new Category { Name = "glasses", CategoryId = 3 }
            );

            modelBuilder.Entity<Product>().HasData
            (
                new Product
                {
                    ProductId = 1,
                    Name = "Instamatic 133 Camera Kodak",
                    Price = 45,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.",
                    Inventory = 10,
                    Image = "https://images.unsplash.com/photo-1496335506811-1e4380d47d18?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Minimum design watch (white)",
                    Price = 60,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.",
                    Inventory = 5,
                    Image = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1289&q=80",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Quite simple sunglasses",
                    Price = 30,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.",
                    Inventory = 4,
                    Image = "https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=80",
                    CategoryId = 3
                }
            );
        }
    }
}