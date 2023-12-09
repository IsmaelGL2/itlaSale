using Sale.Application.Core;
using Sale.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Contracts
{
    public interface IUsuarioService : IBaseServices<UsuarioDtoAdd, UsuarioDtoUpdate, UsuarioDtoDelete>
    {

    }
}
