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
    public partial class AgregarEspeciesForm : Form
    {
        public AgregarEspeciesForm()
        {
            InitializeComponent();
        }

        /*Regalito de error*/
        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Niglio sos un capo");
        }

        private void btnAgregarEspecie_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampos();
                EspecieDAO especieDAO = new EspecieDAO();
                Especie especieIngreso = new Especie()
                {
                    Nombre = txtIngresoNombreEspecie.Text,
                    EdadMadurez = int.Parse(txtIngresoEdadMadurezEspecie.Text),
                    PesoPromedio = decimal.Parse(txtIngresoPesoPromedioEspecie.Text)
                };

                bool resultado = especieDAO.InsertarEspecie(especieIngreso);

                if (!resultado)
                {
                    throw new Exception("No se pudo guardar la especie en la base de datos.");
                }
                else
                {
                    MessageBox.Show("Especie creada correctamente!");
                }
                limpiarCampos();

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void validarCampos()
        {
            /*Validar que se ingrese un nombre a la especie*/
            if (string.IsNullOrWhiteSpace(txtIngresoNombreEspecie.Text))
            {
                string msg = "El nombre de la especie es obligatorio.";
                throw new ValidationException(msg);
            }

            /*Validar que se ingrese una edad a la especie*/
            if (string.IsNullOrWhiteSpace(txtIngresoEdadMadurezEspecie.Text))
            {
                string msg = "La edad de la especie es obligatorio.";
                throw new ValidationException(msg);
            }

            /*Validar que se ingrese un entero en la edad de madurez*/
            if (!int.TryParse(txtIngresoEdadMadurezEspecie.Text, out int edad) || edad <= 0)
            {
                string msg = "La edad de madurez debe ser mayor a 0.";
                throw new ValidationException(msg);
            }

            /*Validar si ingresa un valor a peso promedio de la especie*/
            if (string.IsNullOrWhiteSpace(txtIngresoPesoPromedioEspecie.Text))
            {
                string msg = "Debe ingresar un peso promedio.";
                throw new ValidationException(msg);
            }

            /*Validar que sea un decimal*/
            if (!decimal.TryParse(txtIngresoPesoPromedioEspecie.Text, out decimal pesoPromedio) || pesoPromedio <= 0)
            {
                string msg = "El peso promedio de la especie debe ser mayor a 0.";
                throw new ValidationException(msg);
            }
        }

        private void limpiarCampos()
        {
            txtIngresoEdadMadurezEspecie.Clear();
            txtIngresoNombreEspecie.Clear();
            txtIngresoPesoPromedioEspecie.Clear();
        }

        private void btnCancelarAgregar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            this.Close();
        }
    }
}
