using Sale.Domain.Entities;
using Sale.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {

        List<Producto> GetProductosById(int Productoid);

        Producto GetProductoMent(int id);

    }
}
