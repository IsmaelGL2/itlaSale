namespace Sale.Api.Models.Modules.Usuario
{
    public class GetusuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
