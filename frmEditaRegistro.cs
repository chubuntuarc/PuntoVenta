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
    public partial class frmEditaRegistro : Form
    {
        public frmEditaRegistro()
        {
            InitializeComponent();
        }

        private void frmEditaRegistro_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmRegistrar user = new frmRegistrar();
            DialogResult pregunta = MessageBox.Show("¿Deseas eliminar la caja " + txtId.Text + "?");
            if (pregunta == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("SP_Borra_Mac", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@idCaja", SqlDbType.Int);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_Inserta_Mac", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = Convert.ToInt32(txtId.Text); 
            cmd.Parameters.Add(folio);

            SqlParameter nombre = new SqlParameter("@cNombre", SqlDbType.VarChar, 50);
            nombre.Value = txtNombre.Text;
            cmd.Parameters.Add(nombre);

            SqlParameter mac = new SqlParameter("@cMac", SqlDbType.VarChar, 50);
            mac.Value = txtMac.Text;
            cmd.Parameters.Add(mac);

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
}
