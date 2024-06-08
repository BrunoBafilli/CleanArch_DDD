using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityFramework.Mappings.Order
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Tabela
            builder.ToTable("OrderItem");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.OwnsOne(p => p.Price, pv =>
            {
                pv.Property(x => x.Value)
                    .IsRequired()
                    .HasColumnName("Price")
                    .HasColumnType("DECIMAL(18,2)");
            });

            // Relacionamento
            builder.HasMany(x => x.Products)
                .WithOne(x => x.OrderItem)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
