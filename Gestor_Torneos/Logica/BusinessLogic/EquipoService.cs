using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;

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
    }
}
