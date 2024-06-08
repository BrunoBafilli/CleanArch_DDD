using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Order;

namespace Infrastructure.Database.EntityFramework.Mappings.Order
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Tabela
            builder.ToTable("Product");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            // Propriedades
            builder.OwnsOne(p => p.Price, pv =>
            {
                pv.Property(x => x.Value)
                    .IsRequired()
                    .HasColumnName("Price")
                    .HasColumnType("DECIMAL(18,2)")
                    .HasMaxLength(80);
            });

            builder.OwnsOne(s => s.Stock, sk =>
            {
                sk.Property(x => x.Quantity)
                    .IsRequired()
                    .HasColumnName("Stock")
                    .HasColumnType("INT")
                    .HasMaxLength(80);
            });

            //Relacionamento
            builder.HasOne(x => x.OrderItem)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
