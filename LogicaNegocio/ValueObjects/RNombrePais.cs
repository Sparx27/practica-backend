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
    public class RNombrePais
    {
        public string Valor { get; set; }
        public RNombrePais(string valor) 
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if(Valor.Length < 2 || Valor.Length > 30)
            {
                throw new PaisException("Nombre Pais not between 2 y 30");
            }
        }
    }
}
