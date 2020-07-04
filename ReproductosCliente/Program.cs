using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductosCliente
{
    static class Program
    {
        private static string rfc = "";
        private static string carlos = "";
        private static string jetx = "";
        private static string ross = "";
        private static string fabymc = "";
        private static string dianaYaz = "";
        private static string carlosm = "";
        private static string jessuca = "";
        private static string luzCarolina = "";
        private static string tarjeta_de_credito = "";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
