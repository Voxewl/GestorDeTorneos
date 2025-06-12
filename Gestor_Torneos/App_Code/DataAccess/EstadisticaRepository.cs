using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class EstadisticaRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<Estadistica> ObtenerTodas()
        {
            var lista = new List<Estadistica>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT e.*, eq.Nombre AS NombreEquipo
                                 FROM Estadisticas e
                                 JOIN Equipos eq ON e.ID_Equipo = eq.ID_Equipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Estadistica
                        {
                            ID_Estadistica = (int)reader["ID_Estadistica"],
                            ID_Equipo = (int)reader["ID_Equipo"],
                            Puntos = (int)reader["Puntos"],
                            Victorias = (int)reader["Victorias"],
                            Derrotas = (int)reader["Derrotas"],
                            NombreEquipo = reader["NombreEquipo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Estadistica ObtenerPorEquipo(int idEquipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Estadisticas WHERE ID_Equipo = @ID_Equipo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Equipo", idEquipo);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Estadistica
                        {
                            ID_Estadistica = (int)reader["ID_Estadistica"],
                            ID_Equipo = (int)reader["ID_Equipo"],
                            Puntos = (int)reader["Puntos"],
                            Victorias = (int)reader["Victorias"],
                            Derrotas = (int)reader["Derrotas"]
                        };
                    }
                }
            }

            return null;
        }

        public void Actualizar(Estadistica estadistica)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Estadisticas
                                 SET Puntos = @Puntos,
                                     Victorias = @Victorias,
                                     Derrotas = @Derrotas
                                 WHERE ID_Estadistica = @ID_Estadistica";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Estadistica", estadistica.ID_Estadistica);
                cmd.Parameters.AddWithValue("@Puntos", estadistica.Puntos);
                cmd.Parameters.AddWithValue("@Victorias", estadistica.Victorias);
                cmd.Parameters.AddWithValue("@Derrotas", estadistica.Derrotas);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CrearInicial(int idEquipo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Estadisticas (ID_Equipo, Puntos, Victorias, Derrotas)
                                 VALUES (@ID_Equipo, 0, 0, 0)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Equipo", idEquipo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}