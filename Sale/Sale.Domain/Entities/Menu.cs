using Sale.Domain.Core;


namespace Sale.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string? descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }

    }
}
