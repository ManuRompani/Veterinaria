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
    public partial class VerTodosAnimalesForm : Form
    {
        private AnimalDAO _animalDao;
        private List<Animal> _listaAnimales;

        public VerTodosAnimalesForm()
        {
            InitializeComponent();
            _animalDao = new AnimalDAO();
            _listaAnimales = new List<Animal>();
        }


        public void cargarAnimalesDataGridView()
        {

            try
            {
                _listaAnimales = _animalDao.getAllAnimals();
                dataGridView1.DataSource = _listaAnimales;
            }
            catch
            {
                MessageBox.Show("Error al cargar los animales");
            }

        }

        private void VerTodosAnimalesForm_Load(object sender, EventArgs e)
        {
            this.cargarAnimalesDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.cargarAnimalesDataGridView();
                MessageBox.Show("Ya actualizado");
            }
            catch {
                MessageBox.Show("Error al recargar");
            }
        }
    }
}
