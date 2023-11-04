using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Sale.Api.Models.Modules.Producto;
using Sale.Domain.Entities;
using Sale.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpGet("GetProductos")]
        public IActionResult Get()
        {

            var productos = this.productoRepository.GetEntities()
                .Select(pt =>
                new GetProductoModel()
                {
                    Id = pt.Id,
                    Marca = pt.Marca,
                    FechaRegistro = pt.FechaRegistro,
                    FechaMod = pt.FechaMod,
                    IdUsuarioMod = pt.IdUsuarioMod
                });

            return Ok(productos);

        }

        [HttpGet("GetProducto")]
        public IActionResult Get(int id)
        {

            var producto = this.productoRepository.GetEntity(id);

            GetProductoModel productoModel = new GetProductoModel()
            {
                Id = producto.Id,
                Marca = producto.Marca,
                FechaRegistro = producto.FechaRegistro,
                FechaMod = producto.FechaMod,
                IdUsuarioMod = producto.IdUsuarioMod
            };

            return Ok(productoModel);

        }

        //[HttpGet("{id}")]
        //public Producto Get(int id)
        //{
        //    return this.productoRepository.GetEntity(id);
        //}

        [HttpPost("SaveProducto")]
        public IActionResult Post([FromBody] ProductoAppModel productoApp)
        {
            this.productoRepository.Update(new Producto() { 
            
                FechaRegistro = productoApp.ChangeDate,
                IdUsuarioCreacion = productoApp.ChangeUser,
                Marca = productoApp.Marca,
                CodigoBarra = productoApp.CodigoBarra

            });
            return Ok();
        }

        [HttpPut("UpdateStudent")]
        public IActionResult Put([FromBody] ProductoUpdateModel productoUpdate)
        {

            this.productoRepository.Save(new Producto()
            {

                FechaMod = productoUpdate.ChangeDate,
                IdUsuarioMod = productoUpdate.ChangeUser,
                Marca = productoUpdate.Marca,
                CodigoBarra = productoUpdate.CodigoBarra,
                Id = productoUpdate.Id

            });

            return Ok();
        }

    }
}
