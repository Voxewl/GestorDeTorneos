namespace Gestor_Torneos.DataAccess
{
    public class TorneoRepository
    {
        private readonly string _connectionString;

        public TorneoRepository()
        {
            _connectionString = Conexion.Cadena;  // Usamos la clase Conexion para obtener la cadena de conexión
        }

        public List<Torneo> ObtenerTodosLosTorneos()
        {
            List<Torneo> torneos = new List<Torneo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Torneos";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    torneos.Add(new Torneo
                    {
                        Id = Convert.ToInt32(reader["ID_Torneo"]),
                        Nombre = reader["Nombre"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]),
                    });
                }
            }

            return torneos;
        }

        public void AgregarTorneo(Torneo torneo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Torneos (Nombre, Tipo, FechaInicio, FechaFin) VALUES (@Nombre, @Tipo, @FechaInicio, @FechaFin)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", torneo.Nombre);
                command.Parameters.AddWithValue("@Tipo", torneo.Tipo);
                command.Parameters.AddWithValue("@FechaInicio", torneo.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", torneo.FechaFin);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}