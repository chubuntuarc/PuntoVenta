using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeraDesktop
{
    class xSQL
    {
        public static SqlConnection conn;
        public static void conecta()
        {
            conn = new SqlConnection(Cadena.leerDatos());
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Mensajes.Error("Ha ocurrido un error en el Sistema " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
