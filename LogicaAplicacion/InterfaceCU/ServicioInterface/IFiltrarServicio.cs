using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Servicio
{
    public interface IFiltrarServicio
    {


        IEnumerable<ListarServicioChico> FiltrarServicios(int? precioMinimo, int? precioMaximo, string? descripcion, string? zona);



    }
}
