using Sale.Domain.Entities;
using Sale.Domain.Repository;
using System.Collections.Generic;
using Sale.Infrastructure.Interfaces;
using System.Linq.Expressions;
using System;
using Sale.Infrastructure.Context;
using System.Linq;
using Sale.Infrastructure.Core;

namespace Sale.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SaleContext context;

        public UsuarioRepository(SaleContext context) : base(context)
        {
            this.context = context;
        }

        public override void Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChanges();
        }
        public override void Update(Usuario entity)
        {
            var usuarioToUpdate = base.GetEntity(entity.Id);

            usuarioToUpdate.Nombre = entity.Nombre;
            usuarioToUpdate.Correo = entity.Correo;
            usuarioToUpdate.Telefono = entity.Telefono;
            usuarioToUpdate.FechaRegistro = entity.FechaRegistro;

            context.Usuarios.Update(usuarioToUpdate);
            context.SaveChanges();
        }
    }

}
