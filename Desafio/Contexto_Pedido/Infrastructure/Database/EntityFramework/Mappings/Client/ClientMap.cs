using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Tabela
            builder.ToTable("Client");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.OwnsOne(u => u.PhoneNumber, pn =>
            {
                pn.Property(x => x.Number)
                    .IsRequired()
                    .HasColumnName("PhoneNumber")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);
            });

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Ignore(x => x.OrdersIds);
        }
    }
}
