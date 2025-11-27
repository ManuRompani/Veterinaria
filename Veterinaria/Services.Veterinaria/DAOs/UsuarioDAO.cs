using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class UsuarioDAO : GenericDAO
    {
        public bool autenticarUsuario(Usuario usuario)
        {

            bool isAutenticado = false;
            try
            {
                ValidarUsuario(usuario);
                
                string query = "Select UserName from Usuarios where UserName = @uName and UserPassword = @uPass";
                setearConsulta(query);

                insertarParametro("uName", usuario.UserName);
                insertarParametro("uPass", usuario.UserPassword);
                
                ejecutarLectura();
                if (_lector.Read())
                    isAutenticado = true;

                return isAutenticado;
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

        public bool isFirstLogin()
        {
            try
            {
                bool isFirstLogin = true;
                
                string query = "Select Count(*) Cantidad from Usuarios";
                setearConsulta(query);
                
                ejecutarLectura();
                if (_lector.Read() && !_lector.IsDBNull(0) && _lector.GetInt32(0) > 0)
                    isFirstLogin = false;

                return isFirstLogin;
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

        public void registrarUsuario(Usuario usuario)
        {
            try
            {

                ValidarUsuario(usuario);
                
                string query = "INSERT INTO Usuarios (UserName, UserPassword) VALUES (@uName, @uPass)";
                setearConsulta(query);
                
                insertarParametro("uName", usuario.UserName);
                insertarParametro("uPass", usuario.UserPassword);
                
                ejecutarLectura();

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

        private void ValidarUsuario(Usuario usuario)
        {
            const int caracLimite = 25;

            if (string.IsNullOrWhiteSpace(usuario.UserName) || string.IsNullOrWhiteSpace(usuario.UserPassword) 
                || usuario.UserName.Length > caracLimite || usuario.UserPassword.Length > caracLimite)
            {
                throw new ArgumentException($"El nombre de usuario y la contraseña no pueden estar vacíos ni superar los {caracLimite} caracteres.");
            }
        }
    }
}
