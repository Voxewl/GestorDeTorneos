using System;
namespace Gestor_Torneos.Models
{
    public class Torneo
    {
        public int ID_Torneo { get; set; }
        public string Nombre { get; set; }
        public int? TipoId { get; set; }  // FK a TiposTorneo
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualiza { get; set; }

        // Opcional: para mostrar en combos sin otra consulta
        public string NombreTipoTorneo { get; set; }
    }
}