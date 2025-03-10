using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioServicio : IRepositorio<Servicio>
    {

        IEnumerable<Servicio> BuscarServicios(string criterio);

        IEnumerable<Servicio> ObtenerServiciosBelleza();

         IEnumerable<Servicio> ObtenerServiciosReparaciones();
        IEnumerable<Servicio> ObtenerServiciosLegales();

        IEnumerable<Servicio> FiltroDeServicio(int? precioMinimo, int? precioMaximo, string? descripcion, string? zona);

        Servicio MostrarServicioCompleto(int id);


    }
}
