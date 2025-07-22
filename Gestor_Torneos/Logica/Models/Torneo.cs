using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.Models
{
    public class Torneo
    {

        public int ID_Torneo { get; set; }
        public string Nombre { get; set; }
        public string TipoTorneo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string DescripcionTorneo { get; set; }  // Agregar la propiedad DescripcionTorneo
        public DateTime FechaCreacion { get; set; }
    }
}
