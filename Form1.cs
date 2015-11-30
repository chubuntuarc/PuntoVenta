using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace JeraDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbSuperior;
            lblUsuario.Parent = pbSuperior;
            label5.Parent = pbSuperior;
            label6.Parent = pbSuperior;
            timer2.Start();
            lblFecha.Parent = pbSuperior;
            timer1.Start();
            dgvVenta.Focus();
            xSQL.conecta();
            Generales.privilegios();
        }



        private void pbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
                Util.Animate(pMenu, Util.Effect.Slide, 350, 0);

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (pMenu.Visible == true)
            {
                Util.Animate(pMenu, Util.Effect.Slide, 100, 0);
            }
            if (pBusqueda.Visible == true)
            {
                Util.Animate(pBusqueda, Util.Effect.Slide, 100, 0);
            }
        }

        //Timer que controla la animación de inicio del sistema
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .10;
            if (this.Opacity == 1)
            {
                timer1.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Today.ToString();
            lblFecha.Text = DateTime.Now.ToLongTimeString();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Util.Animate(pBusqueda, Util.Effect.Slide, 250, 0);
            txtBusqueda.Text = "";
            txtBusqueda.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaBusqueda()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM producto");
            xSQL.conn.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            frmConfiguracion conf = new frmConfiguracion();
            frmRetiro reg = new frmRetiro();
            frmBloqueado bloquear = new frmBloqueado();
            if (e.KeyData == (Keys.Control | Keys.M)) Util.Animate(pMenu, Util.Effect.Slide, 350, 0);
            if (e.KeyData == (Keys.Control | Keys.B)) Util.Animate(pBusqueda, Util.Effect.Slide, 350, 0);
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.C)) conf.Show();
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.R)) reg.Show();
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.B))
            {
                xSQL.conn.Open();
                SqlCommand cmd = new SqlCommand("update turnos set estado_actual = 'Bloqueado' where caja = " + Generales.cajaActual + " and cajero = " + Generales.cajeroActual + "", xSQL.conn);
                cmd.ExecuteNonQuery();
                xSQL.conn.Close();
                frmBloqueado bloqueado = new frmBloqueado();
                bloqueado.Show();
                this.Hide();
            }
            if (e.KeyData == (Keys.Control | Keys.Q)) Application.Exit();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            frmConfiguracion conf = new frmConfiguracion();
            frmRetiro reg = new frmRetiro();
            frmBloqueado bloquear = new frmBloqueado();
            if (e.KeyData == (Keys.Control | Keys.M)) Util.Animate(pMenu, Util.Effect.Slide, 350, 0);
            if (e.KeyData == (Keys.Control | Keys.B)) Util.Animate(pBusqueda, Util.Effect.Slide, 350, 0);
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.C)) conf.Show();
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.R)) reg.Show();
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.B))
            {
                xSQL.conn.Open();
                SqlCommand cmd = new SqlCommand("update turnos set estado_actual = 'Bloqueado' where caja = " + Generales.cajaActual + " and cajero = " + Generales.cajeroActual + "", xSQL.conn);
                cmd.ExecuteNonQuery();
                xSQL.conn.Close();
                frmBloqueado bloqueado = new frmBloqueado();
                bloqueado.Show();
                this.Hide();
            }
            if (e.KeyData == (Keys.Control | Keys.Q)) Application.Exit();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select id_producto as Id, nombre_producto as Producto, precio as Precio, tasa_de_impuesto as IVA from Producto where nombre_producto like '%" + txtBusqueda.Text + "%'", xSQL.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "busqueda");
            dgvBusqueda.DataSource = ds.Tables["busqueda"];
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Se define una lista temporal de registro seleccionados
            //
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
            DataGridViewRow cellSelecion = dgvBusqueda.CurrentRow as DataGridViewRow;
            rowSelected.Add(cellSelecion);
            decimal sum = 0;
            decimal subtotal = 0;
            foreach (DataGridViewRow row in rowSelected)
            {
                decimal iva = Convert.ToDecimal(row.Cells["IVA"].Value) / 100 + 1;
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                decimal suma = precio * iva;
                dgvVenta.Rows.Add(new object[] {
                                            row.Cells["Id"].Value,
                                            row.Cells["Producto"].Value,
                                            1,
                                            row.Cells["Precio"].Value,
                                            row.Cells["IVA"].Value,
                                            suma
                                            });
            }
            for (int i = 0; i < dgvVenta.RowCount; i++)
            {
                subtotal = subtotal + Convert.ToDecimal(dgvVenta.Rows[i].Cells[3].Value);
                sum = sum + Convert.ToDecimal(dgvVenta.Rows[i].Cells[5].Value);
                txtsubtotal.Text = "$ " + subtotal.ToString("0.##"); 
                txtTotal.Text = "$ " + sum.ToString("0.##");
            }
        }

        private void AbrirTurno()
        {
            string sMac = Generales.MacAdress();
            Boolean bPasa = false;

            SqlCommand SP = new SqlCommand("valida_Caja", xSQL.conn);
            SP.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlMac = new SqlParameter("@cMac", SqlDbType.VarChar);
            sqlMac.Value = sMac;
            SP.Parameters.Add(sqlMac);


            SqlParameter sqlPasa = new SqlParameter("@bPasa", SqlDbType.Bit);
            sqlPasa.Direction = ParameterDirection.Output;
            SP.Parameters.Add(sqlPasa);

            try
            {
                xSQL.conn.Open();
                SP.ExecuteNonQuery();

                bPasa = (Boolean)sqlPasa.Value;

                if (!bPasa)
                {
                    Mensajes.Error("Este equipo no está registrado como caja");
                }
                else
                {
                    Mensajes.Aviso("Turno Abierto");
                }
            }
            catch (Exception ex)
            {
                Mensajes.Error("Se ha producido un error: \n" + ex.Message);
            }
            finally
            {
                xSQL.conn.Close();
            }

        }

        private void pbCerrarTurno_Click(object sender, EventArgs e)
        {
            frmCerrarTurno cerrar = new frmCerrarTurno();
            cerrar.Show();
            this.Hide();
        }

        private void pbRetiro_Click(object sender, EventArgs e)
        {
            frmRetiro retiro = new frmRetiro();
            retiro.ShowDialog();
        }

    }
}


