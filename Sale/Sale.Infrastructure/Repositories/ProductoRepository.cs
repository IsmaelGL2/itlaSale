using Microsoft.EntityFrameworkCore.Internal;
using Sale.Domain.Entities;
using Sale.Domain.Repository;
using Sale.Infrastructure.Context;
using Sale.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Infrastructure.Repositories
{
    public class ProductoRepository : IBaseRepository<Producto>, IProductoRepository
    {
        private readonly SaleContext context;

        public ProductoRepository(SaleContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Producto, bool>> filter)
        {
            return this.context.Producto.Any(filter);
        }

        public void Delete(Producto producto)
        {
            this.context.Producto.Remove(producto);
        }

        public List<Producto> GetProductos()
        {
            var products = (from pt in this.GetProductos()
                            join depto in this.context.Producto on pt.Id equals depto.Id
                            where !pt.Eliminado
                            select new Producto()
                            {

                            }).ToList();
            return products;
        }

        public Producto GetProducto(int id)
        {
            //return this.context.Producto.Find(id);
            return this.GetProductos().SingleOrDefault(pt  => pt.Id == id);
        }

        public void Save(Producto producto)
        {
            this.context.Producto.Add(producto);
        }

        public void Update(Producto producto)
        {
            this.context.Producto.Update(producto);
        }

        public List<Producto> FindAll(Expression<Func<Producto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
