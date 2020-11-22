using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace Entidades
{
    public class Compra
    {
        #region Atributos
        private int nroTicket;
        private int precio;
        private int cantidad;
        private Producto producto;
        private Cliente comprador;
        private Empleado vendedor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Compra()
        {
            
        }

        /// <summary>
        /// Constructor parametrizado: asigna los atributos de la compra.
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="precio"></param>
        /// <param name="comprador"></param>
        /// <param name="vendedor"></param>
        public Compra(int ticket, Empleado empleado, Cliente cliente, Producto producto, int cantidad, int precio)
        {
            this.NroTicket = ticket;
            this.vendedor = empleado;
            this.comprador = cliente;
            this.producto = producto;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura para el Ticket.
        /// </summary>
        public int NroTicket
        { 
            get { return this.nroTicket; }
            set
            {
                try
                {
                    this.nroTicket = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de sólo lectura para el Producto.
        /// </summary>
        public Producto Producto { get { return this.producto; } }

        /// <summary>
        /// Permisos de lectura y escritura para la cantidad.
        /// </summary>
        public int Cantidad 
        { 
            get { return this.cantidad; }
            set
            {
                try
                {
                    this.cantidad = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura para el precio.
        /// </summary>
        public int Precio 
        { 
            get { return this.precio; }
            set
            {
                try
                {
                    this.precio = value;
                }
                catch(FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de sólo lectura para el Cliente.
        /// </summary>
        public Cliente Cliente { get { return this.comprador; } }

        /// <summary>
        /// Permisos de sólo lectura para el Empleado.
        /// </summary>
        public Empleado Empleado { get { return this.vendedor; } }

        /// <summary>
        /// Propiedad que retorna la descripción del Producto.
        /// </summary>
        private string Descripcion { get { return this.Producto.Descripcion; } }

        /// <summary>
        /// Propiedad que retorna el nombre del Comprador.
        /// </summary>
        private string Comprador { get { return this.comprador.Apellido + ", " + this.comprador.Nombre; } }

        /// <summary>
        /// Propiedad que retorna el nombre del Vendedor.
        /// </summary>
        private string Vendedor { get { return this.vendedor.Apellido + ", " + this.vendedor.Nombre; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace públicos los atributos de la compra.
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            return this.ToString();
        }

        /// <summary>
        /// Actualiza los atributos cada vez que se agregue una nueva compra.
        /// </summary>
        /// <param name="compra"></param>
        public static void AgregarCompra(Compra compra)
        {
            Inventario.ListadoCompras += compra;
            compra.Producto.Stock -= compra.Cantidad;
            compra.Producto.Vendidos += compra.Cantidad;
            compra.Empleado.Ventas++;
            compra.Cliente.Compras++;
        }

        /// <summary>
        /// Guarda el archivo de la compra en la ruta especificada.
        /// </summary>
        /// <returns>Los datos del archivo, caso contrario lanza excepción.</returns>
        public bool Guardar(string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Ticket_" + this.NroTicket.ToString() + ".txt";

                Texto texto = new Texto();

                texto.Guardar(path, datos);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Evalúa si la compra ya existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator ==(List<Compra> listadoCompras, Compra compra)
        {
            foreach (Compra c in listadoCompras)
            {
                if (c.NroTicket == compra.NroTicket)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Evalúa si la compra no existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator !=(List<Compra> listadoCompras, Compra compra)
        {
            return !(listadoCompras == compra);
        }

        /// <summary>
        /// Agrega una compra al listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si se pudo agregar, caso contrario lanza excepcion.</returns>
        public static List<Compra> operator +(List<Compra> listadoCompras, Compra compra)
        {
            if (listadoCompras != compra)
            {
                listadoCompras.Add(compra);
                return listadoCompras;
            }
            else
            {
                throw new VentaException("El ticket corresponde a una venta ya cerrada.");
            }
        }

        /// <summary>
        /// Sobrecarga el método ToString mostrando los atributos de la compra.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("TICKET : " + this.NroTicket.ToString());
            sb.AppendLine("---------------->");
            sb.AppendLine("");
            sb.AppendLine("PRODUCTOS : " + this.Producto.Descripcion + " (" + this.Cantidad.ToString() + ")");
            sb.AppendLine("PRECIO : $" + this.Precio.ToString());
            sb.AppendLine("CLIENTE: " + this.Comprador);
            sb.AppendLine("VENDEDOR: " + this.Vendedor);
            sb.AppendLine("");

            return sb.ToString();
        }
        #endregion
    }
}
