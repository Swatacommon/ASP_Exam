using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task23.Models
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllPhones();
        T Get(int ID);
        T Add(T item);
        T Remove(string id);
        T Update(T item);
    }

}
