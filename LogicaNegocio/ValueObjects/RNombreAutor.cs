using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public class RNombreAutor
    {
        public string Valor {  get; set; }
        public RNombreAutor(string valor)
        {
            Valor = valor;
        }   
        private void Validar()
        {
            if (Valor.Length < 2 || Valor.Length > 30)
                throw new AutorException("Nombre autor not between 2 y 30");
        }
    }
}
