using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        /// <summary>
        /// Excepción: el alumno está repetido.
        /// </summary>
        public AlumnoRepetidoException():base("Alumno Repetido.")
        {

        }
    }
}
