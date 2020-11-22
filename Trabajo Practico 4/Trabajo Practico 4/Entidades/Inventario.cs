using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace Entidades
{
    public abstract class Inventario
    {
        #region Atributos
        private static List<Producto> listadoProductos = new List<Producto>();
        private static List<Cliente> listadoClientes = new List<Cliente>();
        private static List<Empleado> listadoEmpleados = new List<Empleado>();
        private static List<Compra> listadoCompras = new List<Compra>();
        
        public enum ETipo { Cliente, Empleado, Producto, Compra }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura para productos.
        /// </summary>
        public static List<Producto> ListadoProductos
        {
            get { return listadoProductos; }
            set { listadoProductos = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para clientes.
        /// </summary>
        public static List<Cliente> ListadoClientes
        {
            get { return listadoClientes; }
            set { listadoClientes = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para empleados.
        /// </summary>
        public static List<Empleado> ListadoEmpleados
        {
            get { return listadoEmpleados; }
            set { listadoEmpleados = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para compras.
        /// </summary>
        public static List<Compra> ListadoCompras
        {
            get { return listadoCompras; }
            set { listadoCompras = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Carga la información del negocio desde la base de datos.
        /// </summary>
        public static void CargaInformacion()
        {
            ListadoClientes = DataBase.ImportarClientes();
            ListadoEmpleados = DataBase.ImportarEmpleados();
            ListadoProductos = DataBase.ImportarProductos();
            ListadoCompras = DataBase.ImportarVentas();
        }

        /// <summary>
        /// Serializa un archivo con los productos.
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static bool Guardar(List<Producto> productos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Productos.xml";
                XmlSerializer xml = new XmlSerializer(typeof(List<Producto>));

                XML<List<Producto>> archivo = new XML<List<Producto>>();

                archivo.Guardar(path, productos);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }

        /// <summary>
        /// Lista la entidad del tipo que sea pasado por parámetro.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Los datos de la entidad.</returns>
        public static string Listar(ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            switch (tipo)
            {
                case ETipo.Cliente:
                    sb.AppendLine("<----------- LISTADO DE CLIENTES ----------->\n");
                    foreach (Cliente c in ListadoClientes)
                    {
                        sb.AppendLine(c.Mostrar());
                    }
                    break;

                case ETipo.Empleado:
                    sb.AppendLine("<----------- LISTADO DE EMPLEADOS ----------->\n");
                    foreach (Empleado e in ListadoEmpleados)
                    {
                        sb.AppendLine(e.Mostrar());
                    }
                    break;

                case ETipo.Producto:
                    sb.AppendLine("<----------- LISTADO DE PRODUCTOS ----------->\n");
                    foreach (Producto p in ListadoProductos)
                    {
                        sb.AppendLine(p.Mostrar());
                    }
                    break;

                case ETipo.Compra:
                    sb.AppendLine("<----------- LISTADO DE VENTAS ----------->\n");
                    foreach (Compra p in ListadoCompras)
                    {
                        sb.AppendLine(p.Mostrar());
                    }
                    break;

                default:
                    break;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hardcodea productos. Método llamado desde las acciones rápidas del Formulario.
        /// </summary>
        public static void HardcodearProductos()
        {
            Producto p1 = new Producto(ListadoProductos.ProximoID(), "Portátil Ideapd 320", 448, 100);
            ListadoProductos += p1;
            DataBase.InsertarProducto(p1);

            Producto p2 = new Producto(ListadoProductos.ProximoID(), "Impresora HP Deskjet 3720", 59, 80);
            ListadoProductos += p2;
            DataBase.InsertarProducto(p2);

            Producto p3 = new Producto(ListadoProductos.ProximoID(), "Monitor 27 LED Full HD", 245, 75);
            ListadoProductos += p3;
            DataBase.InsertarProducto(p3);
        }

        /// <summary>
        /// Hardcodea otro grupo de productos. El método se llama desde la consola Test,
        /// únicamente para probar funcionalidades, no los inserta en la base de datos.
        /// </summary>
        /// <returns>La lista de nuevos productos.</returns>
        public static string HardcodearProductos2()
        {
            Producto p1 = new Producto(ListadoProductos.ProximoID(), "Notebook Lenovo", 1200, 50);
            ListadoProductos += p1;

            Producto p2 = new Producto(ListadoProductos.ProximoID(), "Mouse Inalambrico", 100, 85);
            ListadoProductos += p2;

            Producto p3 = new Producto(ListadoProductos.ProximoID(), "Teclado Inalambrico", 245, 90);
            ListadoProductos += p3;

            return p1.Mostrar() + p2.Mostrar() + p3.Mostrar();
        }

        /// <summary>
        /// Harcodea nuevas ventas. El método se llama desde las acciones rápidas del Formulario.
        /// </summary>
        public static void HardcodearVentas()
        {
            Compra c1 = new Compra(ListadoCompras.ProximoID(), ListadoEmpleados[5], ListadoClientes[2], ListadoProductos[3], 2, ListadoProductos[3].Precio * 2);
            Compra.AgregarCompra(c1);
            DataBase.InsertarVenta(c1);
            
            Compra c2 = new Compra(ListadoCompras.ProximoID(), ListadoEmpleados[3], ListadoClientes[4], ListadoProductos[5], 3, ListadoProductos[5].Precio * 3);
            Compra.AgregarCompra(c2);
            DataBase.InsertarVenta(c2);
        }

        public static string HardcodearVentas2()
        {
            Compra c1 = new Compra(ListadoCompras.ProximoID(), ListadoEmpleados[2], ListadoClientes[5], ListadoProductos[2], 2, ListadoProductos[2].Precio * 2);
            Compra.AgregarCompra(c1);

            Compra c2 = new Compra(ListadoCompras.ProximoID(), ListadoEmpleados[1], ListadoClientes[3], ListadoProductos[4], 3, ListadoProductos[4].Precio * 3);
            Compra.AgregarCompra(c2);

            return c1.Mostrar() + c2.Mostrar();
        }

        /// <summary>
        /// Hardcodea una cola de clientes. El método se llama desde el Hilo que corre en el formulario.
        /// </summary>
        /// <returns></returns>
        public static Queue<Cliente> HardcodearNuevosClientes()
        {
            Queue<Cliente> cola = new Queue<Cliente>();

            cola.Enqueue(new Cliente(ListadoClientes.ProximoID(), "Johnny", "Depp"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+1, "Scarlett", "Johansson"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+2, "Leonardo", "DiCaprio"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+3, "Hugh", "Jackman"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+4, "Anya", "Taylor-Joy"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+5, "Robert", "De Niro"));
            cola.Enqueue(new Cliente(ListadoClientes.ProximoID()+6, "Charlize", "Theron"));

            return cola;
        }
        #endregion
    }
}
