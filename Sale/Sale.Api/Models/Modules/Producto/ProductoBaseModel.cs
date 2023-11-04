using Sale.Api.Models.Core;

namespace Sale.Api.Models.Modules.Producto
{
    public abstract class ProductoBaseModel : ModelBase
    {

        public string? Marca { get; set; }
        public string? CodigoBarra { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
