using Microsoft.EntityFrameworkCore;
using Sale.Domain.Entities;

namespace Sale.Infrastructure.Context
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext>options) : base(options)  
        {
        }

        public DbSet<Menu> Menus { get; set; } 
    }
}
