using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Excepción de archivos.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivoException(Exception innerException) : base("Directorio sin especificar o error de conversión.", innerException)
        {

        }
    }
}
