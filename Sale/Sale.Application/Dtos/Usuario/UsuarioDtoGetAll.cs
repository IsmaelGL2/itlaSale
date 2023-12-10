using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Dtos.Usuario
{
    public class UsuarioDtoGetAll
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
