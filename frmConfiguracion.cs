using System;
using System.Windows.Forms;

namespace JeraDesktop
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pbServidor_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(Generales.servidor) == Generales.nAdmin | Generales.nAdmin == 1)
            {
                frmServidor servidor = new frmServidor();
                servidor.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
            
        }

        private void pbUsuarios_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Generales.usuarios) == Generales.nAdmin | Generales.nAdmin == 1)
            {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
            this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Generales.clientes) == Generales.nAdmin | Generales.nAdmin == 1)
            {
                frmClientes cliente = new frmClientes();
                cliente.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Generales.productos) == Generales.nAdmin | Generales.nAdmin == 1)
            {
                frmProductos producto = new frmProductos();
                producto.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Generales.departamentos) == Generales.nAdmin | Generales.nAdmin == 1)
            {
                frmDepartamentos depa = new frmDepartamentos();
                depa.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Generales.registarr) == Generales.nAdmin | Generales.nAdmin == 1)
            {
                frmRegistrar reg = new frmRegistrar();
                reg.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a esta configuración");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Generales.nAdmin == 1)
            {
                frmModulos modulos = new frmModulos();
                modulos.Show();
                this.Hide();
            }
            else
            {
                Mensajes.Error("No tiene acceso a este control");
            }
            
        }
    }
}
