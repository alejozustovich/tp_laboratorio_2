using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Form_Menu
{
    public partial class FrmCompra : Form
    {
        #region Atributos
        private Producto p1;
        private int precio;
        private int cantidad;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmCompra()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        /// <summary>
        /// Carga: asigno listados a ComboBox y muestro todo vacío.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCompra_Load(object sender, EventArgs e)
        {
            cmbClientes.DataSource = Inventario.ListadoClientes;
            cmbEmpleados.DataSource = Inventario.ListadoEmpleados;
            cmbProducto.DataSource = Inventario.ListadoProductos;
            cmbClientes.SelectedItem = null;
            cmbEmpleados.SelectedItem = null;
            cmbProducto.SelectedItem = null;
            lblClien.Text = string.Empty;
            lblEmpl.Text = string.Empty;
            lblProd.Text = string.Empty;
            lblPrecio.Text = string.Empty;
            btnComprar.Enabled = false;
        }
        #endregion

        #region Seleccion de items
        /// <summary>
        /// Completa el detalle de facturación de Producto con el seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProducto.SelectedItem != null)
            {
                lblProd.Text = cmbProducto.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Completa el detalle de facturación de Cliente con el seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbClientes.SelectedItem != null)
            {
                lblClien.Text = cmbClientes.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Completa el detalle de facturación de Vendedor con el seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEmpleados.SelectedItem != null)
            {
                lblEmpl.Text = cmbEmpleados.SelectedItem.ToString();
            }
        }
        #endregion

        #region Calcular precio
        /// <summary>
        /// Calcula el precio segun producto y cantidad ingresada.
        /// Habilita el boton de compra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbProducto.SelectedItem != null)
                {
                    p1 = (Producto)Inventario.ListadoProductos.BuscarDescripcion(cmbProducto.SelectedItem.ToString());
                }
                else
                {
                    throw new ProductoException("Se debe ingresar un producto.");
                }

                precio = int.Parse(txtCantidad.Text) * p1.Precio;
                lblPrecio.Text = precio.ToString();
                precio = 0;
                btnComprar.Enabled = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato incorrecto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Comprar
        /// <summary>
        /// Crea un nuevo objeto Compra con los atributos elegidos.
        /// Registra la compra en la base de datos e imprime un ticket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                cantidad = int.Parse(txtCantidad.Text.ToString());

                if (p1.Stock > cantidad)
                {
                    if(lblEmpl.Text.ToString() != string.Empty && lblClien.Text.ToString() != string.Empty && lblProd.Text.ToString() != string.Empty)
                    {
                        Compra c1 = new Compra(
                            Inventario.ListadoCompras.ProximoID(),
                            (Empleado)Inventario.ListadoEmpleados.BuscarDescripcion(lblEmpl.Text),
                            (Cliente)Inventario.ListadoClientes.BuscarDescripcion(lblClien.Text),
                            p1, cantidad, Convert.ToInt32(lblPrecio.Text.ToString()));

                        Inventario.ListadoCompras += c1;
                        DataBase.InsertarVenta(c1);
                        MessageBox.Show("¡¡Muchas gracias por su compra!!\n\n" + c1.Mostrar());
                        c1.Guardar(c1.ToString());
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        throw new VentaException("Existen campos sin completar.");
                    }
                }
                else
                {
                    throw new ProductoException("No hay stock disponible.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato incorrecto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Salir del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
