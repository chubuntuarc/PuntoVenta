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
    public partial class frmModulos : Form
    {
        public frmModulos()
        {
            InitializeComponent();
        }

        private void privilegios()
        {
            if(Generales.servidor == "1")
            {
                checkBox1.Checked = true;
            }
            if (Generales.usuarios == "1")
            {
                checkBox2.Checked = true;
            }
            if (Generales.clientes == "1")
            {
                checkBox3.Checked = true;
            }
            if (Generales.productos == "1")
            {
                checkBox4.Checked = true;
            }
            if (Generales.registarr == "1")
            {
                checkBox5.Checked = true;
            }
            if (Generales.departamentos == "1")
            {
                checkBox6.Checked = true;
            }
        }
        private void frmModulos_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            privilegios();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if(checkBox1.Checked)
            {
                
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'servidor'", xSQL.conn);
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'servidor'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if (checkBox2.Checked)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'usuarios'", xSQL.conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'usuarios'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if (checkBox3.Checked)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'clientes'", xSQL.conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'clientes'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if (checkBox4.Checked)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'productos'", xSQL.conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'productos'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if (checkBox5.Checked)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'registrar'", xSQL.conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'registrar'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            xSQL.conn.Open();
            if (checkBox6.Checked)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 1 where modulo = 'departamentos'", xSQL.conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Modulos set admin = 0 where modulo = 'departamentos'", xSQL.conn);
                cmd.ExecuteNonQuery();
            }
            xSQL.conn.Close();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Generales.privilegios();
            this.Close();
        }
    }
}
