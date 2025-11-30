using Services.Veterinaria.DAOs;
using Services.Veterinaria.Model;
using Services.Veterinaria.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Veterinaria.Ventanas_Especies
{
    public partial class EditarEspeciesForm : Form
    {
        private EspecieDAO especieDAO;
        private List<Especie> _listadoEspecies;

        public EditarEspeciesForm()
        {
            InitializeComponent();
            especieDAO = new EspecieDAO();
            cargarEspeciesCMB();

        }

        private void cargarEspeciesCMB()
        {
            try
            {
                _listadoEspecies = especieDAO.getAllEspecies();
                cmbEspecies.DataSource = _listadoEspecies;
                cmbEspecies.DisplayMember = "Nombre";
                cmbEspecies.ValueMember = "ID";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las expecies");
            }

        }

        private void cmbEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecies.SelectedItem is Especie especieSeleccionada)
            {
                lblID.Text = especieSeleccionada.ID.ToString();
                txtNombre.Text = especieSeleccionada.Nombre;
                txtEdadMadurez.Text = especieSeleccionada.EdadMadurez.ToString();
                txtPesoPromedio.Text = especieSeleccionada.PesoPromedio.ToString();
            }
        }

        private void actualizarEspecie(Especie especie)
        {
            bool resultado = especieDAO.updateEspecie(especie);

            if (resultado)
            {
                MessageBox.Show("Especie editada correctamente!");
                cargarEspeciesCMB();
            }
            else
            {
                MessageBox.Show("Error al actualizar la especie");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampos();

                if (cmbEspecies.SelectedItem is Especie especieSeleccionada)
                {
                    Especie espActualizada = new Especie
                    {
                        ID = especieSeleccionada.ID,
                        Nombre = txtNombre.Text,
                        EdadMadurez = int.Parse(txtEdadMadurez.Text),
                        PesoPromedio = decimal.Parse(txtPesoPromedio.Text)
                    };

                    actualizarEspecie(espActualizada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la especie");
            }

            
        }
        private void validarCampos()
        {
            /*Validar que se ingrese un nombre a la especie*/
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                string msg = "El nombre de la especie es obligatorio.";
                throw new ValidationException(msg);
            }

            /*Validar que se ingrese una edad a la especie*/
            if (string.IsNullOrWhiteSpace(txtEdadMadurez.Text))
            {
                string msg = "La edad de la especie es obligatorio.";
                throw new ValidationException(msg);
            }

            /*Validar que se ingrese un entero en la edad de madurez*/
            if (!int.TryParse(txtEdadMadurez.Text, out int edad) || edad <= 0)
            {
                string msg = "La edad de madurez debe ser mayor a 0.";
                throw new ValidationException(msg);
            }

            /*Validar si ingresa un valor a peso promedio de la especie*/
            if (string.IsNullOrWhiteSpace(txtPesoPromedio.Text))
            {
                string msg = "Debe ingresar un peso promedio.";
                throw new ValidationException(msg);
            }

            /*Validar que sea un decimal*/
            if (!decimal.TryParse(txtPesoPromedio.Text, out decimal pesoPromedio) || pesoPromedio <= 0)
            {
                string msg = "El peso promedio de la especie debe ser mayor a 0.";
                throw new ValidationException(msg);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
