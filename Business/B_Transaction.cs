using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using Business.Intefaces;

namespace Business
{
    public class B_Transaction : ICrud<TransactionEntity>, IDisposable
    {
        public void AddItem(TransactionEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbTransaction.Add(t);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TransactionEntity> FindAllItem()
        {
            using (var db = new InventoryContext())
            {
                return db.TbTransaction.ToList();
            }
        }

        public void UpdateItem(TransactionEntity t)
        {
            using (var db = new InventoryContext())
            {
                db.TbTransaction.Update(t);
                db.SaveChanges();
            }
        }
    }
}
