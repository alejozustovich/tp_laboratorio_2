using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Vacía todo el contenido de la calculadora y deshabilita los botones de conversión.
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = String.Empty;
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            cmbOperador.Text = String.Empty;
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Llama al método Limpiar.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la operación correspondiente entre los números.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Llama al método Operar, y muestra el resultado en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtNumero1 != null && txtNumero2 != null)
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Llama al método DecimalBinario y muestra el resultado en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                this.btnConvertirADecimal.Enabled = true;
                this.btnConvertirABinario.Enabled = false;
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
            }
        }

        /// <summary>
        /// Llama al método BinarioDecimal y muestra el resultado en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = false;
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
