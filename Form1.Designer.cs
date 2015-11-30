namespace JeraDesktop
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.pBusqueda = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.pbCerrarTurno = new System.Windows.Forms.PictureBox();
            this.pbRetiro = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.pbSuperior = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrarTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRetiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuperior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSlogan
            // 
            this.lblSlogan.AutoSize = true;
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.ForeColor = System.Drawing.Color.Honeydew;
            this.lblSlogan.Location = new System.Drawing.Point(12, 9);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(356, 55);
            this.lblSlogan.TabIndex = 3;
            this.lblSlogan.Text = "Punto de Venta";
            // 
            // timer1
            // 
            this.timer1.Interval = 35;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.SlateGray;
            this.pMenu.Controls.Add(this.label1);
            this.pMenu.Controls.Add(this.pictureBox2);
            this.pMenu.Location = new System.Drawing.Point(12, 79);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(239, 580);
            this.pMenu.TabIndex = 7;
            this.pMenu.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuración";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::JeraDesktop.Properties.Resources.ic_settings_white_24dp_2x;
            this.pictureBox2.Location = new System.Drawing.Point(15, 498);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(551, 2);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(115, 31);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(460, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(115, 31);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Usuario";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(425, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Subtotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(467, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(413, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Impuesto";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubtotal.Location = new System.Drawing.Point(557, 552);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(140, 26);
            this.txtsubtotal.TabIndex = 13;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuesto.Location = new System.Drawing.Point(557, 589);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(140, 26);
            this.txtImpuesto.TabIndex = 13;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(557, 627);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(139, 38);
            this.txtTotal.TabIndex = 13;
            this.txtTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // pBusqueda
            // 
            this.pBusqueda.Controls.Add(this.txtBusqueda);
            this.pBusqueda.Controls.Add(this.dgvBusqueda);
            this.pBusqueda.Location = new System.Drawing.Point(291, 79);
            this.pBusqueda.Name = "pBusqueda";
            this.pBusqueda.Size = new System.Drawing.Size(406, 239);
            this.pBusqueda.TabIndex = 15;
            this.pBusqueda.Visible = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(3, 10);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(400, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.Location = new System.Drawing.Point(3, 36);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.RowHeadersVisible = false;
            this.dgvBusqueda.Size = new System.Drawing.Size(400, 200);
            this.dgvBusqueda.TabIndex = 0;
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            // 
            // dgvVenta
            // 
            this.dgvVenta.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Producto,
            this.Cantidad,
            this.Clave,
            this.IVA,
            this.Importe,
            this.Impuestos});
            this.dgvVenta.Location = new System.Drawing.Point(54, 76);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.RowHeadersVisible = false;
            this.dgvVenta.Size = new System.Drawing.Size(643, 466);
            this.dgvVenta.TabIndex = 16;
            this.dgvVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 130;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Precio";
            this.Clave.Name = "Clave";
            // 
            // IVA
            // 
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // Impuestos
            // 
            this.Impuestos.HeaderText = "Impuestos";
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(608, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "Usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(586, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "►";
            // 
            // pbOk
            // 
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Image = global::JeraDesktop.Properties.Resources.ic_check_box_black_24dp_2x;
            this.pbOk.Location = new System.Drawing.Point(707, 617);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(48, 48);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOk.TabIndex = 21;
            this.pbOk.TabStop = false;
            this.pbOk.Click += new System.EventHandler(this.pbOk_Click);
            // 
            // pbCerrarTurno
            // 
            this.pbCerrarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCerrarTurno.Image = global::JeraDesktop.Properties.Resources.ic_lock_black_24dp_2x;
            this.pbCerrarTurno.Location = new System.Drawing.Point(703, 187);
            this.pbCerrarTurno.Name = "pbCerrarTurno";
            this.pbCerrarTurno.Size = new System.Drawing.Size(48, 48);
            this.pbCerrarTurno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCerrarTurno.TabIndex = 20;
            this.pbCerrarTurno.TabStop = false;
            this.pbCerrarTurno.Click += new System.EventHandler(this.pbCerrarTurno_Click);
            // 
            // pbRetiro
            // 
            this.pbRetiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRetiro.Image = global::JeraDesktop.Properties.Resources.ic_touch_app_black_24dp_2x;
            this.pbRetiro.Location = new System.Drawing.Point(703, 133);
            this.pbRetiro.Name = "pbRetiro";
            this.pbRetiro.Size = new System.Drawing.Size(48, 48);
            this.pbRetiro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbRetiro.TabIndex = 19;
            this.pbRetiro.TabStop = false;
            this.pbRetiro.Click += new System.EventHandler(this.pbRetiro_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::JeraDesktop.Properties.Resources.ic_find_in_page_black_24dp_2x;
            this.pictureBox3.Location = new System.Drawing.Point(703, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSalir.Image = global::JeraDesktop.Properties.Resources.ic_cancel_black_24dp_2x;
            this.pbSalir.Location = new System.Drawing.Point(12, 611);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(48, 48);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSalir.TabIndex = 5;
            this.pbSalir.TabStop = false;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // pbMenu
            // 
            this.pbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenu.Image = global::JeraDesktop.Properties.Resources.ic_menu_black_36dp_2x;
            this.pbMenu.Location = new System.Drawing.Point(12, 76);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(36, 33);
            this.pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenu.TabIndex = 4;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.pbMenu_Click);
            // 
            // pbSuperior
            // 
            this.pbSuperior.Image = global::JeraDesktop.Properties.Resources.images;
            this.pbSuperior.Location = new System.Drawing.Point(-2, -1);
            this.pbSuperior.Name = "pbSuperior";
            this.pbSuperior.Size = new System.Drawing.Size(1183, 71);
            this.pbSuperior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSuperior.TabIndex = 1;
            this.pbSuperior.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JeraDesktop.Properties.Resources.gray_background1;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1183, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 671);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.pbCerrarTurno);
            this.Controls.Add(this.pbRetiro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pBusqueda);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pbSalir);
            this.Controls.Add(this.pbMenu);
            this.Controls.Add(this.lblSlogan);
            this.Controls.Add(this.pbSuperior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jera | Punto de Venta | Valkiria Tech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pBusqueda.ResumeLayout(false);
            this.pBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrarTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRetiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuperior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSuperior;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.PictureBox pbMenu;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvVenta;
        public System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pbRetiro;
        private System.Windows.Forms.PictureBox pbCerrarTurno;
        private System.Windows.Forms.PictureBox pbOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
    }
}

