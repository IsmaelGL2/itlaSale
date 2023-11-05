

using Sale.Application.Dtos.Base;

namespace Sale.Application.Dtos.Producto
{
    public abstract class ProductoDtoBase : DtoBase
    {
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
    }
}
