using Services.Veterinaria.DAOs;
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
    public partial class VerReportePesosAnimales : Form
    {
        public VerReportePesosAnimales()
        {
            InitializeComponent();
        }

        public void validarCampos() {
           
            if (!int.TryParse(textBox1.Text, out int edadMin) ||
            !int.TryParse(textBox2.Text, out int edadMax))
            {
                string msg = "Por favor ingresa números válidos para el rango de edad.";
                throw new ValidationException(msg);                
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AnimalDAO _animalDAO = new AnimalDAO();
            
            try {
                this.validarCampos();
                int.TryParse(textBox1.Text, out int edadMin);
                int.TryParse(textBox2.Text, out int edadMax);

                DataTable dt = _animalDAO.getPorRangoEdad(edadMin, edadMax);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
