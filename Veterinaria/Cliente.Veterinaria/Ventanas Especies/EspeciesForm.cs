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
    public partial class EspeciesForm : Form
    {
        private EspecieDAO especieDAO;
        private List<Especie> _listadoEspecies;
        public EspeciesForm()
        {
            InitializeComponent();
            especieDAO = new EspecieDAO();
            cargarEspeciesDGV();
        }

        private void cargarEspeciesDGV()
        {
            try
            {
                _listadoEspecies = especieDAO.getAllEspecies();
                dgvEspecies.DataSource = _listadoEspecies;
            }
            catch
            {
                MessageBox.Show("Error al cargar las especies");
            } 
        }

        private void btnActualizarDGV_Click(object sender, EventArgs e)
        {
            cargarEspeciesDGV();
        }
    }
}
