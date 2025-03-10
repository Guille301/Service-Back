using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Servicio
{
    public class ServicioAltaDto
    {

        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string ImagenBase64 { get; set; } // 📌 Aquí recibes la imagen en Base64
        public int PrestadorId { get; set; }
        
        public string NombreCategoria { get; set; }


    }
}
