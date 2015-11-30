using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JeraDesktop
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            obtenerId("id_usuario", "usuario", "id_usuario");
            txtId.Text = texto3;
            cargarTabla();
        }

        private void cargarTabla()
        {
            xSQL.conn.Open();
            DataTable dtTabla = new DataTable();
            SqlDataAdapter daMarca = new SqlDataAdapter();
            string sql = "SELECT * FROM usuario";
            daMarca.SelectCommand = new SqlCommand(sql, xSQL.conn);
            daMarca.Fill(dtTabla);
            xSQL.conn.Close();

            foreach (DataRow row in dtTabla.Rows)
            {
                string id_usuario, nombre;
                id_usuario = Convert.ToString(row[0]);
                nombre = Convert.ToString(row[1]);
                dgvUsuarios.Rows.Add(id_usuario, nombre);
            }

        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion conf = new frmConfiguracion();
            conf.Show();
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
            if(txtContrasena.Text != txtConfirmar.Text)
            {
                Mensajes.Aviso("No coinciden las contraseñas.\n Vuelve a intentarlo");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SP_Inserta_usuario", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                folio.Direction = ParameterDirection.InputOutput;
                folio.Value = 0;
                cmd.Parameters.Add(folio);

                SqlParameter nombre = new SqlParameter("@cNombre", SqlDbType.VarChar, 50);
                nombre.Value = txtUsuario.Text;
                cmd.Parameters.Add(nombre);

                SqlParameter contrasena = new SqlParameter("@cContrasena", SqlDbType.VarChar, 50);
                contrasena.Value = Encriptador.RijndaelSimple.EncryptKey(txtContrasena.Text);
                cmd.Parameters.Add(contrasena);

                SqlParameter estado = new SqlParameter("@cEstatus", SqlDbType.VarChar, 20);
                estado.Value = "Activo";
                cmd.Parameters.Add(estado);

                SqlParameter admin = new SqlParameter("@bEs_Administrador", SqlDbType.Bit);
                admin.Value = chkAdministrador.Checked;
                cmd.Parameters.Add(admin);

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
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(dgvUsuarios.Visible == false)
            {
                dgvUsuarios.Visible = true;
            }
            else
            {
                dgvUsuarios.Visible = false;
            }

        }
        public string idUsr;
        public string nombreUsr;
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            frmEditaUsuario editar = new frmEditaUsuario();
            editar.txtId.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            editar.txtUsuario.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            idUsr = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            nombreUsr = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            editar.Show();
            this.Hide();
        }
    }
}
