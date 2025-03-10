using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Cliente
{
    public class ClienteAltaDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaDeNacimiento { get; set; }


        public string FotoPerfil { get; set; } // 📌 Aquí recibes la imagen en Base64




    }
}
