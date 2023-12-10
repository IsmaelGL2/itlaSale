using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Dtos.Usuario
{
    public abstract class UsuarioDtoBase 
    {


        public int? IdRol { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public int IdUsuarioCreacion { get; set; }

        public DateTime? EnrollmentDate { get; set; }
    }
}
