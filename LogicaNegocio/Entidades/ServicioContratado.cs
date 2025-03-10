using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class ServicioContratado
    {

        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Datos { get; set; }  


        public string Estado { get; set; } // Puede ser realizado , en proceso o terminado o cancelado


        public ServicioContratado()
        {
            
        }

        public ServicioContratado(int clienteId, Cliente cliente, int servicioId, Servicio servicio, DateTime fechaHora, string lugar, string datos, string estado)
        {
            ClienteId = clienteId;
            Cliente = cliente;
            ServicioId = servicioId;
            Servicio = servicio;
            FechaHora = fechaHora;
            Lugar = lugar;
            Datos = datos;
            Estado = estado;
        }



    }
}
