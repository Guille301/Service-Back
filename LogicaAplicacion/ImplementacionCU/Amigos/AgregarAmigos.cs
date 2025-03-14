using Compartido.DTOS.Amigos;
using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Amigos
{
    public class AgregarAmigos : IAgregarAmigos
    {

        private readonly IRepositorioClienteAmigos _repo;


        public AgregarAmigos(IRepositorioClienteAmigos repoClienteAmigo)
        {
            _repo = repoClienteAmigo;

        }


        public void AltaAmigos(AgregarAmigosDTO amigoDto)
        {

            try
            {


                // Validaciones de negocio
                if (amigoDto.ClienteId == amigoDto.AmigoId)
                {
                    throw new InvalidOperationException("Un cliente no puede agregarse a sí mismo como amigo.");
                }



                var clienteAmigo = new ClienteAmigo
                {
                    ClienteId = amigoDto.ClienteId,
                    AmigoId = amigoDto.AmigoId
                };



                _repo.Add(clienteAmigo);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }












        }









    }
}
