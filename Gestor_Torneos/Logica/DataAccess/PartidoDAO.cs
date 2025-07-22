using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class PartidoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void Insertar(int torneoId, int equipo1, int equipo2, DateTime fecha)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Partidos (ID_Torneo, ID_Equipo1, ID_Equipo2, Fecha)
            VALUES (@TorneoId, @Equipo1, @Equipo2, @Fecha)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TorneoId", torneoId);
                cmd.Parameters.AddWithValue("@Equipo1", equipo1);
                cmd.Parameters.AddWithValue("@Equipo2", equipo2);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<PartidoResumen> ObtenerResumen()
        {
            List<PartidoResumen> lista = new List<PartidoResumen>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                p.ID_Partido, 
                p.ID_Torneo, 
                t.Nombre AS Torneo,
                p.ID_Equipo1,
                p.ID_Equipo2,
                e1.Nombre AS Equipo1, 
                e2.Nombre AS Equipo2, 
                p.Fecha
            FROM Partidos p
            INNER JOIN Torneos t ON p.ID_Torneo = t.ID_Torneo
            INNER JOIN Equipos e1 ON p.ID_Equipo1 = e1.ID_Equipo
            INNER JOIN Equipos e2 ON p.ID_Equipo2 = e2.ID_Equipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new PartidoResumen
                    {
                        ID_Partido = (int)reader["ID_Partido"],
                        ID_Torneo = (int)reader["ID_Torneo"],
                        ID_Equipo1 = (int)reader["ID_Equipo1"],
                        ID_Equipo2 = (int)reader["ID_Equipo2"],
                        Torneo = reader["Torneo"].ToString(),
                        Equipo1 = reader["Equipo1"].ToString(),
                        Equipo2 = reader["Equipo2"].ToString(),
                        Fecha = (DateTime)reader["Fecha"]
                    });
                }
            }

            return lista;
        }


        public static void Actualizar(int id, int equipo1, int equipo2, DateTime fecha)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Partidos SET ID_Equipo1 = @e1, ID_Equipo2 = @e2, Fecha = @fecha WHERE ID_Partido = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e1", equipo1);
                cmd.Parameters.AddWithValue("@e2", equipo2);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Partidos WHERE ID_Partido = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static PartidoResumen ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT p.ID_Partido, p.Fecha, p.ID_Equipo1, p.ID_Equipo2, p.ID_Torneo
            FROM Partidos p
            WHERE p.ID_Partido = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PartidoResumen
                    {
                        ID_Partido = (int)reader["ID_Partido"],
                        ID_Equipo1 = (int)reader["ID_Equipo1"],
                        ID_Equipo2 = (int)reader["ID_Equipo2"],
                        Fecha = (DateTime)reader["Fecha"],
                        ID_Torneo = (int)reader["ID_Torneo"]
                    };
                }
            }
            return null;
        }
        public static List<PartidoResumen> ObtenerPorTorneo(int torneoId)
        {
            List<PartidoResumen> lista = new List<PartidoResumen>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ID_Partido, ID_Equipo1, ID_Equipo2, Fecha, ID_Torneo
            FROM Partidos
            WHERE ID_Torneo = @torneoId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@torneoId", torneoId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new PartidoResumen
                    {
                        ID_Partido = (int)reader["ID_Partido"],
                        ID_Equipo1 = (int)reader["ID_Equipo1"],
                        ID_Equipo2 = (int)reader["ID_Equipo2"],
                        Fecha = (DateTime)reader["Fecha"],
                        ID_Torneo = (int)reader["ID_Torneo"]
                    });
                }
            }

            return lista;
        }

    }
}