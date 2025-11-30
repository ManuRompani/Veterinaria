using Services.Veterinaria.DAOs;
using Services.Veterinaria.Model;
using Services.Veterinaria.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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

        public void limpiarTextBox() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        public void validarCampos() {
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
        }
        

        private List<Services.Veterinaria.Model.Cliente> ObtenerClientesDesdeDB()
        {
            List<Services.Veterinaria.Model.Cliente> clientes = new List<Services.Veterinaria.Model.Cliente>();
            string query = "SELECT DNI, NOMBRE, APELLIDO, TELEFONO FROM CLIENTES";

            using (SqlConnection conexion = new SqlConnection(@"Server=YAMILAHOLIKDESK\SQLEXPRESS;Database=Veterinaria;Integrated Security=True;"))
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
            try { 
                this.validarCampos();

                AnimalDAO _animalDAO = new AnimalDAO();

                Animal nuevoAnimal = new Animal
                {
                    Nombre = textBox1.Text,
                    Peso = decimal.Parse(textBox2.Text),
                    Edad = int.Parse(textBox3.Text),
                };

                nuevoAnimal.ClienteDueño = new Services.Veterinaria.Model.Cliente { Dni = (int)cmbCliente.SelectedValue };
                nuevoAnimal.Especie = new Especie { ID = (int)cmbEspecie.SelectedValue };

                if (_animalDAO.insertAnimal(nuevoAnimal))
                {
                    MessageBox.Show("Animal agregado exitosamente");
                    this.limpiarTextBox();
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex) { 
            MessageBox.Show(ex.Message + ". Excepcion final");
            }
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}