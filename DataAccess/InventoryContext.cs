using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAccess
{
    public class InventoryContext : DbContext
    {
        public DbSet<CategoryEntity> TbCategory { get; set; }
        public DbSet<ProductEntity> TbProduct { get; set; }
        public DbSet<WarehouseEntity> TbWarehouse { get; set; }
        public DbSet<StorageEntity> TbStorage { get; set; }
        public DbSet<TransactionEntity> TbTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<CategoryEntity>().HasData(LoadCategory());
            modelbuilder.Entity<WarehouseEntity>().HasData(LoadWareHouse());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            if (!option.IsConfigured)
            {
                option.UseSqlServer("Server=(local);Database=Inventory;Integrated Security=true");
            }
        }

        public IEnumerable<CategoryEntity> LoadCategory()
        {
            CategoryEntity[] categories = {new CategoryEntity{
                CategoryId = "AHR",
                CategoryName = "Aseo Hogar"
                },
                new CategoryEntity
                {
                    CategoryId = "ASP",
                    CategoryName = "Aseo Personal"
                },
                new CategoryEntity
                {
                    CategoryId = "HGR",
                    CategoryName =  "Hogar"
                },
                new CategoryEntity
                {
                    CategoryId = "PRF",
                    CategoryName = "Perfumeria"
                },
                new CategoryEntity
                {
                    CategoryId = "SLD",
                    CategoryName = "Salud"
                },
                new CategoryEntity
                {
                    CategoryId = "VDJ",
                    CategoryName = "Videojuegos"
                }
            };  

            return categories;
        }

        public IEnumerable<WarehouseEntity> LoadWareHouse()
        {
            WarehouseEntity[] warehouses =
            {
                new WarehouseEntity{WarehouseId = "N-Bod",Name = "Bodega del Norte", Adress = "7th Floor"},
                new WarehouseEntity{WarehouseId = "S-Bod",Name = "Bodega del Sur", Adress = "Room 1879"},
                new WarehouseEntity{WarehouseId = "E-Bod",Name = "Bodega del Este", Adress = "Suite 63"},
                new WarehouseEntity{WarehouseId = "LP-Bod",Name= "Lote Praderas de Sandino", Adress = "14th Floor"},
                new WarehouseEntity{WarehouseId = "Dinsa-C",Name = "Planta central de Dinsa",Adress = "PO Box 98900"}
            };

            return warehouses;
        }
    }
}
