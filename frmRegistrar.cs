using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeraDesktop
{
    public partial class frmRegistrar : Form
    {
        public frmRegistrar()
        {
            InitializeComponent();
        }

        private void frmRegistrar_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            txtMac.Text = Generales.MacAdress();
            cargarTabla();
        }


        private void cargarTabla()
        {
            xSQL.conn.Open();
            DataTable dtTabla = new DataTable();
            SqlDataAdapter daMarca = new SqlDataAdapter();
            string sql = "SELECT * FROM cajas where habilitada = 1";
            daMarca.SelectCommand = new SqlCommand(sql, xSQL.conn);
            daMarca.Fill(dtTabla);
            xSQL.conn.Close();

            foreach (DataRow row in dtTabla.Rows)
            {
                string idCaja, nombrecaja, macCaja;
                idCaja = Convert.ToString(row[0]);
                nombrecaja = Convert.ToString(row[1]);
                macCaja = Convert.ToString(row[2]);
                dataGridView1.Rows.Add(idCaja, nombrecaja, macCaja);
            }

        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_Inserta_Mac", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = 0;
            cmd.Parameters.Add(folio);

            SqlParameter mac = new SqlParameter("@cMac", SqlDbType.VarChar, 20);
            mac.Value = txtMac.Text;
            cmd.Parameters.Add(mac);

            SqlParameter nombre = new SqlParameter("@cNombre", SqlDbType.VarChar, 20);
            nombre.Value = txtNombre.Text;
            cmd.Parameters.Add(nombre);


            try
            {
                xSQL.conn.Open();
                cmd.ExecuteNonQuery();
                Mensajes.Aviso("Registro guardado con éxito ");
            }
            catch (Exception ex)
            {
                Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
            }
            finally
            {
                xSQL.conn.Close();
                this.Close();
                frmConfiguracion conf = new frmConfiguracion();
                conf.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmEditaRegistro edita = new frmEditaRegistro();
            edita.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(dataGridView1.Visible)
            {
                dataGridView1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditaRegistro editar = new frmEditaRegistro();
            editar.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editar.txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editar.txtMac.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            editar.Show();
            this.Hide();
        }
    }
}
