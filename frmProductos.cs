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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            llenarDepartamentos();
            obtenerId("id_producto","producto","id_producto");
            txtId.Text = texto3;
            cargarTabla();
        }

        private void cargarTabla()
        {
            xSQL.conn.Open();
            DataTable dtTabla = new DataTable();
            SqlDataAdapter daMarca = new SqlDataAdapter();
            string sql = "SELECT * FROM producto";
            daMarca.SelectCommand = new SqlCommand(sql, xSQL.conn);
            daMarca.Fill(dtTabla);
            xSQL.conn.Close();

            foreach (DataRow row in dtTabla.Rows)
            {
                string id_usuario, nombre, clave, precio;
                id_usuario = Convert.ToString(row[0]);
                nombre = Convert.ToString(row[1]);
                clave = Convert.ToString(row[5]);
                precio = Convert.ToString(row[7]);
                dgvProductos.Rows.Add(id_usuario, nombre, clave, precio);
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

        private void llenarDepartamentos()
        {
            xSQL.conn.Open();
            DataSet dsd = new DataSet();
            SqlDataAdapter dad = new SqlDataAdapter("Select nombre from departamento", xSQL.conn);
            dad.Fill(dsd, "departamento");
            cbDepartamento.DataSource = dsd.Tables[0].DefaultView;
            cbDepartamento.DataSource = dsd.Tables[0].DefaultView;
            cbDepartamento.DisplayMember = "nombre";
            xSQL.conn.Close();

        }

        public int idDepa;
        private void obteneridDepartamento()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("Select id_departamento from departamento where nombre = '" + cbDepartamento.Text.ToString() + "'", xSQL.conn);
            SqlDataReader leer = cmd.ExecuteReader();
            if(leer.Read())
            {
                idDepa = leer.GetInt32(0);
            }
            xSQL.conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            obteneridDepartamento();
            SqlCommand cmd = new SqlCommand("SP_Inserta_Producto", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nIdProducto", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = 0;
            cmd.Parameters.Add(folio);

            SqlParameter nombre = new SqlParameter("@cProducto", SqlDbType.VarChar, 50);
            nombre.Value = txtProducto.Text;
            cmd.Parameters.Add(nombre);

            SqlParameter departamento = new SqlParameter("@nDepartamento", SqlDbType.Int);
            departamento.Value = idDepa;
            cmd.Parameters.Add(departamento);

            SqlParameter barras = new SqlParameter("@cCodBarras", SqlDbType.VarChar, 50);
            barras.Value = txtBarras.Text;
            cmd.Parameters.Add(barras);

            SqlParameter cuenta = new SqlParameter("@bSeCuenta", SqlDbType.Bit);
            cuenta.Value = chkCuenta.Checked;
            cmd.Parameters.Add(cuenta);

            SqlParameter clave = new SqlParameter("@cClave", SqlDbType.VarChar, 50);
            clave.Value = txtClave.Text;
            cmd.Parameters.Add(clave);

            SqlParameter interes = new SqlParameter("@nTasaInteres", SqlDbType.Decimal);
            interes.Value = txtImpuesto.Text;
            cmd.Parameters.Add(interes);

            SqlParameter precio = new SqlParameter("@nPrecio", SqlDbType.Money);
            precio.Value = txtPrecio.Text;
            cmd.Parameters.Add(precio);

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
            if (dgvProductos.Visible == true)
            {
                dgvProductos.Visible = false;
            }
            else
            {
                dgvProductos.Visible = true;
            }
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditaProductos editar = new frmEditaProductos();
            editar.txtId.Text = dgvProductos.CurrentRow.Cells[0].ToString();
            editar.txtProducto.Text = dgvProductos.CurrentRow.Cells[1].ToString();
            editar.txtClave.Text = dgvProductos.CurrentRow.Cells[2].ToString();
            editar.Show();
            this.Hide();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditaProductos editar = new frmEditaProductos();
            editar.txtId.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            editar.txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            editar.txtClave.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            editar.Show();
            this.Hide();
        }
    }
}
