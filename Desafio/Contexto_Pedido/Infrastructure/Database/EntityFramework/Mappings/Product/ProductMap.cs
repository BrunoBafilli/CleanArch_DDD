using Domain.Entities;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Database.EntityFramework.Mappings.Product
{
    public class ProductMap : IEntityTypeConfiguration<Domain.Entities.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.Product> builder)
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
        }
    }
}
