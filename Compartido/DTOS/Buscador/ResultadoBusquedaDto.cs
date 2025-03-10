using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Buscador
{
    public class ResultadoBusquedaDto
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; } //  "Servicio", o "Prestador"
        public string Descripcion { get; set; }

        public byte[] Foto { get; set; } // 📌 Aquí recibes la imagen en Base64



    }
}
