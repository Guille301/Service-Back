using Compartido.DTOS.Cliente;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class PrestadorMappers
    {
        //Alta
        public static Prestador FromPrestadorAltaDto(PrestadorAltaDto altaDto)
        {

            Prestador prestador = new Prestador
            {
                Nombre = altaDto.Nombre,
                Email = altaDto.Email,
                Celular = altaDto.Celular,
                Sexo = altaDto.Sexo,
                Ciudad = altaDto.Ciudad,
                Barrio = altaDto.Barrio,
                Descripcion = altaDto.Descripcion,
                ImagenesDeTrabajos = new byte[0], // Inicializa como null si no es requerido al alta
                Servicios = new List<Servicio>(), // Inicializa como lista vacía
                Comentarios = new List<ComentariosPrestador>(), // Inicializa como lista vacía
                Mensajes = new List<Mensajes>(), // Inicializa como lista vacía
                FotoPerfil = string.IsNullOrEmpty(altaDto.FotoPerfil)
                                            ? new byte[0]
                                      : Convert.FromBase64String(altaDto.FotoPerfil),
            };
            prestador.SetPassword(altaDto.Contra);



            return prestador;
        }


        //Listar buscador
        public static ListarPrestadorBuscadorDto FromPrestadorToListarPrestadorBuscador(Prestador prestador)
        {
            return new ListarPrestadorBuscadorDto
            {
                Nombre = prestador.Nombre,
                Ciudad = prestador.Ciudad,
                Barrio = prestador.Barrio,
                Descripcion = prestador.Descripcion
            };
        }


        //Editar prestador
        public static Prestador FromEditarPrestadorDto(EditarPrestadorDto editarPrestadorDto)
        {
            return new Prestador(
                editarPrestadorDto.Id,
                editarPrestadorDto.Nombre,
                editarPrestadorDto.Email,
                editarPrestadorDto.Celular,
                editarPrestadorDto.Ciudad,
                editarPrestadorDto.Barrio,
                editarPrestadorDto.Descripcion
            );
        }



        //Perfil prestador
        public static PerfilPrestadorDTO DetallesCompletosPrestador(Prestador prestadorDetailsDto)
        {
            return new PerfilPrestadorDTO
            {
                Nombre = prestadorDetailsDto.Nombre,
                Email = prestadorDetailsDto.Email,
                Celular = prestadorDetailsDto.Celular,
                Sexo = prestadorDetailsDto.Sexo,
                Ciudad = prestadorDetailsDto.Ciudad,
                Barrio = prestadorDetailsDto.Barrio,
                Descripcion = prestadorDetailsDto.Descripcion,
                FotoPerfil = prestadorDetailsDto.FotoPerfil,
                ComentariosPrestador = prestadorDetailsDto.Comentarios?.Select(c => new DTOS.Comentarios.ComentariosPrestador.MostrarComentariosPrestadorDTO
                {
                    Contenido = c.Contenido,
                    Estrellas = c.Estrellas,
                    NombreCliente = c.NombreCliente
                }).ToList(),
                Servicios = prestadorDetailsDto.Servicios?.Select(s => new ListarServicioChico
                {
                    Nombre = s.Nombre,
                    Precio = s.Precio,
                    Descripcion = s.Descripcion,
                    FotoServicio = s.ImagenesDeTrabajosSimilares
                }).ToList()
            };
        }





    }
}
