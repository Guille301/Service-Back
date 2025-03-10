using Compartido.DTOS.Cliente;
using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Servicio;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosServicios
{
    public class AltaComentariosServicios : IAltaComentarioServicios
    {



        private readonly IRepositorioComentarioServicio _repo;


        public AltaComentariosServicios(IRepositorioComentarioServicio repo)
        {
            _repo = repo;

        }

       
        

        public void AltaComentarioServicio(AltaComentarioServicioDTO altaDto)
        {

            try
            {
                LogicaNegocio.Entidades.ComentariosServicio com = ComentariosMapper.FromAltaComentarioServicio(altaDto);

                _repo.Add(com);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }






    }
}
