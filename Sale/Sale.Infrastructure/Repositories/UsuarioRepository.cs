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

        
    }

}
