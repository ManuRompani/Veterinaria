using Services.Veterinaria.Model;
using Services.Veterinaria.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class ClienteDAO : GenericDAO
    {
        public Cliente getByDNI(int dni)
        {
            Cliente cliente = null;
            try
            {
                string query = "SELECT NOMBRE, APELLIDO, TELEFONO FROM CLIENTES WHERE DNI = @DNI";
                setearConsulta(query);
                insertarParametro("DNI", dni.ToString());
                ejecutarLectura();
                if(_lector.Read())
                {
                    cliente = new Cliente
                    {
                        Dni = dni,
                        Nombre = _lector.IsDBNull(0) ? null : _lector.GetString(0),
                        Apellido = _lector.IsDBNull(1) ? null : _lector.GetString(1),
                        Telefono = _lector.IsDBNull(2) ? null : _lector.GetString(2)
                    };
                }

                return cliente;
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }


        /// <summary>
        /// Devuelve un listado (DataTale) de Clientes con la cantidad de Animales que poseen.
        /// Columnas: DNI, Nombre, Apellido, Telefono, Cantidad de Animales
        /// </summary>
        public DataTable GetTodosConCantidadDeAnimales()
        {
            DataTable dataTable = null;
            try
            {
                //Une las tablas de Animales con Clientes cuando el DNI coincide.
                //Agrupa por DNI (y otros) y cuenta cuantas filas hay en cada grupo
                //Como el cliente siempre es el mismo nos centramos en el resultado como animales de cada cliente
                //Ademas al pasarle a Count A.Cliente_ID y hacer un left join q completa con null, no se cuentan las filas que no tienen animal
                
                string query = "Select C.DNI, C.Nombre, C.Apellido, C.Telefono, COUNT(A.Cliente_ID) as 'Cantidad de Animales' " +
                    "from Clientes as C left join Animales as A on C.DNI = A.Cliente_ID " +
                    "group by C.DNI, C.Nombre, C.Apellido, C.Telefono";

                setearConsulta(query);

                ejecutarLectura();

                if (_lector.HasRows)
                {
                    dataTable = new DataTable();
                    dataTable.Load(_lector);
                }

                return dataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }

        /// <summary>
        /// Devuelve un Cliente (DataTale) la cantidad de Animales que posee.
        /// Columnas: DNI, Nombre, Apellido, Telefono, Cantidad de Animales
        /// </summary>
        public DataTable getByDNIConCantidadAnimales(int dni)
        {
            DataTable dataTable = null;
            try
            {
                //Une las tablas de Animales con Clientes cuando el DNI coincide.
                //Agrupa por DNI (y otros) y cuenta cuantas filas hay en cada grupo
                //Como el cliente siempre es el mismo nos centramos en el resultado como animales de cada cliente
                //Ademas al pasarle a Count A.Cliente_ID y hacer un left join q completa con null, no se cuentan las filas que no tienen animal

                string query = "Select C.DNI, C.Nombre, C.Apellido, C.Telefono, COUNT(A.Cliente_ID) as 'Cantidad de Animales' " +
                    "from Clientes as C left join Animales as A on C.DNI = A.Cliente_ID where C.DNI = @dni " +
                    "group by C.DNI, C.Nombre, C.Apellido, C.Telefono";

                setearConsulta(query);

                insertarParametro("dni", dni.ToString());

                ejecutarLectura();

                if (_lector.HasRows)
                {
                    dataTable = new DataTable();
                    dataTable.Load(_lector);
                }

                return dataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }

        public int Agregar(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);

                string query = "INSERT INTO Clientes (DNI, Nombre, Apellido, Telefono) VALUES (@dni, @nombre, @apellido, @telefono)";
                setearConsulta(query);
                
                insertarParametro("dni", cliente.Dni.ToString());
                insertarParametro("nombre", cliente.Nombre);
                insertarParametro("apellido", cliente.Apellido);
                insertarParametro("telefono", cliente.Telefono);

                return ejecutarConsulta();
            }
            //ClavePrimaria existente, en este  caso el DNI
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new DNIExistException(cliente.Dni);
            }
            //Propiedad que debe ser unica se repeite. No se usa con clientes pero lo dejo para luego reutilizarlo con especies
            catch (SqlException ex) when (ex.Number == 2601)
            {
                throw new UniquePropertyException();
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }

        public List<Cliente> GetTodos()
        {
            List<Cliente> clientes = null; 
            try
            {
                string query = "Select DNI, Nombre, Apellido, Telefono from Clientes";
                setearConsulta(query);

                ejecutarLectura();

                while (_lector.Read())
                {
                    if(clientes is null)
                    {
                        clientes = new List<Cliente>();
                    }

                    Cliente cliente = new Cliente
                    {
                        Dni = _lector.GetInt32(0),
                        Nombre = _lector.IsDBNull(1) ? null : _lector.GetString(1),
                        Apellido = _lector.IsDBNull(2) ? null : _lector.GetString(2),
                        Telefono = _lector.IsDBNull(3) ? null : _lector.GetString(3)
                    };

                    clientes.Add(cliente);
                }

                return clientes;
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        } 
        private void ValidarCliente(Cliente cliente)
        {
            const int caracLimiteNombre = 25;
            const int caracLimiteApellido = 25;

            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Nombre) || cliente.Nombre.Length > caracLimiteNombre)
                    throw new ArgumentException($"El Nombre del Cliente no puede estar vacío ni superar los {caracLimiteNombre} caracteres.");

                if (string.IsNullOrWhiteSpace(cliente.Apellido) || cliente.Apellido.Length > caracLimiteApellido)
                    throw new ArgumentException($"El Apellido del Cliente no puede estar vacío ni superar los {caracLimiteApellido} caracteres.");

                if (!ValidarTelefono(cliente.Telefono))
                    throw new ArgumentException($"El número de telefono {cliente.Telefono} no es valido.");
            }
            catch
            {
                throw;
            }
        }

        private bool ValidarTelefono(string strNumber)
        {
            Regex regex = new Regex(@"^\+?[0-9\s\-\(\)]{8,20}$");
            Match match = regex.Match(strNumber);

            if (match.Success)
                return true;
            else
                return false;
        }

        public int Update(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);

                string query = "Update Clientes Set Nombre = @nombre, Apellido = @apellido, Telefono = @telefono where DNI = @dni";

                setearConsulta(query);

                insertarParametro("dni", cliente.Dni.ToString());
                insertarParametro("nombre", cliente.Nombre);
                insertarParametro("apellido", cliente.Apellido);
                insertarParametro("telefono", cliente.Telefono);

                return ejecutarConsulta();
            }
            catch
            {
                throw;
            }
        }

        public int Delete(int dni)
        {
            try
            {
                string query = "delete from Animales where Animales.Cliente_ID = @dni delete from Clientes where Clientes.DNI = @dni";
                setearConsulta(query);

                insertarParametro("dni", dni.ToString());

                return ejecutarConsulta();
            }
            catch
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }

    }
}
