using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public class EstadisticaDAO
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public static void Insertar(Estadistica est)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO EstadisticasEquipoTorneo 
                            (ID_Equipo, ID_Torneo, Puntos, Victorias, Derrotas)
                             VALUES (@Equipo, @Torneo, @Puntos, @Victorias, @Derrotas)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Equipo", est.ID_Equipo);
            cmd.Parameters.AddWithValue("@Torneo", est.ID_Torneo);
            cmd.Parameters.AddWithValue("@Puntos", est.Puntos);
            cmd.Parameters.AddWithValue("@Victorias", est.Victorias);
            cmd.Parameters.AddWithValue("@Derrotas", est.Derrotas);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static List<Estadistica> ObtenerTodos()
    {
        List<Estadistica> lista = new List<Estadistica>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM EstadisticasEquipoTorneo";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Estadistica
                {
                    ID_Estadistica = (int)reader["ID_Estadistica"],
                    ID_Equipo = (int)reader["ID_Equipo"],
                    ID_Torneo = (int)reader["ID_Torneo"],
                    Puntos = (int)reader["Puntos"],
                    Victorias = (int)reader["Victorias"],
                    Derrotas = (int)reader["Derrotas"]
                });
            }
        }
        return lista;
    }
    public static void ActualizarDesdePartido(int equipoId, int torneoId, int victorias, int derrotas, int puntos)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string selectQuery = @"SELECT ID_Estadistica FROM EstadisticasEquipoTorneo 
                               WHERE ID_Equipo = @Equipo AND ID_Torneo = @Torneo";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
            selectCmd.Parameters.AddWithValue("@Equipo", equipoId);
            selectCmd.Parameters.AddWithValue("@Torneo", torneoId);
            conn.Open();

            object result = selectCmd.ExecuteScalar();

            if (result == null)
            {
                // No existe, insertar nueva estadística
                string insert = @"INSERT INTO EstadisticasEquipoTorneo 
                             (ID_Equipo, ID_Torneo, Puntos, Victorias, Derrotas)
                             VALUES (@Equipo, @Torneo, @Puntos, @Victorias, @Derrotas)";
                SqlCommand insertCmd = new SqlCommand(insert, conn);
                insertCmd.Parameters.AddWithValue("@Equipo", equipoId);
                insertCmd.Parameters.AddWithValue("@Torneo", torneoId);
                insertCmd.Parameters.AddWithValue("@Puntos", puntos);
                insertCmd.Parameters.AddWithValue("@Victorias", victorias);
                insertCmd.Parameters.AddWithValue("@Derrotas", derrotas);
                insertCmd.ExecuteNonQuery();
            }
            else
            {
                // Ya existe, actualizar sumando
                string update = @"UPDATE EstadisticasEquipoTorneo 
                              SET Puntos = Puntos + @Puntos,
                                  Victorias = Victorias + @Victorias,
                                  Derrotas = Derrotas + @Derrotas
                              WHERE ID_Equipo = @Equipo AND ID_Torneo = @Torneo";
                SqlCommand updateCmd = new SqlCommand(update, conn);
                updateCmd.Parameters.AddWithValue("@Puntos", puntos);
                updateCmd.Parameters.AddWithValue("@Victorias", victorias);
                updateCmd.Parameters.AddWithValue("@Derrotas", derrotas);
                updateCmd.Parameters.AddWithValue("@Equipo", equipoId);
                updateCmd.Parameters.AddWithValue("@Torneo", torneoId);
                updateCmd.ExecuteNonQuery();
            }
        }
    }

}