using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.ServicioContratado
{
    public class ListarServiciosContratadosPrestadorDTO
    {


        public int ClienteId { get; set; }


        public int ServicioId { get; set; }

        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Datos { get; set; }


        public bool? Estado { get; set; }



    }
}
