using Entidades;
using Excepciones;
using System;
using System.Windows.Forms;

namespace Form_Menu
{
    public partial class FrmAlta : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmAlta()
        {
            InitializeComponent();
        }
        #endregion

        #region Agregar producto
        /// <summary>
        /// Crea un nuevo objeto Producto con los atributos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.txtID.Text);
                string descripcion = this.txtDescripcion.Text;
                double precio = double.Parse(this.txtPrecio.Text);
                int stock = int.Parse(this.txtStock.Text);

                try
                {
                    Producto p1 = new Producto(id, descripcion, (int)precio, stock);
                    Inventario.ListadoProductos += p1;
                    DataBase.InsertarProducto(p1);
                    DialogResult = DialogResult.OK;
                }
                catch (ProductoException)
                {
                    MessageBox.Show("El producto ya se encuentra registrado en el negocio.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Valores incorrectos.");
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Cierra el formulario.
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
