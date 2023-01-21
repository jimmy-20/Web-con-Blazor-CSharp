﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("TbCategory");

                    b.HasData(
                        new
                        {
                            CategoryId = "AHR",
                            CategoryName = "Aseo Hogar"
                        },
                        new
                        {
                            CategoryId = "ASP",
                            CategoryName = "Aseo Personal"
                        },
                        new
                        {
                            CategoryId = "HGR",
                            CategoryName = "Hogar"
                        },
                        new
                        {
                            CategoryId = "PRF",
                            CategoryName = "Perfumeria"
                        },
                        new
                        {
                            CategoryId = "SLD",
                            CategoryName = "Salud"
                        },
                        new
                        {
                            CategoryId = "VDJ",
                            CategoryName = "Videojuegos"
                        });
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TbProduct");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.Property<string>("StorageId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("WareHouseId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("TbStorage");
                });

            modelBuilder.Entity("Entities.TransactionEntity", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StorageId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isInput")
                        .HasColumnType("bit");

                    b.HasKey("TransactionId");

                    b.HasIndex("StorageId");

                    b.ToTable("TbTransaction");
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Adress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WarehouseId");

                    b.ToTable("TbWarehouse");

                    b.HasData(
                        new
                        {
                            WarehouseId = "N-Bod",
                            Adress = "7th Floor",
                            Name = "Bodega del Norte"
                        },
                        new
                        {
                            WarehouseId = "S-Bod",
                            Adress = "Room 1879",
                            Name = "Bodega del Sur"
                        },
                        new
                        {
                            WarehouseId = "E-Bod",
                            Adress = "Suite 63",
                            Name = "Bodega del Este"
                        },
                        new
                        {
                            WarehouseId = "LP-Bod",
                            Adress = "14th Floor",
                            Name = "Lote Praderas de Sandino"
                        },
                        new
                        {
                            WarehouseId = "Dinsa-C",
                            Adress = "PO Box 98900",
                            Name = "Planta central de Dinsa"
                        });
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.HasOne("Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.HasOne("Entities.ProductEntity", "Product")
                        .WithMany("Storage")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.WarehouseEntity", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Entities.TransactionEntity", b =>
                {
                    b.HasOne("Entities.StorageEntity", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
