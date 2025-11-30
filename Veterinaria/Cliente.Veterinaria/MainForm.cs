using Cliente.Veterinaria.Ventanas_Animales;
using Cliente.Veterinaria.Ventanas_Especies;
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
        AgregarAnimalesForm _animalesForm = null;
        ClientesForm _clientesForm = null;
        EspeciesForm _especiesForm = null;
        AgregarEspeciesForm _agregarEspeciesForm = null;
        EditarEspeciesForm _editarEspeciesForm = null;
        EliminarAnimalesForm _eliminarAnimalesForm = null;
        VerTodosAnimalesForm _verAnimalesForm = null;
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

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e) { }


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
        private void agregarEspecieToolStripMenuItem_Click(object sender, EventArgs e)

        {
            if (this._agregarEspeciesForm is null || _agregarEspeciesForm.IsDisposed)
            {
                this._agregarEspeciesForm = new AgregarEspeciesForm();
                _agregarEspeciesForm.WindowState = FormWindowState.Maximized;
                _agregarEspeciesForm.MdiParent = this;
                _agregarEspeciesForm.Show();
            }

            _agregarEspeciesForm.Activate();
        }

        private void editarEspecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._editarEspeciesForm is null || _editarEspeciesForm.IsDisposed)
            {
                this._editarEspeciesForm= new EditarEspeciesForm();
                _editarEspeciesForm.WindowState = FormWindowState.Maximized;
                _editarEspeciesForm.MdiParent = this;
                _editarEspeciesForm.Show();
            }

            _editarEspeciesForm.Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //============ANIMALES TOOLSTRIP=========================
        private void animalesToolStripMenuItem_Click(object sender, EventArgs e)

        {
            // IsDisposed es un booleano que se pone en true cuando se cierra un formulario, los recursos se liberan y este no puede ser reutilizado
            // Entonces validamos si se encuentra en ese estado o si es null y en caso de que se cumpla alguna de las condiciones creamos uno nuevo

            if (this._animalesForm is null || _animalesForm.IsDisposed)
            {
                this._animalesForm = new AgregarAnimalesForm();
                _animalesForm.WindowState = FormWindowState.Maximized;
                _animalesForm.MdiParent = this;
                _animalesForm.Show();
            }

            _animalesForm.Activate();
        }


        private void eliminarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._eliminarAnimalesForm is null || _eliminarAnimalesForm.IsDisposed)
            {
                this._eliminarAnimalesForm= new EliminarAnimalesForm();
                _eliminarAnimalesForm.WindowState = FormWindowState.Maximized;
                _eliminarAnimalesForm.MdiParent = this;
                _eliminarAnimalesForm.Show();
            }

            _eliminarAnimalesForm.Activate();

        }

        private void agregarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._animalesForm is null || _animalesForm.IsDisposed)
            {
                this._animalesForm = new AgregarAnimalesForm();
                _animalesForm.WindowState = FormWindowState.Maximized;
                _animalesForm.MdiParent = this;
                _animalesForm.Show();

                this.menuStrip1.Visible = false;

            }
            _animalesForm.FormClosed += (s, args) =>
            {
                this.menuStrip1.Visible = true;
            };

            _animalesForm.Activate();
        }

        private void verAnimalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._verAnimalesForm is null || _verAnimalesForm.IsDisposed)
            {
                this._verAnimalesForm = new VerTodosAnimalesForm();
                _verAnimalesForm.WindowState = FormWindowState.Maximized;
                _verAnimalesForm.MdiParent = this;
                _verAnimalesForm.Show();

                this.menuStrip1.Visible = false;

            }
            _verAnimalesForm.FormClosed += (s, args) =>
            {
                this.menuStrip1.Visible = true;
            };

            _verAnimalesForm.Activate();
        }
    }
}
