using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Prestador
{
    public interface IEditarPrestador
    {
        public void EditarPrestador(EditarPrestadorDto DTO);

    }
}
