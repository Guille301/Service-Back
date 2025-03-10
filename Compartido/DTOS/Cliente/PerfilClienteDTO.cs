using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Cliente
{
    public class PerfilClienteDTO
    {


        public string Nombre { get; set; }

        public byte[] FotoPerfil { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public DateTime FechaDeNacimiento { get; set; }



    }
}
