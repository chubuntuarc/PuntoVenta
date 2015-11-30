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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            obtenerId("id_cliente", "cliente", "id_cliente");
            txtId.Text = texto3;
            cargarTabla();
        }

        private void cargarTabla()
        {
            xSQL.conn.Open();
            DataTable dtTabla = new DataTable();
            SqlDataAdapter daMarca = new SqlDataAdapter();
            string sql = "SELECT * FROM cliente";
            daMarca.SelectCommand = new SqlCommand(sql, xSQL.conn);
            daMarca.Fill(dtTabla);
            xSQL.conn.Close();

            foreach (DataRow row in dtTabla.Rows)
            {
                string id_usuario, nombre, paterno, materno;
                id_usuario = Convert.ToString(row[0]);
                nombre = Convert.ToString(row[1]);
                paterno = Convert.ToString(row[2]);
                materno = Convert.ToString(row[3]);
                dgvClientes.Rows.Add(id_usuario, nombre, paterno, materno);
            }

        }

        public static string texto3;
        private void obtenerId(string columna1, string tabla, string columna2)
        {
            xSQL.conn.Open();
            string cadena = "SELECT TOP 1 " + columna1 + " FROM " + tabla + "  ORDER BY " + columna2 + " DESC ";
            string value = "";
            SqlCommand obtener = new SqlCommand(cadena, xSQL.conn);
            SqlDataReader reader = obtener.ExecuteReader();
            if (reader.Read() == true)
            {
                string obt = reader[columna2].ToString();
                int folio = Convert.ToInt32(obt);
                int suma = ++folio;
                if (suma <= 9)
                {
                    value = "0" + Convert.ToString(suma);
                    texto3 = value;
                }
                else
                {
                    value = Convert.ToString(suma);
                    texto3 = value;
                }
            }
            xSQL.conn.Close();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_Inserta_Cliente", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = 0;
            cmd.Parameters.Add(folio);

            SqlParameter nombre = new SqlParameter("@cNombre", SqlDbType.VarChar, 50);
            nombre.Value = txtUsuario.Text;
            cmd.Parameters.Add(nombre);

            SqlParameter paterno = new SqlParameter("@cApaterno", SqlDbType.VarChar, 50);
            paterno.Value = txtPaterno.Text;
            cmd.Parameters.Add(paterno);

            SqlParameter materno = new SqlParameter("@cAmaterno", SqlDbType.VarChar, 50);
            materno.Value = txtMaterno.Text;
            cmd.Parameters.Add(materno);

            SqlParameter telefono = new SqlParameter("@cTelefono", SqlDbType.VarChar, 50);
            telefono.Value = txtTelefono.Text;
            cmd.Parameters.Add(telefono);

            SqlParameter celular = new SqlParameter("@cCelular", SqlDbType.VarChar, 50);
            celular.Value = txtCelular.Text;
            cmd.Parameters.Add(celular);

            SqlParameter direccion = new SqlParameter("@cDireccion", SqlDbType.VarChar, 80);
            direccion.Value = txtDireccion.Text;
            cmd.Parameters.Add(direccion);

            SqlParameter estado = new SqlParameter("@cEstatus", SqlDbType.VarChar, 20);
            estado.Value = "Activo";
            cmd.Parameters.Add(estado);

            SqlParameter limite = new SqlParameter("@mLimCredito", SqlDbType.Money);
            limite.Value = txtLimite.Text;
            cmd.Parameters.Add(limite);

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

        public string idCli;
        public string nombreCli;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditarClientes editar = new frmEditarClientes();
            editar.txtId.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            editar.txtUsuario.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            editar.txtPaterno.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            editar.txtMaterno.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            idCli = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            nombreCli = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            editar.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(dgvClientes.Visible)
            {
                dgvClientes.Visible = false;
            }
            else
            {
                dgvClientes.Visible = true;
            }
        }
    }
}
