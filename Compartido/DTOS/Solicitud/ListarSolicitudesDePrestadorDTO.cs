using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Solicitud
{
    public class ListarSolicitudesDePrestadorDTO
    {

        public int IdCliente { get; set; }


        public int IdServicio { get; set; }


        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Datos { get; set; }

        public bool? Aprobado { get; set; }




    }
}
