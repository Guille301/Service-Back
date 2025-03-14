using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Prestador;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosPrestador
{
    public class EditarComentariosPrestador : IEditarComentariosPrestador
    {

        private readonly IRepositorioComentarioPrestador _repositorioComentarioPrestador;


        public EditarComentariosPrestador(IRepositorioComentarioPrestador repo)
        {
            _repositorioComentarioPrestador = repo;

        }

        public void EditarComentarioPrestador(EditarComentarioPrestadorDTO DTO, int idComentario)
        {
            try
            {
                var comentarioExistente = _repositorioComentarioPrestador.FindById(idComentario);

                if(comentarioExistente != null)
                {

                    var com = ComentariosMapper.FromEditarComentarioPrestadorDto(DTO);
                    _repositorioComentarioPrestador.Update(com);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }










    }
}
