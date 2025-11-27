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


        //Metodos privados de los daos para crear consultas sin repetir codigo
        //
        //Esto es para desconectar la base de datos
        protected void desconectar()
        {
            if (_lector != null)
                _lector.Close();
            
            _dbConnection.Close();
        }

        
        protected void insertarParametro(string nombre, string valor)
        {
            DbParameter parametro = _comando.CreateParameter();
            
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            
            _comando.Parameters.Add(parametro);
        }

        protected void setearConsulta(string consulta)
        {
            _comando = _dbConnection.CreateCommand();
            _comando.CommandText = consulta;
        }

        protected void ejecutarLectura()
        {
            if(this._dbConnection.State == ConnectionState.Closed)
                this._dbConnection.Open();

            this._lector = _comando.ExecuteReader();
        }

    }
}
