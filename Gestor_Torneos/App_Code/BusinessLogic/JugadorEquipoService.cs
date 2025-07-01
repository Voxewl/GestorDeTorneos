using System;
using System.Collections.Generic;
using System.Linq;
using Gestor_Torneos.Models;

public class JugadorEquipoService
{
    /// <summary>
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
}