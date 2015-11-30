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
    public partial class frmEditarClientes : Form
    {
        public frmEditarClientes()
        {
            InitializeComponent();
        }

        private void frmEditarClientes_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmClientes cli = new frmClientes();
            cli.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_Inserta_Cliente", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = Convert.ToInt32(txtId.Text); ;
            cmd.Parameters.Add(folio);

            SqlParameter nombre = new SqlParameter("@cNombre", SqlDbType.VarChar, 50);
            nombre.Value = txtUsuario.Text;
            cmd.Parameters.Add(nombre);

            SqlParameter paterno = new SqlParameter("@cApaterno", SqlDbType.VarChar, 50);
            paterno.Value = txtPaterno.Text;
            cmd.Parameters.Add(paterno);

            SqlParameter materno = new SqlParameter("@cAmaterno", SqlDbType.VarChar, 50);
            materno.Value = txtMaterno.Text;
            cmd.Parameters.Add(materno);

            SqlParameter telefono = new SqlParameter("@cTelefono", SqlDbType.VarChar, 50);
            telefono.Value = txtTelefono.Text;
            cmd.Parameters.Add(telefono);

            SqlParameter celular = new SqlParameter("@cCelular", SqlDbType.VarChar, 50);
            celular.Value = txtCelular.Text;
            cmd.Parameters.Add(celular);

            SqlParameter direccion = new SqlParameter("@cDireccion", SqlDbType.VarChar, 80);
            direccion.Value = txtDireccion.Text;
            cmd.Parameters.Add(direccion);

            SqlParameter estado = new SqlParameter("@cEstatus", SqlDbType.VarChar, 20);
            estado.Value = txtEstado.Text;
            cmd.Parameters.Add(estado);

            SqlParameter limite = new SqlParameter("@mLimCredito", SqlDbType.Money);
            limite.Value = txtLimite.Text;
            cmd.Parameters.Add(limite);

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmClientes user = new frmClientes();
            DialogResult pregunta = MessageBox.Show("¿Deseas eliminar el cliente " + txtId.Text + "?");
            if (pregunta == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("SP_Borra_Cliente", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@idCliente", SqlDbType.Int);
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
