using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSolicitud : IRepositorio<Solicitud>
    {

        public IEnumerable<Solicitud> SolicitudesPorPrestador(int idPrestador);

        public void AprobarONo(Solicitud objeto);


    }
}
