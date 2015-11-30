using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text;

namespace JeraDesktop
{
    public partial class frmLogin : Form
    {
        int nIntentos = 1;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            label2.Parent = pbConf;
            try
            {
                xSQL.conecta();
            }
            catch(Exception ex)
            {
                Mensajes.Error("Ocurrio un error de conexion: \n" + ex.Message);
            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Acceso();  
        }

        public SqlCommand cmd;
        private void Acceso()
        {
            string pass = "";
            string nombre = "";
            int admin = 0;
            int cajero = 0;
            try
            {
                xSQL.conn.Open();
                cmd = new SqlCommand("SELECT nombre, contrasena, es_administrador from Usuario where id_usuario = " + txtUsuario.Text + "", xSQL.conn);
                SqlDataReader contra = cmd.ExecuteReader();
                if(contra.Read())
                {
                    if(contra.HasRows)
                    {
                        pass = Encriptador.RijndaelSimple.DecryptKey(contra[1].ToString());
                        nombre = contra[0].ToString();
                        admin = Convert.ToInt32(contra[2]);
                    }

                    if (pass != txtContrasena.Text)
                    {
                        Mensajes.Error("Usuario y/o contraseña incorrecta " + nIntentos.ToString() + "/3");
                        if (nIntentos == 3)
                        {
                            Mensajes.Error("Número de intentos excedido");
                            Application.Exit();
                        }
                        else
                        {
                            nIntentos++;
                        }
                    }
                    else
                    {
                        cajero = Convert.ToInt32(txtUsuario.Text);
                        frmTurno turno = new frmTurno();
                        Generales.cajeroActual = cajero;
                        turno.Show();
                        Generales.sUsuario = nombre;
                        Generales.nAdmin = admin;
                        turno.lblCajero.Text = nombre;
                        this.Hide();
                    }
                   
                }
                else
                {
                    Mensajes.Error("No se encontro usuario");
                }

                contra.Close();
                

            }
            catch (Exception ex)
            {
                Mensajes.Error("Error en el sistema " + ex.Message);
            }
            finally
            {
                xSQL.conn.Close();
            }





        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) Acceso();
        }

    }

    }

