using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class EditorialException : Exception
    {
        public EditorialException() { }
        public EditorialException(string message) : base(message) { }
        EditorialException(string message, Exception innerException) : base(message, innerException) { }
    }
}
