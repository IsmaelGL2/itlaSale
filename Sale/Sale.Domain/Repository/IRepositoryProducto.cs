using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Domain.Repository
{
    internal interface IRepositoryProducto
    {
        void Save(Producto products);
        void Update(Producto products);
        void Delete(Producto products);
        List<Producto> GetProducts();
        Producto GetById(int id);
    }
}
