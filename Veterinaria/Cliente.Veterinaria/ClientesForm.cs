using Cliente.Veterinaria.Ventanas_Animales;
using Services.Veterinaria.DAOs;
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
    public partial class ClientesForm : Form
    {
        private readonly ClienteDAO _clienteDAO = null;
        public ClientesForm()
        {
            InitializeComponent();

            _clienteDAO = new ClienteDAO();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            DataTable cliente = null;
            try
            {
                string sDNI = tboxBuscarDNI.Text;

                if (string.IsNullOrWhiteSpace(sDNI))
                {
                    cliente = _clienteDAO.GetTodosConCantidadDeAnimales();
                }
                else
                {
                    cliente = _clienteDAO.getByDNIConCantidadAnimales(int.Parse(sDNI));

                }
                
                if (cliente is null)
                {
                    MessageBox.Show(
                        $"No se encontró ningún cliente con el DNI {sDNI}.",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = cliente;

                AgregarBotones();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "El DNI debe contener solo números.",
                    "Formato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error inesperado:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            AgregarClienteForm agregarClienteForm = new AgregarClienteForm(_clienteDAO, true);
            agregarClienteForm.ShowDialog();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _clienteDAO.GetTodosConCantidadDeAnimales();

                AgregarBotones();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                   "Ocurrió un error al intentar cargar el listado de Clientes.\n" +
                   $"Detalles: {ex.Message}",
                   "Error al agregar cliente",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
               );
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    int dni = (int)senderGrid.Rows[e.RowIndex].Cells["DNI"].Value;
                    int animales = (int)senderGrid.Rows[e.RowIndex].Cells["Cantidad de Animales"].Value;

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Editar":
                            AgregarClienteForm clienteForm = new AgregarClienteForm(this._clienteDAO, false, dni);
                            clienteForm.ShowDialog();
                            break;
                        case "Ver Animales":
                            if(animales > 0)
                            {
                                DetalleAnimalForm detalleAnimalForm = new DetalleAnimalForm(dni);
                                detalleAnimalForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("El Cliente no tiene Animales");
                            }
                            break;

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgregarBotones()
        {
            if (dgvClientes.Columns.Contains("Editar"))
                dgvClientes.Columns.Remove("Editar");

            if (dgvClientes.Columns.Contains("Ver Animales"))
                dgvClientes.Columns.Remove("Ver Animales");

            if (!dgvClientes.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditarCliente = new DataGridViewButtonColumn();
                btnEditarCliente.Text = "Editar";
                btnEditarCliente.Name = "Editar";
                btnEditarCliente.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(btnEditarCliente);
            }

            if (!dgvClientes.Columns.Contains("Ver Animales"))
            {
                DataGridViewButtonColumn btnVerAnimales = new DataGridViewButtonColumn();
                btnVerAnimales.Text = "Ver Animales";
                btnVerAnimales.Name = "Ver Animales";
                btnVerAnimales.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(btnVerAnimales);
            }
        }
    }
}
