using Fixxo.WebShop.ProductService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fixxo.WebShop.ProductService.DataAccess
{
    /// <summary>
    /// Liskov Substitution Principle: DbContext follows the principle, which is provided by Entity FrameWork Core.
    /// </summary>
    public class FixxoDbContext : DbContext
    {
        public FixxoDbContext(DbContextOptions<FixxoDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products => Set<ProductEntity>(); 
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductEntity>()
                        .HasOne(e => e.Category)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
