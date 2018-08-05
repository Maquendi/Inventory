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
    public class PersonaRepositorio
    {
        private Connexion con;

        public PersonaRepositorio()
        {
            this.con = new Connexion();
        }
   



        public void registrar(Persona person)
        {
            string sql = "INSERT INTO persona(nombre,apellido,cedula,correo) VALUES(@nombre,@apellido,@cedula,@correo)";

            var conn = this.con.getConnexion();

            using (IDbTransaction tran = conn.BeginTransaction())
            {
                try
                {

                    SqlCommand command = new SqlCommand(sql,conn);

                    command.Parameters.AddWithValue("@nombre", person.nombre);

                    command.Parameters.AddWithValue("@apellido", person.apellido);

                    command.Parameters.AddWithValue("@cedula", person.cedula);

                    command.Parameters.AddWithValue("@correo", person.correo);

                    persistirUsuario(person.usuario, conn);


                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }




        private void persistirUsuario(Usuario usuario,SqlConnection conn)
        {
            string sql = "INSERT INTO usuario(id_usuario,nombre_usuario,contrasenia,rol) VALUES(@Id, @username,@pass,@role)";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@Id",usuario.user_id);
            command.Parameters.AddWithValue("@username", usuario.username);
            command.Parameters.AddWithValue("@pass", usuario.password);
            command.Parameters.AddWithValue("@role", usuario.role);
        }




        public Persona Authenticar(string username, string password)
        {
            string query = "select * from usuario u inner join persona p on p.persona_id = u.id_usuario WHERE u.nombre_usuario = @username AND u.contrasenia = @contra";

            SqlCommand command = new SqlCommand(query, con.getConnexion());

            Persona person = null;

            command.Parameters.AddWithValue("@username",username);
            command.Parameters.AddWithValue("@contra", password);
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    person = new Persona();
                    person.nombre = reader["nombre"].ToString();
                    person.apellido = reader["apellido"].ToString();
                    person.persona_id = reader.GetInt32(0);
                    person.correo = reader["correo"].ToString();
                    person.cedula = reader["cedula"].ToString();
                    person.usuario.username = username;
                    person.usuario.password = password;
                    person.usuario.role = reader["rol"].ToString(); 
                    person.usuario.user_id = reader.GetInt32(0);
                   
                }

                con.closeConnection();
            }

            return person;
        }

    }
}
