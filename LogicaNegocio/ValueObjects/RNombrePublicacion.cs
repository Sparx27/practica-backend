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
    public class RNombrePublicacion
    {
        public string Valor {  get; set; }
        public RNombrePublicacion(string valor)
        {
            Valor = valor;
        }
        private RNombrePublicacion()
        {
            if(string.IsNullOrEmpty(Valor) || Valor.Length < 2 || Valor.Length > 30)
            {
                throw new PublicacionException("Nombre publicacion not between 2 y 30");
            }
        }
    }
}
