using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario() : base()
        {

        }
        
        /// <summary>
        /// Constructor parametrizado: asigna el legajo.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos del universitario.
        /// </summary>
        /// <returns>Los datos del universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);
            
            return sb.ToString();
        }
        /// <summary>
        /// Indica las clases en que participa el universitario.
        /// </summary>
        /// <returns>El nombre de las clases.</returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Valida que la instancia de la clase Universitario sea igual al objeto recibido.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son iguales, caso contrario False.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                if (((Universitario)obj).legajo == this.legajo || ((Universitario)obj).DNI == this.DNI)
                {
                    return true;
                }
            }
                
            return false;
        }
        
        /// <summary>
        /// Compara si 2 universitarios son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son iguales, caso contrario False.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Compara si 2 universitarios son diferentes.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son diferentes, caso contrario False.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
