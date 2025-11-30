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

namespace Cliente.Veterinaria.Ventanas_Animales
{
    public partial class EditarAnimalForm : Form
    {
        private Animal _animal;
        private AnimalDAO _animalDAO = null;

        private Services.Veterinaria.Model.Cliente nuevoCliente = null;
        private Especie nuevaEspecie = null;

        public EditarAnimalForm(Animal animal)
        {
            InitializeComponent();

            _animal = animal;
            _animalDAO = new AnimalDAO();

            //Medio raro pero bueno
            nuevaEspecie = animal.Especie;
            nuevoCliente = new Services.Veterinaria.Model.Cliente
            {
                Dni = animal.ClienteDueño.Dni
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampos();

                _animal.Nombre = textBox1.Text;
                _animal.Peso = decimal.Parse(textBox2.Text);
                _animal.Edad = int.Parse(textBox3.Text);
                _animal.ClienteDueño = nuevoCliente;
                _animal.Especie = nuevaEspecie;

                if (_animalDAO.updateAnimal(_animal))
                {
                    MessageBox.Show("El animal fue editado correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No fue posible editar al animal.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                   || string.IsNullOrWhiteSpace(textBox3.Text))
            {

                string msg = "Los campos no pueden estar vacios";
                throw new ValidationException(msg);
            }

            // Valido ingreso de edad
            if (!int.TryParse(textBox3.Text, out int edad))
            {
                string msg = "La edad debe ser un numero";
                throw new ValidationException(msg);
            }

            if (edad <= 0)
            {
                string msg = "La edad no puede ser menor a 0";
                throw new ValidationException(msg);
            }

            //Valido ingreso de peso
            if (!decimal.TryParse(textBox2.Text, out decimal peso))
            {
                string msg = "El peso debe ser un numero";
                throw new ValidationException(msg);
            }
            if (peso < 0)
            {
                string msg = "El peso no puede ser negativo";
                throw new ValidationException(msg);
            }

            if(nuevoCliente is null)
            {
                string msg = "El Cliente no puede estar vacío";
                throw new ValidationException(msg);
            }

            if (nuevaEspecie is null)
            {
                string msg = "La Especie no puede estar vacía";
                throw new ValidationException(msg);
            }
        }

        private void EditarAnimalForm_Load(object sender, EventArgs e)
        {
            try
            {
                CargarClientes();
                CargarEspecies();

                textBox1.Text = _animal.Nombre;
                textBox2.Text = _animal.Peso.ToString();
                textBox3.Text = _animal.Edad.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarClientes()
        {
            try
            {
                ClienteDAO clienteDAO = new ClienteDAO();

                List<Services.Veterinaria.Model.Cliente> clientes = clienteDAO.GetTodos();

                cmbCliente.DataSource = null;
                cmbCliente.DataSource = clientes;

                foreach (var cliente in clientes)
                {
                    if (cliente.Dni == _animal.ClienteDueño.Dni)
                    {
                        cmbCliente.SelectedItem = cliente;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarEspecies()
        {
            try
            {
                EspecieDAO especieDAO = new EspecieDAO();

                List<Especie> especies = especieDAO.getAllEspecies();

                cmbEspecie.DataSource = null;
                cmbEspecie.DataSource = especies;

                foreach (Especie especie in especies)
                {
                    if (especie.ID == _animal.Especie.ID)
                    {
                        cmbEspecie.SelectedItem = especie;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            nuevoCliente = (Services.Veterinaria.Model.Cliente)cmbCliente.SelectedItem;
        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            nuevaEspecie = (Especie)cmbEspecie.SelectedItem;
        }
    }
}
