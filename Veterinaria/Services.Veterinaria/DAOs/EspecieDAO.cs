using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class EspecieDAO : GenericDAO
    {
        /*Metodo para insertar una especie a la BD*/
        public bool InsertarEspecie(Especie especie)
        {
            try
            {
                string query = @"INSERT INTO Especies (Nombre, EdadMadurez, PesoPromedio)
                        VALUES (@nombre, @edadmadurez, @pesopromedio)";

                setearConsulta(query);

                insertarParametro("@nombre", especie.Nombre);
                insertarParametro("@edadmadurez", especie.EdadMadurez.ToString());
                insertarParametro("@pesopromedio", especie.PesoPromedio.ToString());

                int RowsAffected = ejecutarConsulta();

                return RowsAffected > 0;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error al insertar la especie '{especie.Nombre}': {ex.Message}", ex);
            }
            finally
            {
                desconectar();
            }
        }

        /*Metodo para obtener todas las especies*/
        public List<Especie> getAllEspecies()
        {
            List<Especie> _listadoEspecies = new List<Especie>();

            try
            {
                string query = @"SELECT ID, Nombre, EdadMadurez, PesoPromedio 
                        FROM Especies 
                        ORDER BY Nombre";

                setearConsulta(query);
                ejecutarLectura();

                while (_lector.Read())
                {
                    Especie especie = new Especie
                    {
                        ID = _lector.GetInt32(0),
                        Nombre = _lector.GetString(1),
                        EdadMadurez = _lector.GetInt32(2),
                        PesoPromedio = _lector.GetDecimal(3),
                    };
                    _listadoEspecies.Add(especie);
                }

                return _listadoEspecies;
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

        /*Metodo para Modificar/editar/updatear una especie*/
        public bool updateEspecie(Especie especie)
        {
            try
            {
                string query = @"UPDATE Especies
                                SET Nombre = @nombre,
                                    EdadMadurez = @edadmadurez,
                                    PesoPromedio = @pesopromedio
                                WHERE ID = @id";
                setearConsulta(query);

                insertarParametro("@nombre", especie.Nombre);
                insertarParametro("@edadmadurez", especie.EdadMadurez.ToString());
                insertarParametro("@pesopromedio", especie.PesoPromedio.ToString());
                insertarParametro("@id", especie.ID.ToString());

                int RowsAffected = ejecutarConsulta();

                return RowsAffected > 0;
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
