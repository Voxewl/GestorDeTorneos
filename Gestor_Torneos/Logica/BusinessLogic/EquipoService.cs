using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;
using System.Collections.Generic;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class EquipoService
    {
        public static string RegistrarEquipo(Equipo equipo)
        {
            equipo.FechaCreacion = DateTime.Now;
            equipo.FechaActualiza = DateTime.Now;
            return EquipoDAO.RegistrarEquipo(equipo);
        }

        public static string ActualizarEquipo(Equipo equipo)
        {
            equipo.FechaActualiza = DateTime.Now;
            return EquipoDAO.ActualizarEquipo(equipo);
        }

        public static string EliminarEquipo(int id)
        {
            return EquipoDAO.EliminarEquipo(id);
        }
        public static List<Equipo> ObtenerPorTorneo(int torneoId)
        {
            return EquipoDAO.ObtenerPorTorneo(torneoId);
        }
        public static List<Equipo> ObtenerTodos()
        {
            return EquipoDAO.ObtenerTodos();
        }

    }
}
