using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class UsuarioCliente
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación 1:1 con Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        //public bool Activo { get; set; }
        //Tener este atributo es util para cuando se autoriza verificando por medio del mail, pero en esta etapa no lo voy a hacer asi.






    }
}
