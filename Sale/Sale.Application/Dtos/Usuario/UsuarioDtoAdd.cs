

using Microsoft.Extensions.Configuration;
using System;

namespace Sale.Application.Dtos.Usuario
{
    public class UsuarioDtoAdd : UsuarioDtoBase
    {
        public DateTime? EnrollmentDate { get; set; }
        
    }
}
