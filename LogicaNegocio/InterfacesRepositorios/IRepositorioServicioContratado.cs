using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioServicioContratado : IRepositorio<ServicioContratado>
    {



        IEnumerable<ServicioContratado> ObtenerServiciosContratadosDePrestador(int id);


        IEnumerable<ServicioContratado> ObtenerServiciosContratadosDeCliente(int id);




    }
}
