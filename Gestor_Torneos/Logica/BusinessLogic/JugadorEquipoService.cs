using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class JugadorEquipoService
    {        /// <summary>
             /// Asigna un jugador a un equipo (evita duplicados).
             /// </summary>
        public static string AsignarJugadorAEquipo(int jugadorId, int equipoId)
        {
            var asignaciones = JugadorEquipoDAO.ObtenerAsignaciones();
            bool yaExiste = asignaciones.Any(a => a.JugadorId == jugadorId && a.ID_Equipo == equipoId);

            if (yaExiste)
                return "Este jugador ya está asignado a ese equipo.";

            JugadorEquipoDAO.Asignar(jugadorId, equipoId);
            return "Jugador asignado correctamente al equipo.";
        }

        public static List<JugadorEquipo> ObtenerAsignaciones()
        {
            return JugadorEquipoDAO.ObtenerAsignaciones();
        }
        public static string EliminarAsignacion(int jugadorId, int equipoId)
        {
            try
            {
                JugadorEquipoDAO.Eliminar(jugadorId, equipoId);
                return "Asignación eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la asignación: " + ex.Message;
            }
        }

    }
}