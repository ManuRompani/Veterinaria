using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class GenericDAO
    {
        protected readonly DbConnection _dbConnection;
        protected DbCommand _comando;
        protected DbDataReader _lector;

        public GenericDAO()
        {
            string sConnect = ConfigurationManager.ConnectionStrings["LocalConnection"].ToString();
            _dbConnection = new SqlConnection(sConnect);
        }


        //============== Metodos privados de los daos para crear consultas sin repetir codigo ==============
        //
        //
        /// <summary>
        /// Cierra el lector y la conexion
        /// </summary>
        protected void desconectar()
        {
            if (_lector != null)
                _lector.Close();

            _dbConnection.Close();
        }

        /// <summary>
        /// Agrega un parametro al comando
        /// </summary>
        protected void insertarParametro(string nombre, string valor)
        {
            DbParameter parametro = _comando.CreateParameter();

            parametro.ParameterName = nombre;
            parametro.Value = valor;

            _comando.Parameters.Add(parametro);
        }
        protected void insertarParametro(string nombre, int valor)
        {
            DbParameter parametro = _comando.CreateParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Int32;
            _comando.Parameters.Add(parametro);
        }

        protected void insertarParametro(string nombre, decimal valor)
        {
            DbParameter parametro = _comando.CreateParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Decimal;
            _comando.Parameters.Add(parametro);
        }

        /// <summary>
        /// Setea la consulta sql en el comando
        /// </summary>
        protected void setearConsulta(string consulta)
        {
            _comando = _dbConnection.CreateCommand();
            _comando.CommandText = consulta;
        }

        /// <summary>
        /// Ejecuta un SELECT y abre el lector
        /// </summary>
        protected void ejecutarLectura()
        {
            if (this._dbConnection.State == ConnectionState.Closed)
                this._dbConnection.Open();

            this._lector = _comando.ExecuteReader();
        }

        /// <summary>
        /// Ejecuta un INSERT, UPDATE o DELETE y devuelve el numero de filas afectadas
        /// </summary>
        protected int ejecutarConsulta()
        {
            if (this._dbConnection.State == ConnectionState.Closed)
                this._dbConnection.Open();

            return _comando.ExecuteNonQuery();
        }


    }
}
