using Compartido.DTOS.Solicitud;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Solicitud;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Solicitud
{
    public class AltaSolicitud : IAltaSolicitud
    {


        private readonly IRepositorioSolicitud _repo;


        public AltaSolicitud(IRepositorioSolicitud repo)
        {
            _repo = repo;

        }







        public void Alta(AltaSolicitudDTO SolicitudAltaDTO)
        {
            try
            {


                LogicaNegocio.Entidades.Solicitud com = SolicitudMapper.FromAltaSolicitud(SolicitudAltaDTO);

                _repo.Add(com);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }

        }















    }
}
