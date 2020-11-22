using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using System.Threading;
using Form_Menu;
using System.Linq;

namespace Forms
{
    public partial class FrmMenu : Form
    {
        #region Atributos
        private Thread news;
        private delegate void ActualizarTextBox(string news);
        private static event ActualizarTextBox Abrir;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor sin parámetros del formulario.
        /// </summary>
        public FrmMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region Cargar
        /// <summary>
        /// Carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Inventario.CargaInformacion();
            cmbListados.DataSource = null;
        }
        #endregion

        #region Agregar producto
        /// <summary>
        /// Abre el formulario de Alta producto para ingresarlo manualmente al negocio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmAlta alta = new FrmAlta();
            if (alta.ShowDialog() == DialogResult.OK)
            {
                dgvListados.DataSource = null;
                dgvListados.DataSource = Inventario.ListadoProductos;
                MessageBox.Show("Se agregó el producto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Comprar
        /// <summary>
        /// Abre el formulario de Compras para realizarla manualmente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmCompra compra = new FrmCompra();
            if(compra.ShowDialog() == DialogResult.OK)
            {
                dgvListados.DataSource = null;
                dgvListados.DataSource = Inventario.ListadoCompras;
                MessageBox.Show("Se agregó la venta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Acciones rápidas
        /// <summary>
        /// Hardcodea nuevos productos y los guarda en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHardcodeProd_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario.HardcodearProductos();
                dgvListados.DataSource = null;
                dgvListados.DataSource = Inventario.ListadoProductos;
                this.btnHardcodeProd.Enabled = false;

                MessageBox.Show("Los productos se agregaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ProductoException)
            {
                MessageBox.Show("Los productos ya existen en el negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Hardcodea nuevas ventas y las guarda en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHardcodeVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario.HardcodearVentas();
                dgvListados.DataSource = null;
                dgvListados.DataSource = Inventario.ListadoCompras;
                this.btnHardcodeVentas.Enabled = false;

                MessageBox.Show("Las ventas se realizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (VentaException)
            {
                MessageBox.Show("Ha ocurrido un error en las ventas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Archivos
        /// <summary>
        /// Serializa el listado de los Productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArchivos_Click(object sender, EventArgs e)
        {
            Inventario.Guardar(Inventario.ListadoProductos);
            MessageBox.Show("Se serializaron los productos.");
        }
        #endregion

        #region Reportes
        /// <summary>
        /// Muestra los listados según el item seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbListados_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbListados.SelectedItem.ToString())
            {
                case "Productos":
                    dgvListados.DataSource = null;
                    dgvListados.DataSource = Inventario.ListadoProductos;
                    break;
                case "Clientes":
                    dgvListados.DataSource = null;
                    dgvListados.DataSource = Inventario.ListadoClientes;
                    break;
                case "Empleados":
                    dgvListados.DataSource = null;
                    dgvListados.DataSource = Inventario.ListadoEmpleados;
                    break;
                case "Ventas":
                    dgvListados.DataSource = null;
                    dgvListados.DataSource = Inventario.ListadoCompras;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Newsletter - Nuevos clientes
        /// <summary>
        /// Asigno un método al evento Abrir y lo lanzo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrirLocal_Click(object sender, EventArgs e)
        {
            Abrir += AbrirLocal;
            Abrir("Se abrieron las puertas del local");
        }

        /// <summary>
        /// Se ejecuta el método por el evento Abrir.
        /// Se muestra mensaje por pantalla y permite el ingreso de clientes al local.
        /// </summary>
        /// <param name="news"></param>
        private void AbrirLocal(string news)
        {
            MessageBox.Show(news);
            IngresoClientes();
            btnAbrirLocal.Enabled = false;
        }

        /// <summary>
        /// Si el evento se lanzó, inicio el hilo para que vayan ingresando los clientes.
        /// </summary>
        private void IngresoClientes()
        {
            if (Abrir != null)
            {
                if (this.news != null && this.news.IsAlive)
                {
                    this.news.Abort();
                }
                else
                {
                    news = new Thread(NuevosClientes);
                    news.Start();
                }
            }
        }

        /// <summary>
        /// Ingresan clientes al local. Se van registrando como nuevos clientes del negocio cada 5 segundos.
        /// Lanzo alerta en sección de Newsletter donde se informa el reciente ingreso de cada cliente.
        /// </summary>
        private void NuevosClientes()
        {
            try
            {
                Queue<Cliente> cola = Inventario.HardcodearNuevosClientes();

                for (int i = 0; i < cola.Count; i++)
                {
                    Thread.Sleep(5000);
                    Inventario.ListadoClientes += cola.ElementAt(i);
                    DataBase.InsertarCliente(cola.ElementAt(i));
                    ActualizarNewsLetter(DateTime.Now.ToString() + $" ¡Se ha registrado un nuevo cliente! Bienvenidx {cola.ElementAt(i).Nombre} {cola.ElementAt(i).Apellido}" + Environment.NewLine);
                }
            }
            catch (ClienteException)
            {
                MessageBox.Show("El cliente ya se encuentra registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Delego la acción de actualizar el Newsletter a mi delegado de tipo ActualizarTextBox,
        /// ya que el control pertenece al hilo principal.
        /// </summary>
        /// <param name="texto"></param>
        private void ActualizarNewsLetter(string texto)
        {
            if (this.txtNews.InvokeRequired)
            {
                ActualizarTextBox delegado = new ActualizarTextBox(ActualizarNewsLetter);
                this.BeginInvoke(delegado, new Object[] { texto });
            }
            else
            {
                this.txtNews.Text += texto;
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Cierra la aplicación junto con los hilos que estén corriendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                Show();
            }
            else
            {
                if (this.news != null && this.news.IsAlive)
                {
                    news.Abort();
                }

                Application.Exit();
            }
        }
        #endregion
    }
}
