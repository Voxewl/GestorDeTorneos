namespace Gestor_Torneos.Models
{
    public class Estadistica
    {
        public int ID_Estadistica { get; set; }
        public int ID_Equipo { get; set; }

        public int Puntos { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }

        // Propiedad auxiliar para mostrar el nombre del equipo
        public string NombreEquipo { get; set; }
    }
}