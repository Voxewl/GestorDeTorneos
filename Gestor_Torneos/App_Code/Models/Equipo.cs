namespace Gestor_Torneos.Models
{
    public class Equipo
    {
        public int ID_Equipo { get; set; }
        public string Nombre { get; set; }
        public int ID_Torneo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualiza { get; set; }

        // Propiedades auxiliares (opcional para mostrar el nombre del torneo en listados)
        public string NombreTorneo { get; set; }
    }
}