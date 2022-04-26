using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    interface ICrud<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T row);
        void Delete(int id);
        void Update(T row);
        void Save();
    }
}
