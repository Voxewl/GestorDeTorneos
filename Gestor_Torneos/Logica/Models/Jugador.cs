using System;

namespace Gestor_Torneos.Logica.Models
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string UserId { get; set; }
        public string Alias { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}