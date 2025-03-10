using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Servicio
    {
        private string nombreCategoria;
        private string tipoDeServicio;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public byte[] ImagenesDeTrabajosSimilares { get; set; }

        // Relación con prestador
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        // Relación con comentarios
        public List<ComentariosServicio> Comentarios { get; set; }

        // Relación con clientes que contrataron el servicio
        public List<ServicioContratado> ServiciosContratados { get; set; }

        //Cantidad de personas que sugieren este servicio
        public int CantSugerencias  { get; set; }

        //Voy a mostrar a las categorias como un string 
        public string Categorias { get; set; }


        public Servicio()
        {
            
        }

        public Servicio(string nombre, double precio, string descripcion, byte[] imagenesDeTrabajosSimilares, int prestadorId, Prestador prestador, List<ComentariosServicio> comentarios, List<ServicioContratado> serviciosContratados)
        {
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            ImagenesDeTrabajosSimilares = imagenesDeTrabajosSimilares;
            PrestadorId = prestadorId;
            Prestador = prestador;
            Comentarios = comentarios;
            ServiciosContratados = serviciosContratados;
        }

        public Servicio(int id, string nombre, double precio, string descripcion,string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            Categorias = categoria;
        }

        public Servicio(int id, string nombre, string tipoDeServicio, double precio, string descripcion, string nombreCategoria)
        {
            Id = id;
            Nombre = nombre;
            this.tipoDeServicio = tipoDeServicio;
            Precio = precio;
            Descripcion = descripcion;
            this.nombreCategoria = nombreCategoria;
        }
    }
}
