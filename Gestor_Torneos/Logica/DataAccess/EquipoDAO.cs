using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Gestor_Torneos.Logica.Models;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class EquipoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static string RegistrarEquipo(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Equipos (Nombre, FechaCreacion, FechaActualiza)
                                 VALUES (@Nombre, @FechaCreacion, @FechaActualiza)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                cmd.Parameters.AddWithValue("@FechaCreacion", equipo.FechaCreacion);
                cmd.Parameters.AddWithValue("@FechaActualiza", equipo.FechaActualiza);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();

                return filas > 0 ? "Equipo registrado correctamente." : "No se pudo registrar el equipo.";
            }
        }

        public static string ActualizarEquipo(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Equipos SET Nombre = @Nombre, FechaActualizada = @FechaActualizada
                                 WHERE ID_Equipo = @ID_Equipo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                cmd.Parameters.AddWithValue("@FechaActualizada", equipo.FechaActualiza);
                cmd.Parameters.AddWithValue("@ID_Equipo", equipo.ID_Equipo);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();

                return filas > 0 ? "Equipo actualizado correctamente." : "No se pudo actualizar el equipo.";
            }
        }

        public static string EliminarEquipo(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Equipos WHERE ID_Equipo = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();

                return filas > 0 ? "Equipo eliminado correctamente." : "No se pudo eliminar el equipo.";
            }
        }

        public static List<Equipo> ObtenerTodos()
        {
            List<Equipo> equipos = new List<Equipo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Equipo, Nombre, FechaCreacion, FechaActualizada FROM Equipos";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    equipos.Add(new Equipo
                    {
                        ID_Equipo = (int)reader["ID_Equipo"],
                        Nombre = reader["Nombre"].ToString(),
                        FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                        FechaActualiza = Convert.ToDateTime(reader["FechaActualizada"])
                    });
                }
            }
            return equipos;
        }
    }
}
