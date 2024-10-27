using Compartido.DTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones;

namespace Compartido.Mappers
{
    public static class PaisMapper
    {
        public static Pais DTOtoEntidad(PaisDTO dto)
        {
            if(dto == null)
            {
                throw new PaisException("Datos de ingreso Pais vacios");
            }
            return new Pais
            {
                Id = dto.Id,
                Nombre = new LogicaNegocio.ValueObjects.RNombrePais(dto.Nombre)
            };
        }

        public static PaisDTO EntidadToDTO(Pais pais)
        {
            if (pais == null) throw new PaisException("Datos de Pais vacios");
            return new PaisDTO
            {
                Id = pais.Id,
                Nombre = pais.Nombre.Valor
            };
        }

        public static IEnumerable<PaisDTO> ListaEntidadToListaDTO(List<Pais> lista) =>
            lista.Select(p => new PaisDTO
            {
                Id = p.Id,
                Nombre = p.Nombre.Valor
            });
    }
}
