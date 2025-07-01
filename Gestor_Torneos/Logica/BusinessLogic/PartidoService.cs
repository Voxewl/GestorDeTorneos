using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class PartidoService
    { /// <summary>
      /// Registra un nuevo partido, validando que los equipos no sean iguales.
      /// </summary>
        public static string RegistrarPartido(Partido partido)
        {
            if (partido.ID_Equipo1 == partido.ID_Equipo2)
                return "Los equipos no pueden ser iguales.";

            PartidoDAO.Insertar(partido);
            ActualizarEstadisticas(partido);
            return "Partido registrado correctamente.";
        }

        private static void ActualizarEstadisticas(Partido partido)
        {
            // Para equipo 1
            EstadisticaDAO.ActualizarDesdePartido(
                partido.ID_Equipo1,
                partido.ID_Torneo,
                partido.GolesEquipo1 > partido.GolesEquipo2 ? 1 : 0,
                partido.GolesEquipo1 < partido.GolesEquipo2 ? 1 : 0,
                partido.GolesEquipo1 > partido.GolesEquipo2 ? 3 :
                partido.GolesEquipo1 == partido.GolesEquipo2 ? 1 : 0
            );

            // Para equipo 2
            EstadisticaDAO.ActualizarDesdePartido(
                partido.ID_Equipo2,
                partido.ID_Torneo,
                partido.GolesEquipo2 > partido.GolesEquipo1 ? 1 : 0,
                partido.GolesEquipo2 < partido.GolesEquipo1 ? 1 : 0,
                partido.GolesEquipo2 > partido.GolesEquipo1 ? 3 :
                partido.GolesEquipo2 == partido.GolesEquipo1 ? 1 : 0
            );
        }
    }
}