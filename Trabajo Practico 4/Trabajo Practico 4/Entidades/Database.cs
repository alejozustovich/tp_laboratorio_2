using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Excepciones;

namespace Entidades
{
    public static class DataBase
    {
        #region Atributos
        private const string cadena = @"Server=.\SQLEXPRESS;Database=VentasTP4;Integrated security=true";
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estático: instancia la conexión y el comando.
        /// </summary>
        static DataBase()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = cadena;

            comando = new SqlCommand();
            comando.Connection = conexion;
        }
        #endregion

        #region Importar Clientes
        /// <summary>
        /// Importa los clientes desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> ImportarClientes()
        {
            try
            {
                List<Cliente> c1 = new List<Cliente>();
                comando.CommandText = "SELECT * FROM Clientes";
                conexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    c1 += new Cliente(int.Parse(dr["id"].ToString()), dr["nombre"].ToString(), dr["apellido"].ToString(), int.Parse(dr["compras"].ToString()));
                }

                return c1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Importar Empleados
        /// <summary>
        /// Importa los Empleados desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Empleado> ImportarEmpleados()
        {
            try
            {
                List<Empleado> e1 = new List<Empleado>();
                comando.CommandText = "SELECT * FROM Empleados";
                conexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    e1 += new Empleado(int.Parse(dr["id"].ToString()), dr["nombre"].ToString(), dr["apellido"].ToString(), int.Parse(dr["ventas"].ToString()));
                }

                return e1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Importar Productos
        /// <summary>
        /// Importa los Productos desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ImportarProductos()
        {
            try
            {
                List<Producto> p1 = new List<Producto>();
                comando.CommandText = "SELECT * FROM Productos";
                conexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    p1 += new Producto(int.Parse(dr["id"].ToString()), dr["descripcion"].ToString(), int.Parse(dr["precio"].ToString()), int.Parse(dr["stock"].ToString()), int.Parse(dr["vendidos"].ToString()));
                }

                return p1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Importar Ventas
        /// <summary>
        /// Importa las Ventas desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Compra> ImportarVentas()
        {
            try
            {
                List<Compra> compra = new List<Compra>();
                comando.CommandText = "SELECT Ventas.id, Ventas.id_empleado, Ventas.id_cliente, Detalle.id_producto, Detalle.cantidad, Ventas.importe " +
                "FROM Ventas INNER JOIN Detalle ON Ventas.id = Detalle.id_venta";
                conexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    compra += new Compra(int.Parse(dr["id"].ToString()),
                         (Empleado)Inventario.ListadoEmpleados.BuscarID(int.Parse(dr["id_empleado"].ToString())),
                         (Cliente)Inventario.ListadoClientes.BuscarID(int.Parse(dr["id_cliente"].ToString())),
                         (Producto)Inventario.ListadoProductos.BuscarID(int.Parse(dr["id_producto"].ToString())),
                         int.Parse(dr["cantidad"].ToString()), int.Parse(dr["importe"].ToString()));
                }

                return compra;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Insertar Cliente
        /// <summary>
        /// Ingresa un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static bool InsertarCliente(Cliente c1)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO Clientes VALUES (@nombre , @apellido, @compras)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@nombre", c1.Nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", c1.Apellido));
                comando.Parameters.Add(new SqlParameter("@compras", c1.Compras));
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }

            return true;
        }
        #endregion

        #region Insertar Producto
        /// <summary>
        /// Ingresa un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool InsertarProducto(Producto p1)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO Productos VALUES (@descripcion , @precio, @vendidos, @stock)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@descripcion", p1.Descripcion));
                comando.Parameters.Add(new SqlParameter("@precio", p1.Precio));
                comando.Parameters.Add(new SqlParameter("@vendidos", p1.Vendidos));
                comando.Parameters.Add(new SqlParameter("@stock", p1.Stock));

                return comando.ExecuteNonQuery() != -1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Insertar Venta
        /// <summary>
        /// Ingresa una nueva venta en la base de datos.
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static bool InsertarVenta(Compra c1)
        {
            try
            {
                comando.CommandText = "INSERT INTO Ventas VALUES (@id_empleado , @id_cliente, @importe)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@id_empleado", c1.Empleado.Legajo));
                comando.Parameters.Add(new SqlParameter("@id_cliente", c1.Cliente.Codigo));
                comando.Parameters.Add(new SqlParameter("@importe", c1.Precio));
                conexion.Open();

                if (comando.ExecuteNonQuery() > 0)
                {
                    try
                    {
                        comando.CommandText = "INSERT INTO Detalle VALUES (@id_venta , @id_producto, @cantidad)";
                        comando.Parameters.Clear();
                        comando.Parameters.Add(new SqlParameter("@id_venta", c1.NroTicket));
                        comando.Parameters.Add(new SqlParameter("@id_producto", c1.Producto.Id));
                        comando.Parameters.Add(new SqlParameter("@cantidad", c1.Cantidad));

                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new DBException(e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }

            return true;
        }
        #endregion
    }
}

