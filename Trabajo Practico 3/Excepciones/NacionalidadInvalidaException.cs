using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException: Exception
    {
        /// <summary>
        /// Excepción: La nacionalidad no coincide con el DNI.
        /// </summary>
        /// <param name="message"></param>

        public NacionalidadInvalidaException(string message) : base(message)
        {

        }

        public NacionalidadInvalidaException():this("La Nacionalidad no coincide con el número de DNI")
        {

        }
    }
}
