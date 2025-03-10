using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Prestador;
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
    public class EditarComentariosServicios : IEditarComentariosServicio
    {

        private readonly IRepositorioComentarioServicio _repo;


        public EditarComentariosServicios(IRepositorioComentarioServicio repo)
        {
            _repo = repo;

        }

       

        public void EditarComentarioServicio(EditarComentarioServicioDTO DTO, int idComentario)
        {
            try
            {
                var comentarioExistente = _repo.FindById(idComentario);

                if (comentarioExistente != null)
                {

                    var com = ComentariosMapper.FromEditarComentarioServicio(DTO);
                    _repo.Update(com);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
