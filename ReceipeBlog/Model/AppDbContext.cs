

using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ReceipeBlog.Model
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<FoodReceipe> FoodReceipes { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<FoodReceipeIngredient> FoodReceipeIngredients{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodReceipeIngredient>().HasKey(r1 => new { r1.FoodReceipeId, r1.IngredientId });

            modelBuilder.Entity<FoodReceipeIngredient>().HasOne(r1 =>r1.FoodReceipe).
                WithMany(r =>r.FoodReceipeIngredients).HasForeignKey(ri => ri.FoodReceipeId);

            modelBuilder.Entity<FoodReceipeIngredient>().HasOne(r1 => r1.Ingredients).
                WithMany(r => r.FoodReceipeIngredients).HasForeignKey(ri => ri.IngredientId);
        }
    }
}