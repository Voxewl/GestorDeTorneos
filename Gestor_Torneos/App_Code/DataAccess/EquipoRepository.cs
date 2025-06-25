using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class EquipoRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<Equipo> ObtenerTodos()
        {
            List<Equipo> equipos = new List<Equipo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT e.*, t.Nombre AS NombreTorneo
                                 FROM Equipos e
                                 JOIN Torneos t ON e.ID_Torneo = t.ID_Torneo";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipos.Add(new Equipo
                        {
                            ID_Equipo = (int)reader["ID_Equipo"],
                            Nombre = reader["Nombre"].ToString(),
                            ID_Torneo = (int)reader["ID_Torneo"],
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaActualiza = reader["FechaActualiza"] as DateTime?,
                            NombreTorneo = reader["NombreTorneo"].ToString()
                        });
                    }
                }
            }

            return equipos;
        }

        public void Agregar(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Equipos (Nombre, ID_Torneo)
                                 VALUES (@Nombre, @ID_Torneo)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                cmd.Parameters.AddWithValue("@ID_Torneo", equipo.ID_Torneo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Equipos
                                 SET Nombre = @Nombre,
                                     ID_Torneo = @ID_Torneo
                                 WHERE ID_Equipo = @ID_Equipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                cmd.Parameters.AddWithValue("@ID_Torneo", equipo.ID_Torneo);
                cmd.Parameters.AddWithValue("@ID_Equipo", equipo.ID_Equipo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idEquipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Equipos WHERE ID_Equipo = @ID_Equipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Equipo", idEquipo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Equipo ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Equipos WHERE ID_Equipo = @ID_Equipo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Equipo", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Equipo
                        {
                            ID_Equipo = (int)reader["ID_Equipo"],
                            Nombre = reader["Nombre"].ToString(),
                            ID_Torneo = (int)reader["ID_Torneo"],
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaActualiza = reader["FechaActualiza"] as DateTime?
                        };
                    }
                }
            }

            return null;
        }
    }
}