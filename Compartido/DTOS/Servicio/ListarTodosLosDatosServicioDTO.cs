using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Prestador;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Servicio
{
    public class ListarTodosLosDatosServicioDTO
    {


        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public byte[] ImagenesDeTrabajosSimilares { get; set; }


        public int CantSugerencias { get; set; }

        public string Categorias { get; set; }

        public string NombrePrestador { get; set; } // Solo el nombre del prestador

        public List<MostrarComentariosServiciosDTO> ComentariosServicio { get; set; }



    }
}
