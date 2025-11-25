using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.DAOs
{
    public class GenericDAO
    {
        private readonly DbConnection dbConnection;

        public GenericDAO()
        {
            string sConnect = ConfigurationManager.ConnectionStrings["LocalConnection"].ToString();
            dbConnection = new SqlConnection(sConnect);
            dbConnection.Open();
        }
        
        public void desconectar()
        {
            dbConnection.Close();
        }
    }
}
