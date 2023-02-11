using Foodies.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Inventory.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Nutrition> Nutritions { get; set; } = null!;
        public DbSet<FoodNutrition> FoodNutritions { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodNutrition>().HasKey(f => new { f.FoodId, f.NutritionId });
            
            modelBuilder.Entity<FoodNutrition>()
                .HasOne(ft => ft.Food)
                .WithMany(f => f.FoodNutritions)
                .HasForeignKey(ft => ft.FoodId);

            modelBuilder.Entity<FoodNutrition>()
                .HasOne(ft => ft.Nutrition)
                .WithMany(n => n.FoodNutritions)
                .HasForeignKey(ft => ft.NutritionId);

        }

    }
}
