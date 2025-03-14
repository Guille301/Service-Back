using Compartido.DTOS.Cliente;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Prestador
{
    public class AltaPrestador : IAltaPrestador
    {

        private readonly IRepositorioPrestador _repositorioPrestador;


        public AltaPrestador(IRepositorioPrestador repoPrestador)
        {
            _repositorioPrestador = repoPrestador;

        }

        void IAltaPrestador.AltaPrestador(PrestadorAltaDto PrestadorAltaDTO)
        {
            try
            {
                // Validar que los datos no sean nulos o vacíos
                if (string.IsNullOrEmpty(PrestadorAltaDTO.Nombre) ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Email) ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Contra) ||
                    PrestadorAltaDTO.Celular == 0 ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Sexo) ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Ciudad) ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Barrio) ||
                    string.IsNullOrEmpty(PrestadorAltaDTO.Descripcion))
                {
                    throw new Exception("Todos los campos son obligatorios y no pueden estar vacíos.");
                }

                // Verificar si el email ya está registrado
                LogicaNegocio.Entidades.Prestador prestadorExistente = _repositorioPrestador.FindByEmail(PrestadorAltaDTO.Contra);
                if (prestadorExistente != null)
                {
                    throw new Exception("El email ya está registrado.");
                }

                // Mapear y agregar el nuevo prestador
                LogicaNegocio.Entidades.Prestador nuevoPrestador = PrestadorMappers.FromPrestadorAltaDto(PrestadorAltaDTO);
                _repositorioPrestador.Add(nuevoPrestador);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar el prestador: {ex.Message}");
            }
        }




    }
}
