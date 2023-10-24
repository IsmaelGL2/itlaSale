using Microsoft.EntityFrameworkCore;
using Sale.Infrastructure.Context;
using Sale.Infrastructure.Interfaces;
using Sale.Infrastructure.Repositories;

namespace Sale.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Agregar dependencia del contexto
            builder.Services.AddDbContext<SaleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SaleContext")));

            //Dependencia de los repositores
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            //Dependencias de los app services
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}