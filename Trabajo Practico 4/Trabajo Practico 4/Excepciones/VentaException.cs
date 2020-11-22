using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class VentaException : Exception
    {
        /// <summary>
        /// Excepción de ventas.
        /// </summary>
        /// <param name="mensaje"></param>
        public VentaException(string mensaje) : base(mensaje)
        {

        }
    }
}
