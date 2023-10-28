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
            return this.context.Producto.Any(filter);
        }

        public void Delete(Producto producto)
        {
            this.context.Producto.Remove(producto);
        }

        public List<Producto> GetProductos()
        {
            return this.context.Producto.Where(pt => !pt.Eliminado).ToList();
            //return this.context.productos.ToList();
        }

        public Producto GetProducto(int id)
        {
            return this.context.Producto.Find(id);
        }

        public void Save(Producto producto)
        {
            this.context.Producto.Add(producto);
        }

        public void Update(Producto producto)
        {
            this.context.Producto.Update(producto);
        }
    }
}
