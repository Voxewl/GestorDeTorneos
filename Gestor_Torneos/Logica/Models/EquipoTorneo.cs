using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.Models
{
    public class EquipoTorneo
    {
        public int ID_Equipo { get; set; }
        public int ID_Torneo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}