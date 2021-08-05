using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesProducts.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
            .HasColumnName("PedID");

            builder.Property(e => e.PedIva)
                .IsRequired()
                .HasColumnName("PedIVA")
                .IsUnicode(false);

            builder.Property(e => e.PedSubTot)
            .HasColumnName("PedSubTot")
                .IsRequired();

            builder.Property(e => e.PedTotal)
           .HasColumnName("PedTotal")
               .IsRequired();

            builder.Property(e => e.PedVrUnit)
          .HasColumnName("PedVrUnit")
              .IsRequired();

            builder.Property(e => e.PedCant)
          .HasColumnName("PedCant")
              .IsRequired();

            builder.Property(e => e.PedProd)
         .HasColumnName("PedProd")
             .IsRequired();

        
            builder.HasOne(d => d.PedProdNavigation)
                .WithMany(p => p.Pedido)
                .HasForeignKey(d => d.PedProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Producto");

            builder.HasOne(d => d.PedUsuNavigation)
                     .WithMany(p => p.Pedido)
                     .HasForeignKey(d => d.PedUsu)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Pedido_Usuario");
        }
    }
}
