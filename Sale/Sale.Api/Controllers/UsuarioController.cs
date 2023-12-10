using Microsoft.AspNetCore.Mvc;
//using Sale.Domain.Entities;
//using Sale.Domain.Repository;
using Sale.Infrastructure.Interfaces;
using Sale.Api.Models.Modules.Usuario;
using Sale.Domain.Entities;
using Sale.Application.Contracts;
using Sale.Application.Dtos.Usuario;
using Sale.Application.Core;
using Sale.Application.Exceptions;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            var result = this.usuarioService.GetAll();

            if(!result.Success) 
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<UsuarioController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpGet("GetUsuario")]
        public IActionResult Get(int id)
        {
            var result = this.usuarioService.GetById(id);
            //var usuario = this.usuarioRepository.GetEntity(id);
            if (!result.Success)
                return BadRequest(result);
            
            /*if (result == null)
            {
                return NotFound(); // Usuario no encontrado
            }*/

            return Ok(result);
        }


        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioDtoAdd usuarioApp)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result = usuarioService.Save(usuarioApp);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (UsuarioServiceException ssex)
            {

                result.Message = ssex.Message;
                result.Success = false;
            }



            return Ok(result);
        }

        
        [HttpPut(" DeleteUsuario")]
        public IActionResult Delete([FromBody] UsuarioDtoDelete usurioDtoDelete)
        {
            var result = this.usuarioService.Delete(usurioDtoDelete);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        /*[HttpPut(" UpdateUsuario)")]
        public void Put(int id, [FromBody] UsuarioUpdateModel usuarioUpdate)
        {
        }*/
        // DELETE api/<UsuarioController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
