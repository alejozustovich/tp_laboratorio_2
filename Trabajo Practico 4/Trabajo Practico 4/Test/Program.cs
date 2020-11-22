using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Acuña Zustovich, Alejo. 2D. TP4.";

            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA INICIAR ----------->");
            Console.ReadKey();
            Console.Clear();

            Inventario.CargaInformacion();

            Console.WriteLine(Inventario.Listar(Inventario.ETipo.Cliente));
            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA VER LISTADO DE EMPLEADOS ----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(Inventario.Listar(Inventario.ETipo.Empleado));
            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA VER LISTADO DE PRODUCTOS ----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(Inventario.Listar(Inventario.ETipo.Producto));
            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA VER LISTADO DE VENTAS ----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(Inventario.Listar(Inventario.ETipo.Compra));
            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA AGREGAR NUEVOS PRODUCTOS ----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("<----------- LISTADO DE NUEVOS PRODUCTOS ----------->\n");
            try
            {
                Console.WriteLine(Inventario.HardcodearProductos2());
            }
            catch (ProductoException)
            {
                Console.WriteLine("Ocurrió un error al cargar los productos.");
            }
            try
            {
                Inventario.ListadoProductos += new Producto(1, "Testing", 109, 50);
            }
            catch (ProductoException)
            {
                Console.WriteLine("El producto ya se encuentra registrado.");
            }

            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA REALIZAR VENTAS ----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("<----------- LISTADO DE NUEVAS VENTAS ----------->\n");
            try
            {
                Console.WriteLine(Inventario.HardcodearVentas2());
            }
            catch (VentaException)
            {
                Console.WriteLine("Ocurrió un error al cargar las ventas.");
            }
            try
            {
                Inventario.ListadoCompras += new Compra(1, Inventario.ListadoEmpleados[0], Inventario.ListadoClientes[1], Inventario.ListadoProductos[2], 1, 100);
            }
            catch (VentaException)
            {
                Console.WriteLine("Ya existe una venta cerrada con el número de ticket.");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("<----------- PRESIONE UNA TECLA PARA SALIR ----------->");
            Console.ReadKey();
        }
    }
}
