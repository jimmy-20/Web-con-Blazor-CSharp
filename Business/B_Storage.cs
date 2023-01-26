using Business.Intefaces;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Storage : ICrud<StorageEntity>,IDisposable
    {
        public void AddItem(StorageEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbStorage.Add(t);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StorageEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbStorage.ToList();
            }
        }

        public IEnumerable<StorageEntity> FindAllItemByWarehouse(string idWarehouse)
        {
            using(var db = new InventoryContext())
            {
                return db.TbStorage.Include(x => x.Product).Include(x => x.Warehouse).Where(s => s.WareHouseId == idWarehouse).ToList();
            }
        }

        public void UpdateItem(StorageEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbStorage.Update(t);
                db.SaveChanges();
            }
        }

        public bool IsExistsProductStorage(StorageEntity s) {
            using (var db = new InventoryContext())
            {
                return db.TbStorage.Any(storage => storage.ProductId == s.ProductId && storage.WareHouseId == s.WareHouseId);
            }
        }
    }
}
