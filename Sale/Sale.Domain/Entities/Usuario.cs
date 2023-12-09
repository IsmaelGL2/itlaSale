using Sale.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public int IdUsuarioCreacion { get; set; }
        public string? Nombre { get; set; }  

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public int? IdRol { get; set; }

        public string? UrlFoto { get; set; }

        public string? NombreFoto { get; set; }

        public string? Clave { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public bool Eliminado { get; set; }
    }
}
