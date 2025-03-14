using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class ClienteAmigo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int AmigoId { get; set; }
        public Cliente Amigo { get; set; }






        public ClienteAmigo()
        {
          
        }









        public ClienteAmigo(int clienteId, Cliente cliente, int amigoId, Cliente amigo)
        {
            ClienteId = clienteId;
            Cliente = cliente;
            AmigoId = amigoId;
            Amigo = amigo;
        }




    }
}
