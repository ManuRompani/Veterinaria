using Services.Veterinaria.DAOs;
using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Veterinaria
{
    public partial class LoginForm : Form
    {
        private UsuarioDAO _usuarioDAO = null;
        private bool _isFirstLogin = true;
        public LoginForm()
        {
            InitializeComponent();

            _usuarioDAO = new UsuarioDAO();
            _isFirstLogin = _usuarioDAO.isFirstLogin();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_isFirstLogin)
            {
                lblTitulo.Text = "Bienvenido!";
                lblTextoGuia.Visible = true;
                lblNombre.Text = "Nuevo Usuario";
                lblPass.Text = "Nueva Contraseña";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string uName = tboxName.Text;
                string uPass = tboxPass.Text;

                Usuario usuario = new Usuario
                {
                    UserName = uName,
                    UserPassword = uPass
                };

                if(_isFirstLogin)
                {
                    _usuarioDAO.registrarUsuario(usuario);
                }
                else
                {
                    if (!_usuarioDAO.autenticarUsuario(usuario))
                    {
                        MessageBox.Show("Credenciales incorrectas!");
                        return;
                    }
                }

                //Oculta el form de login
                this.Hide();

                //Se crear el form main donde ocurrira todo
                //Una vez cerrado el main se cerrara todoa la aplciacion con el form de logininclusive
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
