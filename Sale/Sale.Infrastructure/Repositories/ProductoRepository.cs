using Microsoft.EntityFrameworkCore.Internal;
using Sale.Domain.Entities;
using Sale.Domain.Repository;
using Sale.Infrastructure.Context;
using Sale.Infrastructure.Core;
using Sale.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto> , IProductoRepository
    {
        private readonly SaleContext context;

        public ProductoRepository(SaleContext context): base(context) 
        {
            this.context = context;
        }

        public override void Save(Producto entity)
        {
            context.Productos.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Producto entity)
        {
            var productoToUpdate = base.GetEntity(entity.Id);

            productoToUpdate.CodigoBarra = entity.CodigoBarra;
            productoToUpdate.Marca = entity.Marca;
            productoToUpdate.Descripcion = entity.Descripcion;
            productoToUpdate.IdCategoria = entity.IdCategoria;
            productoToUpdate.Stock = entity.Stock;
            productoToUpdate.UrlImagen = entity.UrlImagen;
            productoToUpdate.NombreImagen = entity.NombreImagen;
            productoToUpdate.Precio = entity.Precio;
            productoToUpdate.FechaMod = entity.FechaMod;
            productoToUpdate.Id = entity.Id;

            context.Productos.Update(productoToUpdate);
            context.SaveChanges();

        }

        public Producto GetProductoMent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductosById(int Productoid)
        {
            throw new NotImplementedException();
        }

    }
}
