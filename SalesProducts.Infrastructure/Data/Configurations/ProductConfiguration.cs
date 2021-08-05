using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesProducts.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
         .HasColumnName("ProId");

            builder.Property(e => e.ProDesc)
                   .IsRequired()
                   .HasColumnName("ProDesc")
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(e => e.ProValor)
                  .IsRequired()
                  .HasColumnName("ProValor")
                  .HasColumnType("money");

        }
    }
}
