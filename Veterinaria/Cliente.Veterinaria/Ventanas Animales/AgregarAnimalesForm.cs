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
    public partial class AgregarAnimalesForm : Form
    {
        public AgregarAnimalesForm()
        {
            InitializeComponent();
        }

        private void AgregarAnimalesForm_Load(object sender, EventArgs e)
        {

            //Creo los objetos DAO para acceder a sus metodos.
            ClienteDAO clienteDao = new ClienteDAO();
            //EspecieDAO especieDao = new EspecieDAO();


            //Le paso al combobox todos los clientes con su nombre completo
            //cmbCliente.DataSource = clienteDao.getAll();
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Dni";

            //Le paso al combobox todas las especie por su nombre
            //cmbEspecie.DataSource = especieDao.getAll();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text)){
                //Ideal crear una excepcion para validar campos vacios
                MessageBox.Show("Los campos no pueden estar vacios");
                return;
            }

            // Valido ingreso de edad
            if (!int.TryParse(textBox2.Text, out int edad)){
                MessageBox.Show("La edad debe ser un numero");
                return;
            }
            if (edad < 0) {
                MessageBox.Show("La edad no puede ser negativa");
            }

            //Valido ingreso de peso
            if (!decimal.TryParse(textBox3.Text, out decimal peso))
            {
                MessageBox.Show("El peso debe ser numerico");
                return;
            }
            if (peso < 0)
            {
                MessageBox.Show("El peso no puede ser negativo");
            }

            

            //Si todo sale bien, creo el objeto animal

            Animal nuevoAnimal = new Animal
            {
                Nombre = textBox1.Text,
                Peso = peso,
                Edad = edad
            };

            
            //nuevoAnimal.Cliente = new Cliente { Dni = (int)cmbCliente.SelectedValue };
            nuevoAnimal.Especie = new Especie { ID = (int)cmbEspecie.SelectedValue };
        }
    }
}
