using Microsoft.AspNetCore.Mvc;
//using Sale.Domain.Entities;
//using Sale.Domain.Repository;
using Sale.Infrastructure.Interfaces;
using Sale.Api.Models.Modules.Usuario;
using Sale.Domain.Entities;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            var usuarios = this.usuarioRepository.GetEntities()
                                                 .Select(st => 
                                                          new GetusuarioModel ()
                                                          {
                                                              FechaRegistro = st.FechaRegistro,
                                                              Correo = st.Correo,
                                                              Telefono = st.Telefono,
                                                              Nombre = st.Nombre,
                                                              UsuarioId = st.Id

                                                          });


            return Ok(usuarios);
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
            var usuario = this.usuarioRepository.GetEntity(id);

            if (usuario == null)
            {
                return NotFound(); // Usuario no encontrado
            }

            GetusuarioModel usuarioModel = new GetusuarioModel() 
            {
                FechaRegistro = usuario.FechaRegistro,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Nombre = usuario.Nombre,
                UsuarioId = usuario.Id
            };
    

            return Ok(usuarioModel);
        }


        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioAppModel usuarioApp)
        {
            if (usuarioApp == null)
            {
                return BadRequest("Los datos del usuario no pueden estar vacíos.");
            }

            this.usuarioRepository.Save(new Usuario()
            {
                FechaRegistro = usuarioApp.FechaMod,
                Correo = usuarioApp.Correo,
                Telefono = usuarioApp.Telefono,
                Nombre = usuarioApp.Nombre,
                Eliminado = false,
                IdUsuarioCreacion = usuarioApp.ChangeUser

            }) ;

            return Ok();
        }

        
        [HttpPut(" UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateModel usuarioUpdate)
        {
            this.usuarioRepository.Update(new Usuario()
            {
                FechaRegistro = usuarioUpdate.FechaRegistro,
                Correo = usuarioUpdate.Correo,
                Telefono = usuarioUpdate.Telefono,
                Nombre = usuarioUpdate.Nombre,
                Id = usuarioUpdate.Id

            });

            return Ok();
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
