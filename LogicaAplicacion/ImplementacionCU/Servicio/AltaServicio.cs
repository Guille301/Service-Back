using Compartido.DTOS.Cliente;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Servicio;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio
{
    public class AltaServicio : IAltaServicio
    {


        private readonly IRepositorioServicio _repositorioServicio;


        public AltaServicio(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;

        }



        void IAltaServicio.AltaServicio(ServicioAltaDto servicioAltaDTO)
        {
            try
            {
                    LogicaNegocio.Entidades.Servicio ser = ServicioMappers.FromServicioAltaDto(servicioAltaDTO);

                _repositorioServicio.Add(ser);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }





    }
}
