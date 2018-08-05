using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace Inventory.Conexion
{
    public class Connexion
    {

        public string connectionString = "Server=localhost;Database=Sys_Inventario;Trusted_Connection=true";

        private SqlConnection con;


        public SqlConnection getConnexion()
        {
            con = new SqlConnection(connectionString);

            con.Open();
            return con;
        }


        public void closeConnection()
        {
            this.con.Close();
        }

    }
}
