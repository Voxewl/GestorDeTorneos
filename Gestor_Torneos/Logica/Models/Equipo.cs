using System;

namespace Gestor_Torneos.Logica.Models
{
    public class Equipo
    {
        public int ID_Equipo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualiza { get; set; } // ← corregido
    }
}
