using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor() : base()
        {

        }

        /// <summary>
        /// Constructor estático.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor parametrizado: asigna la clase.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra las clases del día del profesor.
        /// </summary>
        /// <returns>El listado de clases.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos del profesor.
        /// </summary>
        /// <returns>Los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            
            return sb.ToString();
        }

        /// <summary>
        /// Agrega dos clases del dia a un profesor.
        /// </summary>
        private void _randomClases()
        {
            Universidad.EClases aux;

            while (this.clasesDelDia.Count <2)
            {
                aux = (Universidad.EClases)Profesor.random.Next(1, 4);
                this.clasesDelDia.Enqueue(aux);
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Valida si el profesor está en la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>True si el profesor está en la clase, caso contrario False.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Valida si el profesor no está en la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>True si el profesor no está, caso contrario False.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Valida si el objeto es de tipo Profesor.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si es Profesor, caso contrario False.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Profesor)
            {
                return base.Equals(obj);
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga el método ToString: muestra los datos del profesor.
        /// </summary>
        /// <returns>Los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
