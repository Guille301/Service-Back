using Compartido.DTOS.ServicioContratado;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.ServicioContratado;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.ServicioContratado
{
    public class ListarServicioContratadoCliente : IListarSerContratadoCliente
    {



        private readonly IRepositorioServicioContratado _repo;


        public ListarServicioContratadoCliente(IRepositorioServicioContratado repoServicio)
        {
            _repo = repoServicio;

        }





        

        List<ListarServiciosContratadosClienteDTO> IListarSerContratadoCliente.MostarServiciosContratadosCliente(int id)
        {
            var servicioContratado = _repo.ObtenerServiciosContratadosDeCliente(id);


            var dto = ServicioContratadoMappers.FromServicioContratadoListarCliente(servicioContratado);

            return dto;
        }






    }
}
