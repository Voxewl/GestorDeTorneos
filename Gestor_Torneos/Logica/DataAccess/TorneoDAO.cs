using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Gestor_Torneos.Logica.Models;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class Torneo
    {
        public int ID_Torneo { get; set; }
        public string Nombre { get; set; }
    }

    public class TorneoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<Torneo> ObtenerTodos()
        {
            List<Torneo> torneos = new List<Torneo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Torneo, Nombre FROM Torneos";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    torneos.Add(new Torneo
                    {
                        ID_Torneo = (int)reader["ID_Torneo"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            return torneos;
        }
    }
}
