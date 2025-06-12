using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

namespace Gestor_Torneos.BusinessLogic
{
    public class TipoTorneoService
    {
        private readonly TipoTorneoRepository _tipoTorneoRepository;

        public TipoTorneoService()
        {
            _tipoTorneoRepository = new TipoTorneoRepository();
        }

        public List<TipoTorneo> ObtenerTodos()
        {
            return _tipoTorneoRepository.ObtenerTodos();
        }

        public TipoTorneo ObtenerPorId(int id)
        {
            return _tipoTorneoRepository.ObtenerPorId(id);
        }
    }
}