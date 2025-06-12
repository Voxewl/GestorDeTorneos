using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class PartidoRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<Partido> ObtenerTodos()
        {
            List<Partido> lista = new List<Partido>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.*, 
                                        t.Nombre AS NombreTorneo, 
                                        e1.Nombre AS NombreEquipo1, 
                                        e2.Nombre AS NombreEquipo2
                                 FROM Partidos p
                                 JOIN Torneos t ON p.ID_Torneo = t.ID_Torneo
                                 JOIN Equipos e1 ON p.ID_Equipo1 = e1.ID_Equipo
                                 JOIN Equipos e2 ON p.ID_Equipo2 = e2.ID_Equipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Partido
                        {
                            ID_Partido = (int)reader["ID_Partido"],
                            ID_Torneo = (int)reader["ID_Torneo"],
                            ID_Equipo1 = (int)reader["ID_Equipo1"],
                            ID_Equipo2 = (int)reader["ID_Equipo2"],
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            GolesEquipo1 = (byte)reader["GolesEquipo1"],
                            GolesEquipo2 = (byte)reader["GolesEquipo2"],
                            Finalizado = (bool)reader["Finalizado"],
                            NombreTorneo = reader["NombreTorneo"].ToString(),
                            NombreEquipo1 = reader["NombreEquipo1"].ToString(),
                            NombreEquipo2 = reader["NombreEquipo2"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Partido ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Partidos WHERE ID_Partido = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Partido
                        {
                            ID_Partido = (int)reader["ID_Partido"],
                            ID_Torneo = (int)reader["ID_Torneo"],
                            ID_Equipo1 = (int)reader["ID_Equipo1"],
                            ID_Equipo2 = (int)reader["ID_Equipo2"],
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            GolesEquipo1 = (byte)reader["GolesEquipo1"],
                            GolesEquipo2 = (byte)reader["GolesEquipo2"],
                            Finalizado = (bool)reader["Finalizado"]
                        };
                    }
                }
            }

            return null;
        }

        public void Agregar(Partido partido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Partidos (ID_Torneo, ID_Equipo1, ID_Equipo2, Fecha, GolesEquipo1, GolesEquipo2, Finalizado)
                                 VALUES (@ID_Torneo, @ID_Equipo1, @ID_Equipo2, @Fecha, @GolesEquipo1, @GolesEquipo2, @Finalizado)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Torneo", partido.ID_Torneo);
                cmd.Parameters.AddWithValue("@ID_Equipo1", partido.ID_Equipo1);
                cmd.Parameters.AddWithValue("@ID_Equipo2", partido.ID_Equipo2);
                cmd.Parameters.AddWithValue("@Fecha", partido.Fecha);
                cmd.Parameters.AddWithValue("@GolesEquipo1", partido.GolesEquipo1);
                cmd.Parameters.AddWithValue("@GolesEquipo2", partido.GolesEquipo2);
                cmd.Parameters.AddWithValue("@Finalizado", partido.Finalizado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Partido partido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Partidos
                                 SET ID_Torneo = @ID_Torneo,
                                     ID_Equipo1 = @ID_Equipo1,
                                     ID_Equipo2 = @ID_Equipo2,
                                     Fecha = @Fecha,
                                     GolesEquipo1 = @GolesEquipo1,
                                     GolesEquipo2 = @GolesEquipo2,
                                     Finalizado = @Finalizado
                                 WHERE ID_Partido = @ID_Partido";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Partido", partido.ID_Partido);
                cmd.Parameters.AddWithValue("@ID_Torneo", partido.ID_Torneo);
                cmd.Parameters.AddWithValue("@ID_Equipo1", partido.ID_Equipo1);
                cmd.Parameters.AddWithValue("@ID_Equipo2", partido.ID_Equipo2);
                cmd.Parameters.AddWithValue("@Fecha", partido.Fecha);
                cmd.Parameters.AddWithValue("@GolesEquipo1", partido.GolesEquipo1);
                cmd.Parameters.AddWithValue("@GolesEquipo2", partido.GolesEquipo2);
                cmd.Parameters.AddWithValue("@Finalizado", partido.Finalizado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Partidos WHERE ID_Partido = @ID_Partido";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Partido", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}