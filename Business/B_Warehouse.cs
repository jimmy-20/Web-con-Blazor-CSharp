using Business.Intefaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Warehouse : ICrud<WarehouseEntity>,IDisposable
    {
        public void AddItem(WarehouseEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbWarehouse.Add(t);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<WarehouseEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbWarehouse.ToList();
            }
        }

        public void UpdateItem(WarehouseEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbWarehouse.Update(t);
                db.SaveChanges();
            }
        }
    }
}
