namespace Gestor_Torneos.Models
{
    public class Partido
    {
        public int ID_Partido { get; set; }
        public int ID_Torneo { get; set; }
        public int ID_Equipo1 { get; set; }
        public int ID_Equipo2 { get; set; }
        public DateTime Fecha { get; set; }
        public byte GolesEquipo1 { get; set; }
        public byte GolesEquipo2 { get; set; }
        public bool Finalizado { get; set; }

        // Propiedades auxiliares (para mostrar en listados o combos)
        public string NombreTorneo { get; set; }
        public string NombreEquipo1 { get; set; }
        public string NombreEquipo2 { get; set; }
    }
}