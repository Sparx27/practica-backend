using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorio<T>
    {
        List<T> SelectAll();
        T? SelectById(int id);
        T? SelectByNombre(string nombre);
        void Insert(T t);
        T Update(T t);
        void Delete(int id);
    }
}
