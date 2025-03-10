using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Prestador
{
    public class EditarPrestadorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Descripcion { get; set; }




    }
}
