using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public static class PartidoService
    {
        public static List<PartidoResumen> ObtenerResumen()
        {

            return PartidoDAO.ObtenerResumen();
        }

        public static void Eliminar(int id)
        {
            PartidoDAO.Eliminar(id);
        }
        public static void AgendarPartido(int torneoId, int equipo1, int equipo2, DateTime fecha)
        {
            ValidarPartido(torneoId, equipo1, equipo2, fecha);
            PartidoDAO.Insertar(torneoId, equipo1, equipo2, fecha);
        }

        public static void Actualizar(int id, int equipo1, int equipo2, DateTime fecha)
        {
            var partidoOriginal = PartidoDAO.ObtenerPorId(id);
            ValidarPartido(partidoOriginal.ID_Torneo, equipo1, equipo2, fecha, id);
            PartidoDAO.Actualizar(id, equipo1, equipo2, fecha);
        }

        private static void ValidarPartido(int torneoId, int equipo1, int equipo2, DateTime fecha, int? idExistente = null)
        {
            if (equipo1 == equipo2)
                throw new ArgumentException("No se puede agendar un partido entre el mismo equipo.");

            var partidos = PartidoDAO.ObtenerPorTorneo(torneoId);
            foreach (var p in partidos)
            {
                if (idExistente.HasValue && p.ID_Partido == idExistente.Value)
                    continue;

                if ((p.ID_Equipo1 == equipo1 && p.ID_Equipo2 == equipo2 || p.ID_Equipo1 == equipo2 && p.ID_Equipo2 == equipo1)
                    && p.Fecha.Date == fecha.Date)
                {
                    throw new ArgumentException("Ya existe un partido agendado entre estos equipos ese día.");
                }

                if ((p.ID_Equipo1 == equipo1 || p.ID_Equipo2 == equipo1 || p.ID_Equipo1 == equipo2 || p.ID_Equipo2 == equipo2)
                    && p.Fecha.Date == fecha.Date)
                {
                    throw new ArgumentException("Uno de los equipos ya tiene un partido agendado ese día.");
                }
            }
        }


    }

}