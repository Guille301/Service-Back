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
    public class ConfirmarRealizacion : IConfirmarRealizacion
    {

        private readonly IRepositorioServicioContratado _repo;


        public ConfirmarRealizacion(IRepositorioServicioContratado repoServicio)
        {
            _repo = repoServicio;

        }




        public void Realizado(ServicioRealizadoDTO DTO)
        {


            try
            {
                var servicioBuscado = _repo.FindById(DTO.Id);

                DateTime fechaDTO = DTO.FechaHora.Date;
                DateTime fechaActual = DateTime.Now.Date;

                if (servicioBuscado == null || fechaDTO != fechaActual)
                {
                    throw new Exception("Error en la confirmacion.");
                }

                ServicioContratadoMappers.ActualizarEstado(servicioBuscado, DTO);
                _repo.ServicioRealizadoONo(servicioBuscado);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




            
        }









    }
}
