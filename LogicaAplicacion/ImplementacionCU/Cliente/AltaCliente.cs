using Compartido.DTOS.Cliente;
using Compartido.DTOS.Mappers;
using LogicaAplicacion.InterfaceCU.Cliente;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Cliente
{
    public class AltaCliente : IAltaCliente
    {



        private readonly IRepositorioCliente _repositorioCliente;


        public AltaCliente(IRepositorioCliente repoCliente)
        {
            _repositorioCliente = repoCliente;

        }

        public void Ejecutar(ClienteAltaDTO ClienteAltaDTO)
        {

            try
            {

                LogicaNegocio.Entidades.Cliente cliexistente = _repositorioCliente.FindByEmail(ClienteAltaDTO.Email);
                var verificarCliente = ClienteMappers.FromClienteAltaDto(ClienteAltaDTO);


                //Valido vacios
                if (string.IsNullOrEmpty(ClienteAltaDTO.Nombre) ||
          string.IsNullOrEmpty(ClienteAltaDTO.Email) ||
          ClienteAltaDTO.Celular == 0 ||
          string.IsNullOrEmpty(ClienteAltaDTO.Sexo) ||
          string.IsNullOrEmpty(ClienteAltaDTO.Ciudad) ||
          string.IsNullOrEmpty(ClienteAltaDTO.Barrio) ||
          string.IsNullOrEmpty(ClienteAltaDTO.Contrasena) ||
          ClienteAltaDTO.FechaDeNacimiento == null)
                {
                    throw new Exception("Todos los campos son obligatorios y no pueden estar vacíos.");
                }





                //Validar datos

                if (cliexistente == null && verificarCliente.ValidarMail() && verificarCliente.ValidarNombre())
                {
                    LogicaNegocio.Entidades.Cliente cli = ClienteMappers.FromClienteAltaDto(ClienteAltaDTO);
                    _repositorioCliente.Add(cli);
                }
                else
                {
                    throw new Exception("No se pudo crear el cliente. Verifique los datos ingresados.");
                }


            }
            catch (Exception ex) 
            {

                throw new Exception(ex.Message);


            }
        }







    }
}
