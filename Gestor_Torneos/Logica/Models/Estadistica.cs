using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.Models
{
    public class Estadistica
    {
        public int ID_Estadistica { get; set; }
        public int ID_Equipo { get; set; }
        public int ID_Torneo { get; set; }
        public int Puntos { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
    }
}