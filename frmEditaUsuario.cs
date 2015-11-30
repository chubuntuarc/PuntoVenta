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
    public partial class frmEditaUsuario : Form
    {
        public frmEditaUsuario()
        {
            InitializeComponent();
        }

        public string idUsr;
        public string nombreUsr;
        private void frmEditaUsuario_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmUsuarios user = new frmUsuarios();
            user.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmUsuarios user = new frmUsuarios();
            if (txtContrasena.Text != txtConfirmar.Text)
            {
                Mensajes.Aviso("No coinciden las contraseñas.\n Vuelve a intentarlo");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SP_Inserta_usuario", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                folio.Direction = ParameterDirection.InputOutput;
                folio.Value = Convert.ToInt32(txtId.Text);
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
                    user.Show();
                }
            }
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmUsuarios user = new frmUsuarios();
            DialogResult pregunta =  MessageBox.Show("¿Deseas eliminar el usuario "+txtId.Text+"?");
            if (pregunta == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("SP_Borra_usuario", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@idusuario", SqlDbType.Int);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                
        }
    }
}
