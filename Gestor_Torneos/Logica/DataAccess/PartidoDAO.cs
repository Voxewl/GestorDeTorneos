using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class PartidoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void Insertar(Partido partido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Partidos 
                (ID_Torneo, ID_Equipo1, ID_Equipo2, Fecha, GolesEquipo1, GolesEquipo2, Finalizado)
                VALUES (@Torneo, @Eq1, @Eq2, @Fecha, @G1, @G2, @Fin)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Torneo", partido.ID_Torneo);
                cmd.Parameters.AddWithValue("@Eq1", partido.ID_Equipo1);
                cmd.Parameters.AddWithValue("@Eq2", partido.ID_Equipo2);
                cmd.Parameters.AddWithValue("@Fecha", partido.Fecha);
                cmd.Parameters.AddWithValue("@G1", partido.GolesEquipo1);
                cmd.Parameters.AddWithValue("@G2", partido.GolesEquipo2);
                cmd.Parameters.AddWithValue("@Fin", partido.Finalizado);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Partido> ObtenerTodos()
        {
            List<Partido> lista = new List<Partido>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Partidos";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Partido
                    {
                        ID_Partido = (int)reader["ID_Partido"],
                        ID_Torneo = (int)reader["ID_Torneo"],
                        ID_Equipo1 = (int)reader["ID_Equipo1"],
                        ID_Equipo2 = (int)reader["ID_Equipo2"],
                        Fecha = (DateTime)reader["Fecha"],
                        GolesEquipo1 = (byte)reader["GolesEquipo1"],
                        GolesEquipo2 = (byte)reader["GolesEquipo2"],
                        Finalizado = (bool)reader["Finalizado"]
                    });
                }
            }
            return lista;
        }
    }
}