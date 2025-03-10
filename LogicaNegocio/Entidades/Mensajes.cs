using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Mensajes
    {
        public int Id { get; set; } // Identificador único del mensaje
        public string Contenido { get; set; } // Texto del mensaje
        public DateTime FechaEnvio { get; set; } // Fecha y hora en que se envió el mensaje
        public bool Leido { get; set; } // Indica si el mensaje fue leído

        // Relación con el Cliente (Remitente o Destinatario)
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relación con el Prestador (Remitente o Destinatario)
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        // Indica quién envió el mensaje (Cliente o Prestador)
        public bool EsDeCliente { get; set; }

        public Mensajes()
        {
            
        }

        public Mensajes(string contenido, DateTime fechaEnvio, bool leido, int clienteId, Cliente cliente, int prestadorId, Prestador prestador, bool esDeCliente)
        {
            Contenido = contenido;
            FechaEnvio = fechaEnvio;
            Leido = leido;
            ClienteId = clienteId;
            Cliente = cliente;
            PrestadorId = prestadorId;
            Prestador = prestador;
            EsDeCliente = esDeCliente;
        }




    }
}
