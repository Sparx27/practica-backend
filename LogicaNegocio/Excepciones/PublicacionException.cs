using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class PublicacionException : Exception
    {
        public PublicacionException() { }
        public PublicacionException(string message) : base(message) { }
        public PublicacionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
