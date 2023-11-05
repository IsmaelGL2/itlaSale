using Sale.Application.Core;
using Sale.Application.Dtos.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Contracts
{
    public interface IProductoService : IBaseServices<ProductoDtoAdd,ProductoDtoUpdate,ProductoDtoRemove>
    {
    }
}
