using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class EquipoTorneoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void Asignar(int equipoId, int torneoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO EquipoTorneo (ID_Equipo, ID_Torneo, FechaRegistro) " +
                               "VALUES (@EquipoId, @TorneoId, GETUTCDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EquipoId", equipoId);
                cmd.Parameters.AddWithValue("@TorneoId", torneoId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<EquipoTorneo> ObtenerTodos()
        {
            List<EquipoTorneo> lista = new List<EquipoTorneo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Equipo, ID_Torneo, FechaRegistro FROM EquipoTorneo";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new EquipoTorneo
                    {
                        ID_Equipo = (int)reader["ID_Equipo"],
                        ID_Torneo = (int)reader["ID_Torneo"],
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    });
                }
            }
            return lista;
        }
    }
}