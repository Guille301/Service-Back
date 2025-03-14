using Compartido.DTOS.Prestador;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Prestador
{
    public class PerfilPrestador : IPerfilPrestador
    {


        private readonly IRepositorioPrestador _repositorioPrestador;

        public PerfilPrestador(IRepositorioPrestador repoPrestador)
        {
            _repositorioPrestador = repoPrestador;
        }



        public PerfilPrestadorDTO MostarDatos(int id)
        {

            var prestador = _repositorioPrestador.MostrarPerfilPrestador(id);

            var prestadorDto = PrestadorMappers.DetallesCompletosPrestador(prestador);

            // Retornar el DTO
            return prestadorDto;


        }
    }
}
