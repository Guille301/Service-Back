using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Prestador
{
    public class EditarPrestador : IEditarPrestador
    {
        private readonly IRepositorioPrestador _repositorioPrestador;

        public EditarPrestador(IRepositorioPrestador repoPrestador)
        {
            _repositorioPrestador = repoPrestador;
        }

        void IEditarPrestador.EditarPrestador(EditarPrestadorDto editarPrestadorDto)
        {
            try
            {
                var prestador = PrestadorMappers.FromEditarPrestadorDto(editarPrestadorDto);
                _repositorioPrestador.Update(prestador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
