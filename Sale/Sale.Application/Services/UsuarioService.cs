using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sale.Application.Contracts;
using Sale.Application.Core;
using Sale.Application.Dtos.Usuario;
using Sale.Application.Response;
using Sale.Domain.Entities;
using Sale.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Sale.Application.Exceptions;



namespace Sale.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;
        private readonly IConfiguration configuration;


        public UsuarioService(IUsuarioRepository usuarioReposiroty,
                                            ILogger<UsuarioService> logger, 
                                                    IConfiguration configuration) 
        { 
         
            this.usuarioRepository = usuarioReposiroty;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServicesResult GetAll()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var usuarios = this.usuarioRepository.GetEntities()
                                                 .Select(st =>
                                                          new UsuarioDtoGetAll()
                                                          {
                                                              FechaRegistro = st.FechaRegistro,
                                                              Correo = st.Correo,
                                                              Telefono = st.Telefono,
                                                              Nombre = st.Nombre,
                                                              UsuarioId = st.Id

                                                          });
                result.Data = usuarios;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo los usuarios. ";
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }

        public ServicesResult Delete(UsuarioDtoDelete dtoDelete)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    IdRol = dtoDelete.IdRol,
                    IdUsuarioElimino = dtoDelete.IdUsuarioElimino
                    
                };
                this.usuarioRepository.Delete(usuario);

                result.Message = "Usuario eliminado";
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = $"Error eliminando los usuarios. ";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult Save(UsuarioDtoAdd dtoAdd)
        {
            //ServicesResult result = new ServicesResult();
            UsuarioResponse result = new UsuarioResponse();
            try
            {
                //Validaciones
                if (string.IsNullOrEmpty(dtoAdd.Nombre))
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:estudianteNombreRequerido"]);


                if (dtoAdd.Nombre.Length > 50)
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:estudianteNombreLongitud"]);

                if (!dtoAdd.EnrollmentDate.HasValue)
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:estudianteEnrollmentDateRequerido"]);


                Usuario usuario = new Usuario()
                {
                    FechaRegistro = dtoAdd.FechaMod,
                    EnrollmentDate = dtoAdd.EnrollmentDate,
                    Nombre = dtoAdd.Nombre
                };
                this.usuarioRepository.Save(usuario);

                result.Message = "Usuario creado de manera exitosa";
                //result.UsuarioId = new usuario.IdRol;
                
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error guardando los usuarios. ";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetById(int Id)
        {
            ServicesResult result = new ServicesResult();
            try 
            {
                var usuario = this.usuarioRepository.GetEntity(Id);

                UsuarioDtoGetAll usuarioModel = new UsuarioDtoGetAll()
                {
                    FechaRegistro = usuario.FechaRegistro,
                    Correo = usuario.Correo,
                    Telefono = usuario.Telefono,
                    Nombre = usuario.Nombre,
                    UsuarioId = usuario.Id
                };
                result.Data = usuarioModel;
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = $"Error obteniendo los usuarios. ";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        
        public ServicesResult Update(UsuarioDtoUpdate dtoUpdate)
        {
            ServicesResult result = new ServicesResult();
            try
            {

                // Validaciones //

                if (string.IsNullOrEmpty(dtoUpdate.Nombre))
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:usuarioNombreRequerido"]);


                if (dtoUpdate.Nombre.Length > 50)
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:usuarioNombreLongitud"]);


                if (!dtoUpdate.EnrollmentDate.HasValue)
                    throw new UsuarioServiceException(this.configuration["MensajeValidaciones:usuarioEnrollmentDateRequerido"]);

                Usuario usuario = new Usuario()
                {
                    EnrollmentDate = dtoUpdate.EnrollmentDate,
                    FechaMod = dtoUpdate.FechaMod,
                    FechaRegistro = dtoUpdate.FechaRegistro,
                    Nombre = dtoUpdate.Nombre,
                    IdRol = dtoUpdate.IdRol

                };
                this.usuarioRepository.Update(usuario);


                result.Message = "Usuario actualizado de manera exitosa";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error eliminando los usuarios. ";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}

