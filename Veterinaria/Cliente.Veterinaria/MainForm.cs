using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Veterinaria
{
    public partial class MainForm : Form
    {
        ConfiguracionForm _configuracionForm = null;
        InicioForm _inicioForm = null;

        public MainForm()
        {
            InitializeComponent();
        }


        // ============ cierra toda la app ============
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilziado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._inicioForm is null || _inicioForm.IsDisposed)
            {
                _inicioForm = new InicioForm();
                _inicioForm.WindowState = FormWindowState.Maximized;
                _inicioForm.MdiParent = this;
                _inicioForm.Show();
            }
            
            _inicioForm.Activate();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilizado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._configuracionForm is null || _configuracionForm.IsDisposed)
            {
                this._configuracionForm = new ConfiguracionForm();
                _configuracionForm.WindowState = FormWindowState.Maximized;
                _configuracionForm.MdiParent = this;
                _configuracionForm.Show();
            }

            _configuracionForm.Activate();

        }
    }
}
