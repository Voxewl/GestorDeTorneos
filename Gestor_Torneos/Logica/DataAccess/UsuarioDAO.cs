using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class UsuarioDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<UsuarioDTO> ObtenerTodos()
        {
            var lista = new List<UsuarioDTO>();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, UserName FROM AspNetUsers";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new UsuarioDTO
                    {
                        Id = reader["Id"].ToString(),
                        UserName = reader["UserName"].ToString()
                    });
                }
            }
            return lista;
        }
    }

    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}