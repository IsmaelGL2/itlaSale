using Sale.Domain.Entities;
using System.Collections.Generic;

namespace Sale.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List <TEntity> GetEntities();
        TEntity GetEntity(int id);
    }
}
