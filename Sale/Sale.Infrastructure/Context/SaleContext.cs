using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public DbSet<Producto> Productos { get; set; }

    }
}
