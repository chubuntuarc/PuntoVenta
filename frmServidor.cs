using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeraDesktop
{
    public partial class frmServidor : Form
    {
        public frmServidor()
        {
            InitializeComponent();
        }

        private void frmServidor_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmConfiguracion config = new frmConfiguracion();
            config.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (chkSeguridad.Checked)
            {
                Cadena.escribirDatosSeguridad(txtServidor.Text, txtBase.Text);
                try
                {
                    xSQL.conn.Open();
                    Mensajes.Aviso("Conexión éxitosa");
                    this.Close();
                    frmConfiguracion conf = new frmConfiguracion();
                    conf.Show();
                }
                catch(Exception ex)
                {
                    Mensajes.Error("Fallo la conexión \n" + ex.Message);
                }
                finally
                {
                    xSQL.conn.Close();
                }
            }
            else
            {
                Cadena.guardarDatos(txtServidor.Text, txtBase.Text, txtUsuario.Text, txtContrasena.Text);
                try
                {
                    xSQL.conn.Open();
                    Mensajes.Aviso("Conexión éxitosa");
                    this.Close();
                    frmConfiguracion conf = new frmConfiguracion();
                    conf.Show();
                }
                catch (Exception ex)
                {
                    Mensajes.Error("Fallo la conexión \n" + ex.Message);
                }
                finally
                {
                    xSQL.conn.Close();
                }
            }
        }

        private void chkSeguridad_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSeguridad.Checked)
            {
                txtUsuario.ReadOnly = true;
                txtContrasena.ReadOnly = true;
            }
            else
            {
                txtUsuario.ReadOnly = false;
                txtContrasena.ReadOnly = false;
            }
        }
    }
}
