using Compartido.DTOS.Servicio;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio
{
    public class EditarServicio : IEditarServicio
    {

        private readonly IRepositorioServicio _repositorioServicio;

        public EditarServicio(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;
        }

        void IEditarServicio.EditarServicio(EditarServicioDto editarServicioDto)
        {
            try
            {
                var servicio = ServicioMappers.FromEditarServicioDto(editarServicioDto);
                _repositorioServicio.Update(servicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
