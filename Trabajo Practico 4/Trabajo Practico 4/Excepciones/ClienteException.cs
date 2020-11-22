using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ClienteException : Exception
    {
        /// <summary>
        /// Excepción de Cliente.
        /// </summary>
        /// <param name="mensaje"></param>
        public ClienteException(string mensaje) : base(mensaje)
        {

        }
    }
}
