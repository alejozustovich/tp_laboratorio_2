using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea el nombre de una persona.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea el apellido de una persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna, valida y setea el DNI de una persona.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura: retorna y setea la nacionalidad de una persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set {this.nacionalidad = value; }
        }

        /// <summary>
        /// Permisos de escritura: valida y setea el valor string del DNI de una persona.
        /// </summary>
        public string StringToDNI
        {
            set 
            { 
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores 
        /// <summary>
        /// Constructor por defecto de persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado: asigna el nombre, apellido y nacionalidad de la persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado: asigna el DNI de la persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado: asigna el DNI de la persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el número de DNI coincida con la nacionalidad correspondiente de la persona.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El número de DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 1 && dato <= 89999999)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException();
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException();
            }
            else
            {
                throw new NacionalidadInvalidaException("¡¡Número Fuera de rango!!");
            }
        }

        /// <summary>
        /// Valida que los caracteres del DNI sean numéricos y coincidan con la nacionalidad correspondiente de la persona.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El número de DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                int dni = int.Parse(dato);
                return ValidarDni(nacionalidad, dni);
            }
            catch (FormatException)
            {
                throw new DniInvalidoException("La cadena ingresada no corresponde a un número de Dni");
            }
        }

        /// <summary>
        /// Valida que el nombre de la persona no contenga caracteres incorrectos.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>El nombre validado.</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrWhiteSpace(dato))
            {
                Regex rx = new Regex(@"[^A-Za-z\s]");
                
                if (!rx.IsMatch(dato))
                {
                    return dato;
                }
            }

            return null;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra todos los datos de una persona.
        /// </summary>
        /// <returns>Los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return sb.ToString();
        }
        #endregion
    }
}

