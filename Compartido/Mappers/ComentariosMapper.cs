using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class ComentariosMapper
    {




        /**********************************************************************************************************************************/
        /*************************************************COMENTARIOS PRESTADOR************************************************************/
        /**********************************************************************************************************************************/



        public static LogicaNegocio.Entidades.ComentariosPrestador FromAltaComentarioPrestador(AltaComentarioPrestadorDTO altaDto)
        {
            // Crear una nueva instancia de Servicio con las propiedades correspondientes
            LogicaNegocio.Entidades.ComentariosPrestador servicio = new LogicaNegocio.Entidades.ComentariosPrestador
            {
                Contenido = altaDto.Contenido,
                Estrellas = altaDto.Estrellas,
                ClienteId = altaDto.ClienteId,
                PrestadorId = altaDto.PrestadorId,
                NombreCliente = altaDto.NombreCliente,
                Fecha = DateTime.Now,

            };

            return servicio;
        }



        //Editar 

        public static LogicaNegocio.Entidades.ComentariosPrestador FromEditarComentarioPrestadorDto(EditarComentarioPrestadorDTO editar)
        {
            return new LogicaNegocio.Entidades.ComentariosPrestador(
              editar.Contenido,
              editar.Estrellas,
              editar.Id
            );
        }



























        /**********************************************************************************************************************************/
        /*************************************************COMENTARIOS SERVICIO************************************************************/
        /**********************************************************************************************************************************/


        public static LogicaNegocio.Entidades.ComentariosServicio FromAltaComentarioServicio(AltaComentarioServicioDTO altaDto)
        {
            // Crear una nueva instancia de Servicio con las propiedades correspondientes
            LogicaNegocio.Entidades.ComentariosServicio servicio = new LogicaNegocio.Entidades.ComentariosServicio
            {
                Contenido = altaDto.Contenido,
                Estrellas = altaDto.Estrellas,
                ClienteId = altaDto.ClienteId,
                NombreCliente = altaDto.NombreCliente,
                Fecha = DateTime.Now,
                ServicioId = altaDto.ServicioId

            };

            return servicio;
        }


        public static LogicaNegocio.Entidades.ComentariosServicio FromEditarComentarioServicio(EditarComentarioServicioDTO editar)
        {
            return new LogicaNegocio.Entidades.ComentariosServicio(
              editar.Contenido,
              editar.Estrellas,
              editar.Id
            );
        }








    }
}
