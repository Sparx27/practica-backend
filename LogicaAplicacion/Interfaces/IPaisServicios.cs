using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Interfaces
{
    public interface IPaisServicios
    {
        PaisDTO? SelectPaisById(int id);
        PaisDTO? SelectPaisByNombre(string nombre);
        IEnumerable<PaisDTO> SelectAllPais();
        void InsertPais(PaisDTO dto);
        PaisDTO UpdatePais(PaisDTO dto);
        void DeletePais(int id);
    }
}
