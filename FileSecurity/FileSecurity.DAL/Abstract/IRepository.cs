using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetItem(object key);
        T GetItem(T item);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        void Remove(object key);
    }
}
