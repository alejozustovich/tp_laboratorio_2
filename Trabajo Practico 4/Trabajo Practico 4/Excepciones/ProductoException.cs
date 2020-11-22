using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProductoException : Exception
    {
        /// <summary>
        /// Excepción de productos.
        /// </summary>
        /// <param name="mensaje"></param>
        public ProductoException(string mensaje) : base(mensaje)
        {

        }
    }
}
