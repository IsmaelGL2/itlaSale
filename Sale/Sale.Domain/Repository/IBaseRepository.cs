using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<Producto> GetProductos();
        TEntity GetProducto(int id);
        bool Exists(Expression<Func<Producto, bool>> filter);
    }
}
