using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class TipoTorneoRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<TipoTorneo> ObtenerTodos()
        {
            List<TipoTorneo> tipos = new List<TipoTorneo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TipoId, Nombre FROM TiposTorneo ORDER BY Nombre";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipos.Add(new TipoTorneo
                        {
                            TipoId = (int)reader["TipoId"],
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }

            return tipos;
        }

        public TipoTorneo ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TipoId, Nombre FROM TiposTorneo WHERE TipoId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TipoTorneo
                        {
                            TipoId = (int)reader["TipoId"],
                            Nombre = reader["Nombre"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}