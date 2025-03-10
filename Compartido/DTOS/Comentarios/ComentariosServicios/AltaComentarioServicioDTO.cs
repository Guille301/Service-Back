using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Comentarios.ComentariosServicios
{
    public class AltaComentarioServicioDTO
    {

        public string Contenido { get; set; }
        public int Estrellas { get; set; }

        // Relación con Prestador
        public int ServicioId { get; set; }

        //Relacion con cliente
        public string NombreCliente { get; set; }

        public int ClienteId { get; set; }






    }
}
