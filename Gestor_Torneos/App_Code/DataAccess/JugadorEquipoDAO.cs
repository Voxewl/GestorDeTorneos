using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public class JugadorEquipoDAO
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public static void Asignar(int jugadorId, int equipoId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO JugadorEquipo (JugadorId, ID_Equipo, FechaIngreso) VALUES (@JugadorId, @EquipoId, GETUTCDATE())";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@JugadorId", jugadorId);
            cmd.Parameters.AddWithValue("@EquipoId", equipoId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static List<JugadorEquipo> ObtenerAsignaciones()
    {
        List<JugadorEquipo> lista = new List<JugadorEquipo>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT JugadorId, ID_Equipo, FechaIngreso FROM JugadorEquipo";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new JugadorEquipo
                {
                    JugadorId = (int)reader["JugadorId"],
                    ID_Equipo = (int)reader["ID_Equipo"],
                    FechaIngreso = (DateTime)reader["FechaIngreso"]
                });
            }
        }
        return lista;
    }
}