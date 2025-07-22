using System;

namespace Gestor_Torneos.Logica.Models
{
    public class Partido
    {
        public int ID_Partido { get; set; }
        public string Torneo { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }
        public DateTime Fecha { get; set; }
        public byte GolesEquipo1 { get; set; }
        public byte GolesEquipo2 { get; set; }
        public bool Finalizado { get; set; }
    }
}