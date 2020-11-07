using Extensions;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services.Auth;

namespace server.DataAccess
{
    public class OnlineShopDbContext : DbContext
    {
        private readonly IAuthManager _authManager;

        public OnlineShopDbContext(DbContextOptions options, IAuthManager authManager) : base(options)
        {
            this._authManager = authManager;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed(this._authManager);
        }
    }
}