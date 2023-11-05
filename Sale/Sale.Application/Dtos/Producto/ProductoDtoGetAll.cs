using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Dtos.Producto
{
    public class ProductoDtoGetAll
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
