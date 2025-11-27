using Services.Veterinaria.DAOs;
using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Veterinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = null;
            ClienteDAO clienteDAO = new ClienteDAO();

            cliente = clienteDAO.getByDNI(1234);
            if (cliente != null)
            {
                Console.WriteLine(cliente.Dni);
                Console.WriteLine(cliente.Nombre);
                Console.WriteLine(cliente.Apellido);
                Console.WriteLine(cliente.Telefono);
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
    }
}
