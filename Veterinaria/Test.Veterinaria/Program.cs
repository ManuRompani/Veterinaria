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
            //===================CLIENTE===================
            Cliente cliente = null;
            ClienteDAO clienteDAO = new ClienteDAO();
            Console.WriteLine("=============CLIENTE=============");
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


            //===================USUARIO===================
            Usuario usuario = new Usuario
            {
                UserName = "admin",
                UserPassword = "admin"
            };
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            Console.WriteLine("\n\n=============USUARIO=============");
            Console.WriteLine("Primer inicio:" + usuarioDAO.isFirstLogin());
            Console.WriteLine("Credenciales validas:" + usuarioDAO.autenticarUsuario(usuario));
            
            if (usuarioDAO.isFirstLogin())
            {
                try
                {
                    usuarioDAO.registrarUsuario(usuario);
                    Console.WriteLine("Usuario creado exitosamente");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                Console.WriteLine("Credenciales validas:" + usuarioDAO.autenticarUsuario(usuario));
            }
        }
    }
}
