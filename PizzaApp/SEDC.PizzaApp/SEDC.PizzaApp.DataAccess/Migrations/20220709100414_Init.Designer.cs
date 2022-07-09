﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess.Data;

#nullable disable

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    [Migration("20220709100414_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDelivered = true,
                            Location = "Store1",
                            PaymentMethod = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDelivered = false,
                            Location = "Store2",
                            PaymentMethod = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOnPromotion = true,
                            Name = "Cappricioza",
                            PizzaSize = 0,
                            Price = 0.0
                        },
                        new
                        {
                            Id = 2,
                            IsOnPromotion = false,
                            Name = "Pepperoni",
                            PizzaSize = 0,
                            Price = 0.0
                        },
                        new
                        {
                            Id = 3,
                            IsOnPromotion = false,
                            Name = "Margarita",
                            PizzaSize = 0,
                            Price = 0.0
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            PizzaId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            PizzaId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bob Street 22",
                            FirstName = "Bob",
                            LastName = "Bobsky"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Wayne Street 33",
                            FirstName = "Jill",
                            LastName = "Wayne"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
