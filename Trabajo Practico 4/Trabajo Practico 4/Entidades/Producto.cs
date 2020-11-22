using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        #region Atributos
        private int id;
        private string descripcion;
        private int precio;
        private int unidadesVendidas;
        private int unidadesEnStock;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto: asigna unidades vendidas en 0.
        /// </summary>
        public Producto()
        {
            this.Vendidos = 0;
        }

        /// <summary>
        /// Constructor parametrizado: asigna todos los atributos menos las unidades vendidas.
        /// Este constructor se llama para nuevos productos que ingresan y que aún no se vendieron.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(int id, string descripcion, int precio, int stock) : this()
        {
            this.Descripcion = descripcion;
            this.Id = id;
            this.Precio = precio;
            this.Stock = stock;
        }

        /// <summary>
        /// Constructor parametrizado: asigna unidades vendidas.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="vendidas"></param>
        public Producto(int id, string descripcion, int precio, int stock, int vendidas) : this (id,descripcion,precio,stock)
        {
            this.Vendidos = vendidas;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura para el Id.
        /// </summary>
        public int Id 
        { 
            get { return this.id; }
            set 
            {
                try
                {
                    this.id = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura para la Descripción.
        /// </summary>
        public string Descripcion 
        { 
            get { return this.descripcion; } 
            set { this.descripcion = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para el Precio.
        /// </summary>
        public int Precio
        {
            get { return this.precio; }
            set 
            {
                try
                {
                    precio = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura para las unidades vendidas.
        /// </summary>
        public int Vendidos
        {
            get { return this.unidadesVendidas; }
            set 
            {
                try
                {
                    unidadesVendidas = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Permisos de lectura y escritura para las unidades en stock.
        /// </summary>
        public int Stock
        {
            get { return this.unidadesEnStock; }
            set 
            {
                try
                {
                    unidadesEnStock = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Evalúa si el producto ya existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator == (List<Producto> listadoProductos, Producto producto)
        {
            foreach (Producto p in listadoProductos)
            {
                if (p.Id == producto.Id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Evalúa si el producto no existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator != (List<Producto> listadoProductos, Producto producto)
        {
            return !(listadoProductos == producto);
        }

        /// <summary>
        /// Agrega un producto al listado y lo retorna.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si se pudo agregar, caso contrario lanza excepción.</returns>
        public static List<Producto> operator + (List<Producto> listadoProductos, Producto producto)
        {
            if(listadoProductos != producto)
            {
                listadoProductos.Add(producto);
                return listadoProductos;
            }
            else
            {
                throw new ProductoException("El producto ya se encuentra registrado.");
            }
        }

        /// <summary>
        /// Sobrecarga el método ToString para mostrar la descripción del producto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Descripcion;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace públicos todos los atributos del Producto.
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("PRODUCTO CÓDIGO: " + this.Id);
            sb.AppendLine("DESCRIPCIÓN: " + this.ToString());
            sb.AppendLine("PRECIO: " + this.Precio);
            sb.AppendLine("VENDIDOS: " + this.Vendidos + " u.");
            sb.AppendLine("STOCK: " + this.Stock + " u.");
            sb.AppendLine("");

            return sb.ToString();
        }
        #endregion
    }
}