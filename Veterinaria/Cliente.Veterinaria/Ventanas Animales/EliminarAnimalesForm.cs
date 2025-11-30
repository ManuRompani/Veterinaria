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
    public partial class EliminarAnimalesForm : Form
    {
        private AnimalDAO animalDAO;
        private List<Animal> _listadoAnimales;
        public EliminarAnimalesForm()
        {
            InitializeComponent();
            animalDAO = new AnimalDAO();
            cargarAnimalesDGV();
        }

        private void cargarAnimalesDGV()
        {
            try
            {
                _listadoAnimales = animalDAO.getAllAnimals();
                dgvListaAnimales.DataSource = _listadoAnimales;
            }
            catch
            {
                MessageBox.Show("Error al cargar los animales");
            }
        }

        /*Si necesito actualizar el DGV o dsps de eliminar un animal*/
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarAnimalesDGV();
        }


        /*Boton para eliminar animal el cual te pregunta si enserio queres eliminarlo*/
        private void btnEliminarAnimal_Click(object sender, EventArgs e)
        {
            if (dgvListaAnimales.CurrentRow != null && dgvListaAnimales.CurrentRow.DataBoundItem is Animal animalSeleccionado)
            {
                DialogResult resultado = MessageBox.Show
                    (
                    $"¿Seguro quiere eliminar a '{animalSeleccionado.Nombre}'?", "¿Confirmar eliminar al animal?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                    );

                if (resultado == DialogResult.Yes)
                {
                    eliminarAnimal(animalSeleccionado);
                }
            }
        }

        /*Metodo para eliminar si o si el animal*/
        private void eliminarAnimal(Animal animal)
        {
            try
            {
                bool resultado = animalDAO.deleteAnimal(animal);

                if (resultado)
                {
                    MessageBox.Show("Animal eliminado correctamente", "Éxito");
                    cargarAnimalesDGV(); //Actualizamos por las dudas el dgv
                }
                else
                {
                    MessageBox.Show("Error al eliminar el animal", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el animal: {ex.Message}", "Error");
            }
        }
    }
}
