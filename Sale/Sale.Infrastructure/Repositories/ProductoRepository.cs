using Microsoft.EntityFrameworkCore.Internal;
using Sale.Domain.Entities;
using Sale.Infrastructure.Context;
using Sale.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly SaleContext context;

        public ProductoRepository(SaleContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Producto, bool>> filter)
        {
            return this.context.productos.Any(filter);
        }

        public void Delete(Producto producto)
        {
            this.context.productos.Remove(producto);
        }

        public List<Producto> GetEntities()
        {
            return this.context.productos.Where(pt => !pt.Eliminado).ToList();
        }

        public Producto GetEntity(int id)
        {
            return this.context.productos.Find(id);
        }

        public void Save(Producto producto)
        {
            this.context.productos.Add(producto);
        }

        public void Update(Producto producto)
        {
            this.context.productos.Update(producto);
        }
    }
}
