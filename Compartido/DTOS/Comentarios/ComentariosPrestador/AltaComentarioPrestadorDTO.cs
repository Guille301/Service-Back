using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Comentarios.ComentariosPrestador
{
    public class AltaComentarioPrestadorDTO
    {

        public string Contenido { get; set; }
        public int Estrellas { get; set; }

        // Relación con Prestador
        public int PrestadorId { get; set; }

        //Relacion con cliente
        public string NombreCliente { get; set; }

        public int ClienteId { get; set; }






    }
}
