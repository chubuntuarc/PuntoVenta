using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace JeraDesktop
{
    public partial class frmCerrarTurno : Form
    {
        public frmCerrarTurno()
        {
            InitializeComponent();
        }

        private void frmCerrarTurno_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            llenarTipos();
        }

        private void llenarTipos()
        {
            cbTipo.Items.Add("Temporal");
            cbTipo.Items.Add("Definitivo");
        }

        private void cbTipo_TextChanged(object sender, EventArgs e)
        {
            if(cbTipo.SelectedItem.ToString() == "Temporal")
            {
                txtMontoFinal.ReadOnly = true;
            }
            else
            {
                txtMontoFinal.ReadOnly = false;
            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Close();
        }


        public static int turno;
        private void idTurno()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("select idTurno from turnos where caja = "+Generales.cajaActual+" and cajero = "+Generales.cajeroActual+"",xSQL.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                turno = Convert.ToInt32(reader[0].ToString());
            }
            else
            {
                turno = 0;
            }
            xSQL.conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cbTipo.SelectedItem.ToString() == "Temporal")
            {
                xSQL.conn.Open();
                SqlCommand cmd = new SqlCommand("update turnos set estado_actual = 'Bloqueado' where caja = "+Generales.cajaActual+" and cajero = "+Generales.cajeroActual+"",xSQL.conn);
                cmd.ExecuteNonQuery();
                xSQL.conn.Close();
                frmBloqueado bloqueado = new frmBloqueado();
                bloqueado.Show();
                this.Hide();
            }
            else
            {
                idTurno();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Turno", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                folio.Direction = ParameterDirection.InputOutput;
                folio.Value = turno;
                cmd.Parameters.Add(folio);

                SqlParameter fechaInicial = new SqlParameter("@cFechaInicial", SqlDbType.DateTime);
                fechaInicial.Value = null;
                cmd.Parameters.Add(fechaInicial);

                SqlParameter fechaFinal = new SqlParameter("@cFechaFinal", SqlDbType.DateTime);
                fechaFinal.Value = DateTime.Now;
                cmd.Parameters.Add(fechaFinal);

                SqlParameter caja = new SqlParameter("@nCaja", SqlDbType.Int);
                caja.Value = Generales.cajaActual;
                cmd.Parameters.Add(caja);

                SqlParameter cajero = new SqlParameter("@nCajero", SqlDbType.Int);
                cajero.Value = Generales.cajeroActual;
                cmd.Parameters.Add(cajero);

                SqlParameter montoInicial = new SqlParameter("@nMontoInicial", SqlDbType.Decimal);
                montoInicial.Value = 0;
                cmd.Parameters.Add(montoInicial);

                SqlParameter montoFinal = new SqlParameter("@nMontoFinal", SqlDbType.Decimal);
                montoFinal.Value = Convert.ToInt32(txtMontoFinal.Text);
                cmd.Parameters.Add(montoFinal);

                SqlParameter estadoActual = new SqlParameter("@cEstado", SqlDbType.VarChar, 50);
                estadoActual.Value = "Cerrado";
                cmd.Parameters.Add(estadoActual);

                SqlParameter tipo = new SqlParameter("@cTipo", SqlDbType.VarChar, 50);
                tipo.Value = "";
                cmd.Parameters.Add(tipo);

                try
                {
                    xSQL.conn.Open();
                    cmd.ExecuteNonQuery();
                    Mensajes.Aviso("Hasta luego ");

                }
                catch (Exception ex)
                {
                    Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
                }
                finally
                {
                    xSQL.conn.Close();
                    Application.Exit();
                    
                }
            }
        }


        private void txtMontoFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (cbTipo.SelectedItem.ToString() == "Temporal")
            {
                xSQL.conn.Open();
                SqlCommand cmd = new SqlCommand("update turnos set estado_actual = 'Bloqueado' where caja = "+Generales.cajaActual+" and cajero = "+Generales.cajeroActual+"",xSQL.conn);
                cmd.ExecuteNonQuery();
                xSQL.conn.Close();
                frmBloqueado bloqueado = new frmBloqueado();
                bloqueado.Show();
                this.Hide();
            }
            else
            {
                idTurno();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Turno", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                folio.Direction = ParameterDirection.InputOutput;
                folio.Value = turno;
                cmd.Parameters.Add(folio);

                SqlParameter fechaInicial = new SqlParameter("@cFechaInicial", SqlDbType.DateTime);
                fechaInicial.Value = DateTime.Now;
                cmd.Parameters.Add(fechaInicial);

                SqlParameter fechaFinal = new SqlParameter("@cFechaFinal", SqlDbType.DateTime);
                fechaFinal.Value = DateTime.Now;
                cmd.Parameters.Add(fechaFinal);

                SqlParameter caja = new SqlParameter("@nCaja", SqlDbType.Int);
                caja.Value = Generales.cajaActual;
                cmd.Parameters.Add(caja);

                SqlParameter cajero = new SqlParameter("@nCajero", SqlDbType.Int);
                cajero.Value = Generales.cajeroActual;
                cmd.Parameters.Add(cajero);

                SqlParameter montoInicial = new SqlParameter("@nMontoInicial", SqlDbType.Decimal);
                montoInicial.Value = 0;
                cmd.Parameters.Add(montoInicial);

                SqlParameter montoFinal = new SqlParameter("@nMontoFinal", SqlDbType.Decimal);
                montoFinal.Value = Convert.ToInt32(txtMontoFinal.Text);
                cmd.Parameters.Add(montoFinal);

                SqlParameter estadoActual = new SqlParameter("@cEstado", SqlDbType.VarChar, 50);
                estadoActual.Value = "Cerrado";
                cmd.Parameters.Add(estadoActual);

                SqlParameter tipo = new SqlParameter("@cTipo", SqlDbType.VarChar, 50);
                tipo.Value = "";
                cmd.Parameters.Add(tipo);

                try
                {
                    xSQL.conn.Open();
                    cmd.ExecuteNonQuery();
                    Mensajes.Aviso("Hasta luego ");

                }
                catch (Exception ex)
                {
                    Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
                }
                finally
                {
                    xSQL.conn.Close();
                    Application.Exit();
                    
                }
            }
            }
        }
    }
}
