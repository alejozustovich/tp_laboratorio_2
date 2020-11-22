using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Empleado : Persona
    {
        #region Atributos
        int legajo;
        int cantidadVentas;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Empleado()
        {

        }

        /// <summary>
        /// Constructor parametrizado: asigna los atributos.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="ventas"></param>
        public Empleado(int legajo, string nombre, string apellido, int ventas) : base(nombre, apellido)
        {
            this.legajo = legajo;
            this.cantidadVentas = ventas;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura para el Legajo.
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; } 
            set { this.legajo = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para las Ventas.
        /// </summary>
        public int Ventas
        {
            get { return this.cantidadVentas; }
            set { this.cantidadVentas = value; }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga == : evalúa si el Empleado existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator ==(List<Empleado> listadoEmpleados, Empleado empleado)
        {
            foreach (Empleado e in listadoEmpleados)
            {
                if (e.Legajo == empleado.Legajo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga != : evalúa si el Empleado no existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator !=(List<Empleado> listadoEmpleados, Empleado empleado)
        {
            return !(listadoEmpleados == empleado);
        }

        /// <summary>
        /// Sobrecarga + : agrega un Empleado al listado.
        /// </summary>
        /// <param name="listadoEmpleados"></param>
        /// <param name="empleado"></param>
        /// <returns>El listado de empleados.</returns>
        public static List<Empleado> operator +(List<Empleado> listadoEmpleados, Empleado empleado)
        {
            if (listadoEmpleados != empleado)
            {
                listadoEmpleados.Add(empleado);
            }

            return listadoEmpleados;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace públicos todos los datos del empleado.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("EMPLEADO LEGAJO: " + this.Legajo);
            sb.Append(base.Mostrar());

            return sb.ToString();
        }
        #endregion
    }
}
