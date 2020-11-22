using System.Collections.Generic;
using System.Text;
using Excepciones;

namespace Entidades
{
    public class Cliente : Persona
    {
        #region Atributos
        int codigoCliente;
        int cantidadCompras;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor parametrizado: asigna atributos.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="compras"></param>
        public Cliente(int codigo, string nombre, string apellido, int compras) : base(nombre, apellido)
        {
            this.codigoCliente = codigo;
            this.cantidadCompras = compras;
        }

        /// <summary>
        /// Constructor parametrizado: asigna compras en 0 para nuevos clientes que aún no compraron.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public Cliente(int codigo, string nombre, string apellido) : base(nombre, apellido)
        {
            this.codigoCliente = codigo;
            this.cantidadCompras = 0;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura para el Código.
        /// </summary>
        public int Codigo
        {
            get { return this.codigoCliente; }
            set { this.codigoCliente = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la cantidad de compras.
        /// </summary>
        public int Compras
        {
            get { return this.cantidadCompras; }
            set { this.cantidadCompras = value; }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga == : evalúa si el cliente existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator == (List<Cliente> listadoClientes, Cliente cliente)
        {
            foreach  (Cliente c in listadoClientes)
            {
                if (c.Codigo == cliente.Codigo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga != : evalúa si el cliente no existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator != (List<Cliente> listadoClientes, Cliente cliente)
        {
            return !(listadoClientes == cliente);
        }

        /// <summary>
        /// Agrega un nuevo cliente a la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>El listado de clientes.</returns>
        public static List<Cliente> operator +(List<Cliente> listadoClientes, Cliente cliente)
        {
            if (listadoClientes != cliente)
            {
                listadoClientes.Add(cliente);
            }
            else
            {
                throw new ClienteException("El cliente ya se encuentra registrado.");
            }

            return listadoClientes;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace públicos todos los datos del cliente.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLIENTE CÓDIGO: " + this.Codigo);
            sb.Append(base.Mostrar());

            return sb.ToString();
        }
        #endregion
    }
}
