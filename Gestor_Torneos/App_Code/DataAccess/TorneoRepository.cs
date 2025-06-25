using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class TorneoRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<Torneo> ObtenerTodos()
        {
            List<Torneo> torneos = new List<Torneo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.*, tt.Nombre AS NombreTipoTorneo
                                 FROM Torneos t
                                 LEFT JOIN TiposTorneo tt ON t.TipoId = tt.TipoId";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        torneos.Add(new Torneo
                        {
                            ID_Torneo = (int)reader["ID_Torneo"],
                            Nombre = reader["Nombre"].ToString(),
                            TipoId = reader["TipoId"] as int?,
                            Descripcion = reader["Descripcion"]?.ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                            FechaFin = reader["FechaFin"] as DateTime?,
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaActualiza = reader["FechaActualiza"] as DateTime?,
                            NombreTipoTorneo = reader["NombreTipoTorneo"]?.ToString()
                        });
                    }
                }
            }

            return torneos;
        }

        public void Agregar(Torneo torneo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Torneos (Nombre, TipoId, Descripcion, FechaInicio, FechaFin)
                                 VALUES (@Nombre, @TipoId, @Descripcion, @FechaInicio, @FechaFin)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", torneo.Nombre);
                cmd.Parameters.AddWithValue("@TipoId", (object)torneo.TipoId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", (object)torneo.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaInicio", torneo.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", (object)torneo.FechaFin ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Torneo torneo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Torneos
                                 SET Nombre = @Nombre,
                                     TipoId = @TipoId,
                                     Descripcion = @Descripcion,
                                     FechaInicio = @FechaInicio,
                                     FechaFin = @FechaFin
                                 WHERE ID_Torneo = @ID_Torneo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Torneo", torneo.ID_Torneo);
                cmd.Parameters.AddWithValue("@Nombre", torneo.Nombre);
                cmd.Parameters.AddWithValue("@TipoId", (object)torneo.TipoId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", (object)torneo.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaInicio", torneo.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", (object)torneo.FechaFin ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Torneo ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Torneos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Torneo", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Torneo
                        {
                            ID_Torneo = (int)reader["ID_Torneo"],
                            Nombre = reader["Nombre"].ToString(),
                            TipoId = reader["TipoId"] as int?,
                            Descripcion = reader["Descripcion"]?.ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                            FechaFin = reader["FechaFin"] as DateTime?,
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaActualiza = reader["FechaActualiza"] as DateTime?
                        };
                    }
                }
            }

            return null;
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Torneos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Torneo", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}