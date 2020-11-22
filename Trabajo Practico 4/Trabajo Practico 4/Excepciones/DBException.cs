using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DBException : Exception
    {
        /// <summary>
        /// Excepción de base de datos.
        /// </summary>
        /// <param name="innerException"></param>
        public DBException(Exception innerException) : base("Ocurrió un error en la importación/exportación a la base de datos.", innerException)
        {

        }
    }
}
