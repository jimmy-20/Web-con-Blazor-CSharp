using Business.Intefaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Category : ICrud<CategoryEntity>,IDisposable
    {
        public void AddItem(CategoryEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbCategory.Add(t);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CategoryEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbCategory.ToList();
            }
        }

        public void UpdateItem(CategoryEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbCategory.Update(t);
                db.SaveChanges();
            }
        }
    }
}
