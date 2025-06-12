using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Gestor_Torneos.Models;
using Gestor_Torneos.Utils;

namespace Gestor_Torneos.DataAccess
{
    public class JugadorRepository
    {
        private readonly string connectionString = Conexion.Cadena;

        public List<Jugador> ObtenerTodos()
        {
            List<Jugador> lista = new List<Jugador>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT j.*, u.UserName
                                 FROM Jugadores j
                                 JOIN AspNetUsers u ON j.UserId = u.Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Jugador
                        {
                            JugadorId = (int)reader["JugadorId"],
                            UserId = reader["UserId"].ToString(),
                            Alias = reader["Alias"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Jugador ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT j.*, u.UserName
                                 FROM Jugadores j
                                 JOIN AspNetUsers u ON j.UserId = u.Id
                                 WHERE j.JugadorId = @JugadorId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JugadorId", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Jugador
                        {
                            JugadorId = (int)reader["JugadorId"],
                            UserId = reader["UserId"].ToString(),
                            Alias = reader["Alias"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            UserName = reader["UserName"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public void Agregar(Jugador jugador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Jugadores (UserId, Alias)
                                 VALUES (@UserId, @Alias)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", jugador.UserId);
                cmd.Parameters.AddWithValue("@Alias", jugador.Alias);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int jugadorId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Jugadores WHERE JugadorId = @JugadorId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JugadorId", jugadorId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}