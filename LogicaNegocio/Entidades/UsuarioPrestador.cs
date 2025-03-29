using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class UsuarioPrestador
    {


        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime FechaCreacion { get; set; }
        

        // Relación 1:1 con Prestador
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        //public bool Activo { get; set; }
        //Tener este atributo es util para cuando se autoriza verificando por medio del mail, pero en esta etapa no lo voy a hacer asi.















    }
}
