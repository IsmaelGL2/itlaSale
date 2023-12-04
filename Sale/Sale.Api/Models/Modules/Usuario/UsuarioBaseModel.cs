using Sale.Api.Models.Core;
namespace Sale.Api.Models.Modules.Usuario
{
    public abstract class UsuarioBaseModel : ModelBase
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
    }
}
