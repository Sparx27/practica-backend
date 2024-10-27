using Compartido.DTOs;
using LogicaAplicacion.Interfaces;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones;
using Compartido.Mappers;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasosDeUso
{
    public class PaisServicios : IPaisServicios
    {
        private readonly IPaisRepositorio _repoPais;
        public PaisServicios(IPaisRepositorio repoPais)
        {
            _repoPais = repoPais;
        }

        public void DeletePais(int id)
        {
            ValidarId(id);
            _repoPais.Delete(id);
        }

        public void InsertPais(PaisDTO dto)
        {
            ValidarNombre(dto.Nombre);
            _repoPais.Insert(PaisMapper.DTOtoEntidad(dto));
        }

        public IEnumerable<PaisDTO> SelectAllPais() =>
            PaisMapper.ListaEntidadToListaDTO(_repoPais.SelectAll());

        public PaisDTO? SelectPaisById(int id)
        {
            ValidarId(id);
            Pais? buscar = _repoPais.SelectById(id);
            return buscar is null ? null : PaisMapper.EntidadToDTO(buscar);
        }

        public PaisDTO? SelectPaisByNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) 
                throw new PaisException("Error: Imposible buscar por un nombre vacío");
            Pais? buscar = _repoPais.SelectByNombre(nombre);
            return buscar is null ? null : PaisMapper.EntidadToDTO(buscar);
        }

        public PaisDTO UpdatePais(PaisDTO dto)
        {
            ValidarId(dto.Id);
            ValidarNombre(dto.Nombre);
            Pais actualizado = _repoPais.Update(PaisMapper.DTOtoEntidad(dto));
            return PaisMapper.EntidadToDTO(actualizado);
        }

        private void ValidarNombre(string nombre)
        {
            if(string.IsNullOrEmpty(nombre) || nombre.Length < 2 || nombre.Length > 30)
            {
                throw new PaisException("Error: El nombre debe tener entre 2 y 30 caracteres");
            }
        }
        private void ValidarId(int id)
        {
            if (id <= 0) throw new PaisException("Id de Pais incorrecto");
        }
    }
}
