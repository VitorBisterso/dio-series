using System.Collections.Generic;

namespace dio_series.Interfaces
{
    public interface IRepository<T>
    {
         List<T> ListEntities();
         T GetById(int id);
         void InsertEntity(T entity);
         void RemoveEntity(int id);
         void UpdateEntity(int id, T entity);
         int NextId();
    }
}