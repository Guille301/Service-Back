using Compartido.DTOS.Cliente;
using Compartido.DTOS.Prestador;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Compartido.DTOS.Mappers
{
    public class ClienteMappers
    {
        //ALTA cliente
        public static LogicaNegocio.Entidades.Cliente FromClienteAltaDto(ClienteAltaDTO clienteAltaDto)
        {
            LogicaNegocio.Entidades.Cliente cliente = new LogicaNegocio.Entidades.Cliente
            {
                Nombre = clienteAltaDto.Nombre,
                Email = clienteAltaDto.Email,
                Celular = clienteAltaDto.Celular,
                Sexo = clienteAltaDto.Sexo,
                Ciudad = clienteAltaDto.Ciudad,
                Barrio = clienteAltaDto.Barrio,
                FechaDeNacimiento = clienteAltaDto.FechaDeNacimiento,
                FotoPerfil = string.IsNullOrEmpty(clienteAltaDto.FotoPerfil)
                                      ? new byte[0]
                                      : Convert.FromBase64String(clienteAltaDto.FotoPerfil),
            };

            cliente.SetPassword(clienteAltaDto.Contrasena);


            return cliente;
        }

        //Listar para buscador

        public static ListarClientesBuscador FromListarClientesBuscador(LogicaNegocio.Entidades.Cliente cli)
        {
            return new ListarClientesBuscador
            {
                Nombre = cli.Nombre,
                Ciudad = cli.Ciudad,
                
            };
        }



        //Editar datos de cliente
        public static LogicaNegocio.Entidades.Cliente FromEditarClienteDto(EditarClienteDto clienteAltaDto)
        {
            return new LogicaNegocio.Entidades.Cliente(
                 clienteAltaDto.Id,
                 clienteAltaDto.Nombre,
                 clienteAltaDto.Email,
                 clienteAltaDto.Celular,
                 clienteAltaDto.Sexo,
                 clienteAltaDto.Ciudad,
                 clienteAltaDto.Barrio,
                 clienteAltaDto.Contrasena,
                 clienteAltaDto.FechaDeNacimiento);
        }




        //Perfil cliente

        public static PerfilClienteDTO PerfilCliente(LogicaNegocio.Entidades.Cliente clienteDto)
        {
            return new PerfilClienteDTO
            {
                Nombre = clienteDto.Nombre,
                Email = clienteDto.Email,
                Celular = clienteDto.Celular,
                Sexo = clienteDto.Sexo,
                Ciudad = clienteDto.Ciudad,
                Barrio = clienteDto.Barrio,
                FotoPerfil = clienteDto.FotoPerfil,
                FechaDeNacimiento = clienteDto.FechaDeNacimiento
              
            };
        }



    }
}
