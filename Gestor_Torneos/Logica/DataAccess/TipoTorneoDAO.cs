using Gestor_Torneos.Logica.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class TipoTorneoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<TipoTorneo> ObtenerTodos()
        {
            List<TipoTorneo> tipos = new List<TipoTorneo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TipoId, Nombre FROM TiposTorneo ORDER BY TipoId";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tipos.Add(new TipoTorneo
                    {
                        TipoId = (int)reader["TipoId"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }

            return tipos;
        }

        public static void Insertar(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TiposTorneo (Nombre) VALUES (@Nombre)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int tipoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TiposTorneo WHERE TipoId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", tipoId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void Actualizar(int tipoId, string nuevoNombre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE TiposTorneo SET Nombre = @Nombre WHERE TipoId = @TipoId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                cmd.Parameters.AddWithValue("@TipoId", tipoId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
