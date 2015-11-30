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
    public partial class frmRetiro : Form
    {
        public frmRetiro()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRetiro_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            llenarRetiros();
        }

        private void llenarRetiros()
        {
            cbRetiro.Items.Add("Parcial");
            cbRetiro.Items.Add("Definitivo");
        }

        public static string claveAdmin;
        public static int administrador;
        private void verificarPassword()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("select id_usuario, contrasena from usuario where es_administrador = 1",xSQL.conn);
            SqlDataReader read = cmd.ExecuteReader();
            if(read.Read())
            {
                claveAdmin = Encriptador.RijndaelSimple.DecryptKey(read[1].ToString());
                administrador = Convert.ToInt32(read[0].ToString());
            }
            xSQL.conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                
            if (cbRetiro.SelectedItem.ToString() == "Parcial")
            {
                verificarPassword();
                if(claveAdmin != txtPass.Text)
                {
                    Mensajes.Error("No cuenta con privilegios para realizar esta acción");
                }
                else
                {
                        SqlCommand cmd = new SqlCommand("SP_Inserta_Registro", xSQL.conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                        folio.Direction = ParameterDirection.InputOutput;
                        folio.Value = 0;
                        cmd.Parameters.Add(folio);

                        SqlParameter caja = new SqlParameter("@ncaja", SqlDbType.Int);
                        caja.Value = Generales.cajaActual;
                        cmd.Parameters.Add(caja);

                        SqlParameter cajero = new SqlParameter("@nCajero", SqlDbType.Int);
                        cajero.Value = Generales.cajeroActual;
                        cmd.Parameters.Add(cajero);

                        SqlParameter supervisor = new SqlParameter("@nSupervisor", SqlDbType.Int);
                        supervisor.Value = administrador;                                     
                        cmd.Parameters.Add(supervisor);

                        SqlParameter importe = new SqlParameter("@nImporte", SqlDbType.Money);
                        importe.Value = txtImporte.Text;
                        cmd.Parameters.Add(importe);

                        SqlParameter fecha = new SqlParameter("@sFecha", SqlDbType.DateTime);
                        fecha.Value = DateTime.Now;
                        cmd.Parameters.Add(fecha);

                        SqlParameter concepto = new SqlParameter("@sConcepto", SqlDbType.Text);
                        concepto.Value = rtConcepto.Text;
                        cmd.Parameters.Add(concepto);

                        SqlParameter tipo = new SqlParameter("@sTipo", SqlDbType.VarChar, 50);
                        tipo.Value = "Parcial";
                        cmd.Parameters.Add(tipo);

                        try
                        {
                            xSQL.conn.Open();
                            cmd.ExecuteNonQuery();


                        }
                        catch (Exception ex)
                        {
                            Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
                        }
                        finally
                        {
                            xSQL.conn.Close();
                            this.Close();

                        }
                    }
                }
                else
                {
                    frmCerrarTurno cerrar = new frmCerrarTurno();
                    cerrar.ShowDialog();
                    this.Close();
                }
            }

        private void cbRetiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbRetiro.SelectedItem.ToString() == "Definitivo")
            {
                txtImporte.ReadOnly = true;
                rtConcepto.ReadOnly = true;
                txtPass.ReadOnly = true;
            }
            else
            {

                txtImporte.ReadOnly = false;
                rtConcepto.ReadOnly = false;
                txtPass.ReadOnly = false;
            }
        }
    }
}
