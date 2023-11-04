namespace Sale.Api.Models.Modules.Producto
{
    public class GetProductoModel
    {

        public int Id { get; set; }
        public string? Marca { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }

    }
}
