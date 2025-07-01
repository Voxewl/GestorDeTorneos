using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System.Collections.Generic;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class JugadorService
    {  /// <summary>
       /// Registra un nuevo jugador.
       /// </summary>
        public static string RegistrarJugador(Jugador jugador)
        {
            if (string.IsNullOrWhiteSpace(jugador.Alias) || string.IsNullOrWhiteSpace(jugador.UserId))
                return "Alias y UserId son obligatorios.";

            JugadorDAO.Insertar(jugador);
            return "Jugador registrado correctamente.";
        }

        public static List<Jugador> ObtenerTodos()
        {
            return JugadorDAO.ObtenerTodos();
        }
        public static string ActualizarJugador(Jugador jugador)
        {
            if (string.IsNullOrWhiteSpace(jugador.Alias))
                return "El alias no puede estar vacío.";

            JugadorDAO.Actualizar(jugador);
            return "Jugador actualizado correctamente.";
        }

        public static string EliminarJugador(int jugadorId)
        {
            JugadorDAO.Eliminar(jugadorId);
            return "Jugador eliminado correctamente.";
        }

    }
}
