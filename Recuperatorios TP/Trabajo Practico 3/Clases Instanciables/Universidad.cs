using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{ 
    public class Universidad
    {
        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto: inicializa las listas.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura: retorna y setea la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna y setea la lista de Jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna y setea la lista de Instructores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna y setea la lista de Jornadas según un índice.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>La Jornada correspondiente, caso contrario Null.</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Valida si un alumno pertenece a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si pertenece, caso contrario False.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item==a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Valida si un alumno no pertenece a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si no pertenece, caso contrario False.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Valida si un profesor pertenece a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si pertenece, caso contrario False.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Valida si un profesor no pertenece a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si no pertenece, caso contrario False.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Valida si el profesor está disponible para dar clases.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>El profesor disponible, caso contrario lanza excepcion.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item==clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Valida si el profesor no está disponible para dar clases.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>El profesor, caso contrario lanza excepcion.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor itemProfesor in u.Instructores)
            {
                if (itemProfesor != clase)
                {
                    return itemProfesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una jornada completa a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>La Universidad.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j1 = new Jornada(clase, (g == clase));
            
            for (int i = 0; i < g.Alumnos.Count; i++)
            {
                if (g.Alumnos[i] == clase)
                {
                    j1.Alumnos.Add(g.Alumnos[i]);
                }
            }

            g.Jornadas.Add(j1);
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>La Universidad con el alumno agregado, caso contrario lanza excepcion.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u!=a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>La Universidad.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u!=i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Muestra todos los datos de la Universidad.
        /// </summary>
        /// <returns>Los datos de la Universidad.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Toma los datos de una Universidad y los guarda en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True si pudo guardar, caso contrario lanza excepcion.</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                string aux = System.IO.Directory.GetCurrentDirectory()+ @"\Archivos";
                System.IO.Directory.CreateDirectory(aux);
                
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Guardar((aux + @"\Universidad.xml"), uni);
                
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee los datos de una Universidad de un archivo XML.
        /// </summary>
        /// <returns>La Universidad, caso contrario lanza excepcion.</returns>
        public static Universidad Leer()
        {
            try
            {
                Universidad universidad = new Universidad();
                
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Leer((System.IO.Directory.GetCurrentDirectory() + @"\Archivos\Universidad.xml"), out universidad);
                
                return universidad;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Retorna todos los datos de la Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>La cadena con los datos de la Universidad.</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("JORNADA: ");
            
            foreach (Jornada item in this.Jornadas)
            {
                sb.AppendFormat(item.ToString());
            }
            
            return sb.ToString();
        }
        #endregion
    }
}
