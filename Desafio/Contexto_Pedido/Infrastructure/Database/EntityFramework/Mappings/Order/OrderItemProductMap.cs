using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityFramework.Mappings.Order
{
    public class OrderItemProductMap : IEntityTypeConfiguration<OrderItemProduct>
    {
        public void Configure(EntityTypeBuilder<OrderItemProduct> builder)
        {
            // Tabela
            builder.ToTable("OrderItemProduct");

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

            // Relacionamento
            builder.HasOne(x => x.OrderItem)
                .WithMany(x => x.OrderItemProducts)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
