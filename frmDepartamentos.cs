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
    public partial class frmDepartamentos : Form
    {
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
        }

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            obtenerId("id_departamento", "departamento", "id_departamento");
            txtId.Text = texto3;
            cargarTabla();
        }

        private void cargarTabla()
        {
            xSQL.conn.Open();
            DataTable dtTabla = new DataTable();
            SqlDataAdapter daMarca = new SqlDataAdapter();
            string sql = "SELECT * FROM departamento";
            daMarca.SelectCommand = new SqlCommand(sql, xSQL.conn);
            daMarca.Fill(dtTabla);
            xSQL.conn.Close();

            foreach (DataRow row in dtTabla.Rows)
            {
                string id_departamento, nombre;
                id_departamento = Convert.ToString(row[0]);
                nombre = Convert.ToString(row[1]);
                dgvDepartamentos.Rows.Add(id_departamento, nombre);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO departamento (nombre) values('"+txtDepartamento.Text+"')", xSQL.conn);
            
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
            if(dgvDepartamentos.Visible)
            {
                dgvDepartamentos.Visible = false;
            }
            else
            {
                dgvDepartamentos.Visible = true;
            }
        }

        private void dgvDepartamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditarDepartamentos editar = new frmEditarDepartamentos();
            editar.txtId.Text = dgvDepartamentos.CurrentRow.Cells[0].Value.ToString();
            editar.txtDepartamento.Text = dgvDepartamentos.CurrentRow.Cells[1].Value.ToString();
            editar.Show();
            this.Hide();
        }
    }
}
