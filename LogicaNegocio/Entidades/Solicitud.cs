using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Solicitud
    {


        public int Id { get; set; }

        public int IdCliente { get; set; }

        public Cliente cliente { get; set; }

        public int IdServicio { get; set; }

        public Servicio servicio { get; set; }

        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Datos { get; set; }

        public bool? Aprobado { get; set; } // null = En proceso, true = Aprobado, false = Rechazado



        public Solicitud()
        {
           
        }

        public Solicitud(int idCliente, Cliente cliente, int idServicio, Servicio servicio, DateTime fechaHora, string lugar, string datos, bool? aprobado)
        {
            IdCliente = idCliente;
            this.cliente = cliente;
            IdServicio = idServicio;
            this.servicio = servicio;
            FechaHora = fechaHora;
            Lugar = lugar;
            Datos = datos;
            Aprobado = aprobado;
        }
    }
}
