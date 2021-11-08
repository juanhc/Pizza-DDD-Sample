﻿// <auto-generated />
using System;
using CharlaDDD.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CharlaDDD.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaOrdersDbContext))]
    [Migration("20211108211410_Add_DoughTypeName")]
    partial class Add_DoughTypeName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.Pizza.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("_basePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.Pizza.PizzaIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredient");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoughType")
                        .HasColumnType("int");

                    b.Property<string>("DoughTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.HasIndex("PizzaOrderId");

                    b.ToTable("PizzaOrderItem");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.Pizza.PizzaIngredient", b =>
                {
                    b.HasOne("CharlaDDD.Domain.Aggregates.Pizza.Pizza", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrder", b =>
                {
                    b.OwnsOne("CharlaDDD.Domain.Aggregates.PizzaOrder.Receiver", "Receiver", b1 =>
                        {
                            b1.Property<int>("PizzaOrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PizzaOrderId");

                            b1.ToTable("PizzaOrders");

                            b1.WithOwner()
                                .HasForeignKey("PizzaOrderId");
                        });

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrderItem", b =>
                {
                    b.HasOne("CharlaDDD.Domain.Aggregates.Pizza.Pizza", null)
                        .WithOne()
                        .HasForeignKey("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrderItem", "PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("PizzaOrderId");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.Pizza.Pizza", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("CharlaDDD.Domain.Aggregates.PizzaOrder.PizzaOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
