using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.Models
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
    }
}