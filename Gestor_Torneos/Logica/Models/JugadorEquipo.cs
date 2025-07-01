using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.Models
{
    public class JugadorEquipo
    {
        public int JugadorId { get; set; }
        public int ID_Equipo { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}