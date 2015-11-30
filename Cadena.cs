using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeraDesktop
{
    class Cadena
    {
        public static void guardarDatos(string sServidor, string sBase, string sUsuario, string sPass)
        {
            string cadena = "Data Source=" + sServidor + ";Initial Catalog=" + sBase + ";User ID = " + sUsuario + "; Password = " + sPass + "; ";
            StreamWriter redactor = new StreamWriter("C:\\Users\\Windows Shity\\Desktop\\cadena.txt");
            redactor.WriteLine(cadena);
            redactor.Close();
        }

        public static void escribirDatosSeguridad(string sServidor, string sBase)
        {
            string cadena = "Data Source=" + sServidor + ";Initial Catalog=" + sBase + ";Integrated Security = true ";
            StreamWriter redactor = new StreamWriter("C:\\Users\\Windows Shity\\Desktop\\cadena.txt");
            redactor.WriteLine(cadena);
            redactor.Close();
        }

        public static string leerDatos()
        {
            string s;
            StreamReader lector = new StreamReader("C:\\Users\\Windows Shity\\Desktop\\cadena.txt");
            s = lector.ReadLine();
            lector.Close();
            return s;
        }
    }
}
