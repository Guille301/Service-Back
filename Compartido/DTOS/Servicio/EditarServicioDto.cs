using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Servicio
{
    public class EditarServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoDeServicio { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }

        public string NombreCategoria { get; set; }



    }
}
