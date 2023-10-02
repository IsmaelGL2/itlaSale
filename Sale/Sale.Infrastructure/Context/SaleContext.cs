using Microsoft.EntityFrameworkCore;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Infrastructure.Context
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
