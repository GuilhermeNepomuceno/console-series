using System.Collections.Generic;

namespace ConsoleSeries
{
    public interface RepositoryInterface<T>
    {
        List<T> List();
        T GetbyID(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}