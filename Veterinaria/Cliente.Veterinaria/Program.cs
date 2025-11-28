using Services.Veterinaria.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cliente.Veterinaria
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //
            //=============ESTRUCTURA GENERAL===============
            //
            //  ¡¡Si es la primera vez que se inicia a la app se crea una cuenta de usuario!!
            //
            //  LoginForm ----> LoginValido? --- SI ---> MainForm |-----> InicioForm (Informacion sobre clientes, ABM, etc)
            //      |               |                             |-----> ConfiguracionForm (Para agregar especies, usuarios, etc)
            //      |               NO
            //      -----------------
            //
        }
    }
}
