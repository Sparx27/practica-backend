using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly LibreriaDBv3Context _context;
        public PaisRepositorio(LibreriaDBv3Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Pais buscar = SelectById(id) ?? throw new PaisException("No existe Pais con ese id");
            _context.Paises.Remove(buscar);
            _context.SaveChanges();
        }

        public void Insert(Pais t)
        {
            Pais? buscar = SelectByNombre(t.Nombre.Valor);
            if(buscar != null) throw new ConflictException("Ya existe Pais con ese nombre");
            _context.Paises.Add(t);
            _context.SaveChanges();
        }

        public List<Pais> SelectAll() => 
            _context.Paises.Include(p => p.Nombre).ToList();

        public Pais? SelectById(int id) => 
            _context.Paises.Include(p => p.Nombre).FirstOrDefault(p => p.Id == id);

        public Pais? SelectByNombre(string nombre) =>
            _context.Paises.Include(p => p.Nombre).FirstOrDefault(p => p.Nombre.Valor == nombre);

        public Pais Update(Pais t)
        {
            Pais? actualizar = SelectById(t.Id) ?? throw new PaisException("No existe Pais con ese Id");
            Pais? buscar = SelectByNombre(t.Nombre.Valor);
            if (buscar != null) throw new ConflictException("Ya existe Pais con ese nombre");
            actualizar.Nombre.Valor = t.Nombre.Valor;
            _context.Paises.Update(actualizar);
            _context.SaveChanges();
            return actualizar;
        }
    }
}
