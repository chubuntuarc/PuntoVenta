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
    public partial class frmEditaProductos : Form
    {
        public frmEditaProductos()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductos pro = new frmProductos();
            pro.Show();
        }

        private void frmEditaProductos_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            llenarDepartamentos();
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

        public string idDepa;
        private void obteneridDepartamento()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("Select id_departamento from departamento where nombre = '" + cbDepartamento.SelectedIndex.ToString() + "'", xSQL.conn);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                idDepa = leer.ToString();
            }
            xSQL.conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            obteneridDepartamento();
            SqlCommand cmd = new SqlCommand("SP_Inserta_Producto", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nIdProducto", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = Convert.ToInt32(txtId.Text) ;
            cmd.Parameters.Add(folio);

            SqlParameter nombre = new SqlParameter("@cProducto", SqlDbType.VarChar, 50);
            nombre.Value = txtProducto.Text;
            cmd.Parameters.Add(nombre);

            SqlParameter departamento = new SqlParameter("@nDepartamento", SqlDbType.Int);
            departamento.Value = Convert.ToInt32(idDepa);
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
                Mensajes.Aviso("Registro modificado con éxito ");
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmProductos user = new frmProductos();
            DialogResult pregunta = MessageBox.Show("¿Deseas eliminar el producto " + txtId.Text + "?");
            if (pregunta == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("SP_Borra_Producto", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@idProducto", SqlDbType.Int);
                folio.Value = Convert.ToInt32(txtId.Text);
                cmd.Parameters.Add(folio);

                try
                {
                    xSQL.conn.Open();
                    cmd.ExecuteNonQuery();
                    Mensajes.Aviso("Registro eliminado con éxito ");
                }
                catch (Exception ex)
                {
                    Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
                }
                finally
                {
                    xSQL.conn.Close();
                    this.Close();
                    user.Show();
                }
            }
            else
            {
                this.Close();
                user.Show();
            }
        }
    }
}
