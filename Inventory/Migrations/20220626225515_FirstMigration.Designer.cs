﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20220626225515_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("0eeb418b-50e1-424d-a81d-59f8d74d99e0"),
                            CategoryName = "Categoria 1"
                        },
                        new
                        {
                            CategoryId = new Guid("98559254-e77e-4e45-9395-9793bea1bbae"),
                            CategoryName = "Categoria 2"
                        },
                        new
                        {
                            CategoryId = new Guid("efc6dfcf-8cb4-46b7-a051-b36e822be152"),
                            CategoryName = "Categoria 3"
                        },
                        new
                        {
                            CategoryId = new Guid("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"),
                            CategoryName = "Categoria 4"
                        });
                });

            modelBuilder.Entity("Entities.InputOutputEntity", b =>
                {
                    b.Property<Guid>("InOutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InOutDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInput")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("StorageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InOutId");

                    b.HasIndex("StorageId");

                    b.ToTable("InputsOuputs", (string)null);
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalQuantity")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("6f453819-bc23-4085-a050-c419130bc878"),
                            CategoryId = new Guid("0eeb418b-50e1-424d-a81d-59f8d74d99e0"),
                            ProductDescription = "Producto 1",
                            ProductName = "Producto 1",
                            TotalQuantity = 10
                        },
                        new
                        {
                            ProductId = new Guid("dd139eee-bf3b-4d81-a8bb-21e989dee8cb"),
                            CategoryId = new Guid("98559254-e77e-4e45-9395-9793bea1bbae"),
                            ProductDescription = "Producto 2",
                            ProductName = "Producto 2",
                            TotalQuantity = 20
                        },
                        new
                        {
                            ProductId = new Guid("e3a0d31c-886f-4c72-877e-c08f2a484ffe"),
                            CategoryId = new Guid("efc6dfcf-8cb4-46b7-a051-b36e822be152"),
                            ProductDescription = "Producto 3",
                            ProductName = "Producto 3",
                            TotalQuantity = 30
                        },
                        new
                        {
                            ProductId = new Guid("362d3236-eed2-4602-8256-036ee828c3b2"),
                            CategoryId = new Guid("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"),
                            ProductDescription = "Producto 4",
                            ProductName = "Producto 4",
                            TotalQuantity = 40
                        });
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.Property<Guid>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartialQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Storages", (string)null);
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Property<Guid>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WarehouseAddress")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses", (string)null);

                    b.HasData(
                        new
                        {
                            WarehouseId = new Guid("c4d478b2-9227-43e9-b106-94e25fb4a75b"),
                            WarehouseAddress = "Direccion 1",
                            WarehouseName = "Bodega 1"
                        },
                        new
                        {
                            WarehouseId = new Guid("e236cc76-4c0b-460a-9333-c1aa2bb5d4c9"),
                            WarehouseAddress = "Direccion 2",
                            WarehouseName = "Bodega 2"
                        },
                        new
                        {
                            WarehouseId = new Guid("82549001-6a77-4885-ae6e-d701c5277b48"),
                            WarehouseAddress = "Direccion 3",
                            WarehouseName = "Bodega 3"
                        },
                        new
                        {
                            WarehouseId = new Guid("1ae7f481-1589-4d1c-883e-b1e7252bebaa"),
                            WarehouseAddress = "Direccion 4",
                            WarehouseName = "Bodega 4"
                        });
                });

            modelBuilder.Entity("Entities.InputOutputEntity", b =>
                {
                    b.HasOne("Entities.StorageEntity", "Storage")
                        .WithMany("InputOutputs")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.HasOne("Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.HasOne("Entities.ProductEntity", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.WarehouseEntity", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.Navigation("InputOutputs");
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
