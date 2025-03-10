using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.ServicioContratado
{
    public class ListarServiciosContratadosClienteDTO
    {
        public int ClienteId { get; set; }


        public int ServicioId { get; set; }

        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Datos { get; set; }


        public string Estado { get; set; }


    }
}
