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
        public EliminarAnimalesForm()
        {
            InitializeComponent();
            RefreshDataGrid();
        }
            
        public void RefreshDataGrid() { 
         AnimalDAO animalDao = new AnimalDAO();
         List<Animal> animals = animalDao.getAllAnimals();

            dataGridView1.DataSource = animals;

            dataGridView1.Columns["ID"].HeaderText = "ID";
            dataGridView1.Columns["Nombre"].HeaderText = "Nombre animal";
            dataGridView1.Columns["Cliente"].HeaderText = "Nombre cliente";
            dataGridView1.Columns["DNI"].HeaderText = "DNI";
            dataGridView1.Columns["Especie"].HeaderText = "Especie";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void EliminarAnimalesForm_Load(object sender, EventArgs e)
        {
            this.RefreshDataGrid();
        }

        private void btnEliminarAnimal_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows != null) {

                Animal seleccionado = (Animal)dataGridView1.CurrentRow.DataBoundItem;

                AnimalDAO dao = new AnimalDAO();
                if (dao.deleteAnimal(seleccionado))
                {
                    MessageBox.Show("Animal eliminado correctamente.");
                    this.RefreshDataGrid(); // recargamos la grilla automáticamente
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el animal.");
                }
            }
            //Si apreta el boton sin seleccionar lanzo una advertencia
            else
            {
                MessageBox.Show("Seleccione un animal para eliminar.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

