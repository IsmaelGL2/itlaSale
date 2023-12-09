using Microsoft.Extensions.DependencyInjection;
using Sale.Application.Contracts;
using Sale.Application.Services;
using Sale.Domain.Entities;
using Sale.Infrastructure.Interfaces;
using Sale.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.loc.Dependencies
{
    public static class UsuarioDependency
    {
        public static void AddUsuarioDependency(this IServiceCollection service)
        {
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddTransient<IUsuarioService, UsuarioService>();
        }
    }
}
