using Sale.Domain.Entities;
using Sale.Domain.Repository;
using System.Collections.Generic;

namespace Sale.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        
        //Aqui van los metodos exclusivos de la entidad
        //List<Usuario> GetUsuarioById(int id);
    }
}
