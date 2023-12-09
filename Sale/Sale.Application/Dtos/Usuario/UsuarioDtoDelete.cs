using System;
using System.Collections.Generic;
using System.Text;
using Sale.Application.Dtos.Base;

namespace Sale.Application.Dtos.Usuario
{
    public class UsuarioDtoDelete : DtoBase
    {
        public int? IdRol { get; set; }
        public int? IdUsuarioElimino { get; set; }


    }
}
