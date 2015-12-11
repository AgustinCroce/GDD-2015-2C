using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba;

namespace AerolineaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(Properties.Settings.Default.Modo == "Admin"){
                Application.Run(new AerolineaFrba.Login());
            }

            if (Properties.Settings.Default.Modo == "Kiosko")
            {
                Application.Run(new AerolineaFrba.SeleccionFuncionalidad("Cliente"));
            }
            
        }
    }
}
