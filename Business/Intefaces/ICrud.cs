using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Intefaces
{
    public interface ICrud<T>
    {
        void AddItem(T t);
        void UpdateItem(T t);
        public IEnumerable<T> FindAllItem();
    }
}
