

using System;
using Sale.Application.Dtos.Base;

namespace Sale.Application.Dtos.Producto
{
    public class ProductoDtoRemove : DtoBase
    {
        public int Id { get; set; }
        public bool Eliminado { get; set; }
    }
}
