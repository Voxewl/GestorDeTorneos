using System;

namespace Gestor_Torneos.Models
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string UserId { get; set; }  // Clave foránea a AspNetUsers
        public string Alias { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Propiedad auxiliar para mostrar el nombre del usuario (opcional)
        public string UserName { get; set; }
    }
}