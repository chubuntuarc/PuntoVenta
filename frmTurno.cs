using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JeraDesktop
{
    public partial class frmTurno : Form
    {
        public frmTurno()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTurno_Load(object sender, EventArgs e)
        {
            xSQL.conecta();
            lblSlogan.Parent = pbConf;
            lblFecha.Text = DateTime.Today.ToString();
            lblinicial.Text = DateTime.Now.ToLongTimeString();
            llenarCaja();
            lblCajero.Text = Generales.sUsuario;
            llenarTurnos();
        }

        private void llenarCaja()
        {
            
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("Select nombrecaja from Cajas where macCaja = '"+Generales.MacAdress()+"'", xSQL.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                lblCaja.Text = reader[0].ToString();
            }
            else
            {
                lblCaja.Text = "No asignada";
            }
            xSQL.conn.Close();
        }

        private void llenarTurnos()
        {
            cbTurnos.Items.Add("Mañana");
            cbTurnos.Items.Add("Tarde");
            cbTurnos.Items.Add("Noche");
            cbTurnos.Items.Add("Especial");
        }

        bool registrado = false;
        private void revisarRegistro()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("Select habilitada from cajas where macCaja = '"+ Generales.MacAdress()+"'", xSQL.conn);
            SqlDataReader leer = cmd.ExecuteReader();
            if(leer.Read())
            {
                registrado = true;
            }
            else
            {
                Mensajes.Error("Equipo no registrado como caja.");
            }
            leer.Close();
            xSQL.conn.Close();
        }

        public static bool estadoTurno;
        private void revisarTurno()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from turnos where caja = "+Generales.cajaActual+" and cajero = "+Generales.cajeroActual+" and estado_actual = 'Activo'",xSQL.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                estadoTurno = true;
            }
            else
            {
                estadoTurno = false;
            }
            xSQL.conn.Close();
            reader.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string estado = "";
            revisarRegistro();
            revisarTurno();
           if (registrado)
           {
               estado = "Activo";
           }
           else
           {
               estado = "Iniactivo";
           }
            Generales.caja();
            Generales.turnoActual = cbTurnos.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand("SP_Inserta_Turno", xSQL.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
            folio.Direction = ParameterDirection.InputOutput;
            folio.Value = 0;
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
            montoInicial.Value = Convert.ToInt32(txtMontoInicial.Text);
            cmd.Parameters.Add(montoInicial);

            SqlParameter montoFinal = new SqlParameter("@nMontoFinal", SqlDbType.Decimal);
            montoFinal.Value = 0;
            cmd.Parameters.Add(montoFinal);

            SqlParameter estadoActual = new SqlParameter("@cEstado", SqlDbType.VarChar, 50);
            estadoActual.Value = estado;
            cmd.Parameters.Add(estadoActual);

            SqlParameter tipo = new SqlParameter("@cTipo", SqlDbType.VarChar, 50);
            tipo.Value = cbTurnos.SelectedItem.ToString();
            cmd.Parameters.Add(tipo);

            try
            {
                if(estadoTurno == true)
                {
                    Mensajes.Aviso("Bienvenido, ya tienes un turno abierto");
                }
                else
                {
                    xSQL.conn.Open();
                    cmd.ExecuteNonQuery();
                    Mensajes.Aviso("Bienvenido ");
                }
                
            }
            catch (Exception ex)
            {
                Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
            }
            finally
            {
                if(estadoTurno)
                {
                    Form1 menu = new Form1();
                    menu.Show();
                    menu.lblUsuario.Text = Generales.sUsuario;
                    this.Hide();
                }
                else
                {
                    xSQL.conn.Close();
                    Form1 menu = new Form1();
                    menu.Show();
                    menu.lblUsuario.Text = Generales.sUsuario;
                    this.Hide();
                }
                
            }
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            Form1 menu = new Form1();
            if (e.KeyData == Keys.Enter)
            {
                string estado = "";
                revisarRegistro();
                revisarTurno();
                if (registrado)
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Iniactivo";
                }
                Generales.caja();
                Generales.turnoActual = cbTurnos.SelectedItem.ToString();

                SqlCommand cmd = new SqlCommand("SP_Inserta_Turno", xSQL.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter folio = new SqlParameter("@nId", SqlDbType.Int);
                folio.Direction = ParameterDirection.InputOutput;
                folio.Value = 0;
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
                montoInicial.Value = Convert.ToInt32(txtMontoInicial.Text);
                cmd.Parameters.Add(montoInicial);

                SqlParameter montoFinal = new SqlParameter("@nMontoFinal", SqlDbType.Decimal);
                montoFinal.Value = 0;
                cmd.Parameters.Add(montoFinal);

                SqlParameter estadoActual = new SqlParameter("@cEstado", SqlDbType.VarChar, 50);
                estadoActual.Value = estado;
                cmd.Parameters.Add(estadoActual);

                SqlParameter tipo = new SqlParameter("@cTipo", SqlDbType.VarChar, 50);
                tipo.Value = cbTurnos.SelectedItem.ToString();
                cmd.Parameters.Add(tipo);

                try
                {
                    if (estadoTurno == true)
                    {
                        Mensajes.Aviso("Bienvenido, ya tienes un turno abierto");
                    }
                    else
                    {
                        xSQL.conn.Open();
                        cmd.ExecuteNonQuery();
                        Mensajes.Aviso("Bienvenido ");
                    }

                }
                catch (Exception ex)
                {
                    Mensajes.Error("A ocurrido un error en el sistema, " + ex.Message);
                }
                finally
                {
                    if (estadoTurno)
                    {
                        Form1 menuform = new Form1();
                        menu.Show();
                        menu.lblUsuario.Text = Generales.sUsuario;
                        this.Hide();
                    }
                    else
                    {
                        xSQL.conn.Close();
                        Form1 menuform = new Form1();
                        menu.Show();
                        menu.lblUsuario.Text = Generales.sUsuario;
                        this.Hide();
                    }

                }

            }
        }
    }
}
