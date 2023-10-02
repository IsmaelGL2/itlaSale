using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Domain.Repository
{
    public interface IUsuarioRepository
    {
        void Save(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
        List <Usuario> GetUsuarios();
        Usuario GetUsuarios(int id);

    }
}
