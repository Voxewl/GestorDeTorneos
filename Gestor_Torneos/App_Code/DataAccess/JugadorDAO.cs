using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public class JugadorDAO
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public static void Insertar(Jugador jugador)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Jugadores (UserId, Alias, FechaRegistro) VALUES (@UserId, @Alias, GETUTCDATE())";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", jugador.UserId);
            cmd.Parameters.AddWithValue("@Alias", jugador.Alias);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static List<Jugador> ObtenerTodos()
    {
        List<Jugador> lista = new List<Jugador>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT JugadorId, UserId, Alias, FechaRegistro FROM Jugadores";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Jugador
                {
                    JugadorId = (int)reader["JugadorId"],
                    UserId = reader["UserId"].ToString(),
                    Alias = reader["Alias"].ToString(),
                    FechaRegistro = (DateTime)reader["FechaRegistro"]
                });
            }
        }
        return lista;
    }
}