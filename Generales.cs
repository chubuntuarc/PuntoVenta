using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace JeraDesktop
{
    class Generales
    {
        public static int nAdmin;
        public static string sUsuario;
        public static string servidor;
        public static string usuarios;
        public static string clientes;
        public static string productos;
        public static string registarr;
        public static string departamentos;
        public static string turnoActual;
        public static int cajaActual;
        public static int cajeroActual;

        public static string MacAdress()
        {
            string sMac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    sMac += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return sMac;
        }


        public static void caja()
        {

            xSQL.conn.Open();
            SqlCommand cmd = new SqlCommand("Select idCaja from Cajas where macCaja = '" + Generales.MacAdress() + "'", xSQL.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cajaActual = Convert.ToInt32(reader[0]);
            }
            else
            {
                cajaActual = 0;
            }
            xSQL.conn.Close();
        }

        public static void privilegios()
    {
        xSQL.conn.Open();
        SqlCommand cmd = new SqlCommand("Select admin from Modulos where modulo = 'servidor'", xSQL.conn);
        SqlDataReader read = cmd.ExecuteReader();
        if (read.Read())
        {
            Generales.servidor = read[0].ToString();
        }
        else
        {
            Generales.servidor = "0";
        }
        read.Close();
        xSQL.conn.Close();
        xSQL.conn.Open();
        SqlCommand cmd2 = new SqlCommand("Select admin from Modulos where modulo = 'usuarios'", xSQL.conn);
        SqlDataReader read2 = cmd2.ExecuteReader();
        if (read2.Read())
        {
            Generales.usuarios = read2[0].ToString();
        }
        else
        {
            Generales.usuarios = "0";
        }
        read2.Close();
        xSQL.conn.Close();
        xSQL.conn.Open();
        SqlCommand cmd3 = new SqlCommand("Select admin from Modulos where modulo = 'clientes'", xSQL.conn);
        SqlDataReader read3 = cmd3.ExecuteReader();
        if (read3.Read())
        {
            Generales.clientes = read3[0].ToString();
        }
        else
        {
            Generales.clientes = "0";
        }
        read3.Close();
        xSQL.conn.Close();
        xSQL.conn.Open();
        SqlCommand cmd4 = new SqlCommand("Select admin from Modulos where modulo = 'productos'", xSQL.conn);
        SqlDataReader read4 = cmd4.ExecuteReader();
        if (read4.Read())
        {
            Generales.productos = read4[0].ToString();
        }
        else
        {
            Generales.productos = "0";
        }
        read4.Close();
        xSQL.conn.Close();
        xSQL.conn.Open();
        SqlCommand cmd5 = new SqlCommand("Select admin from Modulos where modulo = 'registrar'", xSQL.conn);
        SqlDataReader read5 = cmd5.ExecuteReader();
        if (read5.Read())
        {
            Generales.registarr = read5[0].ToString();
        }
        else
        {
            Generales.registarr = "0";
        }
        read5.Close();
        xSQL.conn.Close();
        xSQL.conn.Open();
        SqlCommand cmd6 = new SqlCommand("Select admin from Modulos where modulo = 'departamentos'", xSQL.conn);
        SqlDataReader read6 = cmd6.ExecuteReader();
        if (read6.Read())
        {
            Generales.departamentos = read6[0].ToString();
        }
        else
        {
            Generales.departamentos = "0";
        }
        read6.Close();
        xSQL.conn.Close();
    }
    }
}
