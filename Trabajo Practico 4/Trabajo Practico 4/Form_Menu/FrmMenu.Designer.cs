namespace Forms
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvListados = new System.Windows.Forms.DataGridView();
            this.gbReportes = new System.Windows.Forms.GroupBox();
            this.lblConsultar = new System.Windows.Forms.Label();
            this.cmbListados = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnArchivos = new System.Windows.Forms.Button();
            this.lblExportar = new System.Windows.Forms.Label();
            this.lblComprar = new System.Windows.Forms.Label();
            this.lblAgregarProducto = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.gbNews = new System.Windows.Forms.GroupBox();
            this.txtNews = new System.Windows.Forms.TextBox();
            this.btnAbrirLocal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHardcodeProd = new System.Windows.Forms.Button();
            this.btnHardcodeVentas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListados)).BeginInit();
            this.gbReportes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbNews.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(1111, 648);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(121, 31);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvListados
            // 
            this.dgvListados.AllowUserToAddRows = false;
            this.dgvListados.AllowUserToDeleteRows = false;
            this.dgvListados.AllowUserToResizeColumns = false;
            this.dgvListados.AllowUserToResizeRows = false;
            this.dgvListados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListados.ColumnHeadersHeight = 25;
            this.dgvListados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListados.EnableHeadersVisualStyles = false;
            this.dgvListados.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvListados.Location = new System.Drawing.Point(18, 100);
            this.dgvListados.Name = "dgvListados";
            this.dgvListados.ReadOnly = true;
            this.dgvListados.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvListados.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListados.Size = new System.Drawing.Size(1181, 342);
            this.dgvListados.TabIndex = 11;
            // 
            // gbReportes
            // 
            this.gbReportes.Controls.Add(this.lblConsultar);
            this.gbReportes.Controls.Add(this.cmbListados);
            this.gbReportes.Controls.Add(this.dgvListados);
            this.gbReportes.Location = new System.Drawing.Point(12, 12);
            this.gbReportes.Name = "gbReportes";
            this.gbReportes.Size = new System.Drawing.Size(1220, 463);
            this.gbReportes.TabIndex = 20;
            this.gbReportes.TabStop = false;
            this.gbReportes.Text = "Reportes";
            // 
            // lblConsultar
            // 
            this.lblConsultar.AutoSize = true;
            this.lblConsultar.Location = new System.Drawing.Point(913, 22);
            this.lblConsultar.Name = "lblConsultar";
            this.lblConsultar.Size = new System.Drawing.Size(54, 13);
            this.lblConsultar.TabIndex = 23;
            this.lblConsultar.Text = "Consultar:";
            // 
            // cmbListados
            // 
            this.cmbListados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListados.FormattingEnabled = true;
            this.cmbListados.Items.AddRange(new object[] {
            "Productos",
            "Ventas",
            "Clientes",
            "Empleados"});
            this.cmbListados.Location = new System.Drawing.Point(973, 19);
            this.cmbListados.Name = "cmbListados";
            this.cmbListados.Size = new System.Drawing.Size(226, 21);
            this.cmbListados.TabIndex = 0;
            this.cmbListados.SelectedIndexChanged += new System.EventHandler(this.cmbListados_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnArchivos);
            this.groupBox1.Controls.Add(this.lblExportar);
            this.groupBox1.Controls.Add(this.lblComprar);
            this.groupBox1.Controls.Add(this.lblAgregarProducto);
            this.groupBox1.Controls.Add(this.btnAgregarProducto);
            this.groupBox1.Controls.Add(this.btnComprar);
            this.groupBox1.Location = new System.Drawing.Point(12, 495);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 185);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // btnArchivos
            // 
            this.btnArchivos.BackColor = System.Drawing.Color.Transparent;
            this.btnArchivos.BackgroundImage = global::Form_Menu.Properties.Resources.Archivos;
            this.btnArchivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivos.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnArchivos.Location = new System.Drawing.Point(109, 125);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(174, 43);
            this.btnArchivos.TabIndex = 3;
            this.btnArchivos.UseVisualStyleBackColor = false;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // lblExportar
            // 
            this.lblExportar.AutoSize = true;
            this.lblExportar.Location = new System.Drawing.Point(6, 140);
            this.lblExportar.Name = "lblExportar";
            this.lblExportar.Size = new System.Drawing.Size(102, 13);
            this.lblExportar.TabIndex = 24;
            this.lblExportar.Text = "Serializar productos:";
            // 
            // lblComprar
            // 
            this.lblComprar.AutoSize = true;
            this.lblComprar.Location = new System.Drawing.Point(6, 88);
            this.lblComprar.Name = "lblComprar";
            this.lblComprar.Size = new System.Drawing.Size(91, 13);
            this.lblComprar.TabIndex = 23;
            this.lblComprar.Text = "Realizar compras:";
            // 
            // lblAgregarProducto
            // 
            this.lblAgregarProducto.AutoSize = true;
            this.lblAgregarProducto.Location = new System.Drawing.Point(6, 39);
            this.lblAgregarProducto.Name = "lblAgregarProducto";
            this.lblAgregarProducto.Size = new System.Drawing.Size(97, 13);
            this.lblAgregarProducto.TabIndex = 22;
            this.lblAgregarProducto.Text = "Agregar productos:";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarProducto.BackgroundImage = global::Form_Menu.Properties.Resources.AgregarProducto;
            this.btnAgregarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnAgregarProducto.Location = new System.Drawing.Point(109, 24);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(174, 43);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.Transparent;
            this.btnComprar.BackgroundImage = global::Form_Menu.Properties.Resources.Comprar;
            this.btnComprar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnComprar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnComprar.Location = new System.Drawing.Point(109, 73);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(174, 43);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // gbNews
            // 
            this.gbNews.Controls.Add(this.txtNews);
            this.gbNews.Location = new System.Drawing.Point(587, 495);
            this.gbNews.Name = "gbNews";
            this.gbNews.Size = new System.Drawing.Size(495, 185);
            this.gbNews.TabIndex = 23;
            this.gbNews.TabStop = false;
            this.gbNews.Text = "Newsletter";
            // 
            // txtNews
            // 
            this.txtNews.BackColor = System.Drawing.Color.Black;
            this.txtNews.ForeColor = System.Drawing.Color.White;
            this.txtNews.Location = new System.Drawing.Point(19, 29);
            this.txtNews.Multiline = true;
            this.txtNews.Name = "txtNews";
            this.txtNews.ReadOnly = true;
            this.txtNews.Size = new System.Drawing.Size(454, 139);
            this.txtNews.TabIndex = 0;
            // 
            // btnAbrirLocal
            // 
            this.btnAbrirLocal.BackColor = System.Drawing.Color.DarkGray;
            this.btnAbrirLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirLocal.ForeColor = System.Drawing.Color.Black;
            this.btnAbrirLocal.Location = new System.Drawing.Point(1111, 568);
            this.btnAbrirLocal.Name = "btnAbrirLocal";
            this.btnAbrirLocal.Size = new System.Drawing.Size(121, 74);
            this.btnAbrirLocal.TabIndex = 6;
            this.btnAbrirLocal.Text = "Abrir local";
            this.btnAbrirLocal.UseVisualStyleBackColor = false;
            this.btnAbrirLocal.Click += new System.EventHandler(this.btnAbrirLocal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHardcodeProd);
            this.groupBox2.Controls.Add(this.btnHardcodeVentas);
            this.groupBox2.Location = new System.Drawing.Point(351, 495);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 185);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones rápidas";
            // 
            // btnHardcodeProd
            // 
            this.btnHardcodeProd.BackColor = System.Drawing.Color.Transparent;
            this.btnHardcodeProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHardcodeProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHardcodeProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHardcodeProd.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHardcodeProd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHardcodeProd.Location = new System.Drawing.Point(11, 39);
            this.btnHardcodeProd.Name = "btnHardcodeProd";
            this.btnHardcodeProd.Size = new System.Drawing.Size(174, 43);
            this.btnHardcodeProd.TabIndex = 4;
            this.btnHardcodeProd.Text = "Hardcodear Nuevos Productos";
            this.btnHardcodeProd.UseVisualStyleBackColor = false;
            this.btnHardcodeProd.Click += new System.EventHandler(this.btnHardcodeProd_Click);
            // 
            // btnHardcodeVentas
            // 
            this.btnHardcodeVentas.BackColor = System.Drawing.Color.Transparent;
            this.btnHardcodeVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHardcodeVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHardcodeVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHardcodeVentas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHardcodeVentas.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHardcodeVentas.Location = new System.Drawing.Point(11, 110);
            this.btnHardcodeVentas.Name = "btnHardcodeVentas";
            this.btnHardcodeVentas.Size = new System.Drawing.Size(174, 43);
            this.btnHardcodeVentas.TabIndex = 5;
            this.btnHardcodeVentas.Text = "Hardcodear Nuevas Ventas";
            this.btnHardcodeVentas.UseVisualStyleBackColor = false;
            this.btnHardcodeVentas.Click += new System.EventHandler(this.btnHardcodeVentas_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1244, 692);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAbrirLocal);
            this.Controls.Add(this.gbNews);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbReportes);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListados)).EndInit();
            this.gbReportes.ResumeLayout(false);
            this.gbReportes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbNews.ResumeLayout(false);
            this.gbNews.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvListados;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesEnStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesVendidasDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn carritoDeComprasDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox gbReportes;
        private System.Windows.Forms.ComboBox cmbListados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblComprar;
        private System.Windows.Forms.Label lblAgregarProducto;
        private System.Windows.Forms.Label lblConsultar;
        private System.Windows.Forms.GroupBox gbNews;
        private System.Windows.Forms.TextBox txtNews;
        private System.Windows.Forms.Button btnAbrirLocal;
        private System.Windows.Forms.Button btnArchivos;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHardcodeProd;
        private System.Windows.Forms.Button btnHardcodeVentas;
    }
}

