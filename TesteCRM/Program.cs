using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteCRM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            if (Classes.clsVariaveis.IsAuthorizedLogin)
            {
                try
                {
                    Application.Run(new frmMDI());
                }
                catch
                {
                    MessageBox.Show("Erro no Aplicativo - Favor Abrir o CRM novamente");
                    Application.Exit();
                }
            }
        }
    }
}
