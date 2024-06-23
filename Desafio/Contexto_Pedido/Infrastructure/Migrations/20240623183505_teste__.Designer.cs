﻿// <auto-generated />
using System;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240623183505_teste__")]
    partial class teste__
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.DomainEvents.Client.Events.CreateClientEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OcurredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("CreateClientEvent");
                });

            modelBuilder.Entity("Domain.Entities.Client.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasMaxLength(80)
                        .HasColumnType("DATETIME")
                        .HasColumnName("OrderDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderItemProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.ToTable("OrderItemProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.DomainEvents.Client.Events.CreateClientEvent", b =>
                {
                    b.HasOne("Domain.Entities.Client.Client", null)
                        .WithMany("CreateClientEvents")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Domain.Entities.Client.Client", b =>
                {
                    b.OwnsOne("Domain.Entities.Client.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderItem", b =>
                {
                    b.HasOne("Domain.Entities.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Entities.Order.ValueObject.Price", "Price", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasColumnType("DECIMAL(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("Order");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderItemProduct", b =>
                {
                    b.HasOne("Domain.Entities.Order.OrderItem", "OrderItem")
                        .WithMany("OrderItemProducts")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Entities.Order.ValueObject.Price", "Price", b1 =>
                        {
                            b1.Property<int>("OrderItemProductId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasMaxLength(80)
                                .HasColumnType("DECIMAL(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("OrderItemProductId");

                            b1.ToTable("OrderItemProduct");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemProductId");
                        });

                    b.Navigation("OrderItem");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Product.Product", b =>
                {
                    b.OwnsOne("Domain.Entities.Order.ValueObject.Stock", "Stock", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasMaxLength(80)
                                .HasColumnType("INT")
                                .HasColumnName("Stock");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Domain.Entities.Order.ValueObject.Price", "Price", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasMaxLength(80)
                                .HasColumnType("DECIMAL(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Stock")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Client.Client", b =>
                {
                    b.Navigation("CreateClientEvents");
                });

            modelBuilder.Entity("Domain.Entities.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderItem", b =>
                {
                    b.Navigation("OrderItemProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
