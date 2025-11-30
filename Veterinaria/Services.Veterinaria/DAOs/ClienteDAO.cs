using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class ClienteDAO : GenericDAO
    {
        private readonly List<Cliente> _cacheClientes;


        public Cliente getByDNI(int dni)
        {
            Cliente cliente = null;
            try
            {
                if(_cacheClientes != null)
                {
                    foreach(Cliente clienteCache in _cacheClientes)
                    {
                        if(clienteCache.Dni == dni)
                        {
                            return clienteCache;
                        }
                    }
                }

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
    
    
    }
}
