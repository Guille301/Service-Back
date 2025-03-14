using Compartido.DTOS.ServicioContratado;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.ServicioContratado;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.ServicioContratado
{
    public class ListarServicioContratadoPrestador : IListarSerContratadoPrestador
    {


        private readonly IRepositorioServicioContratado _repo;


        public ListarServicioContratadoPrestador(IRepositorioServicioContratado repoServicio)
        {
            _repo = repoServicio;

        }





        public List<ListarServiciosContratadosPrestadorDTO> MostarServiciosContratados(int id)
        {

            var servicioContratado = _repo.ObtenerServiciosContratadosDePrestador(id); 


            var dto = ServicioContratadoMappers.FromServicioContratadoListarPrestador(servicioContratado);

            return dto;

        }




    }
}
