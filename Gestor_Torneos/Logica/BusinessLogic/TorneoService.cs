using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class TorneoService
    {
        public static List<Torneo> ObtenerTodos()
        {
            return TorneoDAO.ObtenerTodos();
        }

        // Método Insertar con todos los parámetros
        public static void Insertar(string nombre, int tipoId, DateTime fechaInicio, DateTime? fechaFin, string descripcionTorneo)
        {
            // Validación de fechas
            if (fechaFin.HasValue && fechaFin.Value < fechaInicio)
            {
                throw new ArgumentException("La fecha de finalización no puede ser anterior a la fecha de inicio.");
            }

            // Llamamos al DAO para insertar el torneo en la base de datos
            TorneoDAO.Insertar(nombre, tipoId, fechaInicio, fechaFin, descripcionTorneo);
        }

        public static void Eliminar(int idTorneo)
        {
            TorneoDAO.Eliminar(idTorneo);
        }
        public static void Actualizar(int idTorneo, string nombre, int tipoId, DateTime fechaInicio, DateTime? fechaFin, string descripcionTorneo)
        {
            // Validación de fechas
            if (fechaFin.HasValue && fechaFin.Value < fechaInicio)
            {
                throw new ArgumentException("La fecha de finalización no puede ser anterior a la fecha de inicio.");
            }

            // Llamar al DAO para realizar la actualización
            TorneoDAO.Actualizar(idTorneo, nombre, tipoId, fechaInicio, fechaFin, descripcionTorneo);
        }


    }
}


