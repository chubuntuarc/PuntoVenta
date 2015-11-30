using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeraDesktop
{
    class Mensajes
    {
        public static void Aviso(string aviso)
        {
            MessageBox.Show(aviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string aviso)
        {
            MessageBox.Show(aviso, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
