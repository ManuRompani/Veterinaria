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
            List<Animal> _listaAnimales = new List<Animal>();
        }


        public void cargarAnimalesDataGridView()
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
    }
}
