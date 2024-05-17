using Microsoft.EntityFrameworkCore;
using MyBookOnlineShop.Models.Models;
using System.Data;

namespace MyBookOnlineShop.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data into category table
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Detective",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "History",
                    DisplayOrder = 3
                }
            );
        }
    }
}
