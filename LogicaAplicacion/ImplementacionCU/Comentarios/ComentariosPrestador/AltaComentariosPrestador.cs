using Compartido.DTOS.Cliente;
using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Servicio;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosPrestador
{
    public class AltaComentariosPrestador : IAltaComentarioPrestador
    {



        private readonly IRepositorioComentarioPrestador _repositorioComentarioPrestador;


        public AltaComentariosPrestador(IRepositorioComentarioPrestador repo)
        {
            _repositorioComentarioPrestador = repo;

        }




        public void AltaComentarioPrestador(AltaComentarioPrestadorDTO altaDto)
        {


            try
            {
                LogicaNegocio.Entidades.ComentariosPrestador com = ComentariosMapper.FromAltaComentarioPrestador(altaDto);

                _repositorioComentarioPrestador.Add(com);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }



        }

        
    }
}
