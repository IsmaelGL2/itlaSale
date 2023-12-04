namespace Sale.Api.Models.Modules.Usuario
{
    public class UsuarioUpdateModel : UsuarioBaseModel
    {
        public int Id { get; set; } 

        public DateTime? FechaRegistro { get; set; }

        public int IdUsuarioMod { get; set; }
        public DateTime FechaMod { get; set; }
        

    }
}
