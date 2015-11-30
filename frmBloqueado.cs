using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JeraDesktop
{
    public partial class frmBloqueado : Form
    {
        public frmBloqueado()
        {
            InitializeComponent();
        }

        private void frmBloqueado_Load(object sender, EventArgs e)
        {
            lblSlogan.Parent = pbConf;
            lblCajero.Text = Generales.sUsuario;
        }

        public static string clave = "";
        public static bool pass = false;
        private void revisarPass()
        {
            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("select * from usuario where id_usuario = "+Generales.cajeroActual+"",xSQL.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                clave = Encriptador.RijndaelSimple.DecryptKey(reader["contrasena"].ToString());
                if(txtContrasena.Text == clave)
                {
                    pass = true;
                }

            }
            else
            {
                pass = false;
            }
            xSQL.conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string pass = "";
            int nIntentos = 1;
            try
            {
                xSQL.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT contrasena from Usuario where id_usuario = " + Generales.cajeroActual + "", xSQL.conn);
                SqlDataReader contra = cmd.ExecuteReader();
                if (contra.Read())
                {
                    if (contra.HasRows)
                    {
                        pass = Encriptador.RijndaelSimple.DecryptKey(contra[0].ToString());
                    }

                    if (pass != txtContrasena.Text)
                    {
                        Mensajes.Error("Usuario y/o contraseña incorrecta " + nIntentos.ToString() + "/3");
                        if (nIntentos == 3)
                        {
                            Mensajes.Error("Número de intentos excedido");
                        }
                        else
                        {
                            nIntentos++;
                        }
                    }
                    else
                    {
                        contra.Close();
                        SqlCommand cmd2 = new SqlCommand("update turnos set estado_actual = 'Activo' where caja = " + Generales.cajaActual + " and cajero = " + Generales.cajeroActual + "", xSQL.conn);
                        cmd2.ExecuteNonQuery();
                        Form1 menu = new Form1();
                        menu.Show();
                        this.Close();
                    }

                }
                else
                {
                    Mensajes.Error("No se encontro usuario");
                }

                


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
            if (e.KeyData == Keys.Enter)
            {
                string pass = "";
                int nIntentos = 1;
                try
                {
                    xSQL.conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT contrasena from Usuario where id_usuario = " + Generales.cajeroActual + "", xSQL.conn);
                    SqlDataReader contra = cmd.ExecuteReader();
                    if (contra.Read())
                    {
                        if (contra.HasRows)
                        {
                            pass = Encriptador.RijndaelSimple.DecryptKey(contra[0].ToString());
                        }

                        if (pass != txtContrasena.Text)
                        {
                            Mensajes.Error("Usuario y/o contraseña incorrecta " + nIntentos.ToString() + "/3");
                            if (nIntentos == 3)
                            {
                                Mensajes.Error("Número de intentos excedido");
                            }
                            else
                            {
                                nIntentos++;
                            }
                        }
                        else
                        {
                            contra.Close();
                            SqlCommand cmd2 = new SqlCommand("update turnos set estado_actual = 'Activo' where caja = " + Generales.cajaActual + " and cajero = " + Generales.cajeroActual + "", xSQL.conn);
                        cmd2.ExecuteNonQuery();
                        Form1 menu = new Form1();
                        menu.Show();
                        this.Close();
                        }

                    }
                    else
                    {
                        Mensajes.Error("No se encontro usuario");
                    }



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
        }
    }
}
