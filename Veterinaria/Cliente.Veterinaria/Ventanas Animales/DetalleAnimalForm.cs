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

namespace Cliente.Veterinaria.Ventanas_Animales
{
    public partial class DetalleAnimalForm : Form
    {
        private bool _editar = false;
        private int _clienteDni;
        private List<Animal> _animales = null;

        public DetalleAnimalForm(int clienteDni)
        {
            InitializeComponent();

            this._clienteDni = clienteDni;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animal animal = (Animal)cboxAnimales.SelectedItem;
            MostrarAnimal(animal);
        }

        private void DetalleAnimalForm_Load(object sender, EventArgs e)
        {
            try
            {
                AnimalDAO animalDAO = new AnimalDAO();

                _animales = animalDAO.getAllAnimalesConEspecieByDNI(_clienteDni);

                if(_animales is null || _animales.Count < 1)
                {
                    MessageBox.Show("El Cliente no tiene animales");
                    this.Close();
                    return;
                }

                cboxAnimales.DataSource = null;
                cboxAnimales.DataSource = _animales;

                MostrarAnimal(_animales[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarAnimal(Animal animal)
        {
            try
            {
                tboxID.Text = animal.ID.ToString();
                tboxNombre.Text = animal.Nombre;
                tboxPeso.Text = animal.Peso.ToString();
                tboxEdad.Text = animal.Edad.ToString();

                tboxEspecie.Text = animal.Especie.Nombre;
                tboxMadurez.Text = animal.Especie.EdadMadurez.ToString();
                tboxPromedio.Text = animal.Especie.PesoPromedio.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = (Animal)cboxAnimales.SelectedItem;
                animal.ClienteDueño.Dni = _clienteDni;
                EditarAnimalForm editarAnimalForm = new EditarAnimalForm(animal);
                editarAnimalForm.ShowDialog();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
