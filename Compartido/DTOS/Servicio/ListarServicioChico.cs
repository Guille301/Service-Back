using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Servicio
{
    public class ListarServicioChico
    {

        public string Nombre { get; set; }
        public string TipoDeServicio { get; set; }
        public double Precio { get; set; }
        public byte[] FotoServicio { get; set; } // 📌 Aquí recibes la imagen en Base64

        public string Descripcion { get; set; }

    }
}
