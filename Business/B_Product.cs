using Business.Intefaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Product : ICrud<ProductEntity>,IDisposable
    {
        public void AddItem(ProductEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbProduct.Add(t);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ProductEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbProduct.ToList();
            }
        }

        public ProductEntity FindById(string id)
        {
            using (var db = new InventoryContext())
            {
                return db.TbProduct.Find(id);
            }
        }

        public void UpdateItem(ProductEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbProduct.Update(t);
                db.SaveChanges();
            }
        }
    }
}
