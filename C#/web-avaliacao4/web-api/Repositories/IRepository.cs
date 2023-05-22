using System.Collections.Generic;

namespace Repositories
{
    internal interface IRepository <T> where T : class
    {
        List<T> Get();
        T GetById(int id);
        void Add (T entity);
        void Update (int id, T entity);
        void Delete (int id);
    }
}
