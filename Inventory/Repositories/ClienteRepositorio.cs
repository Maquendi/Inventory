using Inventory.Conexion;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class ClienteRepositorio
    {
        private Connexion con;

        public ClienteRepositorio()
        {
            this.con = new Connexion();
        }



        public void guardar(Cliente cliente)
        {
            string query = "INSERT INTO cliente(nombre_cli,apellido_cli,cedula_cli) values(@nombre,@apellido,@cedula)";

            SqlCommand cmd = new SqlCommand(query, con.getConnexion());

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
            cmd.Parameters.Add("@cedula", SqlDbType.VarChar);

            cmd.Parameters["@nombre"].Value = cliente.nombre_cliente;

            cmd.Parameters["@apellido"].Value = cliente.apellido;

            cmd.Parameters["@cedula"].Value = cliente.cedula;

           // con.getConnexion().Open();
            
            cmd.ExecuteNonQuery();

            con.closeConnection();

        }








    }
}
