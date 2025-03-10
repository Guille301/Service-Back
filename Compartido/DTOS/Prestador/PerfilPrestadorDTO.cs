using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Prestador
{
    public class PerfilPrestadorDTO
    {


        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contra { get; set; }

        public int Celular { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Descripcion { get; set; }

        public byte[] FotoPerfil { get; set; }

        public List<ListarServicioChico> Servicios { get; set; }

        public List<MostrarComentariosPrestadorDTO> ComentariosPrestador { get; set; }




    }
}
