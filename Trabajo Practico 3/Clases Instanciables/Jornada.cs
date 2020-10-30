using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clases;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto: instancia la lista de Alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado: asigna las clases y el instructor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clases = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set
            {
                if (value != null)
                {
                    this.alumnos = value;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea la clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clases; }
            set
            {
                if (this.instructor == value)
                {
                    this.clases = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea el instructor.
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set
            {
                if (value == this.clases)
                {
                    this.instructor = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Valida si el alumno está en la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno está, caso contrario False.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a==j.clases)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida si el alumno no está en la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno no está, caso contrario False.</returns>
        public static bool operator !=(Jornada j, Alumno a) 
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>La jornada con el alumno agregado (en caso de que no esté).</returns>
        public static Jornada operator +(Jornada j, Alumno a) 
        {
            foreach (Alumno item in j.Alumnos)
            {
                if (j!=a)
                {
                    j.Alumnos.Add(a);
                }
            }
            return j;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos en un archivo en la ruta.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True en caso de que se haya guardado, caso contrario lanza excepción.</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string ruta = System.IO.Directory.GetCurrentDirectory() + @"\Archivos";
                System.IO.Directory.CreateDirectory(ruta);

                Texto txt = new Texto();
                
                txt.Guardar((ruta + @"\Jornada.txt"), jornada.ToString());

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee el archivo de la ruta y lo retorna como string.
        /// </summary>
        /// <returns>Los datos del archivo, caso contrario lanza excepción.</returns>
        public static string Leer()
        {
            try
            {
                string jornada = string.Empty;
                Texto txt = new Texto();

                txt.Leer((System.IO.Directory.GetCurrentDirectory() + @"\Archivos\Jornada.txt"), out jornada);
                
                return jornada;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Muestra todos los datos de la Jornada.
        /// </summary>
        /// <returns>Los datos de la Jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this.clases.ToString() + " POR " + this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            
            return sb.ToString();
        }
        #endregion
    }
}
