using System.Collections.Generic;

namespace TobaSort.Interfaces
{
    public interface IContext<T>
    {
        List<T> GetAll();
        T GetById(object id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(object id);
    }
}