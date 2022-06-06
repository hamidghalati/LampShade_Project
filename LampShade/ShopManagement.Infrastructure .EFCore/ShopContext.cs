using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure_.EFCore.Mapping;

namespace ShopManagement.Infrastructure_.EFCore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected ShopContext(DbSet<ProductCategory> productCategories)
        {
            ProductCategories = productCategories;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
