namespace Gestor_Torneos.DataAccess
{
    public class EquipoRepository
    {
        private readonly string connectionString;

        public EquipoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        public List<Torneo> ObtenerTorneos()
        {
            var lista = new List<Torneo>();
            using (var conn = ObtenerConexion())
            {
                string query = "SELECT ID_Torneo, Nombre FROM Torneos";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Torneo
                        {
                            Id = Convert.ToInt32(reader["ID_Torneo"]),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void AgregarEquipo(Equipo equipo)
        {
            using (var conn = ObtenerConexion())
            {
                string query = "INSERT INTO Equipos (Nombre, ID_Torneo) VALUES (@Nombre, @TorneoId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                cmd.Parameters.AddWithValue("@TorneoId", equipo.TorneoId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}