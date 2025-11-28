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
        AnimalesForm _animalesForm = null;
        ClientesForm _clientesForm = null;
        EspeciesForm _especiesForm = null;

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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilziado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._clientesForm is null || _clientesForm.IsDisposed)
            {
                _clientesForm = new ClientesForm();
                _clientesForm.WindowState = FormWindowState.Maximized;
                _clientesForm.MdiParent = this;
                _clientesForm.Show();
            }
            
            _clientesForm.Activate();
        }

        private void animalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilizado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._animalesForm is null || _animalesForm.IsDisposed)
            {
                this._animalesForm = new AnimalesForm();
                _animalesForm.WindowState = FormWindowState.Maximized;
                _animalesForm.MdiParent = this;
                _animalesForm.Show();
            }

            _animalesForm.Activate();

        }

        private void especiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilizado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._especiesForm is null || _especiesForm.IsDisposed)
            {
                this._especiesForm = new EspeciesForm();
                _especiesForm.WindowState = FormWindowState.Maximized;
                _especiesForm.MdiParent = this;
                _especiesForm.Show();
            }

            _especiesForm.Activate();
        }
    }
}
