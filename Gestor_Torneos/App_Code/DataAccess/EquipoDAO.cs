using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public class Equipo
{
    public int ID_Equipo { get; set; }
    public string Nombre { get; set; }
}

public class EquipoDAO
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public static List<Equipo> ObtenerTodos()
    {
        List<Equipo> equipos = new List<Equipo>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT ID_Equipo, Nombre FROM Equipos";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                equipos.Add(new Equipo
                {
                    ID_Equipo = (int)reader["ID_Equipo"],
                    Nombre = reader["Nombre"].ToString()
                });
            }
        }
        return equipos;
    }
}