using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System.Collections.Generic;

namespace Gestor_Torneos.Logica.BusinessLogic
{
    public class TipoTorneoService
    {
        public static List<TipoTorneo> ObtenerTodos()
        {
            return TipoTorneoDAO.ObtenerTodos();
        }

        public static void Insertar(string nombre)
        {
            TipoTorneoDAO.Insertar(nombre);
        }

        public static void Eliminar(int tipoId)
        {
            TipoTorneoDAO.Eliminar(tipoId);
        }
        public static void Actualizar(int tipoId, string nuevoNombre)
        {
            TipoTorneoDAO.Actualizar(tipoId, nuevoNombre);
        }

    }
}
