using Compartido.DTOS.Cliente;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class ServicioMappers
    {
        //Alta
        public static LogicaNegocio.Entidades.Servicio FromServicioAltaDto(ServicioAltaDto altaDto)
        {
            // Crear una nueva instancia de Servicio con las propiedades correspondientes
            LogicaNegocio.Entidades.Servicio servicio = new LogicaNegocio.Entidades.Servicio
            {
                Nombre = altaDto.Nombre,
                Precio = altaDto.Precio,
                Descripcion = altaDto.Descripcion,
                ImagenesDeTrabajosSimilares = string.IsNullOrEmpty(altaDto.ImagenBase64)
                                      ? new byte[0]
                                      : Convert.FromBase64String(altaDto.ImagenBase64),  // Si no hay imagen, guardamos null
                PrestadorId = altaDto.PrestadorId,
                Categorias = altaDto.NombreCategoria

            };

            return servicio;
        }





        //Listar buscador
        public static ListarServicioChico FromServicioToListarServicioChico(LogicaNegocio.Entidades.Servicio servicio)
        {
            return new ListarServicioChico
            {
                Nombre = servicio.Nombre,
                Precio = servicio.Precio,
                FotoServicio = servicio.ImagenesDeTrabajosSimilares,
                Descripcion = servicio.Descripcion
            };
        }



        // Editar datos de servicio
        public static LogicaNegocio.Entidades.Servicio FromEditarServicioDto(EditarServicioDto editarServicioDto)
        {
            return new LogicaNegocio.Entidades.Servicio(
                editarServicioDto.Id,
                editarServicioDto.Nombre,
                editarServicioDto.TipoDeServicio,
                editarServicioDto.Precio,
                editarServicioDto.Descripcion,
                editarServicioDto.NombreCategoria
            );
        }


        //Mostrar todos los datos del servicio

        public static ListarTodosLosDatosServicioDTO MostrarTodosLosDatosServicio(LogicaNegocio.Entidades.Servicio mostrarServicio)
        {
            return new ListarTodosLosDatosServicioDTO
            {
                Nombre = mostrarServicio.Nombre,
                Precio = mostrarServicio.Precio,
                Descripcion = mostrarServicio.Descripcion,
                ImagenesDeTrabajosSimilares = mostrarServicio.ImagenesDeTrabajosSimilares,
                CantSugerencias = mostrarServicio.CantSugerencias,
                Categorias = mostrarServicio.Categorias,
                ComentariosServicio = mostrarServicio.Comentarios?.Select(c => new MostrarComentariosServiciosDTO
                {
                    Contenido = c.Contenido,
                    Estrellas = c.Estrellas,
                    NombreCliente = c.NombreCliente
                }).ToList(),
                NombrePrestador = mostrarServicio.Prestador?.Nombre // Solo el nombre del prestador
            };
        }




    }
}
