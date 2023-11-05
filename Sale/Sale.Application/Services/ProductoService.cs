using Microsoft.Extensions.Logging;
using Sale.Application.Contracts;
using Sale.Application.Core;
using Sale.Application.Dtos.Producto;
using Sale.Domain.Entities;
using Sale.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sale.Application.Services
{
    internal class ProductoService : IProductoService
    {

        private readonly IProductoRepository productoRepository;
        private readonly ILogger<ProductoService> logger;

        public ProductoService(IProductoRepository productoRepository, ILogger<ProductoService> logger)
        {
            this.productoRepository = productoRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var productos = this.productoRepository.GetEntities()
                .Select(pt =>
                new ProductoDtoGetAll()
                {
                    Id = pt.Id,
                    Marca = pt.Marca,
                    FechaRegistro = pt.FechaRegistro,
                    FechaMod = pt.FechaMod,
                    IdUsuarioMod = pt.IdUsuarioMod
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los estudiantes.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var producto = this.productoRepository.GetEntity(Id);

                ProductoDtoGetAll productoModel = new ProductoDtoGetAll()
                {
                    Id = producto.Id,
                    Marca = producto.Marca,
                    FechaRegistro = producto.FechaRegistro,
                    FechaMod = producto.FechaMod,
                    IdUsuarioMod = producto.IdUsuarioMod,
                };

                result.Data = productoModel;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el siguiente error obteniendo el estudiante.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(ProductoDtoRemove dtoRemove)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                Producto producto = new Producto()
                {
                    Id = dtoRemove.Id,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.ChangeDate,
                    IdUsuarioElimino = dtoRemove.ChangeUser
                };

                this.productoRepository.Delete(producto);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error removiendo el producto.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(ProductoDtoAdd dtoAdd)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                Producto producto = new Producto()
                {
                    FechaRegistro = dtoAdd.ChangeDate,
                    IdUsuarioCreacion = dtoAdd.ChangeUser,
                    Marca = dtoAdd.Marca,
                    Descripcion = dtoAdd.CodigoBarra
                };
                this.productoRepository.Save(producto);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error guardando el producto.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(ProductoDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Producto producto = new Producto()
                {
                    FechaRegistro = dtoUpdate.ChangeDate,
                    IdUsuarioCreacion = dtoUpdate.ChangeUser,
                    Marca = dtoUpdate.Marca,
                    Descripcion = dtoUpdate.CodigoBarra,
                    FechaMod = dtoUpdate.ChangeDate,
                    Id = dtoUpdate.Id
                };
                this.productoRepository.Save(producto);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error actualizando el producto.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
