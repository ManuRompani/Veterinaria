using Services.Veterinaria.DAOs;
using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private List<Services.Veterinaria.Model.Cliente> ObtenerClientesDesdeDB()
        {
            List<Services.Veterinaria.Model.Cliente> clientes = new List<Services.Veterinaria.Model.Cliente>();
            string query = "SELECT DNI, NOMBRE, APELLIDO, TELEFONO FROM CLIENTES";

            using (SqlConnection conexion = new SqlConnection(@"Server=EMILIANO\SQLEXPRESS01;Database=veterinaria;Integrated Security=True;"))
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        clientes.Add(new Services.Veterinaria.Model.Cliente
                        {
                            Dni = lector.GetInt32(0),
                            Nombre = lector.IsDBNull(1) ? null : lector.GetString(1),
                            Apellido = lector.IsDBNull(2) ? null : lector.GetString(2),
                            Telefono = lector.IsDBNull(3) ? null : lector.GetString(3)
                        });
                    }
                }
            }

            return clientes;
        }

        private void AgregarAnimalesForm_Load(object sender, EventArgs e)
        {
            EspecieDAO _especieDAO = new EspecieDAO();
            List<Services.Veterinaria.Model.Cliente> _listaClientes = this.ObtenerClientesDesdeDB();
            cmbCliente.DataSource = _listaClientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Dni";

            List<Especie> _listaEspecies = _especieDAO.getAllEspecies();
            cmbEspecie.DataSource = _listaEspecies;
            cmbEspecie.DisplayMember = "Nombre";
            cmbEspecie.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnimalDAO _animalDAO = new AnimalDAO();

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                //Ideal crear una excepcion para validar campos vacios
                MessageBox.Show("Los campos no pueden estar vacios");
                return;
            }

            // Valido ingreso de edad
            if (int.TryParse(textBox2.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un numero");
                return;
            }
            if (edad < 0)
            {
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

            nuevoAnimal.ClienteDueño = new Services.Veterinaria.Model.Cliente { Dni = (int)cmbCliente.SelectedValue };
            nuevoAnimal.Especie = new Especie { ID = (int)cmbEspecie.SelectedValue };

            if (_animalDAO.insertAnimal(nuevoAnimal))
            {
                MessageBox.Show("Animal agregado exitosamente");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}