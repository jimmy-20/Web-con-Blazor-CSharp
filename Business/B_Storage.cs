using Business.Intefaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Storage : ICrud<StorageEntity>
    {
        public void AddItem(StorageEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbStorage.Add(t);
                db.SaveChanges();
            }
        }

        public IEnumerable<StorageEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbStorage.ToList();
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
    }
}
