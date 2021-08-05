using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesProducts.Core.Entities;

namespace SalesProducts.Infrastructure.Data
{
    public partial class SalesProductsContext : DbContext
    {
        public SalesProductsContext()
        {
        }

        public SalesProductsContext(DbContextOptions<SalesProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
    
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
