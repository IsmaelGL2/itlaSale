using Sale.Domain.Entities;
using Sale.Domain.Repository;
using System.Collections.Generic;
using Sale.Infrastructure.Interfaces;
using System.Linq.Expressions;
using System;
using Sale.Infrastructure.Context;
using System.Linq;

namespace Sale.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SaleContext context;

        public UsuarioRepository(SaleContext context) 
        { 
            this.context = context;
        }
        public Usuario GetUsuario(int Id)
        {
            return this.context.Usuarios.Find(Id);
        }

        public bool Exists(Expression<Func<Usuario, bool>> filter)
        {
            return this.context.Usuarios.Any(filter);
        }

        public List<Usuario> FindAll(Expression<Func<Usuario, bool>> filter)
        {
            return this.context.Usuarios.Where(filter).ToList();
        }


        public Usuario GetEntity(int id)
        {
             return this.context.Usuarios.Find(id);
        }

        public List<Usuario> GetEntities()
        {
            return this.context.Usuarios.ToList();
            //return this.context.Usuarios.Where(st => !st.Deleted).ToList();
        }

        public void Delete(Usuario entity)
        {
            this.context.Remove(entity);
        }

        public void Save(Usuario entity)
        {
            this.context.Add(entity);
        }

        public void Update(Usuario entity)
        {
            this.context.Update(entity);
        }
    }
}
