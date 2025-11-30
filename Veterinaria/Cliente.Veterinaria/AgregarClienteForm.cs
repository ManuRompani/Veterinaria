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

namespace Cliente.Veterinaria
{
    public partial class AgregarClienteForm : Form
    {
        private ClienteDAO _clienteDAO = null; 
        private bool _isAgregar;
        private int _dni;
        /// <summary>
        /// isAgregar define el comportamiento del formulario, true para agregar cliente, false para editar cliente.
        /// </summary>
        public AgregarClienteForm(ClienteDAO clienteDAO, bool isAgregar, int dni = 0)
        {
            _clienteDAO = clienteDAO;
            //Recibe por parametro si se comportara como formulario para agregar cliente o editar cliente
            _isAgregar = isAgregar;
            _dni = dni;

            InitializeComponent();
        }

        private void btnAgregarCLiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tboxDNI.Text, out int dni))
                {
                    MessageBox.Show(
                        "El DNI debe ser numérico.",
                        "Dato inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                //Tengo que ponerlo asi porque sino me toma el Cliente del namespace
                Services.Veterinaria.Model.Cliente cliente = new Services.Veterinaria.Model.Cliente
                {
                    Dni = dni,
                    Nombre = tboxNombre.Text,
                    Apellido = tboxApellido.Text,
                    Telefono = tboxTelefono.Text
                };

                if(_clienteDAO.Agregar(cliente) > 0)
                {
                    MessageBox.Show(
                        $"El Cliente se agrego correctamente.",
                        "Cliente Agregado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No fue posible agregar al Cliente.",
                        "Error al agregar Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    $"Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (DNIExistException ex)
            {
                MessageBox.Show(
                   ex.Message,
                   $"DNI Inválido",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible agregar al cliente.\n" +
                    "Se produjo un error inesperado.\n\n" +
                    $"Detalles: {ex.Message}",
                    "Error al agregar cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AgregarClienteForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_isAgregar)
                {
                    btnEditar.Visible = true;
                    lblTitulo.Text = "Editar Cliente";
                    tboxDNI.Enabled = false;
                    tboxDNI.ReadOnly = true;
                    btnEliminar.Visible = true;

                    Services.Veterinaria.Model.Cliente cliente = _clienteDAO.getByDNI(_dni);

                    if (cliente is null)
                    {
                        MessageBox.Show(
                           $"No se encontró ningún cliente con el DNI {_dni}.",
                           "Cliente no encontrado",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                       );

                        this.Close();
                        return;
                    }
                    tboxDNI.Text = cliente.Dni.ToString();
                    tboxNombre.Text = cliente.Nombre;
                    tboxApellido.Text = cliente.Apellido;
                    tboxTelefono.Text = cliente.Telefono;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                      $"Se eliminará el cliente con DNI {_dni} y todos sus animales de manera permanente.\n\n¿Desea continuar?",
                      "Confirmar eliminación",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning
                  );

                if (result == DialogResult.Yes)
                {
                    if (_clienteDAO.Delete(_dni) > 0)
                    {
                        MessageBox.Show("Cliente eliminado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible eliminar al Cliente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Services.Veterinaria.Model.Cliente cliente = new Services.Veterinaria.Model.Cliente
                {
                    Dni = _dni,
                    Nombre = tboxNombre.Text,
                    Apellido = tboxApellido.Text,
                    Telefono = tboxTelefono.Text
                };

                if(_clienteDAO.Update(cliente) > 0)
                {
                    MessageBox.Show(
                       $"El Cliente se edito correctamente.",
                       "Cliente editado",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                   );
                }
                else
                {
                    MessageBox.Show(
                       "No fue posible editar al Cliente.",
                       "Error al editar Cliente",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                   );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
