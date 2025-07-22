using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Gestor_Torneos.Logica.DataAccess
{
    public class TorneoDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<Torneo> ObtenerTodos()
        {
            List<Torneo> torneos = new List<Torneo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT t.ID_Torneo, t.Nombre, tt.Nombre AS TipoTorneo, t.FechaInicio, t.FechaFin, t.Descripcion AS DescripcionTorneo " +
                "FROM Torneos t " +
                "JOIN TiposTorneo tt ON tt.TipoId = t.TipoId";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    torneos.Add(new Torneo
                    {
                        ID_Torneo = (int)reader["ID_Torneo"],
                        Nombre = reader["Nombre"].ToString(),
                        TipoTorneo = reader["TipoTorneo"].ToString(),
                        FechaInicio = (DateTime)reader["FechaInicio"],
                        FechaFin = reader["FechaFin"] as DateTime?,
                        DescripcionTorneo = reader["DescripcionTorneo"].ToString() // Aquí asignamos la descripción
                    });
                }
            }

            return torneos;
        }

        // Actualizamos el método Insertar para aceptar la descripción del torneo

        public static void Insertar(string nombre, int tipoId, DateTime fechaInicio, DateTime? fechaFin, string descripcionTorneo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Asegúrate de que el campo Descripcion coincide con el nombre de la columna en la base de datos
                string query = "INSERT INTO Torneos (Nombre, TipoId, FechaInicio, FechaFin, Descripcion, FechaCreacion) " +
                               "VALUES (@Nombre, @TipoId, @FechaInicio, @FechaFin, @Descripcion, GETDATE())";  // Usamos GETDATE() para la fecha de creación automática
                SqlCommand cmd = new SqlCommand(query, conn);

                // Añadir parámetros para evitar inyecciones SQL
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@TipoId", tipoId);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value); // Usamos DBNull si no hay valor
                cmd.Parameters.AddWithValue("@Descripcion", descripcionTorneo); // Descripción

                conn.Open();  // Abrir la conexión a la base de datos
                cmd.ExecuteNonQuery();  // Ejecutar el comando INSERT
            }
        }

        // Actualizamos el método Actualizar para aceptar la descripción del torneo
        public static void Actualizar(int idTorneo, string nombre, int tipoId, DateTime fechaInicio, DateTime? fechaFin, string descripcionTorneo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Torneos SET Nombre = @Nombre, TipoId = @TipoId, FechaInicio = @FechaInicio, " +
                               "FechaFin = @FechaFin, Descripcion = @Descripcion WHERE ID_Torneo = @ID_Torneo";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@TipoId", tipoId);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", descripcionTorneo);
                cmd.Parameters.AddWithValue("@ID_Torneo", idTorneo);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la actualización
            }
        }


        public static void Eliminar(int idTorneo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Torneos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Torneo", idTorneo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}