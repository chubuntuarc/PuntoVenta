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
    public partial class frmEditarDepartamentos : Form
    {
        public frmEditarDepartamentos()
        {
            InitializeComponent();
        }

        private void frmEditarDepartamentos_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDepartamentos depa = new frmDepartamentos();
            depa.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Departamento set nombre = '"+txtDepartamento.Text+"'  where id_departamento = "+txtId.Text+"", xSQL.conn);

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
            frmDepartamentos user = new frmDepartamentos();
            DialogResult pregunta = MessageBox.Show("¿Deseas eliminar el departamento " + txtId.Text + "?");
            if (pregunta == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("delete from departamento where id_departamento = "+txtId.Text+"", xSQL.conn);

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
