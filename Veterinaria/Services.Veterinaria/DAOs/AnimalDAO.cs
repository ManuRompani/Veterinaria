using Services.Veterinaria.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class AnimalDAO : GenericDAO
    {
        /// <summary>
        /// Método para recorrer la DB y devolver una lista con todos los animales
        /// </summary>
        /// <returns></returns>
        public List<Animal> getAllAnimals() {

            var ListaAnimales = new List<Animal>();

            string consulta = "SELECT ID, Nombre, Peso, Edad, Cliente_ID, Especie_ID FROM Animales";

            setearConsulta(consulta);
            ejecutarLectura();

            while(_lector.Read()) {
                Animal animal = new Animal()
                {
                    ID = _lector.GetInt32(0),
                    Nombre = _lector.GetString(1),
                    Peso = _lector.GetDecimal(2),
                    Edad = _lector.GetInt32(3),
                    ClienteDueño = new Cliente { Dni = _lector.GetInt32(4) },
                    Especie = new Especie { ID = _lector.GetInt32(5) }
                };
                ListaAnimales.Add(animal);
            }

            desconectar();

            return ListaAnimales;
        }


        /// <summary>
        /// Meotodo que recorre la DB y devuelve un DataTable con Animal + Cliente Nombre + Especie Nombre
        /// </summary>
        /// <returns></returns>
        public DataTable getTodosAnimalesConEspecie()
        {
            DataTable dataTable = null;
            try
            {
                string query = @"
            SELECT a.Nombre AS Animal,
                   e.Nombre AS Especie,
                   c.Nombre + ' ' + c.Apellido AS Cliente
            FROM Animales a
            JOIN Especies e ON a.Especie_ID = e.ID
            JOIN Clientes c ON a.Cliente_ID = c.DNI";

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
        /// Metodo que recibe dos parametros para buscar por rango de edad en la base de datos.
        /// Devuelve el maximo, minimo y promedio de peso agrupados por especie.
        /// </summary>
        /// <param name="edad1"></param>
        /// <param name="edad2"></param>
        /// <returns></returns>
        public DataTable getPorRangoEdad(int edad1, int edad2) {

            string consulta = @"
        SELECT
            e.Nombre AS Especie,
            MAX(a.Peso) AS PesoMaximo,
            MIN(a.Peso) AS PesoMinimo,
            AVG(a.Peso) AS PesoPromedio
        FROM 
            Animales a
        JOIN 
            Especies e ON a.Especie_ID = e.ID
        WHERE 
            a.Edad BETWEEN @edadMin AND @edadMax
        GROUP BY 
            e.Nombre;";

            setearConsulta(consulta);
            
            //Esto vendria a ser el rango que ingresa el cliente en el textBox
            insertarParametro("@edadMin", edad1.ToString());
            insertarParametro("@edadMax", edad2.ToString());

            ejecutarLectura();
                        
            DataTable dt = new DataTable();
            dt.Load(_lector);   
         

            desconectar();

            return dt;
        
        }



        /// <summary>
        /// Metodo para insertar un animal en la tabla Animales de la base de datos, devuelve un booleano
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool insertAnimal(Animal animal) {

            string edad = animal.Edad.ToString();
            string query = $@"INSERT INTO Animales (Nombre, Peso, Edad, Cliente_ID, Especie_ID)
VALUES (@nombre, @peso, @edad, @clienteId, @especieId);";

            setearConsulta(query);

            insertarParametro("@nombre", animal.Nombre);
            insertarParametro("@peso", animal.Peso.ToString());
            insertarParametro("@edad", animal.Edad.ToString());
            insertarParametro("@clienteId", animal.ClienteDueño.Dni.ToString());
            insertarParametro("@especieId", animal.Especie.ID.ToString());

            int RowsAffected = ejecutarConsulta();

            desconectar();


            // Si RowsAffected es mayor a 0, entonces se inserto correctamente
            return RowsAffected > 0;
        }

        /// <summary>
        /// Metodo para eliminar un animal completo de la base de datos, devuelve un booleano
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool deleteAnimal(Animal animal) {

            string consulta = "DELETE FROM Animales WHERE ID = @id";
            setearConsulta(consulta);
            insertarParametro("@id", animal.ID.ToString());

            int RowsAffected = ejecutarConsulta();

            return RowsAffected > 0;
        }


        /// <summary>
        /// Metodo para actualizar un animal, devuelve un booleano
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool updateAnimal(Animal animal) {

            try
            {
                string consulta = @"UPDATE Animales 
                            SET Nombre = @nombre,
                                Peso = @peso,
                                Edad = @edad,
                                Cliente_ID = @cliente,
                                Especie_ID = @especie
                            WHERE ID = @id";

                setearConsulta(consulta);

                insertarParametro("nombre", animal.Nombre);
                insertarParametro("peso", animal.Peso);
                insertarParametro("edad", animal.Edad);
                insertarParametro("cliente", animal.ClienteDueño.Dni);
                insertarParametro("especie", animal.Especie.ID);
                insertarParametro("id", animal.ID);

                int RowsAffected = ejecutarConsulta();
                desconectar();

                return RowsAffected > 0;
            }
            catch(Exception ex){
                desconectar();
                return false;
            }
        }



        /// <summary>
        /// Devuelve una lista de animales con su especie pertenecientes a un dni en especifico
        /// </summary>
        public List<Animal> getAllAnimalesConEspecieByDNI(int dni)
        {
            List<Animal> animales = null;

            try
            {
                string consulta = "SELECT A.ID, A.Nombre, A.Peso, A.Edad, Cliente_ID, Especie_ID, E.Nombre, E.EdadMadurez, E.PesoPromedio  " +
                    "FROM Animales as A left join Especies as E on A.Especie_ID = E.ID where A.Cliente_ID = @dni";

                setearConsulta(consulta);

                insertarParametro("dni", dni.ToString());

                ejecutarLectura();

                while (_lector.Read())
                {
                    if(animales is null)
                    {
                        animales = new List<Animal>();
                    }

                    Animal animal = new Animal()
                    {
                        ID = _lector.GetInt32(0),
                        Nombre = _lector.GetString(1),
                        Peso = _lector.GetDecimal(2),
                        Edad = _lector.GetInt32(3),
                        ClienteDueño = new Cliente { Dni = _lector.GetInt32(4) },
                        Especie = new Especie
                        {
                            ID = _lector.GetInt32(5),
                            Nombre = _lector.GetString(6),
                            EdadMadurez = _lector.GetInt32(7),
                            PesoPromedio = _lector.GetDecimal(8)

                        }
                    };

                    animales.Add(animal);
                }

                return animales;
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
