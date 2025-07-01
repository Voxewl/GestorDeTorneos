using Gestor_Torneos.Logica.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class EquipoTorneoService
    {        /// <summary>
             /// Asigna un equipo a un torneo. Valida que no se repita.
             /// </summary>
        public static string AsignarEquipoATorneo(int equipoId, int torneoId)
        {
            // Verificar si ya existe la asignación (opcional)
            var asignaciones = EquipoTorneoDAO.ObtenerTodos();
            bool yaExiste = asignaciones.Any(et => et.ID_Equipo == equipoId && et.ID_Torneo == torneoId);

            if (yaExiste)
                return "Este equipo ya está asignado a este torneo.";

            EquipoTorneoDAO.Asignar(equipoId, torneoId);
            return "Equipo asignado correctamente.";
        }
    }
}