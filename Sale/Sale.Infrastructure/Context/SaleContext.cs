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

        public DbSet<Producto> productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C6MC1E9;Database=Sales;User ID=Ismael;Password=Rapido.12345;MultipleActiveResultSets=true",
                sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
        }
    }
}
